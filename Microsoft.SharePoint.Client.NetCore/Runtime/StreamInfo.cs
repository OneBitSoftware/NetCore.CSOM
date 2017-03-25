using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class StreamInfo
    {
        private string m_id;

        private Stream m_stream;

        public string Id
        {
            get
            {
                return this.m_id;
            }
        }

        public Stream Stream
        {
            get
            {
                return this.m_stream;
            }
        }

        public StreamInfo(string streamId, Stream stream)
        {
            if (string.IsNullOrEmpty(streamId))
            {
                throw new ArgumentNullException("streamId");
            }
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            if (stream.Length < 0L)
            {
                throw ClientUtility.CreateArgumentException("stream");
            }
            this.m_id = streamId;
            this.m_stream = stream;
        }
    }
}
