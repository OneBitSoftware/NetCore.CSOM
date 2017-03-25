using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class MimeReader
    {
        private static byte[] CRLFCRLF = new byte[]
        {
            13,
            10,
            13,
            10
        };

        private byte[] boundaryBytes;

        private string content;

        private Stream currentStream;

        private MimeHeaderReader mimeHeaderReader;

        private DelimittedStreamReader reader;

        private byte[] scratch = new byte[2];

        public string Preface
        {
            get
            {
                if (this.content == null)
                {
                    Stream nextStream = this.reader.GetNextStream(this.boundaryBytes);
                    this.content = new StreamReader(nextStream, Encoding.UTF8, false, 256).ReadToEnd();
                    nextStream.Dispose();// Close();
                    if (this.content == null)
                    {
                        this.content = string.Empty;
                    }
                }
                return this.content;
            }
        }

        public MimeReader(Stream stream, string boundary)
        {
            if (stream == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
            }
            if (boundary == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("boundary");
            }
            this.reader = new DelimittedStreamReader(stream);
            this.boundaryBytes = MimeWriter.GetBoundaryBytes(boundary);
            this.reader.Push(this.boundaryBytes, 0, 2);
        }

        public void Close()
        {
            this.reader.Close();
        }

        public Stream GetContentStream()
        {
            return this.GetContentStream(null);
        }

        public Stream GetContentStream(int? contentLength)
        {
            this.mimeHeaderReader.Close();
            return this.reader.GetNextStream(this.boundaryBytes, contentLength);
        }

        public bool ReadNextPart()
        {
            string arg_06_0 = this.Preface;
            if (this.currentStream != null)
            {
                this.currentStream.Dispose();// Close();
                this.currentStream = null;
            }
            Stream nextStream = this.reader.GetNextStream(MimeReader.CRLFCRLF);
            if (nextStream == null)
            {
                return false;
            }
            if (this.BlockRead(nextStream, this.scratch, 0, 2) == 2)
            {
                if (this.scratch[0] == 13 && this.scratch[1] == 10)
                {
                    if (this.mimeHeaderReader == null)
                    {
                        this.mimeHeaderReader = new MimeHeaderReader(nextStream);
                    }
                    else
                    {
                        this.mimeHeaderReader.Reset(nextStream);
                    }
                    return true;
                }
                if (this.scratch[0] == 45 && this.scratch[1] == 45)
                {
                    int num = this.BlockRead(nextStream, this.scratch, 0, 2);
                    if (num < 2 || (this.scratch[0] == 13 && this.scratch[1] == 10))
                    {
                        return false;
                    }
                }
            }
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new FormatException(SR.GetString("MimeReaderTruncated", new object[0])));
        }

        public MimeHeaders ReadHeaders(int maxBuffer, ref int remaining)
        {
            MimeHeaders mimeHeaders = new MimeHeaders();
            while (this.mimeHeaderReader.Read(maxBuffer, ref remaining))
            {
                mimeHeaders.Add(this.mimeHeaderReader.Name, this.mimeHeaderReader.Value, ref remaining);
            }
            return mimeHeaders;
        }

        private int BlockRead(Stream stream, byte[] buffer, int offset, int count)
        {
            int num = 0;
            do
            {
                int num2 = stream.Read(buffer, offset + num, count - num);
                if (num2 == 0)
                {
                    break;
                }
                num += num2;
            }
            while (num < count);
            return num;
        }
    }
}
