using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public abstract class ClientObject : IFromJson
    {
        private ClientRuntimeContext m_context;

        private ClientObjectData m_objectData;

        private ClientObjectCollection m_parentCollection;

        private bool m_setAsNull;

        public ClientRuntimeContext Context
        {
            get
            {
                return this.m_context;
            }
        }

        public object Tag
        {
            get;
            set;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ObjectPath Path
        {
            get
            {
                return this.m_objectData.Path;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ObjectVersion
        {
            get
            {
                return this.m_objectData.Version;
            }
            set
            {
                this.m_objectData.Version = value;
            }
        }

        protected internal ClientObjectData ObjectData
        {
            get
            {
                return this.m_objectData;
            }
        }

        internal ClientQueryInternal Query
        {
            get
            {
                ClientQueryInternal clientQueryInternal = this.m_objectData.Query;
                if (clientQueryInternal == null || clientQueryInternal != this.Context.PendingRequest.LastAction)
                {
                    clientQueryInternal = new ClientQueryInternal(this, null, false, null);
                    this.m_objectData.Query = clientQueryInternal;
                    this.Context.AddQueryIdAndResultObject(clientQueryInternal.Id, this);
                    this.Context.AddQuery(clientQueryInternal);
                    this.Context.AddObjectToQueryCleanupList(this);
                    this.SelectExistingScalarProperties(clientQueryInternal);
                    this.LoadExpandoFields();
                }
                return clientQueryInternal;
            }
        }

        internal ClientObjectCollection ParentCollection
        {
            get
            {
                return this.m_parentCollection;
            }
            set
            {
                this.m_parentCollection = value;
            }
        }

        [PseudoRemote]
        public bool? ServerObjectIsNull
        {
            get
            {
                if (this.m_setAsNull)
                {
                    return new bool?(true);
                }
                ObjectPath path = this.Path;
                if (path == null)
                {
                    return new bool?(false);
                }
                return path.ServerObjectIsNull;
            }
        }

        public ClientObject TypedObject
        {
            get
            {
                if (this.ObjectData.TypedObject == null)
                {
                    return this;
                }
                return this.ObjectData.TypedObject;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ClientObject(ClientRuntimeContext context, ObjectPath objectPath)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.m_context = context;
            this.m_objectData = new ClientObjectData();
            this.m_objectData.Path = objectPath;
        }

        protected void CheckUninitializedProperty(string propName)
        {
            if (this.ServerObjectIsNull.HasValue && this.ServerObjectIsNull.Value)
            {
                if (this.Path != null && !string.IsNullOrEmpty(this.Path.ObjectName))
                {
                    throw new ServerObjectNullReferenceException(Resources.GetString("NamedServerObjectIsNull", new object[]
                    {
                        this.Path.ObjectName
                    }));
                }
                throw new ServerObjectNullReferenceException();
            }
            else
            {
                if (!this.m_objectData.Properties.ContainsKey(propName))
                {
                    throw new PropertyOrFieldNotInitializedException(Resources.GetString("NamedPropertyHasNotBeenInitialized", new object[]
                    {
                        propName
                    }));
                }
                return;
            }
        }

        internal void SetObjectDataFrom(ClientObject otherObject)
        {
            this.m_objectData = otherObject.m_objectData;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void FromJson(JsonReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.PeekTokenType() == JsonTokenType.Null)
            {
                this.SetAsNull();
                reader.ReadObject();
                return;
            }
            reader.ReadObjectStart();
            while (reader.PeekTokenType() != JsonTokenType.ObjectEnd)
            {
                string text = reader.PeekName();
                if (!this.InitOnePropertyFromJson(text, reader))
                {
                    if (text == "_ObjectType_")
                    {
                        reader.ReadName();
                        reader.ReadObject();
                    }
                    else if (text == "_ObjectIdentity_")
                    {
                        reader.ReadName();
                        string identity = reader.ReadString();
                        ObjectPath objectPath = new ObjectPathIdentity(this.Context, identity);
                        if (this.m_objectData.Path != null)
                        {
                            objectPath.Id = this.m_objectData.Path.Id;
                        }
                        this.m_objectData.Path = objectPath;
                        objectPath.ServerObjectIsNull = new bool?(false);
                        this.Context.AddObjectPath(objectPath);
                    }
                    else if (text == "_ObjectVersion_")
                    {
                        reader.ReadName();
                        string version = reader.ReadString();
                        this.m_objectData.Version = version;
                    }
                    else
                    {
                        this.InitNonPropertyFieldFromJson(text, reader);
                    }
                }
            }
            reader.ReadObjectEnd();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool CustomFromJson(JsonReader reader)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            return false;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void InitNonPropertyFieldFromJson(string peekedName, JsonReader reader)
        {
            reader.ReadName();
            reader.ReadObject();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Retrieve()
        {
            this.Query.SelectAllProperties();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Retrieve(params string[] propertyNames)
        {
            ClientQueryInternal query = this.Query;
            if (propertyNames == null)
            {
                return;
            }
            for (int i = 0; i < propertyNames.Length; i++)
            {
                string propertyName = propertyNames[i];
                query.Select(propertyName);
            }
        }

        public virtual void RefreshLoad()
        {
            ClientQueryInternal query = this.Query;
            this.SelectExistingScalarProperties(query);
        }

        public bool IsPropertyAvailable(string propertyName)
        {
            return this.m_objectData.Properties.ContainsKey(propertyName);
        }

        public bool IsObjectPropertyInstantiated(string propertyName)
        {
            return this.m_objectData.ClientObjectProperties.ContainsKey(propertyName);
        }

        private void SelectExistingScalarProperties(ClientQueryInternal query)
        {
            foreach (string current in this.m_objectData.Properties.Keys)
            {
                query.Select(current);
            }
        }

        protected virtual void LoadExpandoFields()
        {
        }

        internal virtual void CleanupQuery()
        {
            this.m_objectData.Query = null;
        }

        protected void RemoveFromParentCollection()
        {
            if (this.m_parentCollection != null)
            {
                this.m_parentCollection.RemoveChild(this);
            }
        }

        internal void SetAsNull()
        {
            this.m_setAsNull = true;
        }

        protected internal void UpdateClientObjectPropertyType(string propertyName, object propertyValue, JsonReader reader)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw ClientUtility.CreateArgumentNullException("propertyName");
            }
            if (propertyValue == null)
            {
                throw ClientUtility.CreateArgumentNullException("propertyValue");
            }
            if (reader == null)
            {
                throw ClientUtility.CreateArgumentNullException("reader");
            }
            ClientObject clientObject = propertyValue as ClientObject;
            if (clientObject == null)
            {
                throw ClientUtility.CreateArgumentException("propertyValue");
            }
            if (!this.ObjectData.ClientObjectProperties.ContainsKey(propertyName))
            {
                throw ClientUtility.CreateArgumentException("propertyName");
            }
            string scriptType;
            if (reader.PeekTokenType() == JsonTokenType.ObjectStart && reader.PeekObjectType(out scriptType))
            {
                Type typeFromScriptType = ScriptTypeMap.GetTypeFromScriptType(scriptType);
                //Edited for .NET Core
                //if (typeFromScriptType != null && typeFromScriptType != propertyValue.GetType() && propertyValue.GetType().IsAssignableFrom(typeFromScriptType))
                if (typeFromScriptType != null && typeFromScriptType != propertyValue.GetType())
                {
                    ClientObject clientObject2 = ScriptTypeMap.CreateObjectFromScriptType(scriptType, this.Context) as ClientObject;
                    if (clientObject2 != null)
                    {
                        clientObject.SetTypedObject(clientObject2);
                        this.ObjectData.ClientObjectProperties[propertyName] = clientObject2;
                    }
                }
            }
        }

        internal void SetTypedObject(ClientObject typedObject)
        {
            this.ObjectData.TypedObject = typedObject;
            if (this.ObjectData.AssociatedObject != null)
            {
                this.ObjectData.AssociatedObject = typedObject;
            }
            typedObject.SetObjectDataFrom(this);
        }
    }
}
