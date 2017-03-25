using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class ClientObjectData
    {
        private string m_version;

        private Dictionary<string, object> m_properties;

        private Dictionary<string, object> m_clientObjectProperties;

        private Dictionary<string, object> m_methodReturnObjects;

        private ClientQueryInternal m_query;

        private ClientObject m_typedObject;

        private ClientObject m_associatedObject;

        private ObjectPath m_path;

        private bool m_collectionDataInited;

        private List<object> m_collectionData;

        internal string Version
        {
            get
            {
                return this.m_version;
            }
            set
            {
                this.m_version = value;
            }
        }

        public Dictionary<string, object> Properties
        {
            get
            {
                if (this.m_properties == null)
                {
                    this.m_properties = new Dictionary<string, object>();
                }
                return this.m_properties;
            }
        }

        public Dictionary<string, object> ClientObjectProperties
        {
            get
            {
                if (this.m_clientObjectProperties == null)
                {
                    this.m_clientObjectProperties = new Dictionary<string, object>();
                }
                return this.m_clientObjectProperties;
            }
        }

        public Dictionary<string, object> MethodReturnObjects
        {
            get
            {
                if (this.m_methodReturnObjects == null)
                {
                    this.m_methodReturnObjects = new Dictionary<string, object>();
                }
                return this.m_methodReturnObjects;
            }
        }

        internal ClientQueryInternal Query
        {
            get
            {
                return this.m_query;
            }
            set
            {
                this.m_query = value;
            }
        }

        internal ClientObject TypedObject
        {
            get
            {
                return this.m_typedObject;
            }
            set
            {
                this.m_typedObject = value;
            }
        }

        internal ClientObject AssociatedObject
        {
            get
            {
                return this.m_associatedObject;
            }
            set
            {
                this.m_associatedObject = value;
            }
        }

        internal ObjectPath Path
        {
            get
            {
                return this.m_path;
            }
            set
            {
                this.m_path = value;
            }
        }

        internal bool CollectionDataInited
        {
            get
            {
                return this.m_collectionDataInited;
            }
            set
            {
                this.m_collectionDataInited = value;
            }
        }

        internal List<object> CollectionData
        {
            get
            {
                if (this.m_collectionData == null)
                {
                    this.m_collectionData = new List<object>();
                }
                return this.m_collectionData;
            }
            set
            {
                this.m_collectionData = value;
            }
        }
    }
}
