using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.EncryptionOption", ValueObject = true, ServerTypeId = "{85614ad4-7a40-49e0-b272-6d1807dbfcc6}")]
    public class EncryptionOption : ClientValueObject
    {
        private byte[] m_aES256CBCKey;

        [Remote]
        public byte[] AES256CBCKey
        {
            get
            {
                return this.m_aES256CBCKey;
            }
            set
            {
                this.m_aES256CBCKey = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{85614ad4-7a40-49e0-b272-6d1807dbfcc6}";
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
            writer.WriteAttributeString("Name", "AES256CBCKey");
            DataConvert.WriteValueToXmlElement(writer, this.AES256CBCKey, serializationContext);
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
            if (peekedName != null && peekedName == "AES256CBCKey")
            {
                flag = true;
                reader.ReadName();
                this.m_aES256CBCKey = reader.ReadByteArray();
            }
            return flag;
        }
    }
}
