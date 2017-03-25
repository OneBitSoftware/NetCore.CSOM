using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class ContentIDHeader : MimeHeader
    {
        public ContentIDHeader(string name, string value) : base(name, value)
        {
        }
    }
}