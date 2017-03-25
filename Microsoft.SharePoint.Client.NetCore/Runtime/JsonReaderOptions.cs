using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    [Flags]
    internal enum JsonReaderOptions
    {
        None = 0,
        DoNotUseEscapedToken = 1,
        IgnoreStringValue = 2
    }
}
