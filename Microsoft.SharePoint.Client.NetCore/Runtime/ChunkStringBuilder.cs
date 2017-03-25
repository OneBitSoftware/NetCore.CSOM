using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal sealed class ChunkStringBuilder
    {
        private class ChunkStringReader : TextReader
        {
            private int m_pos;

            private int m_sbIndex;

            private ChunkStringBuilder m_chunkStringBuilder;

            public ChunkStringReader(ChunkStringBuilder s)
            {
                if (s == null)
                {
                    throw new ArgumentNullException("s");
                }
                this.m_chunkStringBuilder = s;
            }

            //Edited for .NET Core
            //public override void Close()
            public void Close()
            {
                this.Dispose(true);
            }

            protected override void Dispose(bool disposing)
            {
                this.m_chunkStringBuilder = null;
                this.m_pos = 0;
                base.Dispose(disposing);
            }

            public override int Peek()
            {
                if (this.m_chunkStringBuilder == null)
                {
                    throw new InvalidOperationException();
                }
                if (this.m_sbIndex < this.m_chunkStringBuilder.m_sbs.Count && this.m_pos < this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].Length)
                {
                    return (int)this.m_chunkStringBuilder.m_sbs[this.m_sbIndex][this.m_pos];
                }
                return -1;
            }

            public override int Read()
            {
                if (this.m_chunkStringBuilder == null)
                {
                    throw new InvalidOperationException();
                }
                int result;
                if (this.m_sbIndex < this.m_chunkStringBuilder.m_sbs.Count && this.m_pos < this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].Length)
                {
                    result = (int)this.m_chunkStringBuilder.m_sbs[this.m_sbIndex][this.m_pos];
                    this.m_pos++;
                    if (this.m_pos == this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].Length)
                    {
                        this.m_sbIndex++;
                        this.m_pos = 0;
                    }
                }
                else
                {
                    result = -1;
                }
                return result;
            }

            public override int Read(char[] buffer, int index, int count)
            {
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
                if (this.m_chunkStringBuilder == null)
                {
                    throw new InvalidOperationException();
                }
                int num = 0;
                while (count > 0 && this.m_sbIndex < this.m_chunkStringBuilder.m_sbs.Count)
                {
                    if (this.m_pos < this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].Length)
                    {
                        int num2 = this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].Length - this.m_pos;
                        if (num2 > count)
                        {
                            num2 = count;
                        }
                        this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].CopyTo(this.m_pos, buffer, index, num2);
                        count -= num2;
                        num += num2;
                        index += num2;
                        this.m_pos += num2;
                    }
                    if (this.m_pos >= this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].Length)
                    {
                        this.m_pos = 0;
                        this.m_sbIndex++;
                    }
                }
                return num;
            }
        }

        private class UTF8ReadonlyStream : Stream
        {
            private ChunkStringBuilder m_chunkStringBuilder;

            private int m_sbIndex;

            private int m_pos;

            private byte[] m_bytes;

            public override bool CanRead
            {
                get
                {
                    return true;
                }
            }

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

            public override long Length
            {
                get
                {
                    long num = 0L;
                    for (int i = 0; i < this.m_chunkStringBuilder.m_sbs.Count; i++)
                    {
                        num += (long)Encoding.UTF8.GetByteCount(this.m_chunkStringBuilder.m_sbs[i].ToString());
                    }
                    return num;
                }
            }

            public override long Position
            {
                get
                {
                    throw new NotSupportedException();
                }
                set
                {
                    throw new NotSupportedException();
                }
            }

            public UTF8ReadonlyStream(ChunkStringBuilder sb)
            {
                this.m_chunkStringBuilder = sb;
            }

            public override void SetLength(long value)
            {
                throw new NotSupportedException();
            }

            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotSupportedException();
            }

            public override void Flush()
            {
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
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
                if (this.m_chunkStringBuilder == null)
                {
                    throw new InvalidOperationException();
                }
                int num = 0;
                while (count > 0 && this.m_sbIndex < this.m_chunkStringBuilder.m_sbs.Count)
                {
                    if (this.m_bytes == null)
                    {
                        this.m_bytes = Encoding.UTF8.GetBytes(this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].ToString());
                    }
                    if (this.m_pos < this.m_bytes.Length)
                    {
                        int num2 = this.m_bytes.Length - this.m_pos;
                        if (num2 > count)
                        {
                            num2 = count;
                        }
                        Buffer.BlockCopy(this.m_bytes, this.m_pos, buffer, offset, num2);
                        count -= num2;
                        num += num2;
                        offset += num2;
                        this.m_pos += num2;
                    }
                    if (this.m_pos >= this.m_bytes.Length)
                    {
                        this.m_pos = 0;
                        this.m_sbIndex++;
                        this.m_bytes = null;
                    }
                }
                return num;
            }

            public override int ReadByte()
            {
                while (this.m_sbIndex < this.m_chunkStringBuilder.m_sbs.Count)
                {
                    if (this.m_bytes == null)
                    {
                        this.m_bytes = Encoding.UTF8.GetBytes(this.m_chunkStringBuilder.m_sbs[this.m_sbIndex].ToString());
                        this.m_pos = 0;
                    }
                    if (this.m_pos < this.m_bytes.Length)
                    {
                        return (int)this.m_bytes[this.m_pos++];
                    }
                    this.m_pos = 0;
                    this.m_sbIndex++;
                    this.m_bytes = null;
                }
                return -1;
            }

            public override void Write(byte[] buffer, int offset, int count)
            {
                throw new NotSupportedException();
            }

            public override void WriteByte(byte value)
            {
                throw new NotSupportedException();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    this.m_chunkStringBuilder = null;
                }
                base.Dispose(disposing);
            }
        }

        private const int MaxChunkLength = 20000;

        private const int StringBuilderMaxCapacity = 20100;

        private List<StringBuilder> m_sbs;

        private StringBuilder m_sb;

        public char this[int index]
        {
            get
            {
                for (int i = 0; i < this.m_sbs.Count; i++)
                {
                    StringBuilder stringBuilder = this.m_sbs[i];
                    if (index < stringBuilder.Length)
                    {
                        return stringBuilder[index];
                    }
                    index -= stringBuilder.Length;
                }
                throw new ArgumentOutOfRangeException("index");
            }
            set
            {
                for (int i = 0; i < this.m_sbs.Count; i++)
                {
                    StringBuilder stringBuilder = this.m_sbs[i];
                    if (index < stringBuilder.Length)
                    {
                        stringBuilder[index] = value;
                        return;
                    }
                    index -= stringBuilder.Length;
                }
                throw new ArgumentOutOfRangeException("index");
            }
        }

        public int Length
        {
            get
            {
                int num = 0;
                for (int i = 0; i < this.m_sbs.Count; i++)
                {
                    num += this.m_sbs[i].Length;
                }
                return num;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                int i;
                for (i = 0; i < this.m_sbs.Count; i++)
                {
                    StringBuilder stringBuilder = this.m_sbs[i];
                    if (value < stringBuilder.Length)
                    {
                        stringBuilder.Length = value;
                        value = 0;
                        this.m_sb = stringBuilder;
                        break;
                    }
                    value -= stringBuilder.Length;
                }
                if (value == 0)
                {
                    if (i + 1 < this.m_sbs.Count)
                    {
                        this.m_sbs.RemoveRange(i + 1, this.m_sbs.Count - i - 1);
                        return;
                    }
                }
                else
                {
                    this.Append('\0', value);
                }
            }
        }

        public ChunkStringBuilder()
        {
            this.m_sbs = new List<StringBuilder>();
            this.m_sb = ChunkStringBuilder.CreateStringBuilder();
            this.m_sbs.Add(this.m_sb);
        }

        public ChunkStringBuilder(string value)
        {
            this.m_sbs = new List<StringBuilder>();
            if (value != null)
            {
                if (value.Length <= 20000)
                {
                    this.m_sb = ChunkStringBuilder.CreateStringBuilder();
                    this.m_sb.Append(value);
                    this.m_sbs.Add(this.m_sb);
                    return;
                }
                for (int i = 0; i < value.Length; i += 20000)
                {
                    int num = 20000;
                    if (i + num > value.Length)
                    {
                        num = value.Length - i;
                    }
                    this.m_sb = ChunkStringBuilder.CreateStringBuilder();
                    this.m_sb.Append(value, i, num);
                    this.m_sbs.Add(this.m_sb);
                }
            }
        }

        private static StringBuilder CreateStringBuilder()
        {
            return new StringBuilder(16, 20100);
        }

        private void CreateNewBufferIfNecessary()
        {
            if (this.m_sb.Length >= 20000)
            {
                this.m_sb = ChunkStringBuilder.CreateStringBuilder();
                this.m_sbs.Add(this.m_sb);
            }
        }

        public ChunkStringBuilder Append(bool value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(byte value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(char value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(decimal value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(double value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(char[] value)
        {
            return this.Append(value, 0, value.Length);
        }

        public ChunkStringBuilder Append(short value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(int value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(long value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(sbyte value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(float value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(string value)
        {
            if (value != null)
            {
                int i = 0;
                this.CreateNewBufferIfNecessary();
                while (i < value.Length)
                {
                    int val = 20000 - this.m_sb.Length;
                    int num = Math.Min(value.Length - i, val);
                    this.m_sb.Append(value.Substring(i, num));
                    i += num;
                    this.CreateNewBufferIfNecessary();
                }
            }
            return this;
        }

        public ChunkStringBuilder Append(ushort value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(uint value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(ulong value)
        {
            this.m_sb.Append(value);
            this.CreateNewBufferIfNecessary();
            return this;
        }

        public ChunkStringBuilder Append(char value, int repeatCount)
        {
            this.CreateNewBufferIfNecessary();
            while (repeatCount > 0)
            {
                int num = 20000 - this.m_sb.Length;
                int num2 = (repeatCount > num) ? num : repeatCount;
                this.m_sb.Append(value, num2);
                repeatCount -= num2;
                this.CreateNewBufferIfNecessary();
            }
            return this;
        }

        public ChunkStringBuilder Append(string value, int startIndex, int count)
        {
            if (value != null)
            {
                this.CreateNewBufferIfNecessary();
                while (count > 0)
                {
                    int num = 20000 - this.m_sb.Length;
                    int num2 = (count > num) ? num : count;
                    this.m_sb.Append(value, startIndex, num2);
                    startIndex += num2;
                    count -= num2;
                    this.CreateNewBufferIfNecessary();
                }
            }
            return this;
        }

        public ChunkStringBuilder Append(char[] value, int startIndex, int count)
        {
            if (value != null)
            {
                this.CreateNewBufferIfNecessary();
                while (count > 0)
                {
                    int num = 20000 - this.m_sb.Length;
                    int num2 = (count > num) ? num : count;
                    this.m_sb.Append(value, startIndex, num2);
                    startIndex += num2;
                    count -= num2;
                    this.CreateNewBufferIfNecessary();
                }
            }
            return this;
        }

        public ChunkStringBuilder AppendLine()
        {
            this.Append(Environment.NewLine);
            return this;
        }

        public ChunkStringBuilder AppendLine(string value)
        {
            this.Append(value);
            this.AppendLine();
            return this;
        }

        private void SurrogatePairAdjust()
        {
            for (int i = this.m_sbs.Count - 1; i >= 0; i--)
            {
                if (this.m_sbs[i].Length == 0)
                {
                    this.m_sbs.RemoveAt(i);
                }
            }
            for (int j = 0; j < this.m_sbs.Count - 1; j++)
            {
                char highSurrogate = this.m_sbs[j][this.m_sbs[j].Length - 1];
                char c = this.m_sbs[j + 1][0];
                if (char.IsSurrogatePair(highSurrogate, c))
                {
                    this.m_sbs[j].Append(c);
                    this.m_sbs[j + 1].Remove(0, 1);
                }
            }
        }

        public void WriteContentTo(TextWriter writer)
        {
            for (int i = 0; i < this.m_sbs.Count; i++)
            {
                writer.Write(this.m_sbs[i].ToString());
            }
        }

        public void WriteContentAsRawXml(XmlWriter writer)
        {
            this.SurrogatePairAdjust();
            for (int i = 0; i < this.m_sbs.Count; i++)
            {
                writer.WriteRaw(this.m_sbs[i].ToString());
            }
        }

        public void WriteContentAsUTF8(Stream stream)
        {
            this.SurrogatePairAdjust();
            for (int i = 0; i < this.m_sbs.Count; i++)
            {
                StringBuilder stringBuilder = this.m_sbs[i];
                byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
                stream.Write(bytes, 0, bytes.Length);
            }
        }

        public TextWriter CreateTextWriter(IFormatProvider formatProvider)
        {
            return new ChunkStringWriter(this, formatProvider);
        }

        public XmlWriter CreateXmlWriter()
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.OmitXmlDeclaration = true;
            xmlWriterSettings.NewLineHandling = NewLineHandling.Entitize;
            return XmlWriter.Create(this.CreateTextWriter(CultureInfo.InvariantCulture), xmlWriterSettings);
        }

        public TextReader CreateTextReader()
        {
            return new ChunkStringBuilder.ChunkStringReader(this);
        }

        public Stream CreateUTF8ReadonlyStream()
        {
            this.SurrogatePairAdjust();
            return new ChunkStringBuilder.UTF8ReadonlyStream(this);
        }
    }
}
