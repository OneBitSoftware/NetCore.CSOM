using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class MimeHeaders
    {
        private static class Constants
        {
            public const string ContentTransferEncoding = "content-transfer-encoding";

            public const string ContentID = "content-id";

            public const string ContentType = "content-type";

            public const string ContentLength = "content-length";

            public const string MimeVersion = "mime-version";
        }

        private Dictionary<string, MimeHeader> headers = new Dictionary<string, MimeHeader>();

        public ContentTypeHeader ContentType
        {
            get
            {
                MimeHeader mimeHeader;
                if (this.headers.TryGetValue("content-type", out mimeHeader))
                {
                    return mimeHeader as ContentTypeHeader;
                }
                return null;
            }
        }

        public ContentLengthHeader ContentLength
        {
            get
            {
                MimeHeader mimeHeader;
                if (this.headers.TryGetValue("content-length", out mimeHeader))
                {
                    return mimeHeader as ContentLengthHeader;
                }
                return null;
            }
        }

        public ContentIDHeader ContentID
        {
            get
            {
                MimeHeader mimeHeader;
                if (this.headers.TryGetValue("content-id", out mimeHeader))
                {
                    return mimeHeader as ContentIDHeader;
                }
                return null;
            }
        }

        public ContentTransferEncodingHeader ContentTransferEncoding
        {
            get
            {
                MimeHeader mimeHeader;
                if (this.headers.TryGetValue("content-transfer-encoding", out mimeHeader))
                {
                    return mimeHeader as ContentTransferEncodingHeader;
                }
                return null;
            }
        }

        public MimeVersionHeader MimeVersion
        {
            get
            {
                MimeHeader mimeHeader;
                if (this.headers.TryGetValue("mime-version", out mimeHeader))
                {
                    return mimeHeader as MimeVersionHeader;
                }
                return null;
            }
        }

        public void Add(string name, string value, ref int remaining)
        {
            if (name == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
            }
            if (value == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
            }
            if (name != null)
            {
                if (name == "content-type")
                {
                    this.Add(new ContentTypeHeader(value));
                    goto IL_BC;
                }
                if (name == "content-length")
                {
                    this.Add(new ContentLengthHeader(name, value));
                    goto IL_BC;
                }
                if (name == "content-id")
                {
                    this.Add(new ContentIDHeader(name, value));
                    goto IL_BC;
                }
                if (name == "content-transfer-encoding")
                {
                    this.Add(new ContentTransferEncodingHeader(value));
                    goto IL_BC;
                }
                if (name == "mime-version")
                {
                    this.Add(new MimeVersionHeader(value));
                    goto IL_BC;
                }
            }
            remaining += value.Length * 2;
            IL_BC:
            remaining += name.Length * 2;
        }

        public void Add(MimeHeader header)
        {
            if (header == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("header");
            }
            MimeHeader mimeHeader;
            if (this.headers.TryGetValue(header.Name, out mimeHeader))
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeReaderHeaderAlreadyExists", new object[]
                {
                    header.Name
                })));
            }
            this.headers.Add(header.Name, header);
        }

        public void Release(ref int remaining)
        {
            foreach (MimeHeader current in this.headers.Values)
            {
                remaining += current.Value.Length * 2;
            }
        }
    }
}
