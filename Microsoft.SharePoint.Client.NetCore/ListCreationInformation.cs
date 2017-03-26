using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListCreationInformation", ValueObject = true, ServerTypeId = "{e247b7fc-095e-4ea4-a4c9-c5d373723d8c}")]
    public class ListCreationInformation : ClientValueObject
    {
        private string m_customSchemaXml;

        private IDictionary<string, string> m_dataSourceProperties;

        private string m_description;

        private int m_documentTemplateType;

        private ListTemplate m_listTemplate;

        private QuickLaunchOptions m_quickLaunchOption;

        private Guid m_templateFeatureId;

        private int m_templateType;

        private string m_title;

        private string m_url;

        [Remote]
        public string CustomSchemaXml
        {
            get
            {
                return this.m_customSchemaXml;
            }
            set
            {
                this.m_customSchemaXml = value;
            }
        }

        [Remote]
        public IDictionary<string, string> DataSourceProperties
        {
            get
            {
                return this.m_dataSourceProperties;
            }
            set
            {
                this.m_dataSourceProperties = value;
            }
        }

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
        public int DocumentTemplateType
        {
            get
            {
                return this.m_documentTemplateType;
            }
            set
            {
                this.m_documentTemplateType = value;
            }
        }

        [Remote]
        public ListTemplate ListTemplate
        {
            get
            {
                return this.m_listTemplate;
            }
            set
            {
                this.m_listTemplate = value;
            }
        }

        [Remote]
        public QuickLaunchOptions QuickLaunchOption
        {
            get
            {
                return this.m_quickLaunchOption;
            }
            set
            {
                this.m_quickLaunchOption = value;
            }
        }

        [Remote]
        public Guid TemplateFeatureId
        {
            get
            {
                return this.m_templateFeatureId;
            }
            set
            {
                this.m_templateFeatureId = value;
            }
        }

        [Remote]
        public int TemplateType
        {
            get
            {
                return this.m_templateType;
            }
            set
            {
                this.m_templateType = value;
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
        public string Url
        {
            get
            {
                return this.m_url;
            }
            set
            {
                this.m_url = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{e247b7fc-095e-4ea4-a4c9-c5d373723d8c}";
            }
        }

        public ListCreationInformation()
        {
            this.m_dataSourceProperties = new Dictionary<string, string>();
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
            writer.WriteAttributeString("Name", "CustomSchemaXml");
            DataConvert.WriteValueToXmlElement(writer, this.CustomSchemaXml, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "DataSourceProperties");
            DataConvert.WriteValueToXmlElement(writer, this.DataSourceProperties, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Description");
            DataConvert.WriteValueToXmlElement(writer, this.Description, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "DocumentTemplateType");
            DataConvert.WriteValueToXmlElement(writer, this.DocumentTemplateType, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ListTemplate");
            DataConvert.WriteValueToXmlElement(writer, this.ListTemplate, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "QuickLaunchOption");
            DataConvert.WriteValueToXmlElement(writer, this.QuickLaunchOption, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "TemplateFeatureId");
            DataConvert.WriteValueToXmlElement(writer, this.TemplateFeatureId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "TemplateType");
            DataConvert.WriteValueToXmlElement(writer, this.TemplateType, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Title");
            DataConvert.WriteValueToXmlElement(writer, this.Title, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Url");
            DataConvert.WriteValueToXmlElement(writer, this.Url, serializationContext);
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
                case "CustomSchemaXml":
                    flag = true;
                    reader.ReadName();
                    this.m_customSchemaXml = reader.ReadString();
                    break;
                case "DataSourceProperties":
                    flag = true;
                    reader.ReadName();
                    this.m_dataSourceProperties = reader.ReadDictionary<string>();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    this.m_description = reader.ReadString();
                    break;
                case "DocumentTemplateType":
                    flag = true;
                    reader.ReadName();
                    this.m_documentTemplateType = reader.ReadInt32();
                    break;
                case "QuickLaunchOption":
                    flag = true;
                    reader.ReadName();
                    this.m_quickLaunchOption = reader.ReadEnum<QuickLaunchOptions>();
                    break;
                case "TemplateFeatureId":
                    flag = true;
                    reader.ReadName();
                    this.m_templateFeatureId = reader.ReadGuid();
                    break;
                case "TemplateType":
                    flag = true;
                    reader.ReadName();
                    this.m_templateType = reader.ReadInt32();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    this.m_title = reader.ReadString();
                    break;
                case "Url":
                    flag = true;
                    reader.ReadName();
                    this.m_url = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}