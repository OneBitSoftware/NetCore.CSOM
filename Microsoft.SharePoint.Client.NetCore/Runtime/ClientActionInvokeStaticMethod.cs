using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class ClientActionInvokeStaticMethod : ClientAction
    {
        private object[] m_parameters;

        private string m_typeId;

        private SerializationContext m_serializationContext;

        private ChunkStringBuilder m_sb;

        public ClientActionInvokeStaticMethod(ClientRuntimeContext context, string typeId, string methodName, object[] parameters) : base(context, null, methodName)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction.CheckActionParametersInContext(context, parameters);
            this.m_typeId = typeId;
            this.m_parameters = parameters;
            this.m_serializationContext = new SerializationContext(context);
            this.m_sb = new ChunkStringBuilder();
            XmlWriter xmlWriter = this.m_sb.CreateXmlWriter();
            this.WriteToXmlPrivate(xmlWriter, this.m_serializationContext);
            xmlWriter.Dispose();// Close();
            this.m_parameters = null;
        }

        internal override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            this.m_sb.WriteContentAsRawXml(writer);
            serializationContext.MergeFrom(this.m_serializationContext);
        }

        private void WriteToXmlPrivate(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("StaticMethod");
            writer.WriteAttributeString("TypeId", this.m_typeId);
            writer.WriteAttributeString("Name", base.Name);
            writer.WriteAttributeString("Id", base.Id.ToString(CultureInfo.InvariantCulture));
            if (this.m_parameters != null && this.m_parameters.Length > 0)
            {
                writer.WriteStartElement("Parameters");
                for (int i = 0; i < this.m_parameters.Length; i++)
                {
                    object objValue = this.m_parameters[i];
                    writer.WriteStartElement("Parameter");
                    DataConvert.WriteValueToXmlElement(writer, objValue, serializationContext);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }
    }
}
