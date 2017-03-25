using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal sealed class ClientActionExecutionScopeEnd : ClientAction
    {
        private ExecutionScope m_scope;

        public ExecutionScope Scope
        {
            get
            {
                return this.m_scope;
            }
        }

        public ClientActionExecutionScopeEnd(ExecutionScope scope, string name) : base(scope.Context, null, name)
        {
            this.m_scope = scope;
        }

        internal override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
        }
    }
}
