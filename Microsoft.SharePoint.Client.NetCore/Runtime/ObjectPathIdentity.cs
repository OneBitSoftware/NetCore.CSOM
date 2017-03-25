using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ObjectPathIdentity : ObjectPath
    {
        private string m_identity;

        public string Identity
        {
            get
            {
                return this.m_identity;
            }
        }

        internal override string ObjectName
        {
            get
            {
                return Resources.GetString("ObjectNameIdentity", new object[]
                {
                    this.m_identity
                });
            }
        }

        public ObjectPathIdentity(ClientRuntimeContext context, string identity) : base(context, null, false)
        {
            this.m_identity = identity;
        }

        internal override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("Identity");
            writer.WriteAttributeString("Id", base.Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("Name", this.m_identity);
            writer.WriteEndElement();
        }
    }
}