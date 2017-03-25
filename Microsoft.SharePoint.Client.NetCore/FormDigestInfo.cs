using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public sealed class FormDigestInfo
    {
        public string DigestValue
        {
            get;
            internal set;
        }

        public DateTime Expiration
        {
            get;
            internal set;
        }

        internal Version RequestSchemaVersion
        {
            get;
            set;
        }

        internal FormDigestInfo()
        {
        }
    }
}
