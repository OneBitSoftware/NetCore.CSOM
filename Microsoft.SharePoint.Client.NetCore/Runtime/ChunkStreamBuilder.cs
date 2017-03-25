using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal sealed class ChunkStreamBuilder
    {
        private class ReadonlyChunkStream : Stream
        {
            private bool m_isOpen;

            private int m_chunkIndex;

            private int m_readPosition;

            private ChunkStreamBuilder m_sb;

            private bool m_owner;

            public override bool CanRead
            {
                get
                {
                    return this.m_isOpen;
                }
            }

            public override bool CanSeek
            {
                get
                {
                    return this.m_isOpen;
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
                    return this.m_sb.Length;
                }
            }

            public override long Position
            {
                get
                {
                    long num = 0L;
                    int num2 = 0;
                    while (num2 < this.m_sb.ChunkCount - 1 && num2 < this.m_chunkIndex)
                    {
                        num += (long)this.m_sb.GetChunkSize(num2);
                        num2++;
                    }
                    return num + (long)this.m_readPosition;
                }
                set
                {
                    if (value < 0L || (value > 0L && value >= this.Length))
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                    long num = 0L;
                    this.m_chunkIndex = 0;
                    this.m_readPosition = 0;
                    for (int i = 0; i < this.m_sb.ChunkCount; i++)
                    {
                        this.m_chunkIndex = i;
                        long num2 = num;
                        num += (long)this.m_sb.GetChunkSize(i);
                        if (num > value)
                        {
                            this.m_readPosition = (int)(value - num2);
                            return;
                        }
                    }
                }
            }

            public ReadonlyChunkStream(ChunkStreamBuilder sb, bool owner)
            {
                this.m_sb = sb;
                this.m_isOpen = true;
                this.m_owner = owner;
            }

            protected override void Dispose(bool disposing)
            {
                try
                {
                    if (disposing)
                    {
                        this.m_isOpen = false;
                        if (this.m_owner)
                        {
                            this.m_sb.Close();
                        }
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }

            public override void Flush()
            {
                throw new NotSupportedException();
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                if (!this.m_isOpen)
                {
                    throw new ObjectDisposedException(null);
                }
                if (buffer == null)
                {
                    throw new ArgumentNullException("buffer");
                }
                if (offset < 0)
                {
                    throw new ArgumentOutOfRangeException("offset");
                }
                if (count < 0)
                {
                    throw new ArgumentOutOfRangeException("count");
                }
                if (buffer.Length - offset < count)
                {
                    throw new ArgumentOutOfRangeException("count");
                }
                int num = 0;
                while (count > 0 && this.m_chunkIndex < this.m_sb.ChunkCount)
                {
                    int chunkSize = this.m_sb.GetChunkSize(this.m_chunkIndex);
                    byte[] chunk = this.m_sb.GetChunk(this.m_chunkIndex);
                    if (this.m_readPosition == chunkSize)
                    {
                        this.m_chunkIndex++;
                        this.m_readPosition = 0;
                    }
                    else
                    {
                        int num2 = Math.Min(chunkSize - this.m_readPosition, count);
                        Buffer.BlockCopy(chunk, this.m_readPosition, buffer, offset, num2);
                        this.m_readPosition += num2;
                        offset += num2;
                        count -= num2;
                        num += num2;
                    }
                }
                return num;
            }

            public override int ReadByte()
            {
                if (!this.m_isOpen)
                {
                    throw new ObjectDisposedException(null);
                }
                if (this.m_chunkIndex >= this.m_sb.ChunkCount)
                {
                    return -1;
                }
                int chunkSize = this.m_sb.GetChunkSize(this.m_chunkIndex);
                if (this.m_readPosition == chunkSize)
                {
                    this.m_chunkIndex++;
                    this.m_readPosition = 0;
                    if (this.m_chunkIndex >= this.m_sb.ChunkCount)
                    {
                        return -1;
                    }
                    chunkSize = this.m_sb.GetChunkSize(this.m_chunkIndex);
                }
                if (this.m_readPosition < chunkSize)
                {
                    byte[] chunk = this.m_sb.GetChunk(this.m_chunkIndex);
                    if (this.m_readPosition < chunk.Length)
                    {
                        return (int)chunk[this.m_readPosition++];
                    }
                }
                return -1;
            }

            public override long Seek(long offset, SeekOrigin loc)
            {
                long position = 0L;
                switch (loc)
                {
                    case SeekOrigin.Begin:
                        position = offset;
                        break;
                    case SeekOrigin.Current:
                        position = this.Position + offset;
                        break;
                    case SeekOrigin.End:
                        position = this.Length + offset;
                        break;
                }
                this.Position = position;
                return this.Position;
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override void WriteByte(byte value)
            {
                throw new NotSupportedException();
            }
        }

        private bool m_isOpen;

        private int m_chunkSize;

        private List<byte[]> m_chunkBuffers;

        private byte[] m_buffer;

        private int m_position;

        private int ChunkCount
        {
            get
            {
                return this.m_chunkBuffers.Count;
            }
        }

        public long Length
        {
            get
            {
                long num = 0L;
                for (int i = 0; i < this.ChunkCount; i++)
                {
                    num += (long)this.GetChunkSize(i);
                }
                return num;
            }
        }

        public ChunkStreamBuilder()
        {
            this.m_chunkSize = 65536;
            int num = 1024;
            this.m_buffer = new byte[num];
            this.m_position = 0;
            this.m_chunkBuffers = new List<byte[]>();
            this.m_chunkBuffers.Add(this.m_buffer);
            this.m_isOpen = true;
        }

        public void Close()
        {
            this.m_isOpen = false;
            this.m_buffer = null;
            this.m_chunkBuffers = null;
            this.m_position = 0;
        }

        private void EnsureChunkSize(int count)
        {
            if (this.m_buffer.Length == this.m_chunkSize)
            {
                if (this.m_position == this.m_buffer.Length)
                {
                    this.m_buffer = new byte[this.m_chunkSize];
                    this.m_chunkBuffers.Add(this.m_buffer);
                    this.m_position = 0;
                    return;
                }
            }
            else
            {
                int num = this.m_buffer.Length;
                int num2 = num - this.m_position;
                while (num < this.m_chunkSize && count > num2)
                {
                    num *= 2;
                    num2 = num - this.m_position;
                }
                if (num != this.m_buffer.Length)
                {
                    byte[] array = new byte[num];
                    Buffer.BlockCopy(this.m_buffer, 0, array, 0, this.m_position);
                    this.m_chunkBuffers.RemoveAt(this.m_chunkBuffers.Count - 1);
                    this.m_buffer = array;
                    this.m_chunkBuffers.Add(this.m_buffer);
                }
            }
        }

        public void Write(byte[] buffer)
        {
            if (!this.m_isOpen)
            {
                throw new ObjectDisposedException(null);
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            this.Write(buffer, 0, buffer.Length);
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            if (!this.m_isOpen)
            {
                throw new ObjectDisposedException(null);
            }
            if (buffer == null)
            {
                throw new ArgumentNullException("buffer");
            }
            if (offset < 0)
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            if (buffer.Length - offset < count)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            while (count > 0)
            {
                this.EnsureChunkSize(count);
                int num = Math.Min(count, this.m_buffer.Length - this.m_position);
                Buffer.BlockCopy(buffer, offset, this.m_buffer, this.m_position, num);
                this.m_position += num;
                offset += num;
                count -= num;
            }
        }

        public void WriteByte(byte value)
        {
            if (!this.m_isOpen)
            {
                throw new ObjectDisposedException(null);
            }
            this.EnsureChunkSize(1);
            this.m_buffer[this.m_position++] = value;
        }

        private int GetChunkSize(int chunkIndex)
        {
            if (chunkIndex > this.m_chunkBuffers.Count)
            {
                throw new ArgumentOutOfRangeException("chunkIndex");
            }
            if (chunkIndex == this.m_chunkBuffers.Count - 1)
            {
                return this.m_position;
            }
            return this.m_chunkBuffers[chunkIndex].Length;
        }

        private byte[] GetChunk(int chunkIndex)
        {
            return this.m_chunkBuffers[chunkIndex];
        }

        public void CopyFrom(Stream stream)
        {
            if (!this.m_isOpen)
            {
                throw new ObjectDisposedException(null);
            }
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            byte[] array = new byte[1024];
            int count;
            while ((count = stream.Read(array, 0, array.Length)) != 0)
            {
                this.Write(array, 0, count);
            }
        }

        public void WriteTo(Stream stream)
        {
            if (!this.m_isOpen)
            {
                throw new ObjectDisposedException(null);
            }
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            for (int i = 0; i < this.ChunkCount; i++)
            {
                int chunkSize = this.GetChunkSize(i);
                byte[] chunk = this.GetChunk(i);
                stream.Write(chunk, 0, chunkSize);
            }
        }

        internal static void CopyStream(Stream src, Stream dest)
        {
            if (src == null)
            {
                throw new ArgumentNullException("src");
            }
            if (dest == null)
            {
                throw new ArgumentNullException("dest");
            }
            byte[] array = new byte[1024];
            int count;
            while ((count = src.Read(array, 0, array.Length)) != 0)
            {
                dest.Write(array, 0, count);
            }
        }

        public Stream CreateReadonlyStream()
        {
            if (!this.m_isOpen)
            {
                throw new ObjectDisposedException(null);
            }
            return new ChunkStreamBuilder.ReadonlyChunkStream(this, true);
        }

        internal Stream CreateReadonlyStream(bool owner)
        {
            if (!this.m_isOpen)
            {
                throw new ObjectDisposedException(null);
            }
            return new ChunkStreamBuilder.ReadonlyChunkStream(this, owner);
        }
    }
}
