using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.UserIdInfo", ValueObject = true, ServerTypeId = "{c5c3ae1a-63b6-4f25-a887-54b0b20a28e2}")]
    public class UserIdInfo : ClientValueObject
    {
        private string m_nameId;

        private string m_nameIdIssuer;

        [Remote]
        public string NameId
        {
            get
            {
                return this.m_nameId;
            }
        }

        [Remote]
        public string NameIdIssuer
        {
            get
            {
                return this.m_nameIdIssuer;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{c5c3ae1a-63b6-4f25-a887-54b0b20a28e2}";
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
            writer.WriteAttributeString("Name", "NameId");
            DataConvert.WriteValueToXmlElement(writer, this.NameId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "NameIdIssuer");
            DataConvert.WriteValueToXmlElement(writer, this.NameIdIssuer, serializationContext);
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
            if (peekedName != null)
            {
                if (!(peekedName == "NameId"))
                {
                    if (peekedName == "NameIdIssuer")
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_nameIdIssuer = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_nameId = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
