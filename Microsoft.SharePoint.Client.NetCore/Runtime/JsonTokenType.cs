using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public enum JsonTokenType
    {
        ObjectStart,
        ObjectEnd,
        ArrayStart,
        ArrayEnd,
        String,
        Long,
        ULong,
        Double,
        Boolean,
        DateTime,
        Guid,
        Null,
        Name,
        ByteArray,
        StreamLink
    }
}
