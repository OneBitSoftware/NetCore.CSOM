using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ClientQueryInternal : ClientAction, IEquatable<ClientQueryInternal>
    {
        private ClientQueryInternal m_rootQuery;

        private ClientRuntimeContext m_context;

        private ClientQueryInternal m_childItemQuery;

        private bool m_isChildItemQuery;

        private Dictionary<string, ClientQueryProperty> m_properties = new Dictionary<string, ClientQueryProperty>();

        private bool m_selectAllProperties;

        private List<ClientQueryInternal> m_subQueries = new List<ClientQueryInternal>();

        private ChunkStringBuilder m_childItemFilterSb;

        private SerializationContext m_childItemFilterSerializationContext;

        internal ClientRuntimeContext Context
        {
            get
            {
                return this.m_context;
            }
        }

        internal ClientQueryInternal RootQuery
        {
            get
            {
                return this.m_rootQuery;
            }
        }

        public bool IsChildItemQuery
        {
            get
            {
                return this.m_isChildItemQuery;
            }
        }

        internal bool HasChildItemQuery
        {
            get
            {
                return this.m_childItemQuery != null;
            }
        }

        public ClientQueryInternal ChildItemQuery
        {
            get
            {
                if (this.m_childItemQuery == null)
                {
                    this.m_childItemQuery = new ClientQueryInternal(null, "_Child_Items_", true, this);
                    this.m_childItemQuery.SetIsChildItemQuery();
                }
                return this.m_childItemQuery;
            }
        }

        internal bool ChildItemFilterSet
        {
            get
            {
                return this.m_childItemFilterSb != null;
            }
        }

        internal SerializationContext ChildItemExpressionSerializationContext
        {
            get
            {
                if (this.m_childItemFilterSerializationContext == null)
                {
                    this.m_childItemFilterSerializationContext = new SerializationContext(this.Context);
                }
                return this.m_childItemFilterSerializationContext;
            }
        }

        public ClientQueryInternal(ClientObject obj, string name, bool subQuery, ClientQueryInternal parentQuery) : base(ClientQueryInternal.GetContext(obj, parentQuery), subQuery ? null : obj.Path, name)
        {
            if (!subQuery && (obj.Path == null || !obj.Path.IsValid))
            {
                throw new ClientRequestException(Resources.GetString("NoObjectPathAssociatedWithObject"));
            }
            if (subQuery)
            {
                if (parentQuery == null)
                {
                    throw new ArgumentNullException("parentQuery");
                }
                this.m_rootQuery = parentQuery.RootQuery;
                this.m_context = parentQuery.Context;
                return;
            }
            else
            {
                if (obj == null)
                {
                    throw new ArgumentNullException("obj");
                }
                this.m_rootQuery = this;
                this.m_context = obj.Context;
                return;
            }
        }

        private static ClientRuntimeContext GetContext(ClientObject obj, ClientQueryInternal parentQuery)
        {
            if (obj != null)
            {
                return obj.Context;
            }
            if (parentQuery != null)
            {
                return parentQuery.Context;
            }
            throw new ArgumentNullException("parentQuery");
        }

        internal void SetIsChildItemQuery()
        {
            this.m_isChildItemQuery = true;
        }

        public ClientQueryInternal Select(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("propertyName", Resources.GetString("RequestEmptyQueryName"));
            }
            ClientQueryProperty clientQueryProperty = null;
            if (!this.m_properties.TryGetValue(propertyName, out clientQueryProperty))
            {
                clientQueryProperty = new ClientQueryProperty();
                this.m_properties[propertyName] = clientQueryProperty;
            }
            if (clientQueryProperty.Query != null)
            {
                throw new ArgumentOutOfRangeException("propertyName");
            }
            clientQueryProperty.ScalarProperty = true;
            clientQueryProperty.ScalarPropertySet = true;
            return this;
        }

        public ClientQueryInternal SelectWithAll(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentException("propertyName", Resources.GetString("RequestEmptyQueryName"));
            }
            ClientQueryProperty clientQueryProperty = null;
            if (!this.m_properties.TryGetValue(propertyName, out clientQueryProperty))
            {
                clientQueryProperty = new ClientQueryProperty();
                this.m_properties[propertyName] = clientQueryProperty;
            }
            clientQueryProperty.SelectAll = true;
            clientQueryProperty.SelectAllSet = true;
            return this;
        }

        public ClientQueryInternal SelectAllProperties()
        {
            this.m_selectAllProperties = true;
            return this;
        }

        public ClientQueryInternal SelectSubQuery(ClientQueryInternal subQuery)
        {
            if (string.IsNullOrEmpty(subQuery.Name))
            {
                throw new ArgumentException("subQuery", Resources.GetString("RequestEmptyQueryName"));
            }
            ClientQueryProperty clientQueryProperty = null;
            if (this.m_properties.TryGetValue(subQuery.Name, out clientQueryProperty))
            {
                if (clientQueryProperty.ScalarPropertySet && clientQueryProperty.ScalarProperty)
                {
                    throw ClientUtility.CreateArgumentException("subQuery");
                }
                if (clientQueryProperty.Query != null && clientQueryProperty.Query != subQuery)
                {
                    throw ClientUtility.CreateArgumentException("subQuery");
                }
                clientQueryProperty.Query = subQuery;
            }
            else
            {
                clientQueryProperty = new ClientQueryProperty();
                clientQueryProperty.Query = subQuery;
                this.m_properties[subQuery.Name] = clientQueryProperty;
            }
            return this;
        }

        internal ClientQueryInternal GetSubQuery(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }
            ClientQueryProperty clientQueryProperty = null;
            if (this.m_properties.TryGetValue(name, out clientQueryProperty))
            {
                return clientQueryProperty.Query;
            }
            return null;
        }

        internal ClientQueryInternal ChildItemFilterExpression(ChunkStringBuilder childItemFilterExpression)
        {
            if (!this.m_isChildItemQuery)
            {
                throw new InvalidOperationException();
            }
            if (childItemFilterExpression == null)
            {
                throw new ArgumentOutOfRangeException("childItemFilterExpression");
            }
            if (this.m_childItemFilterSb != null)
            {
                throw new InvalidQueryExpressionException();
            }
            this.m_childItemFilterSb = childItemFilterExpression;
            return this;
        }

        internal void WriteInnerXmlTo(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("Query");
            this.WriteInnerXmlCoreTo(writer, serializationContext);
            writer.WriteEndElement();
            if (this.m_childItemQuery != null)
            {
                writer.WriteStartElement("ChildItemQuery");
                this.m_childItemQuery.WriteInnerXmlCoreTo(writer, serializationContext);
                writer.WriteEndElement();
            }
        }

        internal void WriteInnerXmlCoreTo(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteAttributeString("SelectAllProperties", this.m_selectAllProperties ? "true" : "false");
            writer.WriteStartElement("Properties");
            foreach (string current in this.m_properties.Keys)
            {
                ClientQueryProperty clientQueryProperty = this.m_properties[current];
                writer.WriteStartElement("Property");
                writer.WriteAttributeString("Name", current);
                if (clientQueryProperty.ScalarPropertySet)
                {
                    writer.WriteAttributeString("ScalarProperty", clientQueryProperty.ScalarProperty ? "true" : "false");
                }
                if (clientQueryProperty.SelectAllSet)
                {
                    writer.WriteAttributeString("SelectAll", clientQueryProperty.SelectAll ? "true" : "false");
                }
                if (clientQueryProperty.Query != null)
                {
                    clientQueryProperty.Query.WriteInnerXmlTo(writer, serializationContext);
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
            if (this.m_isChildItemQuery && this.m_childItemFilterSb != null)
            {
                writer.WriteStartElement("QueryableExpression");
                this.m_childItemFilterSb.WriteContentAsRawXml(writer);
                writer.WriteEndElement();
                if (this.m_childItemFilterSerializationContext != null)
                {
                    serializationContext.MergeFrom(this.m_childItemFilterSerializationContext);
                }
            }
        }

        internal static void WriteFilterExpressionToXml(XmlWriter writer, SerializationContext serializationContext, LambdaExpression childItemFilterExpression)
        {
            writer.WriteStartElement("Test");
            writer.WriteStartElement("Parameters");
            writer.WriteStartElement("Parameter");
            writer.WriteAttributeString("Name", childItemFilterExpression.Parameters[0].Name);
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteStartElement("Body");
            Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
            dictionary.Add(childItemFilterExpression.Parameters[0].Name, childItemFilterExpression.Parameters[0].Type);
            Expression body = childItemFilterExpression.Body;
            ConditionalExpressionToXmlConverter conditionalExpressionToXmlConverter = new ConditionalExpressionToXmlConverter(body, writer, dictionary, serializationContext);
            conditionalExpressionToXmlConverter.Convert();
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        public override int GetHashCode()
        {
            return base.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            ClientQueryInternal query = obj as ClientQueryInternal;
            return this.Equals(query);
        }

        public bool Equals(ClientQueryInternal query)
        {
            return query != null && base.Id == query.Id;
        }

        internal override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("Query");
            writer.WriteAttributeString("Id", base.Id.ToString());
            writer.WriteAttributeString("ObjectPathId", base.Path.Id.ToString());
            serializationContext.AddObjectPath(base.Path);
            this.WriteInnerXmlTo(writer, serializationContext);
            writer.WriteEndElement();
        }
    }
}
