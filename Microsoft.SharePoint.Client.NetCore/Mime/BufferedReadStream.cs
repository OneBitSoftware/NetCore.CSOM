using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class BufferedReadStream : Stream
    {
        private Stream stream;

        private byte[] storedBuffer;

        private int storedLength;

        private int storedOffset;

        private bool readMore;

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanRead
        {
            get
            {
                return this.stream.CanRead;
            }
        }

        public override long Length
        {
            get
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            }
        }

        public override long Position
        {
            get
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            }
            set
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            }
        }

        public BufferedReadStream(Stream stream) : this(stream, false)
        {
        }

        public BufferedReadStream(Stream stream, bool readMore)
        {
            if (stream == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
            }
            this.stream = stream;
            this.readMore = readMore;
        }

        //Edited for .NET Core
        //public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        //{
        //    if (!this.CanRead)
        //    {
        //        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        //    }
        //    return this.stream.BeginRead(buffer, offset, count, callback, state);
        //}

        //Edited for .NET Core
        //public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        //{
        //    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        //}

        //Edited for .NET Core
        //public override void Close()
        public void Close()
        {
            //this.stream.Close();
            this.stream.Dispose();
        }

        //Edited for .NET Core
        //public override int EndRead(IAsyncResult asyncResult)
        //{
        //    if (!this.CanRead)
        //    {
        //        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        //    }
        //    return this.stream.EndRead(asyncResult);
        //}

        //Edited for .NET Core
        //public override void EndWrite(IAsyncResult asyncResult)
        //{
        //    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        //}

        public override void Flush()
        {
            this.stream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (!this.CanRead)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            }
            if (buffer == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("buffer");
            }
            if (offset < 0)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset"));
            }
            if (offset > buffer.Length)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("offset"));
            }
            if (count < 0)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count"));
            }
            if (count > buffer.Length - offset)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("count"));
            }
            int num = 0;
            if (this.storedOffset < this.storedLength)
            {
                num = Math.Min(count, this.storedLength - this.storedOffset);
                Buffer.BlockCopy(this.storedBuffer, this.storedOffset, buffer, offset, num);
                this.storedOffset += num;
                if (num == count || !this.readMore)
                {
                    return num;
                }
                offset += num;
                count -= num;
            }
            return num + this.stream.Read(buffer, offset, count);
        }

        public override int ReadByte()
        {
            if (this.storedOffset < this.storedLength)
            {
                return (int)this.storedBuffer[this.storedOffset++];
            }
            return base.ReadByte();
        }

        public int ReadBlock(byte[] buffer, int offset, int count)
        {
            int num = 0;
            int num2;
            while (num < count && (num2 = this.Read(buffer, offset + num, count - num)) != 0)
            {
                num += num2;
            }
            return num;
        }

        public void Push(byte[] buffer, int offset, int count)
        {
            if (count == 0)
            {
                return;
            }
            if (this.storedOffset == this.storedLength)
            {
                if (this.storedBuffer == null || this.storedBuffer.Length < count)
                {
                    this.storedBuffer = new byte[count];
                }
                this.storedOffset = 0;
                this.storedLength = count;
            }
            else if (count <= this.storedOffset)
            {
                this.storedOffset -= count;
            }
            else if (count <= this.storedBuffer.Length - this.storedLength + this.storedOffset)
            {
                Buffer.BlockCopy(this.storedBuffer, this.storedOffset, this.storedBuffer, count, this.storedLength - this.storedOffset);
                this.storedLength += count - this.storedOffset;
                this.storedOffset = 0;
            }
            else
            {
                byte[] dst = new byte[count + this.storedLength - this.storedOffset];
                Buffer.BlockCopy(this.storedBuffer, this.storedOffset, dst, count, this.storedLength - this.storedOffset);
                this.storedLength += count - this.storedOffset;
                this.storedOffset = 0;
                this.storedBuffer = dst;
            }
            Buffer.BlockCopy(buffer, offset, this.storedBuffer, this.storedOffset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        }

        public override void SetLength(long value)
        {
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
        }
    }
}
