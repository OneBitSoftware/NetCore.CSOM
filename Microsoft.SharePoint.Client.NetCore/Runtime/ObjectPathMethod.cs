using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ObjectPathMethod : ObjectPath
    {
        private string m_methodName;

        private SerializationContext m_serializationContext;

        private ChunkStringBuilder m_sb;

        private object[] m_parameters;

        internal override string ObjectName
        {
            get
            {
                return Resources.GetString("ObjectNameMethod", new object[]
                {
                    this.m_methodName
                });
            }
        }

        public ObjectPathMethod(ClientRuntimeContext context, ObjectPath parent, string methodName, object[] parameters) : base(context, parent, true)
        {
            ClientAction.CheckActionParametersInContext(context, parameters);
            this.m_methodName = methodName;
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
            writer.WriteStartElement("Method");
            writer.WriteAttributeString("Id", base.Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("ParentId", base.Parent.Id.ToString(CultureInfo.InvariantCulture));
            serializationContext.AddObjectPath(base.Parent);
            writer.WriteAttributeString("Name", this.m_methodName);
            if (this.m_parameters != null && this.m_parameters.Length > 0)
            {
                writer.WriteStartElement("Parameters");
                object[] parameters = this.m_parameters;
                for (int i = 0; i < parameters.Length; i++)
                {
                    object objValue = parameters[i];
                    writer.WriteStartElement("Parameter");
                    DataConvert.WriteValueToXmlElement(writer, objValue, serializationContext);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            writer.WriteEndElement();
        }

        internal override void Invalidate()
        {
            this.m_parameters = null;
            this.m_sb = null;
            this.m_serializationContext = null;
            base.IsValid = false;
        }
    }
}
