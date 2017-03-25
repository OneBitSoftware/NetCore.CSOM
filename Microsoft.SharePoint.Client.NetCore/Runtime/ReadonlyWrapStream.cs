using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal abstract class ReadonlyWrapStream : Stream
    {
        private long m_totalReadCount;

        private bool m_disposed;

        protected abstract Stream UnderlyingStream
        {
            get;
        }

        protected virtual bool OwnUnderlyingStream
        {
            get
            {
                return true;
            }
        }

        protected Action<long> TotalReadCountAction
        {
            get;
            set;
        }

        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return this.UnderlyingStream != null && this.UnderlyingStream.CanSeek;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override long Length
        {
            get
            {
                if (this.UnderlyingStream != null)
                {
                    return this.UnderlyingStream.Length;
                }
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                if (this.UnderlyingStream != null)
                {
                    return this.UnderlyingStream.Position;
                }
                throw new NotSupportedException();
            }
            set
            {
                if (this.UnderlyingStream != null)
                {
                    this.UnderlyingStream.Position = value;
                    return;
                }
                throw new NotSupportedException();
            }
        }

        public override void Flush()
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (this.UnderlyingStream == null)
            {
                return 0;
            }
            int num = this.UnderlyingStream.Read(buffer, offset, count);
            this.m_totalReadCount += (long)num;
            if (num > 0 && this.TotalReadCountAction != null)
            {
                this.TotalReadCountAction(this.m_totalReadCount);
            }
            return num;
        }

        public override int ReadByte()
        {
            if (this.UnderlyingStream == null)
            {
                return -1;
            }
            int num = this.UnderlyingStream.ReadByte();
            if (num >= 0)
            {
                this.m_totalReadCount += 1L;
                if (this.TotalReadCountAction != null)
                {
                    this.TotalReadCountAction(this.m_totalReadCount);
                }
            }
            return num;
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            if (this.UnderlyingStream != null)
            {
                return this.UnderlyingStream.Seek(offset, origin);
            }
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && !this.m_disposed)
            {
                if (this.UnderlyingStream != null && this.OwnUnderlyingStream)
                {
                    this.UnderlyingStream.Dispose();
                }
                this.m_disposed = true;
            }
            base.Dispose(disposing);
        }
    }
}
