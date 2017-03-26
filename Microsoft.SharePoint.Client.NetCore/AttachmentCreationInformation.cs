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
    [ScriptType("SP.AttachmentCreationInformation", ValueObject = true, ServerTypeId = "{edf6309c-8142-4133-921e-4d6aec35550d}")]
    public class AttachmentCreationInformation : ClientValueObject
    {
        private Stream m_contentStream;

        private string m_fileName;

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
        public string FileName
        {
            get
            {
                return this.m_fileName;
            }
            set
            {
                this.m_fileName = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{edf6309c-8142-4133-921e-4d6aec35550d}";
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
            writer.WriteAttributeString("Name", "ContentStream");
            DataConvert.WriteValueToXmlElement(writer, this.ContentStream, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FileName");
            DataConvert.WriteValueToXmlElement(writer, this.FileName, serializationContext);
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
                if (!(peekedName == "ContentStream"))
                {
                    if (peekedName == "FileName")
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_fileName = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_contentStream = reader.ReadStream();
                }
            }
            return flag;
        }
    }
}