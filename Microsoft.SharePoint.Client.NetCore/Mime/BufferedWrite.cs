using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class BufferedWrite
    {
        private byte[] buffer;

        private int offset;

        internal int Length
        {
            get
            {
                return this.offset;
            }
        }

        internal BufferedWrite() : this(256)
        {
        }

        internal BufferedWrite(int initialSize)
        {
            this.buffer = new byte[initialSize];
        }

        private void EnsureBuffer(int count)
        {
            int num = this.buffer.Length;
            if (count > num - this.offset)
            {
                int num2 = num;
                while (num2 != 2147483647)
                {
                    num2 = ((num2 < 1073741823) ? (num2 * 2) : 2147483647);
                    if (count <= num2 - this.offset)
                    {
                        byte[] dst = new byte[num2];
                        Buffer.BlockCopy(this.buffer, 0, dst, 0, this.offset);
                        this.buffer = dst;
                        return;
                    }
                }
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(SR.GetString("WriteBufferOverflow", new object[0])));
            }
        }

        internal byte[] GetBuffer()
        {
            return this.buffer;
        }

        internal void Reset()
        {
            this.offset = 0;
        }

        internal void Write(byte[] value)
        {
            this.Write(value, 0, value.Length);
        }

        internal void Write(byte[] value, int index, int count)
        {
            this.EnsureBuffer(count);
            Buffer.BlockCopy(value, index, this.buffer, this.offset, count);
            this.offset += count;
        }

        internal void Write(string value)
        {
            this.Write(value, 0, value.Length);
        }

        internal void Write(string value, int index, int count)
        {
            this.EnsureBuffer(count);
            for (int i = 0; i < count; i++)
            {
                char c = value[index + i];
                if (c > 'ÿ')
                {
                    string arg_49_0 = "MimeHeaderInvalidCharacter";
                    object[] array = new object[2];
                    array[0] = c;
                    object[] arg_47_0 = array;
                    int arg_47_1 = 1;
                    int num = (int)c;
                    arg_47_0[arg_47_1] = num.ToString("X", CultureInfo.InvariantCulture);
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString(arg_49_0, array)));
                }
                this.buffer[this.offset + i] = (byte)c;
            }
            this.offset += count;
        }
    }
}
