using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ClientObjectPrototype
    {
        private ClientQueryInternal m_query;

        private bool m_childItem;

        private Dictionary<string, ClientObjectPrototype> m_subObjectPrototypes;

        private Dictionary<string, ClientObjectPrototype> m_subObjectCollectionProperties;

        internal ClientQueryInternal Query
        {
            get
            {
                return this.m_query;
            }
        }

        internal bool ChildItemPrototype
        {
            get
            {
                return this.m_childItem;
            }
        }

        internal ClientObjectPrototype(ClientQueryInternal query, bool childItem)
        {
            this.m_query = query;
            this.m_childItem = childItem;
        }

        public void Retrieve()
        {
            if (this.m_childItem)
            {
                this.Query.ChildItemQuery.SelectAllProperties();
                return;
            }
            this.Query.SelectAllProperties();
        }

        public void Retrieve(params string[] propertyNames)
        {
            if (this.m_childItem)
            {
                for (int i = 0; i < propertyNames.Length; i++)
                {
                    string propertyName = propertyNames[i];
                    this.Query.ChildItemQuery.Select(propertyName);
                }
                return;
            }
            for (int j = 0; j < propertyNames.Length; j++)
            {
                string propertyName2 = propertyNames[j];
                this.Query.Select(propertyName2);
            }
        }

        public ClientObjectPrototype<PropertyType> RetrieveObject<PropertyType>(string propertyName)
        {
            if (this.m_subObjectPrototypes == null)
            {
                this.m_subObjectPrototypes = new Dictionary<string, ClientObjectPrototype>();
            }
            ClientObjectPrototype clientObjectPrototype = null;
            if (this.m_subObjectPrototypes.TryGetValue(propertyName, out clientObjectPrototype))
            {
                return (ClientObjectPrototype<PropertyType>)clientObjectPrototype;
            }
            bool flag = false;
            ClientQueryInternal clientQueryInternal;
            if (this.m_childItem)
            {
                clientQueryInternal = this.m_query.ChildItemQuery.GetSubQuery(propertyName);
            }
            else
            {
                clientQueryInternal = this.m_query.GetSubQuery(propertyName);
            }
            if (clientQueryInternal == null)
            {
                clientQueryInternal = new ClientQueryInternal(null, propertyName, true, this.m_query);
                flag = true;
            }
            ClientObjectPrototype<PropertyType> clientObjectPrototype2 = new ClientObjectPrototype<PropertyType>(clientQueryInternal, false);
            if (flag)
            {
                if (this.m_childItem)
                {
                    this.m_query.ChildItemQuery.SelectSubQuery(clientQueryInternal);
                }
                else
                {
                    this.m_query.SelectSubQuery(clientQueryInternal);
                }
            }
            this.m_subObjectPrototypes[propertyName] = clientObjectPrototype2;
            return clientObjectPrototype2;
        }

        public ClientObjectCollectionPrototype<ItemType> RetrieveCollectionObject<ItemType>(string propertyName)
        {
            if (this.m_subObjectCollectionProperties == null)
            {
                this.m_subObjectCollectionProperties = new Dictionary<string, ClientObjectPrototype>();
            }
            ClientObjectPrototype clientObjectPrototype = null;
            if (this.m_subObjectCollectionProperties.TryGetValue(propertyName, out clientObjectPrototype))
            {
                return (ClientObjectCollectionPrototype<ItemType>)clientObjectPrototype;
            }
            bool flag = false;
            ClientQueryInternal clientQueryInternal;
            if (this.m_childItem)
            {
                clientQueryInternal = this.m_query.ChildItemQuery.GetSubQuery(propertyName);
            }
            else
            {
                clientQueryInternal = this.m_query.GetSubQuery(propertyName);
            }
            if (clientQueryInternal == null)
            {
                clientQueryInternal = new ClientQueryInternal(null, propertyName, true, this.m_query);
                flag = true;
            }
            ClientObjectCollectionPrototype<ItemType> clientObjectCollectionPrototype = new ClientObjectCollectionPrototype<ItemType>(clientQueryInternal, false);
            if (flag)
            {
                if (this.m_childItem)
                {
                    this.m_query.ChildItemQuery.SelectSubQuery(clientQueryInternal);
                }
                else
                {
                    this.m_query.SelectSubQuery(clientQueryInternal);
                }
            }
            this.m_subObjectCollectionProperties[propertyName] = clientObjectCollectionPrototype;
            return clientObjectCollectionPrototype;
        }
    }

    public class ClientObjectPrototype<T> : ClientObjectPrototype
    {
        internal ClientObjectPrototype(ClientQueryInternal query, bool childItem) : base(query, childItem)
        {
        }
    }
}
