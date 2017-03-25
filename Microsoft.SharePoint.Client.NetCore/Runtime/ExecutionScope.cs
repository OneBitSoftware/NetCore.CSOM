using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ExecutionScope : IDisposable
    {
        private ClientRuntimeContext m_context;

        private bool m_disposed;

        private string m_name;

        private long m_id;

        private ExecutionScopeDisposingCallback m_disposingCallback;

        private ClientActionExecutionScopeStart m_clientActionExecutionScopeStart;

        internal ClientRuntimeContext Context
        {
            get
            {
                return this.m_context;
            }
        }

        internal ClientActionExecutionScopeStart ClientActionExecutionScopeStart
        {
            get
            {
                return this.m_clientActionExecutionScopeStart;
            }
        }

        public long Id
        {
            get
            {
                return this.m_id;
            }
        }

        public string Name
        {
            get
            {
                return this.m_name;
            }
        }

        internal bool Disposed
        {
            get
            {
                return this.m_disposed;
            }
        }

        internal ExecutionScope(ClientRuntimeContext context, string name, ExecutionScopeDisposingCallback disposingCallback)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.m_context = context;
            this.m_name = name;
            this.m_id = this.m_context.NextSequenceId;
            this.m_context.PendingRequest.ExecutionScopes.Push(this);
            this.m_clientActionExecutionScopeStart = new ClientActionExecutionScopeStart(this, this.m_name);
            this.m_context.PendingRequest.AddQuery(this.m_clientActionExecutionScopeStart);
            this.m_disposingCallback = disposingCallback;
        }

        public void Dispose()
        {
            if (this.m_disposed)
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            if (this.m_disposingCallback != null)
            {
                this.m_disposingCallback();
            }
            if (this.m_context.PendingRequest.ExecutionScopes.Count > 0 && this.m_context.PendingRequest.ExecutionScopes.Pop() == this)
            {
                this.m_context.PendingRequest.AddQuery(new ClientActionExecutionScopeEnd(this, this.m_name));
                this.m_disposed = true;
                return;
            }
            throw ExceptionHandlingScope.CreateInvalidUsageException();
        }

        internal virtual void WriteStart(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement(this.m_name);
            writer.WriteAttributeString("Id", this.Id.ToString(CultureInfo.InvariantCulture));
        }

        internal virtual void WriteEnd(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteEndElement();
        }
    }
}
