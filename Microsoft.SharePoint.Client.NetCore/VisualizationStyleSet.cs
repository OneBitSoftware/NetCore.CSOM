using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.VisualizationStyleSet", ValueObject = true, ServerTypeId = "{ab366d26-be89-4814-b6e6-d9e45aff97bf}")]
    public class VisualizationStyleSet : ClientValueObject
    {
        private string m_aspectRatio;

        private string m_backgroundColor;

        private IList<VisualizationField> m_fields;

        private string m_minHeight;

        [Remote]
        public string AspectRatio
        {
            get
            {
                return this.m_aspectRatio;
            }
            set
            {
                this.m_aspectRatio = value;
            }
        }

        [Remote]
        public string BackgroundColor
        {
            get
            {
                return this.m_backgroundColor;
            }
            set
            {
                this.m_backgroundColor = value;
            }
        }

        [Remote]
        public IList<VisualizationField> Fields
        {
            get
            {
                return this.m_fields;
            }
            set
            {
                this.m_fields = value;
            }
        }

        [Remote]
        public string MinHeight
        {
            get
            {
                return this.m_minHeight;
            }
            set
            {
                this.m_minHeight = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{ab366d26-be89-4814-b6e6-d9e45aff97bf}";
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
            writer.WriteAttributeString("Name", "AspectRatio");
            DataConvert.WriteValueToXmlElement(writer, this.AspectRatio, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "BackgroundColor");
            DataConvert.WriteValueToXmlElement(writer, this.BackgroundColor, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Fields");
            DataConvert.WriteValueToXmlElement(writer, this.Fields, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "MinHeight");
            DataConvert.WriteValueToXmlElement(writer, this.MinHeight, serializationContext);
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
                if (!(peekedName == "AspectRatio"))
                {
                    if (!(peekedName == "BackgroundColor"))
                    {
                        if (!(peekedName == "Fields"))
                        {
                            if (peekedName == "MinHeight")
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_minHeight = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_fields = reader.ReadList<VisualizationField>();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_backgroundColor = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_aspectRatio = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
