using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Microsoft.SharePoint.Client.NetCoreIdcrl
{
    internal class IdcrlAuth
    {
        private class UserRealmInfo
        {
            public string STSAuthUrl
            {
                get;
                set;
            }

            public bool IsFederated
            {
                get;
                set;
            }
        }

        private class FederationProviderInfo
        {
            public string UserRealmServiceUrl
            {
                get;
                set;
            }

            public string SecurityTokenServiceUrl
            {
                get;
                set;
            }

            public string FederationTokenIssuer
            {
                get;
                set;
            }
        }

        private class FederationProviderInfoCacheEntry
        {
            public IdcrlAuth.FederationProviderInfo Value;

            public DateTime Expires;
        }

        private class FederationProviderInfoCache
        {
            private const int CacheLifetimeMinutes = 30;

            private object m_lock = new object();

            private Dictionary<string, IdcrlAuth.FederationProviderInfoCacheEntry> m_cache = new Dictionary<string, IdcrlAuth.FederationProviderInfoCacheEntry>(StringComparer.OrdinalIgnoreCase);

            public bool TryGetValue(string domainname, out IdcrlAuth.FederationProviderInfo value)
            {
                lock (this.m_lock)
                {
                    IdcrlAuth.FederationProviderInfoCacheEntry federationProviderInfoCacheEntry;
                    if (this.m_cache.TryGetValue(domainname, out federationProviderInfoCacheEntry) && federationProviderInfoCacheEntry.Expires > DateTime.UtcNow)
                    {
                        value = federationProviderInfoCacheEntry.Value;
                        return true;
                    }
                }
                value = null;
                return false;
            }

            public void Put(string domainname, IdcrlAuth.FederationProviderInfo value)
            {
                lock (this.m_lock)
                {
                    this.m_cache[domainname] = new IdcrlAuth.FederationProviderInfoCacheEntry
                    {
                        Value = value,
                        Expires = DateTime.UtcNow.AddMinutes(30.0)
                    };
                }
            }
        }

        private IdcrlEnvironment m_env;

        private string m_userRealmServiceUrl;

        private string m_securityTokenServiceUrl;

        private string m_federationTokenIssuer;

        private EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> m_executingWebRequest;

        private static Dictionary<string, int> s_partnerSoapErrorMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {
                "InvalidRequest",
                -2147186474
            },
            {
                "FailedAuthentication",
                -2147186446
            },
            {
                "RequestFailed",
                -2147186473
            },
            {
                "InvalidSecurityToken",
                -2147186472
            },
            {
                "AuthenticationBadElements",
                -2147186471
            },
            {
                "BadRequest",
                -2147186470
            },
            {
                "ExpiredData",
                -2147186469
            },
            {
                "InvalidTimeRange",
                -2147186468
            },
            {
                "InvalidScope",
                -2147186467
            },
            {
                "RenewNeeded",
                -2147186466
            },
            {
                "UnableToRenew",
                -2147186465
            }
        };

        private static IdcrlAuth.FederationProviderInfoCache s_FederationProviderInfoCache = new IdcrlAuth.FederationProviderInfoCache();

        private string UserRealmServiceUrl
        {
            get
            {
                return this.m_userRealmServiceUrl;
            }
        }

        private string ServiceTokenUrl
        {
            get
            {
                return this.m_securityTokenServiceUrl;
            }
        }

        private string FederationTokenIssuer
        {
            get
            {
                return this.m_federationTokenIssuer;
            }
        }

        public IdcrlAuth(IdcrlEnvironment env, EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> executingWebRequest)
        {
            this.m_env = env;
            ClientULS.SendTraceTag(3454918u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "IDCRL Environment {0}", new object[]
            {
                env
            });
            if (this.m_env == IdcrlEnvironment.Production)
            {
                this.m_userRealmServiceUrl = "https://login.microsoftonline.com/GetUserRealm.srf";
                this.m_securityTokenServiceUrl = "https://login.microsoftonline.com/rst2.srf";
                this.m_federationTokenIssuer = "urn:federation:MicrosoftOnline";
            }
            else if (this.m_env == IdcrlEnvironment.Ppe)
            {
                this.m_userRealmServiceUrl = "https://login.windows-ppe.net/GetUserRealm.srf";
                this.m_securityTokenServiceUrl = "https://login.windows-ppe.net/rst2.srf";
                this.m_federationTokenIssuer = "urn:federation:MicrosoftOnline";
            }
            else
            {
                this.m_userRealmServiceUrl = "https://login.microsoftonline-int.com/GetUserRealm.srf";
                this.m_securityTokenServiceUrl = "https://login.microsoftonline-int.com/rst2.srf";
                this.m_federationTokenIssuer = "urn:federation:MicrosoftOnline-int";
            }
            this.m_executingWebRequest = executingWebRequest;
        }

        public string GetServiceToken(string username, string password, string serviceTarget, string servicePolicy)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password");
            }
            if (string.IsNullOrEmpty(serviceTarget))
            {
                throw new ArgumentNullException("serviceTarget");
            }
            this.InitFederationProviderInfoForUser(username);
            IdcrlAuth.UserRealmInfo userRealm = this.GetUserRealm(username);
            if (userRealm.IsFederated)
            {
                string partnerTicketFromAdfs = this.GetPartnerTicketFromAdfs(userRealm.STSAuthUrl, username, password);
                return this.GetServiceToken(partnerTicketFromAdfs, serviceTarget, servicePolicy);
            }
            string securityXml = this.BuildWsSecurityUsingUsernamePassword(username, password);
            return this.GetServiceToken(securityXml, serviceTarget, servicePolicy);
        }

        private IdcrlAuth.UserRealmInfo GetUserRealm(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentNullException("login");
            }
            string userRealmServiceUrl = this.UserRealmServiceUrl;
            string body = string.Format(CultureInfo.InvariantCulture, "login={0}&xml=1", new object[]
            {
                Uri.EscapeDataString(login)
            });
            XDocument xDocument = this.DoPost(userRealmServiceUrl, "application/x-www-form-urlencoded", body, null);
            XAttribute xAttribute = xDocument.Root.Attribute("Success");
            if (xAttribute == null || string.Compare(xAttribute.Value, "true", StringComparison.OrdinalIgnoreCase) != 0)
            {
                ClientULS.SendTraceTag(3454919u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Failed to get user's realm for user {0}", new object[]
                {
                    login
                });
                throw IdcrlAuth.CreateIdcrlException(-2147186539);
            }
            XElement xElement = xDocument.Root.Element("NameSpaceType");
            if (xElement == null)
            {
                ClientULS.SendTraceTag(3454920u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "There is no NameSpaceType element in the response when get user realm for user {0}", new object[]
                {
                    login
                });
                throw IdcrlAuth.CreateIdcrlException(-2147186539);
            }
            if (string.Compare(xElement.Value, "Federated", StringComparison.OrdinalIgnoreCase) != 0 && string.Compare(xElement.Value, "Managed", StringComparison.OrdinalIgnoreCase) != 0)
            {
                ClientULS.SendTraceTag(3454921u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Unknown namespace type for user {0}", new object[]
                {
                    login
                });
                throw IdcrlAuth.CreateIdcrlException(-2147186539);
            }
            IdcrlAuth.UserRealmInfo userRealmInfo = new IdcrlAuth.UserRealmInfo();
            userRealmInfo.IsFederated = (0 == string.Compare(xElement.Value, "Federated", StringComparison.OrdinalIgnoreCase));
            xElement = xDocument.Root.Element("STSAuthURL");
            if (xElement != null)
            {
                userRealmInfo.STSAuthUrl = xElement.Value;
            }
            if (userRealmInfo.IsFederated && string.IsNullOrEmpty(userRealmInfo.STSAuthUrl))
            {
                ClientULS.SendTraceTag(3454922u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "User {0} is a federated account, but there is no STSAuthUrl for the user.", new object[]
                {
                    login
                });
                throw IdcrlAuth.CreateIdcrlException(-2147186539);
            }
            ClientULS.SendTraceTag(3454923u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "User={0}, IsFederated={1}, STSAuthUrl={2}", new object[]
            {
                login,
                userRealmInfo.IsFederated,
                userRealmInfo.STSAuthUrl
            });
            return userRealmInfo;
        }

        private string GetPartnerTicketFromAdfs(string adfsUrl, string username, string password)
        {
            string body = string.Format(CultureInfo.InvariantCulture, "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<s:Envelope xmlns:s=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:saml=\"urn:oasis:names:tc:SAML:1.0:assertion\" xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\" xmlns:wssc=\"http://schemas.xmlsoap.org/ws/2005/02/sc\" xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\">\r\n    <s:Header>\r\n        <wsa:Action s:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action>\r\n        <wsa:To s:mustUnderstand=\"1\">{0}</wsa:To>\r\n        <wsa:MessageID>{1}</wsa:MessageID>\r\n        <ps:AuthInfo xmlns:ps=\"http://schemas.microsoft.com/Passport/SoapServices/PPCRL\" Id=\"PPAuthInfo\">\r\n            <ps:HostingApp>Managed IDCRL</ps:HostingApp>\r\n            <ps:BinaryVersion>6</ps:BinaryVersion>\r\n            <ps:UIVersion>1</ps:UIVersion>\r\n            <ps:Cookies></ps:Cookies>\r\n            <ps:RequestParams>AQAAAAIAAABsYwQAAAAxMDMz</ps:RequestParams>\r\n        </ps:AuthInfo>\r\n        <wsse:Security>\r\n            <wsse:UsernameToken wsu:Id=\"user\">\r\n                <wsse:Username>{2}</wsse:Username>\r\n                <wsse:Password>{3}</wsse:Password>\r\n            </wsse:UsernameToken>\r\n            <wsu:Timestamp Id=\"Timestamp\">\r\n                <wsu:Created>{4}</wsu:Created>\r\n                <wsu:Expires>{5}</wsu:Expires>\r\n            </wsu:Timestamp>\r\n        </wsse:Security>\r\n    </s:Header>\r\n    <s:Body>\r\n        <wst:RequestSecurityToken Id=\"RST0\">\r\n            <wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType>\r\n            <wsp:AppliesTo>\r\n                <wsa:EndpointReference>\r\n                    <wsa:Address>{6}</wsa:Address>\r\n                </wsa:EndpointReference>\r\n            </wsp:AppliesTo>\r\n            <wst:KeyType>http://schemas.xmlsoap.org/ws/2005/05/identity/NoProofKey</wst:KeyType>\r\n        </wst:RequestSecurityToken>\r\n    </s:Body>\r\n</s:Envelope>", new object[]
            {
                IdcrlUtility.XmlValueEncode(adfsUrl),
                Guid.NewGuid().ToString(),
                IdcrlUtility.XmlValueEncode(username),
                IdcrlUtility.XmlValueEncode(password),
                DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                DateTime.UtcNow.AddMinutes(10.0).ToString("o", CultureInfo.InvariantCulture),
                this.FederationTokenIssuer
            });
            XDocument xDocument = this.DoPost(adfsUrl, "application/soap+xml; charset=utf-8", body, new Func<WebException, Exception>(IdcrlAuth.HandleWebException));
            Exception soapException = IdcrlAuth.GetSoapException(xDocument);
            if (soapException != null)
            {
                ClientULS.SendTraceTag(3454924u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "SOAP error from {0}. Exception={1}", new object[]
                {
                    adfsUrl,
                    soapException
                });
                throw soapException;
            }
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xDocument.Root, new string[]
            {
                "{http://www.w3.org/2003/05/soap-envelope}Body",
                "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestSecurityTokenResponse",
                "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestedSecurityToken",
                "{urn:oasis:names:tc:SAML:1.0:assertion}Assertion"
            });
            if (elementAtPath == null)
            {
                ClientULS.SendTraceTag(3454925u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Cannot get security assertion for user {0} from {1}", new object[]
                {
                    username,
                    adfsUrl
                });
                throw IdcrlAuth.CreateIdcrlException(-2147186451);
            }
            return elementAtPath.ToString(SaveOptions.DisableFormatting | SaveOptions.OmitDuplicateNamespaces);
        }

        private string GetServiceToken(string securityXml, string serviceTarget, string servicePolicy)
        {
            string serviceTokenUrl = this.ServiceTokenUrl;
            string text = string.Empty;
            if (!string.IsNullOrEmpty(servicePolicy))
            {
                text = string.Format(CultureInfo.InvariantCulture, "<wsp:PolicyReference URI=\"{0}\"></wsp:PolicyReference>", new object[]
                {
                    servicePolicy
                });
            }
            string body = string.Format(CultureInfo.InvariantCulture, "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<S:Envelope xmlns:S=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" xmlns:wsa=\"http://www.w3.org/2005/08/addressing\" xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\">\r\n  <S:Header>\r\n    <wsa:Action S:mustUnderstand=\"1\">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</wsa:Action>\r\n    <wsa:To S:mustUnderstand=\"1\">{0}</wsa:To>\r\n    <ps:AuthInfo xmlns:ps=\"http://schemas.microsoft.com/LiveID/SoapServices/v1\" Id=\"PPAuthInfo\">\r\n      <ps:BinaryVersion>5</ps:BinaryVersion>\r\n      <ps:HostingApp>Managed IDCRL</ps:HostingApp>\r\n    </ps:AuthInfo>\r\n    <wsse:Security>{1}</wsse:Security>\r\n  </S:Header>\r\n  <S:Body>\r\n    <wst:RequestSecurityToken xmlns:wst=\"http://schemas.xmlsoap.org/ws/2005/02/trust\" Id=\"RST0\">\r\n      <wst:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</wst:RequestType>\r\n      <wsp:AppliesTo>\r\n        <wsa:EndpointReference>\r\n          <wsa:Address>{2}</wsa:Address>\r\n        </wsa:EndpointReference>\r\n      </wsp:AppliesTo>\r\n      {3}\r\n    </wst:RequestSecurityToken>\r\n  </S:Body>\r\n</S:Envelope>\r\n", new object[]
            {
                IdcrlUtility.XmlValueEncode(serviceTokenUrl),
                securityXml,
                IdcrlUtility.XmlValueEncode(serviceTarget),
                text
            });
            XDocument xDocument = this.DoPost(serviceTokenUrl, "application/soap+xml; charset=utf-8", body, new Func<WebException, Exception>(IdcrlAuth.HandleWebException));
            Exception soapException = IdcrlAuth.GetSoapException(xDocument);
            if (soapException != null)
            {
                ClientULS.SendTraceTag(3454926u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Soap error from {0}. Exception={1}", new object[]
                {
                    serviceTokenUrl,
                    soapException
                });
                throw soapException;
            }
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xDocument.Root, new string[]
            {
                "{http://www.w3.org/2003/05/soap-envelope}Body",
                "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestSecurityTokenResponse",
                "{http://schemas.xmlsoap.org/ws/2005/02/trust}RequestedSecurityToken",
                "{http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd}BinarySecurityToken"
            });
            if (elementAtPath == null)
            {
                ClientULS.SendTraceTag(3454927u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Cannot get binary security token for from {0}", new object[]
                {
                    serviceTokenUrl
                });
                throw IdcrlAuth.CreateIdcrlException(-2147186656);
            }
            return elementAtPath.Value;
        }

        private string BuildWsSecurityUsingUsernamePassword(string username, string password)
        {
            DateTime utcNow = DateTime.UtcNow;
            return string.Format(CultureInfo.InvariantCulture, "\r\n            <wsse:UsernameToken wsu:Id=\"user\">\r\n                <wsse:Username>{0}</wsse:Username>\r\n                <wsse:Password>{1}</wsse:Password>\r\n            </wsse:UsernameToken>\r\n            <wsu:Timestamp Id=\"Timestamp\">\r\n                <wsu:Created>{2}</wsu:Created>\r\n                <wsu:Expires>{3}</wsu:Expires>\r\n            </wsu:Timestamp>\r\n", new object[]
            {
                IdcrlUtility.XmlValueEncode(username),
                IdcrlUtility.XmlValueEncode(password),
                utcNow.ToString("o", CultureInfo.InvariantCulture),
                utcNow.AddDays(1.0).ToString("o", CultureInfo.InvariantCulture)
            });
        }

        private XDocument DoPost(string url, string contentType, string body, Func<WebException, Exception> webExceptionHandler)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = contentType;
            ClientULS.SendTraceTag(3454928u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "Sending POST request to {0}", new object[]
            {
                url
            });
            if (this.m_executingWebRequest != null)
            {
                this.m_executingWebRequest(this, new SharePointOnlineCredentialsWebRequestEventArgs(httpWebRequest));
            }
            //Edited for .NET Core
            //using (Stream requestStream = httpWebRequest.GetRequestStream())
            using (Stream requestStream = httpWebRequest.GetRequestStreamAsync().Result)
            {
                if (body != null)
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(body);
                    requestStream.Write(bytes, 0, bytes.Length);
                }
            }
            XDocument result;
            try
            {
                //Edited for .NET Core
                //HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                HttpWebResponse httpWebResponse = httpWebRequest.GetResponseAsync().Result as HttpWebResponse;
                if (httpWebResponse == null)
                {
                    ClientULS.SendTraceTag(3454929u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Unexpected response for POST request to {0}", new object[]
                    {
                        url
                    });
                    throw new InvalidOperationException();
                }
                using (httpWebResponse)
                {
                    using (TextReader textReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        string text = textReader.ReadToEnd();
                        ClientULS.SendTraceTag(3454930u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "URL={0}, StatusCode={1}, ResponseText={2}", new object[]
                        {
                            url,
                            (int)httpWebResponse.StatusCode,
                            text
                        });
                        using (XmlReader xmlReader = XmlReader.Create(new StringReader(text)))
                        {
                            XDocument xDocument = XDocument.Load(xmlReader);
                            result = xDocument;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                ClientULS.SendTraceTag(3454931u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "URL={0}, WebException={1}", new object[]
                {
                    url,
                    ex
                });
                if (webExceptionHandler == null)
                {
                    throw;
                }
                Exception ex2 = webExceptionHandler(ex);
                if (ex2 == null)
                {
                    throw;
                }
                throw ex2;
            }
            return result;
        }

        private static Exception HandleWebException(WebException webException)
        {
            HttpWebResponse httpWebResponse = webException.Response as HttpWebResponse;
            if (httpWebResponse != null && httpWebResponse.ContentType != null && httpWebResponse.ContentType.IndexOf("application/soap+xml", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                try
                {
                    using (TextReader textReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        string text = textReader.ReadToEnd();
                        ClientULS.SendTraceTag(3454932u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "StatusCode={0}, ResponseText={1}", new object[]
                        {
                            (int)httpWebResponse.StatusCode,
                            text
                        });
                        using (XmlReader xmlReader = XmlReader.Create(new StringReader(text)))
                        {
                            XDocument xdoc = XDocument.Load(xmlReader);
                            return IdcrlAuth.GetSoapException(xdoc);
                        }
                    }
                }
                catch (XmlException ex)
                {
                    ClientULS.SendTraceTag(3454933u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Error when read error response. Exception={0}", new object[]
                    {
                        ex
                    });
                }
                catch (IOException ex2)
                {
                    ClientULS.SendTraceTag(3454934u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Error when read error response. Exception={0}", new object[]
                    {
                        ex2
                    });
                }
            }
            return null;
        }

        private static Exception GetSoapException(XDocument xdoc)
        {
            if (IdcrlUtility.GetElementAtPath(xdoc.Root, new string[]
            {
                "{http://www.w3.org/2003/05/soap-envelope}Body",
                "{http://www.w3.org/2003/05/soap-envelope}Fault"
            }) == null)
            {
                return null;
            }
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xdoc.Root, new string[]
            {
                "{http://www.w3.org/2003/05/soap-envelope}Body",
                "{http://www.w3.org/2003/05/soap-envelope}Fault",
                "{http://www.w3.org/2003/05/soap-envelope}Code",
                "{http://www.w3.org/2003/05/soap-envelope}Subcode",
                "{http://www.w3.org/2003/05/soap-envelope}Value"
            });
            XElement elementAtPath2 = IdcrlUtility.GetElementAtPath(xdoc.Root, new string[]
            {
                "{http://www.w3.org/2003/05/soap-envelope}Body",
                "{http://www.w3.org/2003/05/soap-envelope}Fault",
                "{http://www.w3.org/2003/05/soap-envelope}Detail",
                "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}error",
                "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}value"
            });
            XElement elementAtPath3 = IdcrlUtility.GetElementAtPath(xdoc.Root, new string[]
            {
                "{http://www.w3.org/2003/05/soap-envelope}Body",
                "{http://www.w3.org/2003/05/soap-envelope}Fault",
                "{http://www.w3.org/2003/05/soap-envelope}Detail",
                "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}error",
                "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}internalerror",
                "{http://schemas.microsoft.com/Passport/SoapServices/SOAPFault}text"
            });
            string text = null;
            if (elementAtPath != null)
            {
                text = elementAtPath.Value;
                int num = text.IndexOf(':');
                if (num >= 0)
                {
                    text = text.Substring(num + 1);
                }
            }
            string text2 = null;
            if (elementAtPath2 != null)
            {
                text2 = elementAtPath2.Value;
            }
            string text3 = null;
            if (elementAtPath3 != null)
            {
                text3 = elementAtPath3.Value;
            }
            ClientULS.SendTraceTag(3454935u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "PassportErrorCode={0}, PassportDetailCode={1}, PassportErrorText={2}", new object[]
            {
                text,
                text2,
                text3
            });
            int num2;
            long num3;
            if (string.IsNullOrEmpty(text2))
            {
                num2 = IdcrlAuth.MapPartnerSoapFault(text);
            }
            else if ((text2.StartsWith("0x", StringComparison.OrdinalIgnoreCase) && long.TryParse(text2.Substring(2), NumberStyles.HexNumber, CultureInfo.InvariantCulture, out num3)) || long.TryParse(text2, NumberStyles.Integer, CultureInfo.InvariantCulture, out num3))
            {
                num2 = (int)num3;
                if (string.Compare(text, "FailedAuthentication", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    num2 = ((num2 == -2147186639) ? num2 : -2147186655);
                }
            }
            else
            {
                num2 = -2147186656;
            }
            return IdcrlAuth.CreateIdcrlException(num2);
        }

        private static int MapPartnerSoapFault(string code)
        {
            int result;
            if (IdcrlAuth.s_partnerSoapErrorMap.TryGetValue(code, out result))
            {
                return result;
            }
            return -2147186451;
        }

        private static Exception CreateIdcrlException(int hr)
        {
            string resourceId;
            if (!IdcrlErrorCodes.TryGetErrorStringId(hr, out resourceId))
            {
                resourceId = "PPCRL_REQUEST_E_UNKNOWN";
            }
            return new IdcrlException(Resources.GetString(resourceId), hr);
        }

        private void InitFederationProviderInfoForUser(string username)
        {
            int num = username.IndexOf('@');
            if (num < 0 || num == username.Length - 1)
            {
                throw ClientUtility.CreateArgumentException("username");
            }
            string domainname = username.Substring(num + 1);
            IdcrlAuth.FederationProviderInfo federationProviderInfo = this.GetFederationProviderInfo(domainname);
            if (federationProviderInfo != null)
            {
                this.m_userRealmServiceUrl = federationProviderInfo.UserRealmServiceUrl;
                this.m_securityTokenServiceUrl = federationProviderInfo.SecurityTokenServiceUrl;
                this.m_federationTokenIssuer = federationProviderInfo.FederationTokenIssuer;
            }
            ClientULS.SendTraceTag(3454936u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "UserName={0}, UserRealmServiceUrl={1}, SecurityTokenServiceUrl={1}, FederationTokenIssuer={2}", new object[]
            {
                username,
                this.m_userRealmServiceUrl,
                this.m_securityTokenServiceUrl,
                this.m_federationTokenIssuer
            });
        }

        private IdcrlAuth.FederationProviderInfo GetFederationProviderInfo(string domainname)
        {
            IdcrlAuth.FederationProviderInfo federationProviderInfo;
            if (IdcrlAuth.s_FederationProviderInfoCache.TryGetValue(domainname, out federationProviderInfo))
            {
                ClientULS.SendTraceTag(3454937u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "Get federation provider information for {0} from cache. UserRealmServiceUrl={1}, SecurityTokenServiceUrl={2}, FederationTokenIssuer={3}", new object[]
                {
                    domainname,
                    (federationProviderInfo == null) ? null : federationProviderInfo.UserRealmServiceUrl,
                    (federationProviderInfo == null) ? null : federationProviderInfo.SecurityTokenServiceUrl,
                    (federationProviderInfo == null) ? null : federationProviderInfo.FederationTokenIssuer
                });
                return federationProviderInfo;
            }
            federationProviderInfo = this.RequestFederationProviderInfo(domainname);
            IdcrlAuth.s_FederationProviderInfoCache.Put(domainname, federationProviderInfo);
            ClientULS.SendTraceTag(3454938u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Get federation provider information for {0} and put it in cache. UserRealmServcieUrl={1}, SecurityTokenServiceUrl={2}, FederationTokenIssuer={3}", new object[]
            {
                domainname,
                (federationProviderInfo == null) ? null : federationProviderInfo.UserRealmServiceUrl,
                (federationProviderInfo == null) ? null : federationProviderInfo.SecurityTokenServiceUrl,
                (federationProviderInfo == null) ? null : federationProviderInfo.FederationTokenIssuer
            });
            return federationProviderInfo;
        }

        private IdcrlAuth.FederationProviderInfo RequestFederationProviderInfo(string domainname)
        {
            int num;
            while ((num = domainname.IndexOf('.')) > 0)
            {
                string text = string.Format(CultureInfo.InvariantCulture, IdcrlMessageConstants.FPUrlFullUrlFormat, new object[]
                {
                    domainname
                });
                try
                {
                    XDocument xdoc = this.DoGet(text);
                    string fpDomainName = IdcrlAuth.ParseFPDomainName(xdoc);
                    text = string.Format(CultureInfo.InvariantCulture, IdcrlMessageConstants.FPListFullUrlFormat, new object[]
                    {
                        domainname
                    });
                    xdoc = this.DoGet(text);
                    return IdcrlAuth.ParseFederationProviderInfo(xdoc, fpDomainName);
                }
                catch (AggregateException aex)
                {
                    ClientULS.SendTraceTag(3454939u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Exception when request {0}. Exception={1}", new object[]
                    {
                        text,
                       aex
                    });
                }
                catch (WebException ex)
                {
                    ClientULS.SendTraceTag(3454939u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Exception when request {0}. Exception={1}", new object[]
                    {
                        text,
                        ex
                    });
                }
                domainname = domainname.Substring(num + 1);
            }
            return null;
        }

        private static string ParseFPDomainName(XDocument xdoc)
        {
            XElement elementAtPath = IdcrlUtility.GetElementAtPath(xdoc.Root, new string[]
            {
                "FPDOMAINNAME"
            });
            if (elementAtPath == null)
            {
                ClientULS.SendTraceTag(3454940u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Cannot find FPDOMAINNAME element", new object[0]);
                throw IdcrlAuth.CreateIdcrlException(-2147186646);
            }
            return elementAtPath.Value;
        }

        private static IdcrlAuth.FederationProviderInfo ParseFederationProviderInfo(XDocument xdoc, string fpDomainName)
        {
            foreach (XElement current in xdoc.Root.Elements("FP"))
            {
                if (current.Attribute("DomainName") != null && string.Equals(current.Attribute("DomainName").Value, fpDomainName, StringComparison.OrdinalIgnoreCase))
                {
                    XElement elementAtPath = IdcrlUtility.GetElementAtPath(current, new string[]
                    {
                        "URL",
                        "GETUSERREALM"
                    });
                    XElement elementAtPath2 = IdcrlUtility.GetElementAtPath(current, new string[]
                    {
                        "URL",
                        "RST2"
                    });
                    XElement elementAtPath3 = IdcrlUtility.GetElementAtPath(current, new string[]
                    {
                        "URL",
                        "ENTITYID"
                    });
                    if (elementAtPath == null || elementAtPath2 == null || elementAtPath3 == null)
                    {
                        ClientULS.SendTraceTag(3454941u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Cannot get the user realm service url or security token service url for federation provider {0}", new object[]
                        {
                            fpDomainName
                        });
                        throw IdcrlAuth.CreateIdcrlException(-2147186646);
                    }
                    ClientULS.SendTraceTag(3454942u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Find federation provider information for federation provider domain name {0}. UserRealmServiceUrl={1}, SecurityTokenServiceUrl={2}, FederationTokenIssuer={3}", new object[]
                    {
                        fpDomainName,
                        elementAtPath.Value,
                        elementAtPath2.Value,
                        elementAtPath3.Value
                    });
                    return new IdcrlAuth.FederationProviderInfo
                    {
                        UserRealmServiceUrl = elementAtPath.Value,
                        SecurityTokenServiceUrl = elementAtPath2.Value,
                        FederationTokenIssuer = elementAtPath3.Value
                    };
                }
            }
            ClientULS.SendTraceTag(3454943u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Cannot find federation provider information for federation domain {0}", new object[]
            {
                fpDomainName
            });
            throw IdcrlAuth.CreateIdcrlException(-2147186646);
        }

        private XDocument DoGet(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            ClientULS.SendTraceTag(3454944u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "Sending GET request to {0}", new object[]
            {
                url
            });
            if (this.m_executingWebRequest != null)
            {
                this.m_executingWebRequest(this, new SharePointOnlineCredentialsWebRequestEventArgs(httpWebRequest));
            }
            //Edited for .NET Core - added try catch aggregate exception
            //HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponseAsync().Result as HttpWebResponse;
            if (httpWebResponse == null)
            {
                ClientULS.SendTraceTag(3454945u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Unexpected response for GET request to URL {0}", new object[]
                {
                    url
                });
                throw new InvalidOperationException();
            }
            XDocument result;
            using (httpWebResponse)
            {
                using (TextReader textReader = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    string text = textReader.ReadToEnd();
                    ClientULS.SendTraceTag(3454946u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "StatusCode={0}, ResponseText={1}", new object[]
                    {
                        (int)httpWebResponse.StatusCode,
                        text
                    });
                    using (XmlReader xmlReader = XmlReader.Create(new StringReader(text)))
                    {
                        XDocument xDocument = XDocument.Load(xmlReader);
                        result = xDocument;
                    }
                }
            }
            return result;
        }
    }
}