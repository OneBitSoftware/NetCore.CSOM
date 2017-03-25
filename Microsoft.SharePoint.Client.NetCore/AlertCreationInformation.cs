using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.AlertCreationInformation", ValueObject = true, ServerTypeId = "{f0c12e8e-54f5-4e31-b015-f4f824eea024}")]
    public class AlertCreationInformation : ClientValueObject
    {
        //private AlertFrequency m_alertFrequency;

        private string m_alertTemplateName;

        private DateTime m_alertTime;

        //private AlertType m_alertType;

        private bool m_alwaysNotify;

        //private AlertDeliveryChannel m_deliveryChannels;

        //private AlertEventType m_eventType;

        private int m_eventTypeBitmask;

        private string m_filter;

        //private ListItem m_item;

        //private List m_list;

        //private AlertStatus m_status;

        private string m_title;

        private User m_user;

        //[Remote]
        //public AlertFrequency AlertFrequency
        //{
        //    get
        //    {
        //        return this.m_alertFrequency;
        //    }
        //    set
        //    {
        //        this.m_alertFrequency = value;
        //    }
        //}

        [Remote]
        public string AlertTemplateName
        {
            get
            {
                return this.m_alertTemplateName;
            }
            set
            {
                this.m_alertTemplateName = value;
            }
        }

        [Remote]
        public DateTime AlertTime
        {
            get
            {
                return this.m_alertTime;
            }
            set
            {
                this.m_alertTime = value;
            }
        }

        //[Remote]
        //public AlertType AlertType
        //{
        //    get
        //    {
        //        return this.m_alertType;
        //    }
        //    set
        //    {
        //        this.m_alertType = value;
        //    }
        //}

        [Remote]
        public bool AlwaysNotify
        {
            get
            {
                return this.m_alwaysNotify;
            }
            set
            {
                this.m_alwaysNotify = value;
            }
        }

        //[Remote]
        //public AlertDeliveryChannel DeliveryChannels
        //{
        //    get
        //    {
        //        return this.m_deliveryChannels;
        //    }
        //    set
        //    {
        //        this.m_deliveryChannels = value;
        //    }
        //}

        //[Remote]
        //public AlertEventType EventType
        //{
        //    get
        //    {
        //        return this.m_eventType;
        //    }
        //    set
        //    {
        //        this.m_eventType = value;
        //    }
        //}

        [Remote]
        public int EventTypeBitmask
        {
            get
            {
                return this.m_eventTypeBitmask;
            }
            set
            {
                this.m_eventTypeBitmask = value;
            }
        }

        [Remote]
        public string Filter
        {
            get
            {
                return this.m_filter;
            }
            set
            {
                this.m_filter = value;
            }
        }

        //[Remote]
        //public ListItem Item
        //{
        //    get
        //    {
        //        return this.m_item;
        //    }
        //    set
        //    {
        //        this.m_item = value;
        //    }
        //}

        //[Remote]
        //public List List
        //{
        //    get
        //    {
        //        return this.m_list;
        //    }
        //    set
        //    {
        //        this.m_list = value;
        //    }
        //}

        //[Remote]
        //public AlertStatus Status
        //{
        //    get
        //    {
        //        return this.m_status;
        //    }
        //    set
        //    {
        //        this.m_status = value;
        //    }
        //}

        [Remote]
        public string Title
        {
            get
            {
                return this.m_title;
            }
            set
            {
                this.m_title = value;
            }
        }

        [Remote]
        public User User
        {
            get
            {
                return this.m_user;
            }
            set
            {
                this.m_user = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{f0c12e8e-54f5-4e31-b015-f4f824eea024}";
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
            //writer.WriteStartElement("Property");
            //writer.WriteAttributeString("Name", "AlertFrequency");
            //DataConvert.WriteValueToXmlElement(writer, this.AlertFrequency, serializationContext);
            //writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "AlertTemplateName");
            DataConvert.WriteValueToXmlElement(writer, this.AlertTemplateName, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "AlertTime");
            DataConvert.WriteValueToXmlElement(writer, this.AlertTime, serializationContext);
            writer.WriteEndElement();
            //writer.WriteStartElement("Property");
            //writer.WriteAttributeString("Name", "AlertType");
            //DataConvert.WriteValueToXmlElement(writer, this.AlertType, serializationContext);
            //writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "AlwaysNotify");
            DataConvert.WriteValueToXmlElement(writer, this.AlwaysNotify, serializationContext);
            writer.WriteEndElement();
            //writer.WriteStartElement("Property");
            //writer.WriteAttributeString("Name", "DeliveryChannels");
            //DataConvert.WriteValueToXmlElement(writer, this.DeliveryChannels, serializationContext);
            //writer.WriteEndElement();
            //writer.WriteStartElement("Property");
            //writer.WriteAttributeString("Name", "EventType");
            //DataConvert.WriteValueToXmlElement(writer, this.EventType, serializationContext);
            //writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "EventTypeBitmask");
            DataConvert.WriteValueToXmlElement(writer, this.EventTypeBitmask, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Filter");
            DataConvert.WriteValueToXmlElement(writer, this.Filter, serializationContext);
            writer.WriteEndElement();
            //writer.WriteStartElement("Property");
            //writer.WriteAttributeString("Name", "Item");
            //DataConvert.WriteValueToXmlElement(writer, this.Item, serializationContext);
            //writer.WriteEndElement();
            //writer.WriteStartElement("Property");
            //writer.WriteAttributeString("Name", "List");
            //DataConvert.WriteValueToXmlElement(writer, this.List, serializationContext);
            //writer.WriteEndElement();
            //writer.WriteStartElement("Property");
            //writer.WriteAttributeString("Name", "Status");
            //DataConvert.WriteValueToXmlElement(writer, this.Status, serializationContext);
            //writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "Title");
            DataConvert.WriteValueToXmlElement(writer, this.Title, serializationContext);
            writer.WriteEndElement();
            writer.WriteStartElement("Property");
            writer.WriteAttributeString("Name", "User");
            DataConvert.WriteValueToXmlElement(writer, this.User, serializationContext);
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
                //case "AlertFrequency":
                //    flag = true;
                //    reader.ReadName();
                //    this.m_alertFrequency = reader.ReadEnum<AlertFrequency>();
                //    break;
                case "AlertTemplateName":
                    flag = true;
                    reader.ReadName();
                    this.m_alertTemplateName = reader.ReadString();
                    break;
                case "AlertTime":
                    flag = true;
                    reader.ReadName();
                    this.m_alertTime = reader.ReadDateTime();
                    break;
                //case "AlertType":
                //    flag = true;
                //    reader.ReadName();
                //    this.m_alertType = reader.ReadEnum<AlertType>();
                //    break;
                case "AlwaysNotify":
                    flag = true;
                    reader.ReadName();
                    this.m_alwaysNotify = reader.ReadBoolean();
                    break;
                //case "DeliveryChannels":
                //    flag = true;
                //    reader.ReadName();
                //    this.m_deliveryChannels = reader.ReadEnum<AlertDeliveryChannel>();
                //    break;
                //case "EventType":
                //    flag = true;
                //    reader.ReadName();
                //    this.m_eventType = reader.ReadEnum<AlertEventType>();
                //    break;
                case "EventTypeBitmask":
                    flag = true;
                    reader.ReadName();
                    this.m_eventTypeBitmask = reader.ReadInt32();
                    break;
                case "Filter":
                    flag = true;
                    reader.ReadName();
                    this.m_filter = reader.ReadString();
                    break;
                //case "Status":
                //    flag = true;
                //    reader.ReadName();
                //    this.m_status = reader.ReadEnum<AlertStatus>();
                //    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    this.m_title = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}