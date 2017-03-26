using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ViewCreationInformation", ValueObject = true, ServerTypeId = "{a3547807-7266-42f3-b055-afa6e840e458}")]
    public class ViewCreationInformation : ClientValueObject
    {
        private bool m_paged;

        private bool m_personalView;

        private string m_query;

        private uint m_rowLimit = 30u;

        private bool m_setAsDefaultView;

        private string m_title;

        private string[] m_viewFields;

        private ViewType m_viewTypeKind;

        [Remote]
        public bool Paged
        {
            get
            {
                return this.m_paged;
            }
            set
            {
                this.m_paged = value;
            }
        }

        [Remote]
        public bool PersonalView
        {
            get
            {
                return this.m_personalView;
            }
            set
            {
                this.m_personalView = value;
            }
        }

        [Remote]
        public string Query
        {
            get
            {
                return this.m_query;
            }
            set
            {
                this.m_query = value;
            }
        }

        [Remote]
        public uint RowLimit
        {
            get
            {
                return this.m_rowLimit;
            }
            set
            {
                this.m_rowLimit = value;
            }
        }

        [Remote]
        public bool SetAsDefaultView
        {
            get
            {
                return this.m_setAsDefaultView;
            }
            set
            {
                this.m_setAsDefaultView = value;
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

        [Remote]
        public string[] ViewFields
        {
            get
            {
                return this.m_viewFields;
            }
            set
            {
                this.m_viewFields = value;
            }
        }

        [Remote]
        public ViewType ViewTypeKind
        {
            get
            {
                return this.m_viewTypeKind;
            }
            set
            {
                this.m_viewTypeKind = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{a3547807-7266-42f3-b055-afa6e840e458}";
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
            writer.WriteAttributeString("Name", "Paged");
            DataConvert.WriteValueToXmlElement(writer, this.Paged, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "PersonalView");
            DataConvert.WriteValueToXmlElement(writer, this.PersonalView, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Query");
            DataConvert.WriteValueToXmlElement(writer, this.Query, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RowLimit");
            DataConvert.WriteValueToXmlElement(writer, this.RowLimit, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SetAsDefaultView");
            DataConvert.WriteValueToXmlElement(writer, this.SetAsDefaultView, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Title");
            DataConvert.WriteValueToXmlElement(writer, this.Title, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewFields");
            DataConvert.WriteValueToXmlElement(writer, this.ViewFields, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewTypeKind");
            DataConvert.WriteValueToXmlElement(writer, this.ViewTypeKind, serializationContext);
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
            switch (peekedName)
            {
                case "Paged":
                    flag = true;
                    reader.ReadName();
                    this.m_paged = reader.ReadBoolean();
                    break;
                case "PersonalView":
                    flag = true;
                    reader.ReadName();
                    this.m_personalView = reader.ReadBoolean();
                    break;
                case "Query":
                    flag = true;
                    reader.ReadName();
                    this.m_query = reader.ReadString();
                    break;
                case "RowLimit":
                    flag = true;
                    reader.ReadName();
                    this.m_rowLimit = reader.ReadUInt32();
                    break;
                case "SetAsDefaultView":
                    flag = true;
                    reader.ReadName();
                    this.m_setAsDefaultView = reader.ReadBoolean();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    this.m_title = reader.ReadString();
                    break;
                case "ViewFields":
                    flag = true;
                    reader.ReadName();
                    this.m_viewFields = reader.ReadStringArray();
                    break;
                case "ViewTypeKind":
                    flag = true;
                    reader.ReadName();
                    this.m_viewTypeKind = reader.ReadEnum<ViewType>();
                    break;
            }
            return flag;
        }
    }
}
