using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class DelimittedStreamReader
    {
        private enum MatchState
        {
            True,
            False,
            InsufficientData
        }

        private class DelimittedReadStream : Stream
        {
            private DelimittedStreamReader reader;

            private int? contentLength;

            private long pos;

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
                    return false;
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
                    if (this.contentLength.HasValue)
                    {
                        return (long)this.contentLength.Value;
                    }
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
                }
            }

            public override long Position
            {
                get
                {
                    return this.pos;
                }
                set
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
                }
            }

            public DelimittedReadStream(DelimittedStreamReader reader, int? contentLength)
            {
                if (reader == null)
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
                }
                this.reader = reader;
                this.contentLength = contentLength;
            }

            //public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
            //{
            //    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            //}

            //public override void Close()
            //{
            //    this.reader.Close(this);
            //}

            //public override void EndWrite(IAsyncResult asyncResult)
            //{
            //    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            //}

            public override void Flush()
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new NotSupportedException());
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
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
                int num = this.reader.Read(this, buffer, offset, count);
                if (num > 0)
                {
                    this.pos += (long)num;
                }
                return num;
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

        private bool canGetNextStream = true;

        private DelimittedStreamReader.DelimittedReadStream currentStream;

        private byte[] delimitter;

        private byte[] matchBuffer;

        private byte[] scratch;

        private BufferedReadStream stream;

        public DelimittedStreamReader(Stream stream)
        {
            this.stream = new BufferedReadStream(stream);
        }

        public void Close()
        {
            this.stream.Close();
        }

        private void Close(DelimittedStreamReader.DelimittedReadStream caller)
        {
            if (this.currentStream == caller)
            {
                if (this.delimitter == null)
                {
                    this.stream.Close();
                }
                else
                {
                    if (this.scratch == null)
                    {
                        this.scratch = new byte[1024];
                    }
                    while (this.Read(caller, this.scratch, 0, this.scratch.Length) != 0)
                    {
                    }
                }
                this.currentStream = null;
            }
        }

        public Stream GetNextStream(byte[] delimitterValue)
        {
            return this.GetNextStream(delimitterValue, null);
        }

        public Stream GetNextStream(byte[] delimitterValue, int? contentLength)
        {
            if (this.currentStream != null)
            {
                this.currentStream.Dispose();// Close();
                this.currentStream = null;
            }
            if (!this.canGetNextStream)
            {
                return null;
            }
            this.delimitter = delimitterValue;
            this.canGetNextStream = (delimitterValue != null);
            this.currentStream = new DelimittedStreamReader.DelimittedReadStream(this, contentLength);
            return this.currentStream;
        }

        private DelimittedStreamReader.MatchState MatchDelimitter(byte[] buffer, int start, int end)
        {
            if (this.delimitter.Length > end - start)
            {
                for (int i = end - start - 1; i >= 1; i--)
                {
                    if (buffer[start + i] != this.delimitter[i])
                    {
                        return DelimittedStreamReader.MatchState.False;
                    }
                }
                return DelimittedStreamReader.MatchState.InsufficientData;
            }
            for (int j = this.delimitter.Length - 1; j >= 1; j--)
            {
                if (buffer[start + j] != this.delimitter[j])
                {
                    return DelimittedStreamReader.MatchState.False;
                }
            }
            return DelimittedStreamReader.MatchState.True;
        }

        private int ProcessRead(byte[] buffer, int offset, int read)
        {
            if (read == 0)
            {
                return read;
            }
            int i = offset;
            int num = offset + read;
            while (i < num)
            {
                if (buffer[i] == this.delimitter[0])
                {
                    switch (this.MatchDelimitter(buffer, i, num))
                    {
                        case DelimittedStreamReader.MatchState.True:
                            {
                                int result = i - offset;
                                i += this.delimitter.Length;
                                this.stream.Push(buffer, i, num - i);
                                this.currentStream = null;
                                return result;
                            }
                        case DelimittedStreamReader.MatchState.InsufficientData:
                            {
                                int num2 = i - offset;
                                if (num2 > 0)
                                {
                                    this.stream.Push(buffer, i, num - i);
                                    return num2;
                                }
                                return -1;
                            }
                    }
                }
                i++;
            }
            return read;
        }

        private int Read(DelimittedStreamReader.DelimittedReadStream caller, byte[] buffer, int offset, int count)
        {
            if (this.currentStream != caller)
            {
                return 0;
            }
            int num = this.stream.Read(buffer, offset, count);
            if (num == 0)
            {
                this.canGetNextStream = false;
                this.currentStream = null;
                return num;
            }
            if (this.delimitter == null)
            {
                return num;
            }
            int num2 = this.ProcessRead(buffer, offset, num);
            if (num2 < 0)
            {
                if (this.matchBuffer == null || this.matchBuffer.Length < this.delimitter.Length - num)
                {
                    this.matchBuffer = new byte[this.delimitter.Length - num];
                }
                int count2 = this.stream.ReadBlock(this.matchBuffer, 0, this.delimitter.Length - num);
                if (this.MatchRemainder(num, count2))
                {
                    this.currentStream = null;
                    num2 = 0;
                }
                else
                {
                    this.stream.Push(this.matchBuffer, 0, count2);
                    int num3 = 1;
                    while (num3 < num && buffer[num3] != this.delimitter[0])
                    {
                        num3++;
                    }
                    if (num3 < num)
                    {
                        this.stream.Push(buffer, offset + num3, num - num3);
                    }
                    num2 = num3;
                }
            }
            return num2;
        }

        private bool MatchRemainder(int start, int count)
        {
            if (start + count != this.delimitter.Length)
            {
                return false;
            }
            for (count--; count >= 0; count--)
            {
                if (this.delimitter[start + count] != this.matchBuffer[count])
                {
                    return false;
                }
            }
            return true;
        }

        internal void Push(byte[] buffer, int offset, int count)
        {
            this.stream.Push(buffer, offset, count);
        }
    }
}
