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
    [ScriptType("SP.FileCreationInformation", ValueObject = true, ServerTypeId = "{f5c8173c-cae6-4469-a7af-3879ca3c617c}")]
    public class FileCreationInformation : ClientValueObject
    {
        private byte[] m_content;

        private Stream m_contentStream;

        private bool m_overwrite;

        private string m_url;

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
        public bool Overwrite
        {
            get
            {
                return this.m_overwrite;
            }
            set
            {
                this.m_overwrite = value;
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
                return "{f5c8173c-cae6-4469-a7af-3879ca3c617c}";
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
            writer.WriteAttributeString("Name", "Content");
            DataConvert.WriteValueToXmlElement(writer, this.Content, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ContentStream");
            DataConvert.WriteValueToXmlElement(writer, this.ContentStream, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Overwrite");
            DataConvert.WriteValueToXmlElement(writer, this.Overwrite, serializationContext);
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
            if (peekedName != null)
            {
                if (!(peekedName == "Content"))
                {
                    if (!(peekedName == "ContentStream"))
                    {
                        if (!(peekedName == "Overwrite"))
                        {
                            if (peekedName == "Url")
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_url = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_overwrite = reader.ReadBoolean();
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
            return flag;
        }
    }
}
