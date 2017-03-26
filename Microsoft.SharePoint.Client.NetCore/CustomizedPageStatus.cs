using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [Flags]
    public enum CustomizedPageStatus
    {
        None = 0,
        Uncustomized = 1,
        Customized = 2
    }
}
