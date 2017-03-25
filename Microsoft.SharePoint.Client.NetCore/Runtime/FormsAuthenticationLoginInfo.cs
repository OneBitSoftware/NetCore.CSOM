using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class FormsAuthenticationLoginInfo
    {
        private class CookieInfo
        {
            public CookieCollection Cookies;

            public DateTime Expires;
        }

        private string m_loginName;

        private string m_password;

        private bool m_cookieValid;

        private CookieContainer m_cookieContainer;

        private Dictionary<Uri, FormsAuthenticationLoginInfo.CookieInfo> m_authCookies;

        public string LoginName
        {
            get
            {
                return this.m_loginName;
            }
            set
            {
                if (this.m_loginName != value)
                {
                    this.m_cookieValid = false;
                }
                this.m_loginName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.m_password;
            }
            set
            {
                if (this.m_password != value)
                {
                    this.m_cookieValid = false;
                }
                this.m_password = value;
            }
        }

        private CookieContainer CookieContainer
        {
            get
            {
                if (this.m_cookieContainer == null)
                {
                    this.m_cookieContainer = new CookieContainer();
                }
                return this.m_cookieContainer;
            }
        }

        public Uri AuthenticationServiceUrl
        {
            get;
            set;
        }

        public FormsAuthenticationLoginInfo()
        {
        }

        public FormsAuthenticationLoginInfo(string loginName, string password)
        {
            this.m_loginName = loginName;
            this.m_password = password;
        }

        internal CookieCollection EnsureLogin(Uri contextUri)
        {
            if (this.m_authCookies == null || !this.m_cookieValid)
            {
                this.m_authCookies = new Dictionary<Uri, FormsAuthenticationLoginInfo.CookieInfo>();
                this.m_cookieValid = true;
            }
            contextUri = new Uri(contextUri, "/");
            FormsAuthenticationLoginInfo.CookieInfo cookieInfo = null;
            if (this.m_authCookies.TryGetValue(contextUri, out cookieInfo) && cookieInfo.Expires > DateTime.UtcNow)
            {
                return cookieInfo.Cookies;
            }
            cookieInfo = this.Login(contextUri);
            this.m_authCookies[contextUri] = cookieInfo;
            return cookieInfo.Cookies;
        }

        private FormsAuthenticationLoginInfo.CookieInfo Login(Uri contextUri)
        {
            //Edited for .NET Core
            //    Uri uri;
            //    if (this.AuthenticationServiceUrl == null)
            //    {
            //        uri = new Uri(contextUri, "/_vti_bin/authentication.asmx");
            //    }
            //    else
            //    {
            //        uri = this.AuthenticationServiceUrl;
            //    }
            //    Authentication authentication = new Authentication(uri);
            //    authentication.CookieContainer = this.CookieContainer;
            //    LoginResult loginResult = authentication.Login(this.LoginName, this.Password);
            //    FormsAuthenticationLoginInfo.CookieInfo cookieInfo = null;
            //    switch (loginResult.ErrorCode)
            //    {
            //        case LoginErrorCode.NoError:
            //            {
            //                CookieCollection cookies = authentication.CookieContainer.GetCookies(new Uri(contextUri, "/"));
            //                cookieInfo = new FormsAuthenticationLoginInfo.CookieInfo();
            //                cookieInfo.Cookies = cookies;
            //                DateTime expires = DateTime.UtcNow.AddSeconds((double)loginResult.TimeoutSeconds * 0.75);
            //                cookieInfo.Expires = expires;
            //                break;
            //            }
            //        case LoginErrorCode.NotInFormsAuthenticationMode:
            //            throw new ServerException(Resources.GetString("ServerNotInFormsAuthenticationMode"), string.Empty, -1);
            //        case LoginErrorCode.PasswordNotMatch:
            //            throw new ServerException(Resources.GetString("FormsAuthenticationCannotLogin"), string.Empty, -1);
            //    }
            //    if (cookieInfo == null)
            //    {
            //        throw new ServerException(Resources.GetString("FormsAuthenticationCannotLogin"), string.Empty, -1);
            //    }
            //    return cookieInfo;
            return null;
        }
    }
}
