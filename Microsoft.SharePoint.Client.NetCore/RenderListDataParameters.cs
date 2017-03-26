using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RenderListDataParameters", ValueObject = true, ServerTypeId = "{ae2d69b3-12fa-4ecb-ba76-bba24d51e83d}")]
    public class RenderListDataParameters : ClientValueObject
    {
        private bool m_allowMultipleValueFilterForTaxonomyFields;

        private bool m_datesInUtc;

        private bool m_expandFilteredByGroup;

        private bool m_expandGroups;

        private bool m_firstGroupOnly;

        private string m_folderServerRelativeUrl;

        private string m_imageFieldsToTryRewriteToCdnUrls;

        private string m_overrideViewXml;

        private string m_paging;

        private RenderListDataOptions m_renderOptions;

        private bool m_replaceGroup;

        private string m_viewXml;

        [Remote]
        public bool AllowMultipleValueFilterForTaxonomyFields
        {
            get
            {
                return this.m_allowMultipleValueFilterForTaxonomyFields;
            }
            set
            {
                this.m_allowMultipleValueFilterForTaxonomyFields = value;
            }
        }

        [Remote]
        public bool DatesInUtc
        {
            get
            {
                return this.m_datesInUtc;
            }
            set
            {
                this.m_datesInUtc = value;
            }
        }

        [Remote]
        public bool ExpandFilteredByGroup
        {
            get
            {
                return this.m_expandFilteredByGroup;
            }
            set
            {
                this.m_expandFilteredByGroup = value;
            }
        }

        [Remote]
        public bool ExpandGroups
        {
            get
            {
                return this.m_expandGroups;
            }
            set
            {
                this.m_expandGroups = value;
            }
        }

        [Remote]
        public bool FirstGroupOnly
        {
            get
            {
                return this.m_firstGroupOnly;
            }
            set
            {
                this.m_firstGroupOnly = value;
            }
        }

        [Remote]
        public string FolderServerRelativeUrl
        {
            get
            {
                return this.m_folderServerRelativeUrl;
            }
            set
            {
                this.m_folderServerRelativeUrl = value;
            }
        }

        [Remote]
        public string ImageFieldsToTryRewriteToCdnUrls
        {
            get
            {
                return this.m_imageFieldsToTryRewriteToCdnUrls;
            }
            set
            {
                this.m_imageFieldsToTryRewriteToCdnUrls = value;
            }
        }

        [Remote]
        public string OverrideViewXml
        {
            get
            {
                return this.m_overrideViewXml;
            }
            set
            {
                this.m_overrideViewXml = value;
            }
        }

        [Remote]
        public string Paging
        {
            get
            {
                return this.m_paging;
            }
            set
            {
                this.m_paging = value;
            }
        }

        [Remote]
        public RenderListDataOptions RenderOptions
        {
            get
            {
                return this.m_renderOptions;
            }
            set
            {
                this.m_renderOptions = value;
            }
        }

        [Remote]
        public bool ReplaceGroup
        {
            get
            {
                return this.m_replaceGroup;
            }
            set
            {
                this.m_replaceGroup = value;
            }
        }

        [Remote]
        public string ViewXml
        {
            get
            {
                return this.m_viewXml;
            }
            set
            {
                this.m_viewXml = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{ae2d69b3-12fa-4ecb-ba76-bba24d51e83d}";
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
            writer.WriteAttributeString("Name", "AllowMultipleValueFilterForTaxonomyFields");
            DataConvert.WriteValueToXmlElement(writer, this.AllowMultipleValueFilterForTaxonomyFields, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "DatesInUtc");
            DataConvert.WriteValueToXmlElement(writer, this.DatesInUtc, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ExpandFilteredByGroup");
            DataConvert.WriteValueToXmlElement(writer, this.ExpandFilteredByGroup, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ExpandGroups");
            DataConvert.WriteValueToXmlElement(writer, this.ExpandGroups, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FirstGroupOnly");
            DataConvert.WriteValueToXmlElement(writer, this.FirstGroupOnly, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FolderServerRelativeUrl");
            DataConvert.WriteValueToXmlElement(writer, this.FolderServerRelativeUrl, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ImageFieldsToTryRewriteToCdnUrls");
            DataConvert.WriteValueToXmlElement(writer, this.ImageFieldsToTryRewriteToCdnUrls, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "OverrideViewXml");
            DataConvert.WriteValueToXmlElement(writer, this.OverrideViewXml, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Paging");
            DataConvert.WriteValueToXmlElement(writer, this.Paging, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RenderOptions");
            DataConvert.WriteValueToXmlElement(writer, this.RenderOptions, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ReplaceGroup");
            DataConvert.WriteValueToXmlElement(writer, this.ReplaceGroup, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewXml");
            DataConvert.WriteValueToXmlElement(writer, this.ViewXml, serializationContext);
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
                case "AllowMultipleValueFilterForTaxonomyFields":
                    flag = true;
                    reader.ReadName();
                    this.m_allowMultipleValueFilterForTaxonomyFields = reader.ReadBoolean();
                    break;
                case "DatesInUtc":
                    flag = true;
                    reader.ReadName();
                    this.m_datesInUtc = reader.ReadBoolean();
                    break;
                case "ExpandFilteredByGroup":
                    flag = true;
                    reader.ReadName();
                    this.m_expandFilteredByGroup = reader.ReadBoolean();
                    break;
                case "ExpandGroups":
                    flag = true;
                    reader.ReadName();
                    this.m_expandGroups = reader.ReadBoolean();
                    break;
                case "FirstGroupOnly":
                    flag = true;
                    reader.ReadName();
                    this.m_firstGroupOnly = reader.ReadBoolean();
                    break;
                case "FolderServerRelativeUrl":
                    flag = true;
                    reader.ReadName();
                    this.m_folderServerRelativeUrl = reader.ReadString();
                    break;
                case "ImageFieldsToTryRewriteToCdnUrls":
                    flag = true;
                    reader.ReadName();
                    this.m_imageFieldsToTryRewriteToCdnUrls = reader.ReadString();
                    break;
                case "OverrideViewXml":
                    flag = true;
                    reader.ReadName();
                    this.m_overrideViewXml = reader.ReadString();
                    break;
                case "Paging":
                    flag = true;
                    reader.ReadName();
                    this.m_paging = reader.ReadString();
                    break;
                case "RenderOptions":
                    flag = true;
                    reader.ReadName();
                    this.m_renderOptions = reader.ReadEnum<RenderListDataOptions>();
                    break;
                case "ReplaceGroup":
                    flag = true;
                    reader.ReadName();
                    this.m_replaceGroup = reader.ReadBoolean();
                    break;
                case "ViewXml":
                    flag = true;
                    reader.ReadName();
                    this.m_viewXml = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}
