using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class AttachmentStreamFromServer : ReadonlyWrapStream
    {
        private ClientRuntimeContext m_context;

        private string m_streamId;

        private Stream m_underlyingStream;

        protected override Stream UnderlyingStream
        {
            get
            {
                if (this.m_underlyingStream == null)
                {
                    this.m_underlyingStream = this.m_context.GetStreamAndRemoveFromContext(this.m_streamId);
                }
                return this.m_underlyingStream;
            }
        }

        internal AttachmentStreamFromServer(ClientRuntimeContext context, string streamId)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (string.IsNullOrEmpty(streamId))
            {
                throw new ArgumentNullException("streamId");
            }
            this.m_context = context;
            this.m_streamId = streamId;
        }
    }
}
