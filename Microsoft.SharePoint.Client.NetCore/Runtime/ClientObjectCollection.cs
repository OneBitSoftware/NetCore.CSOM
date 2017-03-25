using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public abstract class ClientObjectCollection : ClientObject, IEnumerable
    {
        public bool AreItemsAvailable
        {
            get
            {
                return base.ObjectData.CollectionDataInited;
            }
        }

        public virtual int Count
        {
            get
            {
                this.ThrowIfCollectionNotInited();
                return this.Data.Count;
            }
        }

        private bool DataInited
        {
            get
            {
                return base.ObjectData.CollectionDataInited;
            }
        }

        protected List<object> Data
        {
            get
            {
                return base.ObjectData.CollectionData;
            }
        }

        protected ClientObjectCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            this.ThrowIfCollectionNotInited();
            int count = this.Data.Count;
            for (int i = 0; i < this.Data.Count; i++)
            {
                if (count != this.Data.Count)
                {
                    throw new InvalidOperationException(Resources.GetString("CollectionModified"));
                }
                yield return this.GetItemAtIndex(i);
            }
            yield break;
        }

        protected object GetItemAtIndex(int i)
        {
            return this.Data[i];
        }

        internal void SetDataInited()
        {
            base.ObjectData.CollectionDataInited = true;
        }

        internal void ThrowIfCollectionNotInited()
        {
            if (!this.DataInited)
            {
                throw new CollectionNotInitializedException();
            }
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            if (peekedName == "_Child_Items_")
            {
                reader.ReadName();
                base.ObjectData.CollectionData = new List<object>();
                base.ObjectData.CollectionDataInited = true;
                object[] array = this.ReadChildItems(reader);
                if (array != null)
                {
                    for (int i = 0; i < array.Length; i++)
                    {
                        ClientObject clientObject = array[i] as ClientObject;
                        if (clientObject != null)
                        {
                            clientObject.ParentCollection = this;
                        }
                        base.ObjectData.CollectionData.Add(array[i]);
                    }
                }
                return true;
            }
            return base.InitOnePropertyFromJson(peekedName, reader);
        }

        internal virtual object[] ReadChildItems(JsonReader reader)
        {
            return reader.ReadObjectArray();
        }

        protected void AddChild(ClientObject obj)
        {
            this.Data.Add(obj);
            if (obj.ParentCollection == null)
            {
                obj.ParentCollection = this;
            }
            base.ObjectData.CollectionDataInited = true;
        }

        protected internal void RemoveChild(ClientObject obj)
        {
            if (base.ObjectData.CollectionData == null)
            {
                return;
            }
            ObjectPathIdentity objectPathIdentity = obj.Path as ObjectPathIdentity;
            for (int i = base.ObjectData.CollectionData.Count - 1; i >= 0; i--)
            {
                ClientObject clientObject;
                ObjectPathIdentity objectPathIdentity2;
                if (base.ObjectData.CollectionData[i] == obj)
                {
                    if (((ClientObject)base.ObjectData.CollectionData[i]).ParentCollection == this)
                    {
                        ((ClientObject)base.ObjectData.CollectionData[i]).ParentCollection = null;
                    }
                    base.ObjectData.CollectionData.RemoveAt(i);
                }
                else if (objectPathIdentity != null && (clientObject = (base.ObjectData.CollectionData[i] as ClientObject)) != null && (objectPathIdentity2 = (clientObject.Path as ObjectPathIdentity)) != null && objectPathIdentity.Identity == objectPathIdentity2.Identity)
                {
                    if (((ClientObject)base.ObjectData.CollectionData[i]).ParentCollection == this)
                    {
                        ((ClientObject)base.ObjectData.CollectionData[i]).ParentCollection = null;
                    }
                    base.ObjectData.CollectionData.RemoveAt(i);
                }
            }
        }
    }

    public abstract class ClientObjectCollection<T> : ClientObjectCollection, IQueryable<T>, IEnumerable<T>, IQueryable, IEnumerable
    {
        private ClientObjectPrototype<T> m_itemPrototype;

        public T this[int index]
        {
            get
            {
                base.ThrowIfCollectionNotInited();
                return (T)((object)base.GetItemAtIndex(index));
            }
        }

        public Type ElementType
        {
            get
            {
                return typeof(T);
            }
        }

        public Expression Expression
        {
            get
            {
                return Expression.Constant(this);
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return base.Context.QueryProvider;
            }
        }

        public ClientObjectCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ClientObjectPrototype<T> RetrieveItems()
        {
            if (this.m_itemPrototype == null)
            {
                this.m_itemPrototype = new ClientObjectPrototype<T>(base.Query, true);
            }
            return this.m_itemPrototype;
        }

        public IEnumerator<T> GetEnumerator()
        {
            base.ThrowIfCollectionNotInited();
            int count = this.Count;
            for (int i = 0; i < this.Count; i++)
            {
                if (count != this.Count)
                {
                    throw new InvalidOperationException(Resources.GetString("CollectionModified"));
                }
                yield return (T)((object)base.GetItemAtIndex(i));
            }
            yield break;
        }

        internal override object[] ReadChildItems(JsonReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            return reader.ReadObjectArray(typeof(T));
        }

        internal override void CleanupQuery()
        {
            base.CleanupQuery();
            this.m_itemPrototype = null;
        }
    }
}
