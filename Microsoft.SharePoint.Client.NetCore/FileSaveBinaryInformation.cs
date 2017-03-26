using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FileSaveBinaryInformation", ValueObject = true, ServerTypeId = "{c3de0784-43e6-4f12-bd0c-f0d9a34ebf93}")]
    public class FileSaveBinaryInformation : ClientValueObject
    {
        private bool m_checkRequiredFields;

        private byte[] m_content;

        private Stream m_contentStream;

        private string m_eTag;

        private IDictionary<string, object> m_fieldValues;

        [Remote]
        public bool CheckRequiredFields
        {
            get
            {
                return this.m_checkRequiredFields;
            }
            set
            {
                this.m_checkRequiredFields = value;
            }
        }

        [Remote]
        public byte[] Content
        {
            get
            {
                return this.m_content;
            }
            set
            {
                this.m_content = value;
            }
        }

        [Remote]
        public Stream ContentStream
        {
            get
            {
                return this.m_contentStream;
            }
            set
            {
                this.m_contentStream = value;
            }
        }

        [Remote]
        public string ETag
        {
            get
            {
                return this.m_eTag;
            }
            set
            {
                this.m_eTag = value;
            }
        }

        [Remote]
        public IDictionary<string, object> FieldValues
        {
            get
            {
                return this.m_fieldValues;
            }
            set
            {
                this.m_fieldValues = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{c3de0784-43e6-4f12-bd0c-f0d9a34ebf93}";
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
            writer.WriteAttributeString("Name", "CheckRequiredFields");
            DataConvert.WriteValueToXmlElement(writer, this.CheckRequiredFields, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Content");
            DataConvert.WriteValueToXmlElement(writer, this.Content, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ContentStream");
            DataConvert.WriteValueToXmlElement(writer, this.ContentStream, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ETag");
            DataConvert.WriteValueToXmlElement(writer, this.ETag, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FieldValues");
            DataConvert.WriteValueToXmlElement(writer, this.FieldValues, serializationContext);
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
                if (!(peekedName == "CheckRequiredFields"))
                {
                    if (!(peekedName == "Content"))
                    {
                        if (!(peekedName == "ContentStream"))
                        {
                            if (!(peekedName == "ETag"))
                            {
                                if (peekedName == "FieldValues")
                                {
                                    flag = true;
                                    reader.ReadName();
                                    this.m_fieldValues = reader.ReadDictionary<object>();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_eTag = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_contentStream = reader.ReadStream();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_content = reader.ReadByteArray();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_checkRequiredFields = reader.ReadBoolean();
                }
            }
            return flag;
        }
    }
}
