using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.AppViewCreationInfo", ValueObject = true, ServerTypeId = "{52a8011d-98c5-466f-9cde-2e5ef9cc811b}")]
    public class AppViewCreationInfo : ClientValueObject
    {
        private Guid m_appId;

        private bool m_isPrivate;

        private string m_title;

        [Remote]
        public Guid AppId
        {
            get
            {
                return this.m_appId;
            }
            set
            {
                this.m_appId = value;
            }
        }

        [Remote]
        public bool IsPrivate
        {
            get
            {
                return this.m_isPrivate;
            }
            set
            {
                this.m_isPrivate = value;
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
                return "{52a8011d-98c5-466f-9cde-2e5ef9cc811b}";
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
            writer.WriteAttributeString("Name", "AppId");
            DataConvert.WriteValueToXmlElement(writer, this.AppId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "IsPrivate");
            DataConvert.WriteValueToXmlElement(writer, this.IsPrivate, serializationContext);
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
                if (!(peekedName == "AppId"))
                {
                    if (!(peekedName == "IsPrivate"))
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
                        this.m_isPrivate = reader.ReadBoolean();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_appId = reader.ReadGuid();
                }
            }
            return flag;
        }
    }
}
