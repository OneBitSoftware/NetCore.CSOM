using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ContentTypeCreationInformation", ValueObject = true, ServerTypeId = "{168f3091-4554-4f14-8866-b20d48e45b54}")]
    public class ContentTypeCreationInformation : ClientValueObject
    {
        private string m_description;

        private string m_group;

        private string m_id;

        private string m_name;

        private ContentType m_parentContentType;

        [Remote]
        public string Description
        {
            get
            {
                return this.m_description;
            }
            set
            {
                this.m_description = value;
            }
        }

        [Remote]
        public string Group
        {
            get
            {
                return this.m_group;
            }
            set
            {
                this.m_group = value;
            }
        }

        [Remote]
        public string Id
        {
            get
            {
                return this.m_id;
            }
            set
            {
                this.m_id = value;
            }
        }

        [Remote]
        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        [Remote]
        public ContentType ParentContentType
        {
            get
            {
                return this.m_parentContentType;
            }
            set
            {
                this.m_parentContentType = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{168f3091-4554-4f14-8866-b20d48e45b54}";
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
            writer.WriteAttributeString("Name", "Description");
            DataConvert.WriteValueToXmlElement(writer, this.Description, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Group");
            DataConvert.WriteValueToXmlElement(writer, this.Group, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Id");
            DataConvert.WriteValueToXmlElement(writer, this.Id, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Name");
            DataConvert.WriteValueToXmlElement(writer, this.Name, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ParentContentType");
            DataConvert.WriteValueToXmlElement(writer, this.ParentContentType, serializationContext);
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
                if (!(peekedName == "Description"))
                {
                    if (!(peekedName == "Group"))
                    {
                        if (!(peekedName == "Id"))
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
                            this.m_id = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_group = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_description = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
