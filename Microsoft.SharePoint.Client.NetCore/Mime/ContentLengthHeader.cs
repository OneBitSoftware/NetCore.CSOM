using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class ContentLengthHeader : MimeHeader
    {
        private int m_length;

        public int Length
        {
            get
            {
                return this.m_length;
            }
        }

        public ContentLengthHeader(string name, string value) : base(name, value)
        {
            if (!int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out this.m_length) || this.m_length < 0)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeContentLengthHeaderInvalid", new object[0])));
            }
        }
    }
}
