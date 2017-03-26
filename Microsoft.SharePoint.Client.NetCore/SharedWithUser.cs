using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.SharedWithUser", ValueObject = true, ServerTypeId = "{01d693d9-72c2-4531-9fb9-105c88b6706b}")]
    public sealed class SharedWithUser : ClientValueObject
    {
        private string m_email;

        private string m_name;

        [Remote]
        public string Email
        {
            get
            {
                return this.m_email;
            }
        }

        [Remote]
        public string Name
        {
            get
            {
                return this.m_name;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{01d693d9-72c2-4531-9fb9-105c88b6706b}";
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
            writer.WriteAttributeString("Name", "Email");
            DataConvert.WriteValueToXmlElement(writer, this.Email, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Name");
            DataConvert.WriteValueToXmlElement(writer, this.Name, serializationContext);
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
                if (!(peekedName == "Email"))
                {
                    if (peekedName == "Name")
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_name = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_email = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
