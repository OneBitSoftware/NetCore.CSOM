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

namespace Microsoft.SharePoint.Client.NetCore
{
    public class ClientContext : ClientRuntimeContext
    {
        private const string GetUpdatedFormDigestInfoRequestBody = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n  <soap:Body>\r\n    <GetUpdatedFormDigestInformation xmlns=\"http://schemas.microsoft.com/sharepoint/soap/\" />\r\n  </soap:Body>\r\n</soap:Envelope>";

        private Web m_web;

        private Site m_site;

        private RequestResources m_requestResources;

        private bool m_formDigestHandlingEnabled = true;

        private FormDigestInfo m_formDigestInfo;

        private static XmlNamespaceManager s_nsmgr;

        public Web Web
        {
            get
            {
                if (this.m_web == null)
                {
                    RequestContext current = RequestContext.GetCurrent(this);
                    this.m_web = current.Web;
                }
                return this.m_web;
            }
        }

        public Site Site
        {
            get
            {
                if (this.m_site == null)
                {
                    RequestContext current = RequestContext.GetCurrent(this);
                    this.m_site = current.Site;
                }
                return this.m_site;
            }
        }

        public RequestResources RequestResources
        {
            get
            {
                if (this.m_requestResources == null)
                {
                    this.m_requestResources = new RequestResources();
                }
                return this.m_requestResources;
            }
        }

        private string RequestResourceHeaderValue
        {
            get
            {
                if (this.m_requestResources == null)
                {
                    return null;
                }
                return this.m_requestResources.ToHttpHeaderValue();
            }
        }

        public bool FormDigestHandlingEnabled
        {
            get
            {
                return this.m_formDigestHandlingEnabled;
            }
            set
            {
                this.m_formDigestHandlingEnabled = value;
            }
        }

        public Version ServerVersion
        {
            get
            {
                return base.ServerLibraryVersion;
            }
        }

        private static XmlNamespaceManager NamespaceManager
        {
            get
            {
                if (ClientContext.s_nsmgr == null)
                {
                    XmlNameTable nameTable = new NameTable();
                    XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(nameTable);
                    xmlNamespaceManager.AddNamespace("soap", "http://schemas.xmlsoap.org/soap/envelope/");
                    xmlNamespaceManager.AddNamespace("spsoap", "http://schemas.microsoft.com/sharepoint/soap/");
                    ClientContext.s_nsmgr = xmlNamespaceManager;
                }
                return ClientContext.s_nsmgr;
            }
        }

        public ClientContext(string webFullUrl) : base(webFullUrl)
        {
        }

        public ClientContext(Uri webFullUrl) : base((webFullUrl == null) ? null : webFullUrl.ToString())
        {
        }

        public FormDigestInfo GetFormDigestDirect()
        {
            return this.GetFormDigestInfoPrivate();
        }

        private string GetValueFromResponse(string response, string beginTag, string endTag)
        {
            int num = response.IndexOf(beginTag);
            if (num < 0)
            {
                return null;
            }
            num += beginTag.Length;
            int num2 = response.IndexOf(endTag);
            if (num2 < 0)
            {
                return null;
            }
            if (num > num2)
            {
                return null;
            }
            return response.Substring(num, num2 - num);
        }

        private string GetSitesAsmxUrl()
        {
            string text = base.Url;
            if (!text.EndsWith("/"))
            {
                text += "/";
            }
            return text + "_vti_bin/sites.asmx";
        }

        private void BuildGetUpdatedFormDigestInfoRequestBody(Stream requestStream)
        {
            TextWriter textWriter = new StreamWriter(requestStream, Encoding.UTF8);
            textWriter.Write("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n  <soap:Body>\r\n    <GetUpdatedFormDigestInformation xmlns=\"http://schemas.microsoft.com/sharepoint/soap/\" />\r\n  </soap:Body>\r\n</soap:Envelope>");
            textWriter.Flush();
        }

        private FormDigestInfo ParseFormDigest(Stream responseStream)
        {
            TextReader textReader = new StreamReader(responseStream);
            string response = textReader.ReadToEnd();
            string valueFromResponse = this.GetValueFromResponse(response, "<DigestValue>", "</DigestValue>");
            string valueFromResponse2 = this.GetValueFromResponse(response, "<TimeoutSeconds>", "</TimeoutSeconds>");
            string valueFromResponse3 = this.GetValueFromResponse(response, "<SupportedSchemaVersions>", "</SupportedSchemaVersions>");
            if (valueFromResponse == null || valueFromResponse2 == null)
            {
                return null;
            }
            int num = int.Parse(valueFromResponse2, CultureInfo.InvariantCulture);
            Version version = null;
            if (valueFromResponse3 != null)
            {
                IEnumerable<Version> source = from str in valueFromResponse3.Split(new char[]
                {
                    ','
                })
                                              select new Version(str);
                foreach (Version current in from v in source
                                            orderby v
                                            select v)
                {
                    if (current > ClientSchemaVersions.CurrentVersion)
                    {
                        break;
                    }
                    version = current;
                }
            }
            if (version == null)
            {
                version = ClientSchemaVersions.CurrentVersion;
            }
            return new FormDigestInfo
            {
                DigestValue = valueFromResponse,
                Expiration = DateTime.UtcNow.AddSeconds((double)num * 0.75),
                RequestSchemaVersion = version
            };
        }

