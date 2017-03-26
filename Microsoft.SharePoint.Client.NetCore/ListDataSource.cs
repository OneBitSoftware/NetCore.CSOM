using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListDataSource", ValueObject = true, ServerTypeId = "{06bfe4a5-1516-4b55-a6d7-ecbe3ff7a3c8}")]
    public sealed class ListDataSource : ClientValueObject
    {
        private IDictionary<string, string> m_properties;

        [Remote]
        public IDictionary<string, string> Properties
        {
            get
            {
                return this.m_properties;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{06bfe4a5-1516-4b55-a6d7-ecbe3ff7a3c8}";
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (serializationContext == null)
            {
                throw new ArgumentNullException("serializationContext");
            }
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Properties");
            DataConvert.WriteValueToXmlElement(writer, this.Properties, serializationContext);
            writer.WriteEndElement();
            base.WriteToXml(writer, serializationContext);
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            if (peekedName != null && peekedName == "Properties")
            {
                flag = true;
                reader.ReadName();
                this.m_properties = reader.ReadDictionary<string>();
            }
            return flag;
        }
    }
}
