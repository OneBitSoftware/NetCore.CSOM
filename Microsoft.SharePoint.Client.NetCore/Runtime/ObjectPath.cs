using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public abstract class ObjectPath
    {
        private long m_parentId;

        private long m_id;

        private ClientRuntimeContext m_context;

        private bool? m_serverObjectIsNull;

        private bool m_isValid;

        internal ClientRuntimeContext Context
        {
            get
            {
                return this.m_context;
            }
        }

        internal ObjectPath Parent
        {
            get
            {
                if (this.m_parentId == -1L)
                {
                    return null;
                }
                return this.m_context.ObjectPaths[this.m_parentId];
            }
        }

        internal long Id
        {
            get
            {
                return this.m_id;
            }
            set
            {
                this.m_id = value;
            }
        }

        internal bool? ServerObjectIsNull
        {
            get
            {
                return this.m_serverObjectIsNull;
            }
            set
            {
                this.m_serverObjectIsNull = value;
            }
        }

        internal bool IsValid
        {
            get
            {
                return this.m_isValid;
            }
            set
            {
                this.m_isValid = value;
            }
        }

        internal virtual string ObjectName
        {
            get
            {
                return null;
            }
        }

        internal ObjectPath(ClientRuntimeContext context, ObjectPath parent, bool addToContext)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.m_context = context;
            if (parent == null)
            {
                this.m_parentId = -1L;
            }
            else
            {
                this.m_parentId = parent.Id;
            }
            this.m_id = context.NextSequenceId;
            if (addToContext)
            {
                context.AddObjectPath(this);
                if (!context.ProcessingResponse)
                {
                    ClientActionInstantiateObjectPath clientActionInstantiateObjectPath = new ClientActionInstantiateObjectPath(this);
                    context.AddQuery(clientActionInstantiateObjectPath);
                    ClientActionInstantiateObjectPathResult obj = new ClientActionInstantiateObjectPathResult(this);
                    context.AddQueryIdAndResultObject(clientActionInstantiateObjectPath.Id, obj);
                }
            }
            this.m_isValid = true;
        }

        internal abstract void WriteToXml(XmlWriter writer, SerializationContext serializationContext);

        internal virtual void Invalidate()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPendingReplace()
        {
            this.m_context.PendingRequest.AddToObjectPathCleanupList(this);
        }
    }
}
