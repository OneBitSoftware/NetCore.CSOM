using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RoleDefinitionCreationInformation", ValueObject = true, ServerTypeId = "{59eddf82-1018-4677-8067-69e16efd3495}")]
    public class RoleDefinitionCreationInformation : ClientValueObject
    {
        private BasePermissions m_basePermissions;

        private string m_description;

        private string m_name;

        private int m_order;

        [Remote]
        public BasePermissions BasePermissions
        {
            get
            {
                return this.m_basePermissions;
            }
            set
            {
                this.m_basePermissions = value;
            }
        }

        [Remote]
        public string Description
        {
            get
            {
                return this.m_description;
            }
            set
            {
                this.m_description = value;
            }
        }

        [Remote]
        public string Name
        {
            get
            {
                return this.m_name;
            }
            set
            {
                this.m_name = value;
            }
        }

        [Remote]
        public int Order
        {
            get
            {
                return this.m_order;
            }
            set
            {
                this.m_order = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{59eddf82-1018-4677-8067-69e16efd3495}";
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
            writer.WriteAttributeString("Name", "BasePermissions");
            DataConvert.WriteValueToXmlElement(writer, this.BasePermissions, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Description");
            DataConvert.WriteValueToXmlElement(writer, this.Description, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Name");
            DataConvert.WriteValueToXmlElement(writer, this.Name, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Order");
            DataConvert.WriteValueToXmlElement(writer, this.Order, serializationContext);
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
                if (!(peekedName == "BasePermissions"))
                {
                    if (!(peekedName == "Description"))
                    {
                        if (!(peekedName == "Name"))
                        {
                            if (peekedName == "Order")
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_order = reader.ReadInt32();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_name = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_description = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_basePermissions = reader.Read<BasePermissions>();
                }
            }
            return flag;
        }
    }
}
