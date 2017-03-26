using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.VisualizationField", ValueObject = true, ServerTypeId = "{4f32c806-2dde-4142-9e2b-2e2e082fb9cf}")]
    public class VisualizationField : ClientValueObject
    {
        private string m_internalName;

        private string m_style;

        [Remote]
        public string InternalName
        {
            get
            {
                return this.m_internalName;
            }
            set
            {
                this.m_internalName = value;
            }
        }

        [Remote]
        public string Style
        {
            get
            {
                return this.m_style;
            }
            set
            {
                this.m_style = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{4f32c806-2dde-4142-9e2b-2e2e082fb9cf}";
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
            writer.WriteAttributeString("Name", "InternalName");
            DataConvert.WriteValueToXmlElement(writer, this.InternalName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Style");
            DataConvert.WriteValueToXmlElement(writer, this.Style, serializationContext);
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
                if (!(peekedName == "InternalName"))
                {
                    if (peekedName == "Style")
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_style = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_internalName = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
