using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class SharePointOnlineCredentials : ICredentials
    {
        private class CookieCacheEntry
        {
            public string Cookie;

            public DateTime Expires;

            public bool IsValid
            {
                get
                {
                    return DateTime.UtcNow < this.Expires;
                }
            }
        }

        private const int CacheHours = 1;

        private string m_userName;

        private SecureString m_password;

        private object m_lock = new object();

        private Hashtable m_cachedCookies = new Hashtable();

        public event EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> ExecutingWebRequest;

        public string UserName
        {
            get
            {
                return this.m_userName;
            }
        }

        internal SecureString Password
        {
            get
            {
                return this.m_password;
            }
        }

        public SharePointOnlineCredentials(string username, SecureString password)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw ClientUtility.CreateArgumentNullException("username");
            }
            int num = username.IndexOf('@');
            if (num < 0 || num == username.Length - 1)
            {
                throw ClientUtility.CreateArgumentException("username");
            }
            if (password == null)
            {
                throw ClientUtility.CreateArgumentNullException("password");
            }
            SharePointOnlineAuthenticationModule.EnsureRegistered();
            this.m_userName = username;
            this.m_password = password;
        }

        public NetworkCredential GetCredential(Uri uri, string authType)
        {
            return null;
        }

        public string GetAuthenticationCookie(Uri url)
        {
            return this.GetAuthenticationCookie(url, true, false);
        }

        public string GetAuthenticationCookie(Uri url, bool alwaysThrowOnFailure)
        {
            return this.GetAuthenticationCookie(url, true, alwaysThrowOnFailure);
        }

        internal string GetAuthenticationCookie(Uri url, bool refresh, bool alwaysThrowOnFailure)
        {
            if (url == null)
            {
                throw ClientUtility.CreateArgumentNullException("url");
            }
            if (!url.IsAbsoluteUri)
            {
                throw ClientUtility.CreateArgumentException("url");
            }
            Uri uri = new Uri(url, "/");
            string text = null;
            SharePointOnlineCredentials.CookieCacheEntry cookieCacheEntry = (SharePointOnlineCredentials.CookieCacheEntry)this.m_cachedCookies[uri];
            if (!refresh && cookieCacheEntry != null && cookieCacheEntry.IsValid)
            {
                ClientULS.SendTraceTag(3454916u, ClientTraceCategory.Authentication, ClientTraceLevel.Verbose, "Get cookie from cache for URL {0}", new object[]
                {
                    uri
                });
                return cookieCacheEntry.Cookie;
            }
            if (refresh)
            {
                ISharePointOnlineAuthenticationProvider sharePointOnlineAuthenticationProvider = SharePointOnlineAuthenticationProviderHelper.CreateDefaultProvider();
                text = sharePointOnlineAuthenticationProvider.GetAuthenticationCookie(uri, this.m_userName, this.m_password, alwaysThrowOnFailure, this.ExecutingWebRequest);
                if (!string.IsNullOrEmpty(text))
                {
                    ClientULS.SendTraceTag(3454917u, ClientTraceCategory.Authentication, ClientTraceLevel.Medium, "Put cookie in cache for URL {0}", new object[]
                    {
                        uri
                    });
                    lock (this.m_lock)
                    {
                        this.m_cachedCookies[uri] = new SharePointOnlineCredentials.CookieCacheEntry
                        {
                            Cookie = text,
                            Expires = DateTime.UtcNow.AddHours(1.0)
                        };
                    }
                }
            }
            return text;
        }
    }
}
