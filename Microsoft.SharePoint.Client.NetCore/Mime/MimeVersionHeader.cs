using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class MimeVersionHeader : MimeHeader
    {
        public static readonly MimeVersionHeader Default = new MimeVersionHeader("1.0");

        private string version;

        public string Version
        {
            get
            {
                if (this.version == null && base.Value != null)
                {
                    this.ParseValue();
                }
                return this.version;
            }
        }

        public MimeVersionHeader(string value) : base("mime-version", value)
        {
        }

        private void ParseValue()
        {
            if (base.Value == "1.0")
            {
                this.version = "1.0";
                return;
            }
            int num = 0;
            if (!MailBnfHelper.SkipCFWS(base.Value, ref num))
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeVersionHeaderInvalid", new object[0])));
            }
            StringBuilder stringBuilder = new StringBuilder();
            MailBnfHelper.ReadDigits(base.Value, ref num, stringBuilder);
            if (!MailBnfHelper.SkipCFWS(base.Value, ref num) || num >= base.Value.Length || base.Value[num++] != '.' || !MailBnfHelper.SkipCFWS(base.Value, ref num))
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeVersionHeaderInvalid", new object[0])));
            }
            stringBuilder.Append('.');
            MailBnfHelper.ReadDigits(base.Value, ref num, stringBuilder);
            this.version = stringBuilder.ToString();
        }
    }
}
