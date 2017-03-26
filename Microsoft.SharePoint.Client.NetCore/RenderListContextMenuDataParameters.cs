using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RenderListContextMenuDataParameters", ValueObject = true, ServerTypeId = "{775a72c4-6d8f-457f-ad76-d2779ca29921}")]
    public class RenderListContextMenuDataParameters : ClientValueObject
    {
        private string m_cascDelWarnMessage;

        private string m_customAction;

        private string m_field;

        private string m_iD;

        private string m_inplaceFullListSearch;

        private string m_inplaceSearchQuery;

        private string m_isCSR;

        private string m_isXslView;

        private string m_itemId;

        private string m_listViewPageUrl;

        private string m_overrideScope;

        private string m_rootFolder;

        private string m_view;

        private string m_viewCount;

        [Remote]
        public string CascDelWarnMessage
        {
            get
            {
                return this.m_cascDelWarnMessage;
            }
            set
            {
                this.m_cascDelWarnMessage = value;
            }
        }

        [Remote]
        public string CustomAction
        {
            get
            {
                return this.m_customAction;
            }
            set
            {
                this.m_customAction = value;
            }
        }

        [Remote]
        public string Field
        {
            get
            {
                return this.m_field;
            }
            set
            {
                this.m_field = value;
            }
        }

        [Remote]
        public string ID
        {
            get
            {
                return this.m_iD;
            }
            set
            {
                this.m_iD = value;
            }
        }

        [Remote]
        public string InplaceFullListSearch
        {
            get
            {
                return this.m_inplaceFullListSearch;
            }
            set
            {
                this.m_inplaceFullListSearch = value;
            }
        }

        [Remote]
        public string InplaceSearchQuery
        {
            get
            {
                return this.m_inplaceSearchQuery;
            }
            set
            {
                this.m_inplaceSearchQuery = value;
            }
        }

        [Remote]
        public string IsCSR
        {
            get
            {
                return this.m_isCSR;
            }
            set
            {
                this.m_isCSR = value;
            }
        }

        [Remote]
        public string IsXslView
        {
            get
            {
                return this.m_isXslView;
            }
            set
            {
                this.m_isXslView = value;
            }
        }

        [Remote]
        public string ItemId
        {
            get
            {
                return this.m_itemId;
            }
            set
            {
                this.m_itemId = value;
            }
        }

        [Remote]
        public string ListViewPageUrl
        {
            get
            {
                return this.m_listViewPageUrl;
            }
            set
            {
                this.m_listViewPageUrl = value;
            }
        }

        [Remote]
        public string OverrideScope
        {
            get
            {
                return this.m_overrideScope;
            }
            set
            {
                this.m_overrideScope = value;
            }
        }

        [Remote]
        public string RootFolder
        {
            get
            {
                return this.m_rootFolder;
            }
            set
            {
                this.m_rootFolder = value;
            }
        }

        [Remote]
        public string View
        {
            get
            {
                return this.m_view;
            }
            set
            {
                this.m_view = value;
            }
        }

        [Remote]
        public string ViewCount
        {
            get
            {
                return this.m_viewCount;
            }
            set
            {
                this.m_viewCount = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{775a72c4-6d8f-457f-ad76-d2779ca29921}";
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
            writer.WriteAttributeString("Name", "CascDelWarnMessage");
            DataConvert.WriteValueToXmlElement(writer, this.CascDelWarnMessage, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "CustomAction");
            DataConvert.WriteValueToXmlElement(writer, this.CustomAction, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Field");
            DataConvert.WriteValueToXmlElement(writer, this.Field, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ID");
            DataConvert.WriteValueToXmlElement(writer, this.ID, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "InplaceFullListSearch");
            DataConvert.WriteValueToXmlElement(writer, this.InplaceFullListSearch, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "InplaceSearchQuery");
            DataConvert.WriteValueToXmlElement(writer, this.InplaceSearchQuery, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "IsCSR");
            DataConvert.WriteValueToXmlElement(writer, this.IsCSR, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "IsXslView");
            DataConvert.WriteValueToXmlElement(writer, this.IsXslView, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ItemId");
            DataConvert.WriteValueToXmlElement(writer, this.ItemId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ListViewPageUrl");
            DataConvert.WriteValueToXmlElement(writer, this.ListViewPageUrl, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "OverrideScope");
            DataConvert.WriteValueToXmlElement(writer, this.OverrideScope, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RootFolder");
            DataConvert.WriteValueToXmlElement(writer, this.RootFolder, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "View");
            DataConvert.WriteValueToXmlElement(writer, this.View, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewCount");
            DataConvert.WriteValueToXmlElement(writer, this.ViewCount, serializationContext);
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
                case "CascDelWarnMessage":
                    flag = true;
                    reader.ReadName();
                    this.m_cascDelWarnMessage = reader.ReadString();
                    break;
                case "CustomAction":
                    flag = true;
                    reader.ReadName();
                    this.m_customAction = reader.ReadString();
                    break;
                case "Field":
                    flag = true;
                    reader.ReadName();
                    this.m_field = reader.ReadString();
                    break;
                case "ID":
                    flag = true;
                    reader.ReadName();
                    this.m_iD = reader.ReadString();
                    break;
                case "InplaceFullListSearch":
                    flag = true;
                    reader.ReadName();
                    this.m_inplaceFullListSearch = reader.ReadString();
                    break;
                case "InplaceSearchQuery":
                    flag = true;
                    reader.ReadName();
                    this.m_inplaceSearchQuery = reader.ReadString();
                    break;
                case "IsCSR":
                    flag = true;
                    reader.ReadName();
                    this.m_isCSR = reader.ReadString();
                    break;
                case "IsXslView":
                    flag = true;
                    reader.ReadName();
                    this.m_isXslView = reader.ReadString();
                    break;
                case "ItemId":
                    flag = true;
                    reader.ReadName();
                    this.m_itemId = reader.ReadString();
                    break;
                case "ListViewPageUrl":
                    flag = true;
                    reader.ReadName();
                    this.m_listViewPageUrl = reader.ReadString();
                    break;
                case "OverrideScope":
                    flag = true;
                    reader.ReadName();
                    this.m_overrideScope = reader.ReadString();
                    break;
                case "RootFolder":
                    flag = true;
                    reader.ReadName();
                    this.m_rootFolder = reader.ReadString();
                    break;
                case "View":
                    flag = true;
                    reader.ReadName();
                    this.m_view = reader.ReadString();
                    break;
                case "ViewCount":
                    flag = true;
                    reader.ReadName();
                    this.m_viewCount = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}
