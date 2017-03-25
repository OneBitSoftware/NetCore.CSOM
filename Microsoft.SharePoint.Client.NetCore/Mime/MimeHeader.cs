using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class MimeHeader
    {
        private string name;

        private string value;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public string Value
        {
            get
            {
                return this.value;
            }
        }

        public MimeHeader(string name, string value)
        {
            if (name == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
            }
            this.name = name;
            this.value = value;
        }
    }
}
