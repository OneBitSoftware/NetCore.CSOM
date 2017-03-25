using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class TextPeekReader : TextReader
    {
        internal const int EOF = -1;

        private int m_count;

        private TextReader m_reader;

        private int m_bufferSize;

        private char[] m_buffer;

        private int m_bufferCount;

        private int m_bufferOffset;

        public int BufferSize
        {
            get
            {
                return this.m_bufferSize;
            }
        }

        public int Offset
        {
            get
            {
                return this.m_count;
            }
        }

        public TextPeekReader(TextReader reader)
        {
            this.m_bufferSize = 1024;
            this.m_buffer = new char[this.m_bufferSize];
            this.m_reader = reader;
        }

        public TextPeekReader(TextReader reader, int bufferSize)
        {
            this.m_bufferSize = bufferSize;
            this.m_buffer = new char[this.m_bufferSize];
            this.m_reader = reader;
        }

        //Edited for .NET Core
        public void Close()
        {
            base.Dispose();
            this.m_reader.Dispose();
            //Edited for .NET Core
            //    base.Close();
            //    this.m_reader.Close();
        }

        public override int Peek()
        {
            return this.Peek(0);
        }

        public int Peek(int position)
        {
            if (position > this.m_bufferSize)
            {
                throw new ArgumentOutOfRangeException("position");
            }
            if (this.m_bufferOffset + position < this.m_bufferCount)
            {
                return (int)this.m_buffer[this.m_bufferOffset + position];
            }
            this.FillBuffer();
            if (this.m_bufferOffset + position < this.m_bufferCount)
            {
                return (int)this.m_buffer[this.m_bufferOffset + position];
            }
            return -1;
        }

        public override int Read()
        {
            int num;
            if (this.m_bufferOffset < this.m_bufferCount)
            {
                num = (int)this.m_buffer[this.m_bufferOffset];
                this.m_bufferOffset++;
                this.m_count++;
                return num;
            }
            num = this.m_reader.Read();
            if (num != -1)
            {
                this.m_count++;
            }
            return num;
        }

        public int Peek(char[] buffer, int count)
        {
            if (count > this.m_bufferSize)
            {
                throw new ArgumentOutOfRangeException("count");
            }
            int num = 0;
            while (this.m_bufferOffset + num < this.m_bufferCount && num < count)
            {
                buffer[num] = this.m_buffer[this.m_bufferOffset + num];
                num++;
            }
            if (count > num)
            {
                this.FillBuffer();
                while (this.m_bufferOffset + num < this.m_bufferCount && num < count)
                {
                    buffer[num] = this.m_buffer[this.m_bufferOffset + num];
                    num++;
                }
            }
            return num;
        }

        public int Read(char[] buffer, int count)
        {
            return this.Read(buffer, 0, count);
        }

        public override int Read(char[] buffer, int offset, int count)
        {
            int num = 0;
            while (this.m_bufferOffset < this.m_bufferCount)
            {
                if (num >= count)
                {
                    break;
                }
                buffer[num + offset] = this.m_buffer[this.m_bufferOffset];
                num++;
                this.m_bufferOffset++;
                this.m_count++;
            }
            int num2;
            while (num < count && (num2 = this.m_reader.Read(buffer, num + offset, count - num)) > 0)
            {
                num += num2;
                this.m_count += num2;
            }
            return num;
        }

        private void FillBuffer()
        {
            for (int i = this.m_bufferOffset; i < this.m_bufferCount; i++)
            {
                this.m_buffer[i - this.m_bufferOffset] = this.m_buffer[i];
            }
            this.m_bufferCount -= this.m_bufferOffset;
            this.m_bufferOffset = 0;
            int num;
            while (this.m_bufferCount < this.m_bufferSize && (num = this.m_reader.Read(this.m_buffer, this.m_bufferCount, this.m_bufferSize - this.m_bufferCount)) > 0)
            {
                this.m_bufferCount += num;
            }
        }

        public int Skip()
        {
            return this.Skip(1);
        }

        public int Skip(int count)
        {
            int num = 0;
            while (num < count && this.m_bufferOffset < this.m_bufferCount)
            {
                num++;
                this.m_bufferOffset++;
                this.m_count++;
            }
            if (num < count)
            {
                this.m_bufferOffset = 0;
                this.m_bufferCount = 0;
                do
                {
                    int num2 = this.m_reader.Read();
                    if (num2 == -1)
                    {
                        break;
                    }
                    num++;
                    this.m_count++;
                }
                while (num < count);
            }
            return num;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                this.m_reader.Dispose();
            }
        }
    }
}
