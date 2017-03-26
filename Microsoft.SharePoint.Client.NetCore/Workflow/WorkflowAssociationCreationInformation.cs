using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Workflow
{
    [ScriptType("SP.Workflow.WorkflowAssociationCreationInformation", ValueObject = true, ServerTypeId = "{3c812f4f-8465-41cb-b298-bd33b2604a51}")]
    public class WorkflowAssociationCreationInformation : ClientValueObject
    {
        private string m_contentTypeAssociationHistoryListName;

        private string m_contentTypeAssociationTaskListName;

        private List m_historyList;

        private string m_name;

        private List m_taskList;

        private WorkflowTemplate m_template;

        [Remote]
        public string ContentTypeAssociationHistoryListName
        {
            get
            {
                return this.m_contentTypeAssociationHistoryListName;
            }
            set
            {
                this.m_contentTypeAssociationHistoryListName = value;
            }
        }

        [Remote]
        public string ContentTypeAssociationTaskListName
        {
            get
            {
                return this.m_contentTypeAssociationTaskListName;
            }
            set
            {
                this.m_contentTypeAssociationTaskListName = value;
            }
        }

        [Remote]
        public List HistoryList
        {
            get
            {
                return this.m_historyList;
            }
            set
            {
                this.m_historyList = value;
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
        public List TaskList
        {
            get
            {
                return this.m_taskList;
            }
            set
            {
                this.m_taskList = value;
            }
        }

        [Remote]
        public WorkflowTemplate Template
        {
            get
            {
                return this.m_template;
            }
            set
            {
                this.m_template = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{3c812f4f-8465-41cb-b298-bd33b2604a51}";
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
            writer.WriteAttributeString("Name", "ContentTypeAssociationHistoryListName");
            DataConvert.WriteValueToXmlElement(writer, this.ContentTypeAssociationHistoryListName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ContentTypeAssociationTaskListName");
            DataConvert.WriteValueToXmlElement(writer, this.ContentTypeAssociationTaskListName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "HistoryList");
            DataConvert.WriteValueToXmlElement(writer, this.HistoryList, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Name");
            DataConvert.WriteValueToXmlElement(writer, this.Name, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "TaskList");
            DataConvert.WriteValueToXmlElement(writer, this.TaskList, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Template");
            DataConvert.WriteValueToXmlElement(writer, this.Template, serializationContext);
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
                if (!(peekedName == "ContentTypeAssociationHistoryListName"))
                {
                    if (!(peekedName == "ContentTypeAssociationTaskListName"))
                    {
                        if (peekedName == "Name")
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
                        this.m_contentTypeAssociationTaskListName = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    this.m_contentTypeAssociationHistoryListName = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
