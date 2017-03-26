using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListItemFormUpdateValue", ValueObject = true, ServerTypeId = "{03745a5a-2400-440e-92d6-dad4afee30a6}")]
    public class ListItemFormUpdateValue : ClientValueObject
    {
        private string m_errorMessage;

        private string m_fieldName;

        private string m_fieldValue;

        private bool m_hasException;

        [Remote]
        public string ErrorMessage
        {
            get
            {
                return this.m_errorMessage;
            }
            set
            {
                this.m_errorMessage = value;
            }
        }

        [Remote]
        public string FieldName
        {
            get
            {
                return this.m_fieldName;
            }
            set
            {
                this.m_fieldName = value;
            }
        }

        [Remote]
        public string FieldValue
        {
            get
            {
                return this.m_fieldValue;
            }
            set
            {
                this.m_fieldValue = value;
            }
        }

        [Remote]
        public bool HasException
        {
            get
            {
                return this.m_hasException;
            }
            set
            {
                this.m_hasException = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{03745a5a-2400-440e-92d6-dad4afee30a6}";
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
            writer.WriteAttributeString("Name", "ErrorMessage");
            DataConvert.WriteValueToXmlElement(writer, this.ErrorMessage, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FieldName");
            DataConvert.WriteValueToXmlElement(writer, this.FieldName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "FieldValue");
            DataConvert.WriteValueToXmlElement(writer, this.FieldValue, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "HasException");
            DataConvert.WriteValueToXmlElement(writer, this.HasException, serializationContext);
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
                if (!(peekedName == "ErrorMessage"))
                {
                    if (!(peekedName == "FieldName"))
                    {
                        if (!(peekedName == "FieldValue"))
                        {
                            if (peekedName == "HasException")
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_hasException = reader.ReadBoolean();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_fieldValue = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_fieldName = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_errorMessage = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
