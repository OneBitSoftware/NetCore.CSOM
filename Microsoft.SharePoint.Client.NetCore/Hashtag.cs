using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Hashtag", ValueObject = true, ServerTypeId = "{cdd68411-bc1e-46f6-acc6-9fb857454976}")]
    public class Hashtag : ClientValueObject
    {
        private string m_actor;

        private string m_application;

        private string m_label;

        private DateTime m_timestamp;

        [Remote]
        public string Actor
        {
            get
            {
                return this.m_actor;
            }
            set
            {
                this.m_actor = value;
            }
        }

        [Remote]
        public string Application
        {
            get
            {
                return this.m_application;
            }
            set
            {
                this.m_application = value;
            }
        }

        [Remote]
        public string Label
        {
            get
            {
                return this.m_label;
            }
            set
            {
                this.m_label = value;
            }
        }

        [Remote]
        public DateTime Timestamp
        {
            get
            {
                return this.m_timestamp;
            }
            set
            {
                this.m_timestamp = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{cdd68411-bc1e-46f6-acc6-9fb857454976}";
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
            writer.WriteAttributeString("Name", "Actor");
            DataConvert.WriteValueToXmlElement(writer, this.Actor, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Application");
            DataConvert.WriteValueToXmlElement(writer, this.Application, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Label");
            DataConvert.WriteValueToXmlElement(writer, this.Label, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Timestamp");
            DataConvert.WriteValueToXmlElement(writer, this.Timestamp, serializationContext);
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
                if (!(peekedName == "Actor"))
                {
                    if (!(peekedName == "Application"))
                    {
                        if (!(peekedName == "Label"))
                        {
                            if (peekedName == "Timestamp")
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_timestamp = reader.ReadDateTime();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_label = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_application = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_actor = reader.ReadString();
                }
            }
            return flag;
        }
    }
}