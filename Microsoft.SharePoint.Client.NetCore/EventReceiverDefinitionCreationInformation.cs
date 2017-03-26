using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.EventReceiverDefinitionCreationInformation", ValueObject = true, ServerTypeId = "{2c15382f-b6e4-41f6-8616-4cbe0080a5de}")]
    public class EventReceiverDefinitionCreationInformation : ClientValueObject
    {
        private string m_receiverAssembly;

        private string m_receiverClass;

        private string m_receiverName;

        private int m_sequenceNumber;

        private EventReceiverSynchronization m_synchronization;

        private EventReceiverType m_eventType;

        private string m_receiverUrl;

        [Remote]
        public string ReceiverAssembly
        {
            get
            {
                return this.m_receiverAssembly;
            }
            set
            {
                this.m_receiverAssembly = value;
            }
        }

        [Remote]
        public string ReceiverClass
        {
            get
            {
                return this.m_receiverClass;
            }
            set
            {
                this.m_receiverClass = value;
            }
        }

        [Remote]
        public string ReceiverName
        {
            get
            {
                return this.m_receiverName;
            }
            set
            {
                this.m_receiverName = value;
            }
        }

        [Remote]
        public int SequenceNumber
        {
            get
            {
                return this.m_sequenceNumber;
            }
            set
            {
                this.m_sequenceNumber = value;
            }
        }

        [Remote]
        public EventReceiverSynchronization Synchronization
        {
            get
            {
                return this.m_synchronization;
            }
            set
            {
                this.m_synchronization = value;
            }
        }

        [Remote]
        public EventReceiverType EventType
        {
            get
            {
                return this.m_eventType;
            }
            set
            {
                this.m_eventType = value;
            }
        }

        [Remote]
        public string ReceiverUrl
        {
            get
            {
                return this.m_receiverUrl;
            }
            set
            {
                this.m_receiverUrl = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{2c15382f-b6e4-41f6-8616-4cbe0080a5de}";
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
            writer.WriteAttributeString("Name", "ReceiverAssembly");
            DataConvert.WriteValueToXmlElement(writer, this.ReceiverAssembly, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ReceiverClass");
            DataConvert.WriteValueToXmlElement(writer, this.ReceiverClass, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ReceiverName");
            DataConvert.WriteValueToXmlElement(writer, this.ReceiverName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "SequenceNumber");
            DataConvert.WriteValueToXmlElement(writer, this.SequenceNumber, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Synchronization");
            DataConvert.WriteValueToXmlElement(writer, this.Synchronization, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "EventType");
            DataConvert.WriteValueToXmlElement(writer, this.EventType, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "ReceiverUrl");
            DataConvert.WriteValueToXmlElement(writer, this.ReceiverUrl, serializationContext);
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
            switch (peekedName)
            {
                case "ReceiverAssembly":
                    flag = true;
                    reader.ReadName();
                    this.m_receiverAssembly = reader.ReadString();
                    break;
                case "ReceiverClass":
                    flag = true;
                    reader.ReadName();
                    this.m_receiverClass = reader.ReadString();
                    break;
                case "ReceiverName":
                    flag = true;
                    reader.ReadName();
                    this.m_receiverName = reader.ReadString();
                    break;
                case "SequenceNumber":
                    flag = true;
                    reader.ReadName();
                    this.m_sequenceNumber = reader.ReadInt32();
                    break;
                case "Synchronization":
                    flag = true;
                    reader.ReadName();
                    this.m_synchronization = reader.ReadEnum<EventReceiverSynchronization>();
                    break;
                case "EventType":
                    flag = true;
                    reader.ReadName();
                    this.m_eventType = reader.ReadEnum<EventReceiverType>();
                    break;
                case "ReceiverUrl":
                    flag = true;
                    reader.ReadName();
                    this.m_receiverUrl = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}
