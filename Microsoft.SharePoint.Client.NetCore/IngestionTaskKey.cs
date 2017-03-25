using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.IngestionTaskKey", ValueObject = true, ServerTypeId = "{3314041b-e208-4492-a0e9-a275fa3f6204}")]
    public class IngestionTaskKey : ClientValueObject
    {
        private string m_ingestionTableAccountKey;

        private string m_ingestionTableAccountName;

        private string m_jobId;

        private string m_taskId;

        private string m_tenantName;

        [Remote]
        public string IngestionTableAccountKey
        {
            get
            {
                return this.m_ingestionTableAccountKey;
            }
            set
            {
                this.m_ingestionTableAccountKey = value;
            }
        }

        [Remote]
        public string IngestionTableAccountName
        {
            get
            {
                return this.m_ingestionTableAccountName;
            }
            set
            {
                this.m_ingestionTableAccountName = value;
            }
        }

        [Remote]
        public string JobId
        {
            get
            {
                return this.m_jobId;
            }
            set
            {
                this.m_jobId = value;
            }
        }

        [Remote]
        public string TaskId
        {
            get
            {
                return this.m_taskId;
            }
            set
            {
                this.m_taskId = value;
            }
        }

        [Remote]
        public string TenantName
        {
            get
            {
                return this.m_tenantName;
            }
            set
            {
                this.m_tenantName = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{3314041b-e208-4492-a0e9-a275fa3f6204}";
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
            writer.WriteAttributeString("Name", "IngestionTableAccountKey");
            DataConvert.WriteValueToXmlElement(writer, this.IngestionTableAccountKey, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "IngestionTableAccountName");
            DataConvert.WriteValueToXmlElement(writer, this.IngestionTableAccountName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "JobId");
            DataConvert.WriteValueToXmlElement(writer, this.JobId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "TaskId");
            DataConvert.WriteValueToXmlElement(writer, this.TaskId, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "TenantName");
            DataConvert.WriteValueToXmlElement(writer, this.TenantName, serializationContext);
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
                if (!(peekedName == "IngestionTableAccountKey"))
                {
                    if (!(peekedName == "IngestionTableAccountName"))
                    {
                        if (!(peekedName == "JobId"))
                        {
                            if (!(peekedName == "TaskId"))
                            {
                                if (peekedName == "TenantName")
                                {
                                    flag = true;
                                    reader.ReadName();
                                    this.m_tenantName = reader.ReadString();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                this.m_taskId = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            this.m_jobId = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        this.m_ingestionTableAccountName = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_ingestionTableAccountKey = reader.ReadString();
                }
            }
            return flag;
        }
    }
}