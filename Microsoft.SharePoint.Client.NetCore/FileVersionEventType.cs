using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public enum FileVersionEventType : short
    {
        Share = 1,
        Rename,
        Restore,
        MaxServerType = 28671,
        FromClient
    }
}
