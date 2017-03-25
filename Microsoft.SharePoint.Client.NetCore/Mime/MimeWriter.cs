using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal class MimeWriter
    {
        private Stream stream;

        private byte[] boundaryBytes;

        private MimeWriterState state;

        private BufferedWrite bufferedWrite;

        private Stream contentStream;

        internal MimeWriter(Stream stream, string boundary)
        {
            if (stream == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
            }
            if (boundary == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("boundary");
            }
            this.stream = stream;
            this.boundaryBytes = MimeWriter.GetBoundaryBytes(boundary);
            this.state = MimeWriterState.Start;
            this.bufferedWrite = new BufferedWrite();
        }

        internal static byte[] GetBoundaryBytes(string boundary)
        {
            byte[] array = new byte[boundary.Length + MimeGlobals.BoundaryPrefix.Length];
            for (int i = 0; i < MimeGlobals.BoundaryPrefix.Length; i++)
            {
                array[i] = MimeGlobals.BoundaryPrefix[i];
            }
            Encoding.UTF8.GetBytes(boundary, 0, boundary.Length, array, MimeGlobals.BoundaryPrefix.Length);
            return array;
        }

        internal void StartPart()
        {
            MimeWriterState mimeWriterState = this.state;
            if (mimeWriterState == MimeWriterState.StartPart || mimeWriterState == MimeWriterState.Closed)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString("MimeWriterInvalidStateForStartPart", new object[]
                {
                    this.state.ToString()
                })));
            }
            this.state = MimeWriterState.StartPart;
            if (this.contentStream != null)
            {
                this.contentStream.Flush();
                this.contentStream = null;
            }
            this.bufferedWrite.Write(this.boundaryBytes);
            this.bufferedWrite.Write(MimeGlobals.CRLF);
        }

        internal void Close()
        {
            MimeWriterState mimeWriterState = this.state;
            if (mimeWriterState == MimeWriterState.Closed)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString("MimeWriterInvalidStateForClose", new object[]
                {
                    this.state.ToString()
                })));
            }
            this.state = MimeWriterState.Closed;
            if (this.contentStream != null)
            {
                this.contentStream.Flush();
                this.contentStream = null;
            }
            this.bufferedWrite.Write(this.boundaryBytes);
            this.bufferedWrite.Write(MimeGlobals.DASHDASH);
            this.bufferedWrite.Write(MimeGlobals.CRLF);
            this.Flush();
        }

        private void Flush()
        {
            if (this.bufferedWrite.Length > 0)
            {
                this.stream.Write(this.bufferedWrite.GetBuffer(), 0, this.bufferedWrite.Length);
                this.bufferedWrite.Reset();
            }
        }

        internal void WriteHeader(string name, string value)
        {
            if (name == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
            }
            if (value == null)
            {
                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
            }
            MimeWriterState mimeWriterState = this.state;
            if (mimeWriterState != MimeWriterState.Start)
            {
                switch (mimeWriterState)
                {
                    case MimeWriterState.Content:
                    case MimeWriterState.Closed:
                        break;
                    default:
                        this.state = MimeWriterState.Header;
                        this.bufferedWrite.Write(name);
                        this.bufferedWrite.Write(MimeGlobals.COLONSPACE);
                        this.bufferedWrite.Write(value);
                        this.bufferedWrite.Write(MimeGlobals.CRLF);
                        return;
                }
            }
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString("MimeWriterInvalidStateForHeader", new object[]
            {
                this.state.ToString()
            })));
        }

        internal Stream GetContentStream()
        {
            MimeWriterState mimeWriterState = this.state;
            if (mimeWriterState != MimeWriterState.Start)
            {
                switch (mimeWriterState)
                {
                    case MimeWriterState.Content:
                    case MimeWriterState.Closed:
                        break;
                    default:
                        this.state = MimeWriterState.Content;
                        this.bufferedWrite.Write(MimeGlobals.CRLF);
                        this.Flush();
                        this.contentStream = this.stream;
                        return this.contentStream;
                }
            }
            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString("MimeWriterInvalidStateForContent", new object[]
            {
                this.state.ToString()
            })));
        }
    }
}