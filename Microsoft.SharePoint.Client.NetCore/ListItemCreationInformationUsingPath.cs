using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListItemCreationInformationUsingPath", ValueObject = true, ServerTypeId = "{b3776c4e-509d-4bed-983f-cddc43118e30}")]
    public class ListItemCreationInformationUsingPath : ClientValueObject
    {
        private ResourcePath m_folderPath;

        private ResourcePath m_leafName;

        private FileSystemObjectType m_underlyingObjectType;

        [Remote]
        public ResourcePath FolderPath
        {
            get
            {
                return this.m_folderPath;
            }
            set
            {
                this.m_folderPath = value;
            }
        }

        [Remote]
        public ResourcePath LeafName
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
                return "{b3776c4e-509d-4bed-983f-cddc43118e30}";
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
            writer.WriteAttributeString("Name", "FolderPath");
            DataConvert.WriteValueToXmlElement(writer, this.FolderPath, serializationContext);
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
                if (!(peekedName == "FolderPath"))
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
                        this.m_leafName = reader.Read<ResourcePath>();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_folderPath = reader.Read<ResourcePath>();
                }
            }
            return flag;
        }
    }
}