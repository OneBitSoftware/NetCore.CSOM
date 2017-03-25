using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class ClientActionInvokeMethod : ClientAction
    {
        private object[] m_parameters;

        private string m_version;

        private SerializationContext m_serializationContext;

        private ChunkStringBuilder m_sb;

        public ClientActionInvokeMethod(ClientObject obj, string methodName, object[] parameters) : base(ClientRuntimeContext.GetContextFromClientObject(obj), (obj == null) ? null : obj.Path, methodName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            ClientAction.CheckActionParametersInContext(obj.Context, parameters);
            this.m_parameters = parameters;
            if (obj.Path == null || !obj.Path.IsValid)
            {
                throw new ClientRequestException(Resources.GetString("NoObjectPathAssociatedWithObject"));
            }
            this.m_version = obj.ObjectData.Version;
            this.m_serializationContext = new SerializationContext(obj.Context);
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
            writer.WriteStartElement("Method");
            writer.WriteAttributeString("Name", base.Name);
            writer.WriteAttributeString("Id", base.Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("ObjectPathId", base.Path.Id.ToString(CultureInfo.InvariantCulture));
            if (this.m_version != null)
            {
                writer.WriteAttributeString("Version", this.m_version);
            }
            serializationContext.AddObjectPath(base.Path);
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
