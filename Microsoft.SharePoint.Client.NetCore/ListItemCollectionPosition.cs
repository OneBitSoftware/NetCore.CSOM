using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListItemCollectionPosition", ValueObject = true, ServerTypeId = "{922354eb-c56a-4d88-ad59-67496854efe1}")]
    public class ListItemCollectionPosition : ClientValueObject
    {
        private string m_pagingInfo;

        [Remote]
        public string PagingInfo
        {
            get
            {
                return this.m_pagingInfo;
            }
            set
            {
                this.m_pagingInfo = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{922354eb-c56a-4d88-ad59-67496854efe1}";
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
            writer.WriteAttributeString("Name", "PagingInfo");
            DataConvert.WriteValueToXmlElement(writer, this.PagingInfo, serializationContext);
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
            if (peekedName != null && peekedName == "PagingInfo")
            {
                flag = true;
                reader.ReadName();
                this.m_pagingInfo = reader.ReadString();
            }
            return flag;
        }
    }
}
