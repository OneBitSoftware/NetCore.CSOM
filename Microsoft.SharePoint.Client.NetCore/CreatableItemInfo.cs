using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.CreatableItemInfo", ValueObject = true, ServerTypeId = "{e9797d9d-2304-4c12-bc6b-4a4e9d7a0ea6}")]
    public sealed class CreatableItemInfo : ClientValueObject
    {
        private int m_documentTemplate;

        private string m_fileExtension;

        private string m_itemType;

        [Remote]
        public int DocumentTemplate
        {
            get
            {
                return this.m_documentTemplate;
            }
        }

        [Remote]
        public string FileExtension
        {
            get
            {
                return this.m_fileExtension;
            }
        }

        [Remote]
        public string ItemType
        {
            get
            {
                return this.m_itemType;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{e9797d9d-2304-4c12-bc6b-4a4e9d7a0ea6}";
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
            writer.WriteAttributeString("Name", "DocumentTemplate");
            DataConvert.WriteValueToXmlElement(writer, this.DocumentTemplate, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FileExtension");
            DataConvert.WriteValueToXmlElement(writer, this.FileExtension, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ItemType");
            DataConvert.WriteValueToXmlElement(writer, this.ItemType, serializationContext);
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
                if (!(peekedName == "DocumentTemplate"))
                {
                    if (!(peekedName == "FileExtension"))
                    {
                        if (peekedName == "ItemType")
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_itemType = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_fileExtension = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_documentTemplate = reader.ReadInt32();
                }
            }
            return flag;
        }
    }
}
