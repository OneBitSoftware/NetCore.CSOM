using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public enum AlertEventType
    {
        AddObject = 1,
        ModifyObject,
        DeleteObject = 4,
        Discussion = 4080,
        All = -1
    }
}
