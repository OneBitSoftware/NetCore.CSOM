using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class SharePointOnlineCredentialsWebRequestEventArgs : EventArgs
    {
        private HttpWebRequest m_webRequest;

        public HttpWebRequest WebRequest
        {
            get
            {
                return this.m_webRequest;
            }
        }

        internal SharePointOnlineCredentialsWebRequestEventArgs(HttpWebRequest webRequest)
        {
            this.m_webRequest = webRequest;
        }
    }
}
