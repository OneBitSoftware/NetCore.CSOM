using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ObjectPathStaticProperty : ObjectPath
    {
        private string m_propertyName;

        private string m_typeId;

        internal override string ObjectName
        {
            get
            {
                return Resources.GetString("ObjectNameProperty", new object[]
                {
                    this.m_propertyName
                });
            }
        }

        public ObjectPathStaticProperty(ClientRuntimeContext context, string typeId, string propertyName) : base(context, null, true)
        {
            this.m_typeId = typeId;
            this.m_propertyName = propertyName;
        }

        internal override void WriteToXml(System.Xml.XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("StaticProperty");
            writer.WriteAttributeString("Id", base.Id.ToString(System.Globalization.CultureInfo.InvariantCulture));
            writer.WriteAttributeString("TypeId", this.m_typeId);
            writer.WriteAttributeString("Name", this.m_propertyName);
            writer.WriteEndElement();
        }
    }
}
