using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class ClientActionSetProperty : ClientAction
    {
        private string m_propName;

        private object m_propValue;

        private SerializationContext m_serializationContext;

        private ChunkStringBuilder m_sb;

        public ClientActionSetProperty(ClientObject obj, string propName, object propValue) : base(ClientRuntimeContext.GetContextFromClientObject(obj), (obj == null) ? null : obj.Path, propName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (obj.Path == null || !obj.Path.IsValid)
            {
                throw new ClientRequestException(Resources.GetString("NoObjectPathAssociatedWithObject"));
            }
            ClientAction.CheckActionParameterInContext(obj.Context, propValue);
            this.m_propName = propName;
            this.m_propValue = propValue;
            this.m_serializationContext = new SerializationContext(obj.Context);
            this.m_sb = new ChunkStringBuilder();
            XmlWriter xmlWriter = this.m_sb.CreateXmlWriter();
            this.WriteToXmlPrivate(xmlWriter, this.m_serializationContext);
            xmlWriter.Dispose();//.Close();
            this.m_propValue = null;
        }

        internal override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            this.m_sb.WriteContentAsRawXml(writer);
            serializationContext.MergeFrom(this.m_serializationContext);
        }

        private void WriteToXmlPrivate(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("SetProperty");
            writer.WriteAttributeString("Id", base.Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("ObjectPathId", base.Path.Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("Name", this.m_propName);
            serializationContext.AddObjectPath(base.Path);
            writer.WriteStartElement("Parameter");
            DataConvert.WriteValueToXmlElement(writer, this.m_propValue, serializationContext);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}
