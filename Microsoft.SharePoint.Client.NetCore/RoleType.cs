using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public enum RoleType
    {
        None,
        Guest,
        Reader,
        Contributor,
        WebDesigner,
        Administrator,
        Editor,
        System = 255
    }
}
