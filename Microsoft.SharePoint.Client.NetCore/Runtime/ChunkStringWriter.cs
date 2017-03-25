using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ChunkStringWriter : TextWriter
    {
        private bool m_isOpen;

        private ChunkStringBuilder m_sb;

        private static UnicodeEncoding s_encoding;

        public override Encoding Encoding
        {
            get
            {
                if (ChunkStringWriter.s_encoding == null)
                {
                    ChunkStringWriter.s_encoding = new UnicodeEncoding(false, false);
                }
                return ChunkStringWriter.s_encoding;
            }
        }

        public ChunkStringWriter(ChunkStringBuilder sb, IFormatProvider formatProvider) : base(formatProvider)
        {
            if (sb == null)
            {
                throw new ArgumentNullException("sb");
            }
            this.m_sb = sb;
            this.m_isOpen = true;
        }

        //Edited for .NET Core
        //public override void Close()
        public void Close()
        {
            this.Dispose(true);
        }

        protected override void Dispose(bool disposing)
        {
            this.m_isOpen = false;
            base.Dispose(disposing);
        }

        public override void Write(char value)
        {
            if (!this.m_isOpen)
            {
                throw new InvalidOperationException();
            }
            this.m_sb.Append(value);
        }

        public override void Write(string value)
        {
            if (!this.m_isOpen)
            {
                throw new InvalidOperationException();
            }
            if (value != null)
            {
                this.m_sb.Append(value);
            }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            if (!this.m_isOpen)
            {
                throw new InvalidOperationException();
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if (buffer.Length - index < count)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            this.m_sb.Append(buffer, index, count);
        }
    }
}
