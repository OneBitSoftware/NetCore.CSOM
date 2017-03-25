using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.UserCreationInformation", ValueObject = true, ServerTypeId = "{6ecd8af6-bed3-4a74-be76-1ec981b350e1}")]
    public class UserCreationInformation : ClientValueObject
    {
        private string m_email;

        private string m_loginName;

        private string m_title;

        [Remote]
        public string Email
        {
            get
            {
                return this.m_email;
            }
            set
            {
                this.m_email = value;
            }
        }

        [Remote]
        public string LoginName
        {
            get
            {
                return this.m_loginName;
            }
            set
            {
                this.m_loginName = value;
            }
        }

        [Remote]
        public string Title
        {
            get
            {
                return this.m_title;
            }
            set
            {
                this.m_title = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{6ecd8af6-bed3-4a74-be76-1ec981b350e1}";
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
            writer.WriteAttributeString("Name", "LoginName");
            DataConvert.WriteValueToXmlElement(writer, this.LoginName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Title");
            DataConvert.WriteValueToXmlElement(writer, this.Title, serializationContext);
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
                    if (!(peekedName == "LoginName"))
                    {
                        if (peekedName == "Title")
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_title = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_loginName = reader.ReadString();
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
