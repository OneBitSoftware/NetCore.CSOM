using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class ClientActionSetStaticProperty : ClientAction
    {
        private string m_typeId;

        private object m_propValue;

        private SerializationContext m_serializationContext;

        private ChunkStringBuilder m_sb;

        public ClientActionSetStaticProperty(ClientRuntimeContext context, string typeId, string propName, object propValue) : base(context, null, propName)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction.CheckActionParameterInContext(context, propValue);
            this.m_typeId = typeId;
            this.m_propValue = propValue;
            this.m_serializationContext = new SerializationContext(context);
            this.m_sb = new ChunkStringBuilder();
            XmlWriter xmlWriter = this.m_sb.CreateXmlWriter();
            this.WriteToXmlPrivate(xmlWriter, this.m_serializationContext);
            xmlWriter.Dispose();// Close();
            this.m_propValue = null;
        }

        internal override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            this.m_sb.WriteContentAsRawXml(writer);
            serializationContext.MergeFrom(this.m_serializationContext);
        }

        private void WriteToXmlPrivate(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("SetStaticProperty");
            writer.WriteAttributeString("Id", base.Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("TypeId", this.m_typeId);
            writer.WriteAttributeString("Name", base.Name);
            writer.WriteStartElement("Parameter");
            DataConvert.WriteValueToXmlElement(writer, this.m_propValue, serializationContext);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
