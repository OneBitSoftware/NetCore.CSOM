using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class MimeHeaderReader
    {
        private enum ReadState
        {
            ReadName,
            SkipWS,
            ReadValue,
            ReadLF,
            ReadWS,
            EOF
        }

        private string value;

        private byte[] buffer = new byte[1024];

        private int maxOffset;

        private string name;

        private int offset;

        private MimeHeaderReader.ReadState readState;

        private Stream stream;

        public string Value
        {
            get
            {
                return this.value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public MimeHeaderReader(Stream stream)
        {
            if (stream == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
            }
            this.stream = stream;
        }

        public void Close()
        {
            this.stream.Dispose();// Close();
            this.readState = MimeHeaderReader.ReadState.EOF;
        }

        public bool Read(int maxBuffer, ref int remaining)
        {
            this.name = null;
            this.value = null;
            while (this.readState != MimeHeaderReader.ReadState.EOF)
            {
                if (this.offset == this.maxOffset)
                {
                    this.maxOffset = this.stream.Read(this.buffer, 0, this.buffer.Length);
                    this.offset = 0;
                    if (this.BufferEnd())
                    {
                        break;
                    }
                }
                if (this.ProcessBuffer(maxBuffer, ref remaining))
                {
                    break;
                }
            }
            return this.value != null;
        }

        private bool ProcessBuffer(int maxBuffer, ref int remaining)
        {
            int num = this.offset;
            int num2 = this.maxOffset;
            int i = num;
            switch (this.readState)
            {
                case MimeHeaderReader.ReadState.ReadName:
                    while (i < num2)
                    {
                        byte b = this.buffer[i];
                        if (b == 58)
                        {
                            this.AppendName(Encoding.UTF8.GetString(this.buffer, num, i - num), maxBuffer, ref remaining);
                            i++;
                            goto IL_177;
                        }
                        if (b >= 65 && b <= 90)
                        {
                            b += 32;
                            this.buffer[i] = b;
                        }
                        else if (b < 33 || b > 126)
                        {
                            if (this.name != null || b != 13)
                            {
                                string arg_118_0 = "MimeHeaderInvalidCharacter";
                                object[] array = new object[2];
                                array[0] = this.buffer[i];
                                object[] arg_115_0 = array;
                                int arg_115_1 = 1;
                                int num3 = (int)this.buffer[i];
                                arg_115_0[arg_115_1] = num3.ToString("X", CultureInfo.InvariantCulture);
                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString(arg_118_0, array)));
                            }
                            i++;
                            if (i >= num2 || this.buffer[i] != 10)
                            {
                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeReaderMalformedHeader", new object[0])));
                            }
                            goto IL_283;
                        }
                        i++;
                    }
                    this.AppendName(Encoding.UTF8.GetString(this.buffer, num, i - num), maxBuffer, ref remaining);
                    this.readState = MimeHeaderReader.ReadState.ReadName;
                    goto IL_293;
                case MimeHeaderReader.ReadState.SkipWS:
                    break;
                case MimeHeaderReader.ReadState.ReadValue:
                    goto IL_187;
                case MimeHeaderReader.ReadState.ReadLF:
                    goto IL_20E;
                case MimeHeaderReader.ReadState.ReadWS:
                    goto IL_248;
                case MimeHeaderReader.ReadState.EOF:
                    goto IL_283;
                default:
                    goto IL_293;
            }
            IL_177:
            while (i < num2)
            {
                if (this.buffer[i] != 9 && this.buffer[i] != 32)
                {
                    goto IL_187;
                }
                i++;
            }
            this.readState = MimeHeaderReader.ReadState.SkipWS;
            goto IL_293;
            IL_187:
            num = i;
            while (i < num2)
            {
                byte b2 = this.buffer[i];
                if (b2 == 13)
                {
                    this.AppendValue(Encoding.UTF8.GetString(this.buffer, num, i - num), maxBuffer, ref remaining);
                    i++;
                    goto IL_20E;
                }
                if (b2 == 10)
                {
                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeReaderMalformedHeader", new object[0])));
                }
                i++;
            }
            this.AppendValue(Encoding.UTF8.GetString(this.buffer, num, i - num), maxBuffer, ref remaining);
            this.readState = MimeHeaderReader.ReadState.ReadValue;
            goto IL_293;
            IL_20E:
            if (i >= num2)
            {
                this.readState = MimeHeaderReader.ReadState.ReadLF;
                goto IL_293;
            }
            if (this.buffer[i] != 10)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeReaderMalformedHeader", new object[0])));
            }
            i++;
            IL_248:
            if (i >= num2)
            {
                this.readState = MimeHeaderReader.ReadState.ReadWS;
                goto IL_293;
            }
            if (this.buffer[i] != 32 && this.buffer[i] != 9)
            {
                this.readState = MimeHeaderReader.ReadState.ReadName;
                this.offset = i;
                return true;
            }
            goto IL_187;
            IL_283:
            this.readState = MimeHeaderReader.ReadState.EOF;
            this.offset = i;
            return true;
            IL_293:
            this.offset = i;
            return false;
        }

        private bool BufferEnd()
        {
            if (this.maxOffset != 0)
            {
                return false;
            }
            if (this.readState != MimeHeaderReader.ReadState.ReadWS && this.readState != MimeHeaderReader.ReadState.ReadValue)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeReaderMalformedHeader", new object[0])));
            }
            this.readState = MimeHeaderReader.ReadState.EOF;
            return true;
        }

        public void Reset(Stream inputStream)
        {
            if (inputStream == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("inputStream");
            }
            if (this.readState != MimeHeaderReader.ReadState.EOF)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString("MimeReaderResetCalledBeforeEOF", new object[0])));
            }
            this.stream = inputStream;
            this.readState = MimeHeaderReader.ReadState.ReadName;
            this.maxOffset = 0;
            this.offset = 0;
        }

        private void AppendValue(string headerValue, int maxBuffer, ref int remaining)
        {
            MimeHeaderReader.DecrementBufferQuota(maxBuffer, ref remaining, headerValue.Length * 2);
            if (this.value == null)
            {
                this.value = headerValue;
                return;
            }
            this.value += headerValue;
        }

        private void AppendName(string headerName, int maxBuffer, ref int remaining)
        {
            MimeHeaderReader.DecrementBufferQuota(maxBuffer, ref remaining, headerName.Length * 2);
            if (this.name == null)
            {
                this.name = headerName;
                return;
            }
            this.name += headerName;
        }

        private static void DecrementBufferQuota(int maxBuffer, ref int remaining, int size)
        {
            if (remaining - size <= 0)
            {
                remaining = 0;
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new XmlException(SR.GetString("MtomBufferQuotaExceeded", new object[]
                {
                    maxBuffer
                })));
            }
            remaining -= size;
        }
    }
}
