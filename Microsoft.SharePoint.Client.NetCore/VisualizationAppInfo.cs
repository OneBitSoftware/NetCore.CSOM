using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.VisualizationAppInfo", ValueObject = true, ServerTypeId = "{47684720-7a91-4db0-828a-50f42e8678bb}")]
    public class VisualizationAppInfo : ClientValueObject
    {
        private string m_designUri;

        private Guid m_id;

        private string m_runtimeUri;

        [Remote]
        public string DesignUri
        {
            get
            {
                return this.m_designUri;
            }
            set
            {
                this.m_designUri = value;
            }
        }

        [Remote]
        public Guid Id
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
        public string RuntimeUri
        {
            get
            {
                return this.m_runtimeUri;
            }
            set
            {
                this.m_runtimeUri = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{47684720-7a91-4db0-828a-50f42e8678bb}";
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
            writer.WriteAttributeString("Name", "DesignUri");
            DataConvert.WriteValueToXmlElement(writer, this.DesignUri, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Id");
            DataConvert.WriteValueToXmlElement(writer, this.Id, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "RuntimeUri");
            DataConvert.WriteValueToXmlElement(writer, this.RuntimeUri, serializationContext);
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
                if (!(peekedName == "DesignUri"))
                {
                    if (!(peekedName == "Id"))
                    {
                        if (peekedName == "RuntimeUri")
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_runtimeUri = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_id = reader.ReadGuid();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_designUri = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
