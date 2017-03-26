using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [Flags]
    public enum MoveOperations
    {
        None = 0,
        Overwrite = 1,
        AllowBrokenThickets = 8,
        BypassApprovePermission = 64
    }
}