        internal void FireExecutingWebRequestEventInternal(WebRequestEventArgs args)
        {
            this.OnExecutingWebRequest(args);
        }

        public override void ExecuteQuery()
        {
            string requestResourceHeaderValue = this.RequestResourceHeaderValue;
            if (!string.IsNullOrEmpty(requestResourceHeaderValue))
            {
                base.PendingRequest.RequestExecutor.RequestHeaders["X-SP-REQUESTRESOURCES"] = requestResourceHeaderValue;
            }
            if (this.FormDigestHandlingEnabled)
            {
                this.EnsureFormDigest();
                base.PendingRequest.RequestExecutor.RequestHeaders["X-RequestDigest"] = this.m_formDigestInfo.DigestValue;
                if (this.m_formDigestInfo.RequestSchemaVersion != null)
                {
                    base.RequestSchemaVersion = this.m_formDigestInfo.RequestSchemaVersion;
                }
            }
            base.ExecuteQuery();
        }

        private string ExtractSoapError(WebException webEx)
        {
            try
            {
                HttpWebResponse httpWebResponse = webEx.Response as HttpWebResponse;
                if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.InternalServerError && httpWebResponse.ContentType.IndexOf("text/xml", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        XmlDocument xmlDocument = SPClientUtility.LoadXml(streamReader);
                        //Edited for .NET Core
                        //XmlNode xmlNode = xmlDocument.ChildNodes("soap:Envelope/soap:Body/soap:Fault/detail/spsoap:errorstring", ClientContext.NamespaceManager);
                        //if (xmlNode != null)
                        //{
                        //    return xmlNode.InnerText;
                        //}
                    }
                }
            }
            catch (Exception)
            {
            }
            return null;
        }

        private void EnsureFormDigest()
        {
            if (this.m_formDigestInfo == null || DateTime.UtcNow >= this.m_formDigestInfo.Expiration)
            {
                this.m_formDigestInfo = this.GetFormDigestInfoPrivate();
            }
        }

        private FormDigestInfo GetFormDigestInfoPrivate()
        {
            string sitesAsmxUrl = this.GetSitesAsmxUrl();
            WebRequestExecutor webRequestExecutor = base.WebRequestExecutorFactory.CreateWebRequestExecutor(this, sitesAsmxUrl);
            this.FireExecutingWebRequestEventInternal(new WebRequestEventArgs(webRequestExecutor));
            webRequestExecutor.RequestContentType = "text/xml";
            webRequestExecutor.RequestHeaders["SOAPAction"] = "http://schemas.microsoft.com/sharepoint/soap/GetUpdatedFormDigestInformation";
            if (base.AuthenticationMode == ClientAuthenticationMode.Default)
            {
                webRequestExecutor.RequestHeaders["X-RequestForceAuthentication"] = "true";
            }
            this.BuildGetUpdatedFormDigestInfoRequestBody(webRequestExecutor.GetRequestStream());
            //Edited for .NET Core
            //webRequestExecutor.GetRequestStream().Close();
            //webRequestExecutor.GetRequestStream().Dispose();// Close();
            try
            {
                webRequestExecutor.Execute();
            }
            catch (WebException webEx)
            {
                string text = this.ExtractSoapError(webEx);
                if (string.IsNullOrEmpty(text))
                {
                    throw;
                }
                throw new ClientRequestException(Resources.GetString("CannotContactSiteWithDetails", new object[]
                {
                    base.Url,
                    text
                }));
            }
            if (webRequestExecutor.StatusCode != HttpStatusCode.OK || webRequestExecutor.ResponseContentType.IndexOf("text/xml", StringComparison.OrdinalIgnoreCase) < 0)
            {
                throw new ClientRequestException(Resources.GetString("CannotContactSite", new object[]
                {
                    base.Url
                }));
            }
            FormDigestInfo formDigestInfo = this.ParseFormDigest(webRequestExecutor.GetResponseStream());
            if (formDigestInfo == null)
            {
                throw new ClientRequestException(Resources.GetString("CannotContactSite", new object[]
                {
                    base.Url
                }));
            }
            return formDigestInfo;
        }
    }
}
