using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal enum MimeWriterState
    {
        Start,
        StartPreface,
        StartPart,
        Header,
        Content,
        Closed
    }
}
