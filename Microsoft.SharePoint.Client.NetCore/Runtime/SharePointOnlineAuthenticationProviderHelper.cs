using Microsoft.SharePoint.Client.NetCoreIdcrl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal static class SharePointOnlineAuthenticationProviderHelper
    {
        internal static ISharePointOnlineAuthenticationProvider CreateDefaultProvider()
        {
            return new SharePointOnlineAuthenticationProvider();
        }
    }
}
