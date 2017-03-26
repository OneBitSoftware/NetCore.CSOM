using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FileCollectionAddParameters", ValueObject = true, ServerTypeId = "{19eccee3-91d5-4335-9afc-cd7fe47e5493}")]
    public sealed class FileCollectionAddParameters : ClientValueObject
    {
        private bool m_overwrite;

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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{19eccee3-91d5-4335-9afc-cd7fe47e5493}";
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
            writer.WriteAttributeString("Name", "Overwrite");
            DataConvert.WriteValueToXmlElement(writer, this.Overwrite, serializationContext);
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
            if (peekedName != null && peekedName == "Overwrite")
            {
                flag = true;
                reader.ReadName();
                this.m_overwrite = reader.ReadBoolean();
            }
            return flag;
        }
    }
}
