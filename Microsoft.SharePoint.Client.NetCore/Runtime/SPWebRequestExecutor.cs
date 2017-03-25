using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class SPWebRequestExecutor : WebRequestExecutor
    {
        private HttpWebRequest m_webRequest;

        private HttpWebResponse m_webResponse;

        private ClientRuntimeContext m_context;

        private bool m_setupCredential;

        public override HttpWebRequest WebRequest
        {
            get
            {
                return this.m_webRequest;
            }
        }

        public override string RequestContentType
        {
            get
            {
                return this.m_webRequest.ContentType;
            }
            set
            {
                this.m_webRequest.ContentType = value;
            }
        }

        public override string RequestMethod
        {
            get
            {
                return this.m_webRequest.Method;
            }
            set
            {
                this.m_webRequest.Method = value;
            }
        }

        //Edited for .NET Core
        public override bool RequestKeepAlive
        {
            get
            {
                //Edited for .NET Core
                //return this.m_webRequest.KeepAlive;
                return false;
            }
            set
            {
                //Edited for .NET Core
                //this.m_webRequest.KeepAlive = value;
            }
        }

        public override WebHeaderCollection RequestHeaders
        {
            get
            {
                return this.m_webRequest.Headers;
            }
        }

        public override HttpStatusCode StatusCode
        {
            get
            {
                if (this.m_webResponse == null)
                {
                    throw new InvalidOperationException();
                }
                return this.m_webResponse.StatusCode;
            }
        }

        public override string ResponseContentType
        {
            get
            {
                if (this.m_webResponse == null)
                {
                    throw new InvalidOperationException();
                }
                return this.m_webResponse.ContentType;
            }
        }

        public override WebHeaderCollection ResponseHeaders
        {
            get
            {
                if (this.m_webResponse == null)
                {
                    throw new InvalidOperationException();
                }
                return this.m_webResponse.Headers;
            }
        }

        public SPWebRequestExecutor(ClientRuntimeContext context, string requestUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(requestUrl))
            {
                throw new ArgumentNullException("requestUrl");
            }
            this.m_context = context;
            this.m_webRequest = (HttpWebRequest)System.Net.WebRequest.Create(requestUrl);

            //Edited for .NET Core
            //this.m_webRequest.Timeout = context.RequestTimeout;
            this.m_webRequest.ContinueTimeout = context.RequestTimeout;
            this.m_webRequest.Method = "POST";
        }

        public override Stream GetRequestStream()
        {
            if (!this.m_setupCredential)
            {
                ClientRuntimeContext.SetupRequestCredential(this.m_context, this.m_webRequest);
                this.m_setupCredential = true;
            }
            //Edited for .NET Core
            //return this.m_webRequest.GetRequestStream();
            return this.m_webRequest.GetRequestStreamAsync().Result;
        }

        public override void Execute()
        {
            //Edited for .NET Core
            //this.m_webRequest.GetRequestStream().Close();
            //this.m_webResponse = (HttpWebResponse)this.m_webRequest.GetResponse();
            //this.m_webRequest.GetRequestStreamAsync().Result.Dispose();
            this.m_webResponse = (HttpWebResponse)this.m_webRequest.GetResponseAsync().Result;
        }

        public override Stream GetResponseStream()
        {
            if (this.m_webResponse == null)
            {
                throw new InvalidOperationException();
            }
            return this.m_webResponse.GetResponseStream();
        }

        public override void Dispose()
        {
            if (this.m_webResponse != null)
            {
                //Edited for .NET Core
                //this.m_webResponse.Close();
                this.m_webResponse.Dispose();
            }
        }
    }
}
