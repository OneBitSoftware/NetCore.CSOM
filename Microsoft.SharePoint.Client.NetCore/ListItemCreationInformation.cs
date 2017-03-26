using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListItemCreationInformation", ValueObject = true, ServerTypeId = "{54cdbee5-0897-44ac-829f-411557fa11be}")]
    public class ListItemCreationInformation : ClientValueObject
    {
        private string m_folderUrl;

        private string m_leafName;

        private FileSystemObjectType m_underlyingObjectType;

        [Remote]
        public string FolderUrl
        {
            get
            {
                return this.m_folderUrl;
            }
            set
            {
                this.m_folderUrl = value;
            }
        }

        [Remote]
        public string LeafName
        {
            get
            {
                return this.m_leafName;
            }
            set
            {
                this.m_leafName = value;
            }
        }

        [Remote]
        public FileSystemObjectType UnderlyingObjectType
        {
            get
            {
                return this.m_underlyingObjectType;
            }
            set
            {
                this.m_underlyingObjectType = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{54cdbee5-0897-44ac-829f-411557fa11be}";
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
            writer.WriteAttributeString("Name", "FolderUrl");
            DataConvert.WriteValueToXmlElement(writer, this.FolderUrl, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "LeafName");
            DataConvert.WriteValueToXmlElement(writer, this.LeafName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "UnderlyingObjectType");
            DataConvert.WriteValueToXmlElement(writer, this.UnderlyingObjectType, serializationContext);
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
                if (!(peekedName == "FolderUrl"))
                {
                    if (!(peekedName == "LeafName"))
                    {
                        if (peekedName == "UnderlyingObjectType")
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_underlyingObjectType = reader.ReadEnum<FileSystemObjectType>();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_leafName = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_folderUrl = reader.ReadString();
                }
            }
            return flag;
        }
    }
}