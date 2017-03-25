using System;
using System.Security;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal interface ISharePointOnlineAuthenticationProvider
    {
        //Edited for .NET Core
        //string GetAuthenticationCookie(Uri url, string userName, SecureString password, bool alwaysThrowOnFailure, EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> executingWebRequest);
        string GetAuthenticationCookie(Uri url, string userName, string password, bool alwaysThrowOnFailure, EventHandler<SharePointOnlineCredentialsWebRequestEventArgs> executingWebRequest);
    }
}
