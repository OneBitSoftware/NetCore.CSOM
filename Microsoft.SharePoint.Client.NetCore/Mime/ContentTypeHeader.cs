using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class ContentTypeHeader : MimeHeader
    {
        public static readonly ContentTypeHeader Default = new ContentTypeHeader("application/octet-stream");

        private string mediaType;

        private string subType;

        private Dictionary<string, string> parameters;

        public string MediaType
        {
            get
            {
                if (this.mediaType == null && base.Value != null)
                {
                    this.ParseValue();
                }
                return this.mediaType;
            }
        }

        public string MediaSubtype
        {
            get
            {
                if (this.subType == null && base.Value != null)
                {
                    this.ParseValue();
                }
                return this.subType;
            }
        }

        public Dictionary<string, string> Parameters
        {
            get
            {
                if (this.parameters == null)
                {
                    if (base.Value != null)
                    {
                        this.ParseValue();
                    }
                    else
                    {
                        this.parameters = new Dictionary<string, string>();
                    }
                }
                return this.parameters;
            }
        }

        public ContentTypeHeader(string value) : base("content-type", value)
        {
        }

        private void ParseValue()
        {
            if (this.parameters == null)
            {
                int num = 0;
                this.parameters = new Dictionary<string, string>();
                this.mediaType = MailBnfHelper.ReadToken(base.Value, ref num, null);
                if (num >= base.Value.Length || base.Value[num++] != '/')
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeContentTypeHeaderInvalid", new object[0])));
                }
                this.subType = MailBnfHelper.ReadToken(base.Value, ref num, null);
                while (MailBnfHelper.SkipCFWS(base.Value, ref num))
                {
                    if (num >= base.Value.Length || base.Value[num++] != ';')
                    {
                        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeContentTypeHeaderInvalid", new object[0])));
                    }
                    if (!MailBnfHelper.SkipCFWS(base.Value, ref num))
                    {
                        break;
                    }
                    string text = MailBnfHelper.ReadParameterAttribute(base.Value, ref num, null);
                    if (text == null || num >= base.Value.Length || base.Value[num++] != '=')
                    {
                        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeContentTypeHeaderInvalid", new object[0])));
                    }
                    string value = MailBnfHelper.ReadParameterValue(base.Value, ref num, null);
                    this.parameters.Add(text.ToLowerInvariant(), value);
                }
                if (this.parameters.ContainsKey(MtomGlobals.StartInfoParam))
                {
                    string text2 = this.parameters[MtomGlobals.StartInfoParam];
                    int num2 = text2.IndexOf(';');
                    if (num2 > -1)
                    {
                        while (MailBnfHelper.SkipCFWS(text2, ref num2))
                        {
                            if (text2[num2] != ';')
                            {
                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeContentTypeHeaderInvalid", new object[0])));
                            }
                            num2++;
                            string text3 = MailBnfHelper.ReadParameterAttribute(text2, ref num2, null);
                            if (text3 == null || num2 >= text2.Length || text2[num2++] != '=')
                            {
                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeContentTypeHeaderInvalid", new object[0])));
                            }
                            string value2 = MailBnfHelper.ReadParameterValue(text2, ref num2, null);
                            if (text3 == MtomGlobals.ActionParam)
                            {
                                this.parameters[MtomGlobals.ActionParam] = value2;
                            }
                        }
                    }
                }
            }
        }
    }
}
