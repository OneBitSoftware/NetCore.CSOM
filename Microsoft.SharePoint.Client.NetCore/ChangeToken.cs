using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ChangeToken", ValueObject = true, ServerTypeId = "{41c5be82-b5bf-4b5a-9712-97111fb87686}")]
    public sealed class ChangeToken : ClientValueObject
    {
        private string m_stringValue;

        [Remote]
        public string StringValue
        {
            get
            {
                return this.m_stringValue;
            }
            set
            {
                this.m_stringValue = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{41c5be82-b5bf-4b5a-9712-97111fb87686}";
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
            writer.WriteAttributeString("Name", "StringValue");
            DataConvert.WriteValueToXmlElement(writer, this.StringValue, serializationContext);
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
            if (peekedName != null && peekedName == "StringValue")
            {
                flag = true;
                reader.ReadName();
                this.m_stringValue = reader.ReadString();
            }
            return flag;
        }
    }
}
