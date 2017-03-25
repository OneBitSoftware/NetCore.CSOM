using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public abstract class ClientValueObjectCollection<T> : ClientValueObject, IEnumerable<T>, IEnumerable
    {
        private List<T> m_data;

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual string ChildItemsName
        {
            get
            {
                return null;
            }
        }

        public int Count
        {
            get
            {
                if (this.m_data == null)
                {
                    return 0;
                }
                return this.m_data.Count;
            }
        }

        public T this[int index]
        {
            get
            {
                if (this.m_data == null || index < 0 || index >= this.m_data.Count)
                {
                    throw new ArgumentOutOfRangeException("index");
                }
                return this.m_data[index];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            if (peekedName == "_Child_Items_" || (this.ChildItemsName != null && peekedName == this.ChildItemsName))
            {
                reader.ReadName();
                this.m_data = reader.ReadList<T>();
                return true;
            }
            return base.InitOnePropertyFromJson(peekedName, reader);
        }

        public void Add(T item)
        {
            if (this.m_data == null)
            {
                this.m_data = new List<T>();
            }
            this.m_data.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.m_data != null)
            {
                foreach (T current in this.m_data)
                {
                    yield return current;
                }
            }
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            if (this.m_data != null)
            {
                writer.WriteStartElement("Property");
                writer.WriteAttributeString("Name", "_Child_Items_");
                writer.WriteAttributeString("Type", "Array");
                foreach (T current in this.m_data)
                {
                    writer.WriteStartElement("Object");
                    DataConvert.WriteValueToXmlElement(writer, current, serializationContext);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            base.WriteToXml(writer, serializationContext);
        }
    }
}
