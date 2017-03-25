using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public abstract class ClientAction
    {
        private long m_id;

        private ObjectPath m_objectPath;

        private string m_name;

        public long Id
        {
            get
            {
                return this.m_id;
            }
        }

        public ObjectPath Path
        {
            get
            {
                return this.m_objectPath;
            }
        }

        public string Name
        {
            get
            {
                return this.m_name;
            }
        }

        protected ClientAction(ObjectPath objectPath, string name)
        {
            this.m_objectPath = objectPath;
            this.m_name = name;
            if (objectPath == null)
            {
                this.m_id = ClientRequest.NextSequenceId;
                return;
            }
            this.m_id = objectPath.Context.NextSequenceId;
        }

        internal ClientAction(ClientRuntimeContext context, ObjectPath objectPath, string name)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.m_objectPath = objectPath;
            this.m_name = name;
            this.m_id = context.NextSequenceId;
        }

        internal abstract void WriteToXml(XmlWriter writer, SerializationContext serializationContext);

        internal static void CheckActionParameterInContext(ClientRuntimeContext context, object value)
        {
            if (context != null && value != null)
            {
                ClientObject clientObject = value as ClientObject;
                if (clientObject != null && clientObject.Context != null && clientObject.Context != context)
                {
                    throw new InvalidOperationException(Resources.GetString("NotSameClientContext"));
                }
            }
        }

        internal static void CheckActionParametersInContext(ClientRuntimeContext context, object[] values)
        {
            if (context != null && values != null && values.Length > 0)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    ClientAction.CheckActionParameterInContext(context, values[i]);
                }
            }
        }
    }
}
