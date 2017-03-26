using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RenderListFilterDataParameters", ValueObject = true, ServerTypeId = "{5932e072-c4e0-4809-b1c9-88077c4df471}")]
    public class RenderListFilterDataParameters : ClientValueObject
    {
        private bool m_excludeFieldFilteringHtml;

        private string m_fieldInternalName;

        private string m_overrideScope;

        private string m_processQStringToCAML;

        private string m_viewId;

        [Remote]
        public bool ExcludeFieldFilteringHtml
        {
            get
            {
                return this.m_excludeFieldFilteringHtml;
            }
            set
            {
                this.m_excludeFieldFilteringHtml = value;
            }
        }

        [Remote]
        public string FieldInternalName
        {
            get
            {
                return this.m_fieldInternalName;
            }
            set
            {
                this.m_fieldInternalName = value;
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
        public string ProcessQStringToCAML
        {
            get
            {
                return this.m_processQStringToCAML;
            }
            set
            {
                this.m_processQStringToCAML = value;
            }
        }

        [Remote]
        public string ViewId
        {
            get
            {
                return this.m_viewId;
            }
            set
            {
                this.m_viewId = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{5932e072-c4e0-4809-b1c9-88077c4df471}";
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
            writer.WriteAttributeString("Name", "ExcludeFieldFilteringHtml");
            DataConvert.WriteValueToXmlElement(writer, this.ExcludeFieldFilteringHtml, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FieldInternalName");
            DataConvert.WriteValueToXmlElement(writer, this.FieldInternalName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "OverrideScope");
            DataConvert.WriteValueToXmlElement(writer, this.OverrideScope, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ProcessQStringToCAML");
            DataConvert.WriteValueToXmlElement(writer, this.ProcessQStringToCAML, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ViewId");
            DataConvert.WriteValueToXmlElement(writer, this.ViewId, serializationContext);
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
                if (!(peekedName == "ExcludeFieldFilteringHtml"))
                {
                    if (!(peekedName == "FieldInternalName"))
                    {
                        if (!(peekedName == "OverrideScope"))
                        {
                            if (!(peekedName == "ProcessQStringToCAML"))
                            {
                                if (peekedName == "ViewId")
                                {
                                    flag = true;
                                    reader.ReadName();
                                    this.m_viewId = reader.ReadString();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_processQStringToCAML = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_overrideScope = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_fieldInternalName = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_excludeFieldFilteringHtml = reader.ReadBoolean();
                }
            }
            return flag;
        }
    }
}
