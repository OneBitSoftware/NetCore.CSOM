using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreIdcrl
{
    internal class SharePointOnlineAuthenticationProvider : ISharePointOnlineAuthenticationProvider
    {
        private class IdcrlHeader
        {
            public string IdcrlType;

            public string ServiceTarget;

            public string ServicePolicy;

            public string Endpoint;
        }

        private static string s_idcrlEnvironment;

        private static string IdcrlServiceEnvironment
        {
            get
            {
                string text = SharePointOnlineAuthenticationProvider.s_idcrlEnvironment;
                if (text == null)
                {
                    text = "production";
                    //Edited for .NET Core - Commented out lines below
                    //RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\MSOIdentityCRL");
                    //if (registryKey != null)
                    //{
                    //    string text2 = (string)registryKey.GetValue("ServiceEnvironment", null);
                    //    if (string.Compare(text2, "INT-MSO", StringComparison.OrdinalIgnoreCase) == 0)
                    //    {
                    //        text = "INT-MSO";
                    //    }
                    //    else if (string.Equals(text2, "PPE-MSO", StringComparison.OrdinalIgnoreCase))
                    //    {
                    //        text = "PPE-MSO";
                    //    }
                    //    registryKey.Close();
                    //}
                    ClientULS.SendTraceTag(3991715u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "IdcrlServiceEnvironment={0}", new object[]
                    {
                        text
                    });
                    SharePointOnlineAuthenticationProvider.s_idcrlEnvironment = text;
                }
                return text;
            }
        }

        public string GetAuthenticationCookie(Uri url, string username, SecureString password, bool alwaysThrowOnFailure, EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> executingWebRequest)
        {
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException("username");
            }
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }
            SharePointOnlineAuthenticationProvider.IdcrlHeader idcrlHeader = this.GetIdcrlHeader(url, alwaysThrowOnFailure, executingWebRequest);
            if (idcrlHeader == null)
            {
                ClientULS.SendTraceTag(3991707u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Cannot get IDCRL header for {0}", new object[]
                {
                    url
                });
                if (alwaysThrowOnFailure)
                {
                    throw new ClientRequestException(Resources.GetString("CannotContactSite", new object[]
                    {
                        url
                    }));
                }
                return null;
            }
            else
            {
                IdcrlEnvironment env;
                if (string.Compare(SharePointOnlineAuthenticationProvider.IdcrlServiceEnvironment, "INT-MSO", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    env = IdcrlEnvironment.Int;
                }
                else if (string.Equals(SharePointOnlineAuthenticationProvider.IdcrlServiceEnvironment, "PPE-MSO", StringComparison.OrdinalIgnoreCase))
                {
                    env = IdcrlEnvironment.Ppe;
                }
                else
                {
                    env = IdcrlEnvironment.Production;
                }
                IdcrlAuth idcrlAuth = new IdcrlAuth(env, executingWebRequest);
                //Edited for .NET Core - Changed from SecureString to string
                string password2 = SharePointOnlineAuthenticationProvider.FromSecureString(password);
                string serviceToken = idcrlAuth.GetServiceToken(username, password2, idcrlHeader.ServiceTarget, idcrlHeader.ServicePolicy);
                if (!string.IsNullOrEmpty(serviceToken))
                {
                    return this.GetCookie(url, idcrlHeader.Endpoint, serviceToken, alwaysThrowOnFailure, executingWebRequest);
                }
                ClientULS.SendTraceTag(3991708u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Cannot get IDCRL ticket for username {0}", new object[]
                {
                    username
                });
                if (alwaysThrowOnFailure)
                {
                    throw new IdcrlException(Resources.GetString("PPCRL_REQUEST_E_UNKNOWN", new object[]
                    {
                        -2147186615
                    }));
                }
                return null;
            }
        }

        private string GetCookie(Uri url, string endpoint, string ticket, bool throwIfFail, EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> executingWebRequest)
        {
            Uri uri = new Uri(url, endpoint);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
            CookieContainer cookieContainer = new CookieContainer();
            httpWebRequest.CookieContainer = cookieContainer;
            httpWebRequest.Headers[HttpRequestHeader.Authorization] = "BPOSIDCRL " + ticket;
            httpWebRequest.Headers["X-IDCRL_ACCEPTED"] = "t";
            if (executingWebRequest != null)
            {
                executingWebRequest(this, new SharePointOnlineCredentialsWebRequestEventArgs(httpWebRequest));
            }
        //Edited for .NET Core
            //WebResponse response = httpWebRequest.GetResponse();
            WebResponse response = httpWebRequest.GetResponseAsync().Result;
            string cookieHeader = cookieContainer.GetCookieHeader(uri);
            if (string.IsNullOrWhiteSpace(cookieHeader))
            {
                UriBuilder uriBuilder = new UriBuilder(uri);
        //Edited for .NET Core
                //uriBuilder.Host = httpWebRequest.Host;
                uriBuilder.Host = httpWebRequest.RequestUri.IdnHost;
                ClientULS.SendTraceTag(5825556u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "Try get cookie using {0}", new object[]
                {
                    uriBuilder.ToString()
                });
                cookieHeader = cookieContainer.GetCookieHeader(uriBuilder.Uri);
                ClientULS.SendTraceTag(5825557u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Get cookie using {0} and cookie value is {0}", new object[]
                {
                    uriBuilder.ToString(),
                    cookieHeader
                });
            }
            if (response != null)
            {
                response.Dispose();//Close();
            }
            if (string.IsNullOrWhiteSpace(cookieHeader))
            {
                ClientULS.SendTraceTag(3991709u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Cannot get cookie for {0}", new object[]
                {
                    url
                });
                if (throwIfFail)
                {
                    throw new ClientRequestException(Resources.GetString("CannotGetCookie", new object[]
                    {
                        url
                    }));
                }
            }
            return cookieHeader;
        }

        private SharePointOnlineAuthenticationProvider.IdcrlHeader GetIdcrlHeader(Uri url, bool alwaysThrowOnFailure, EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> executingWebRequest)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Headers["X-IDCRL_ACCEPTED"] = "t";
            //Edited for .NET Core - Commented out
            //httpWebRequest.AuthenticationLevel = AuthenticationLevel.None;
            if (executingWebRequest != null)
            {
                executingWebRequest(this, new SharePointOnlineCredentialsWebRequestEventArgs(httpWebRequest));
            }
            HttpWebResponse httpWebResponse = null;
            try
            {
                //Edited for .NET Core
                //httpWebResponse = (httpWebRequest.GetResponse() as HttpWebResponse);
                httpWebResponse = httpWebRequest.GetResponseAsync().Result as HttpWebResponse;
            }
            // In .NET Core the Async factor complicates it with an Aggregate exception
            // The first request is always unauthorized and that throws, so the below catch is necessary
            catch (AggregateException aex)
            {
                if (aex.InnerException != null && aex.InnerException.GetType() == typeof(WebException))
                {
                    var ex = aex.InnerException as WebException;
                    ClientULS.SendTraceTag(3991710u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Exception in request. Url={0}, WebException={1}", new object[]
                    {
                        url,
                        ex
                    });
                    httpWebResponse = (ex.Response as HttpWebResponse);
                    if (alwaysThrowOnFailure && (httpWebResponse == null || (httpWebResponse.StatusCode != HttpStatusCode.Forbidden && httpWebResponse.StatusCode != HttpStatusCode.Unauthorized)))
                    {
                        throw;
                    }
                }
            }
            catch (WebException ex)
            {
                ClientULS.SendTraceTag(3991710u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Exception in request. Url={0}, WebException={1}", new object[]
                {
                    url,
                    ex
                });
                httpWebResponse = (ex.Response as HttpWebResponse);
                if (alwaysThrowOnFailure && (httpWebResponse == null || (httpWebResponse.StatusCode != HttpStatusCode.Forbidden && httpWebResponse.StatusCode != HttpStatusCode.Unauthorized)))
                {
                    throw;
                }
            }
            if (httpWebResponse != null)
            {
                string webResponseHeader = IdcrlUtility.GetWebResponseHeader(httpWebResponse);
                HttpStatusCode statusCode = httpWebResponse.StatusCode;
                ClientULS.SendTraceTag(4839637u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Response.StatusCode={0}, Headers={1}", new object[]
                {
                    statusCode,
                    webResponseHeader
                });
                string text = httpWebResponse.Headers["X-IDCRL_AUTH_PARAMS_V1"];
                if (string.IsNullOrEmpty(text))
                {
                    text = httpWebResponse.Headers[HttpResponseHeader.WwwAuthenticate];
                }
                //Edited for .NET Core
                httpWebResponse.Dispose();//.Close();
                ClientULS.SendTraceTag(3991712u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "IdcrlHeader={0}", new object[]
                {
                    text
                });
                return this.ParseIdcrlHeader(text, url, statusCode, webResponseHeader, alwaysThrowOnFailure);
            }
            ClientULS.SendTraceTag(3991711u, ClientTraceCategory.Authentication, ClientTraceLevel.High, "Cannot get response for request to {0}", new object[]
            {
                url
            });
            if (alwaysThrowOnFailure)
            {
                throw new ClientRequestException(Resources.GetString("CannotContactSite", new object[]
                {
                    url
                }));
            }
            return null;
        }

        private SharePointOnlineAuthenticationProvider.IdcrlHeader ParseIdcrlHeader(string headerValue, Uri url, HttpStatusCode statusCode, string allResponseHeaders, bool alwaysThrowOnFailure)
        {
            if (!string.IsNullOrWhiteSpace(headerValue))
            {
                SharePointOnlineAuthenticationProvider.IdcrlHeader idcrlHeader = new SharePointOnlineAuthenticationProvider.IdcrlHeader();
                string[] array = headerValue.Split(new char[]
                {
                    ','
                });
                for (int i = 0; i < array.Length; i++)
                {
                    string text = array[i];
                    string text2 = text.Trim();
                    string[] array2 = text2.Split(new char[]
                    {
                        '='
                    });
                    if (array2.Length == 2)
                    {
                        array2[0] = array2[0].Trim().ToUpperInvariant();
                        array2[1] = array2[1].Trim(new char[]
                        {
                            ' ',
                            '"'
                        });
                        string a;
                        if ((a = array2[0]) != null)
                        {
                            if (!(a == "IDCRL TYPE"))
                            {
                                if (!(a == "ENDPOINT"))
                                {
                                    if (!(a == "ROOTDOMAIN"))
                                    {
                                        if (a == "POLICY")
                                        {
                                            idcrlHeader.ServicePolicy = array2[1];
                                        }
                                    }
                                    else
                                    {
                                        idcrlHeader.ServiceTarget = array2[1];
                                    }
                                }
                                else
                                {
                                    idcrlHeader.Endpoint = array2[1];
                                }
                            }
                            else
                            {
                                idcrlHeader.IdcrlType = array2[1];
                            }
                        }
                    }
                }
                if (idcrlHeader.IdcrlType != "BPOSIDCRL" || string.IsNullOrEmpty(idcrlHeader.ServicePolicy) || string.IsNullOrEmpty(idcrlHeader.ServiceTarget) || string.IsNullOrEmpty(idcrlHeader.Endpoint))
                {
                    ClientULS.SendTraceTag(3991714u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Cannot extract required information from IDCRL header. Header={0}, IdcrlType={1}, ServicePolicy={2}, ServiceTarget={3}, Endpoint={4}", new object[]
                    {
                        headerValue,
                        idcrlHeader.IdcrlType,
                        idcrlHeader.ServicePolicy,
                        idcrlHeader.ServiceTarget,
                        idcrlHeader.Endpoint
                    });
                    if (alwaysThrowOnFailure)
                    {
                        throw new ClientRequestException(Resources.GetString("InvalidIdcrlHeader", new object[]
                        {
                            url.OriginalString,
                            headerValue,
                            statusCode,
                            allResponseHeaders
                        }));
                    }
                    idcrlHeader = null;
                }
                return idcrlHeader;
            }
            ClientULS.SendTraceTag(3991713u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "IDCRL header value is empty", new object[0]);
            if (alwaysThrowOnFailure)
            {
                throw new NotSupportedException(Resources.GetString("SharePointClientCredentialsNotSupported", new object[]
                {
                    url.OriginalString,
                    statusCode,
                    allResponseHeaders
                }));
            }
            return null;
        }

        private static string FromSecureString(SecureString value)
        {
            //Edited for .NET Core - was using legacy Framework API
            //var intPtr = Marshal.StringToBSTR(value);
            var intPtr = SecureStringMarshal.SecureStringToGlobalAllocUnicode(value);
            if (intPtr == IntPtr.Zero)
            {
                return string.Empty;
            }
            string result;
            try
            {
                //Edited for .NET Core - was using legacy Framework API
                //result = Marshal.PtrToStringBSTR(intPtr);
                result = Marshal.PtrToStringUni(intPtr);
            }
            finally
            {
                //Edited for .NET Core - was using legacy Framework API
                //Marshal.ZeroFreeBSTR(intPtr);
                Marshal.ZeroFreeGlobalAllocUnicode(intPtr);
            }
            return result;
        }

        internal bool DoesSupportIdcrl(Uri uri)
        {
            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }
            return this.GetIdcrlHeader(uri, true, null) != null;
        }
    }
}
