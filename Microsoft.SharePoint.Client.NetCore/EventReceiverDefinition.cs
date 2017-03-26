using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.EventReceiverDefinition", ServerTypeId = "{a8d3515c-1135-4fff-95a6-4e5e5fff4adc}")]
    public sealed class EventReceiverDefinition : ClientObject
    {
        [Remote]
        public string ReceiverAssembly
        {
            get
            {
                base.CheckUninitializedProperty("ReceiverAssembly");
                return (string)base.ObjectData.Properties["ReceiverAssembly"];
            }
        }

        [Remote]
        public string ReceiverClass
        {
            get
            {
                base.CheckUninitializedProperty("ReceiverClass");
                return (string)base.ObjectData.Properties["ReceiverClass"];
            }
        }

        [Remote]
        public Guid ReceiverId
        {
            get
            {
                base.CheckUninitializedProperty("ReceiverId");
                return (Guid)base.ObjectData.Properties["ReceiverId"];
            }
        }

        [Remote]
        public string ReceiverName
        {
            get
            {
                base.CheckUninitializedProperty("ReceiverName");
                return (string)base.ObjectData.Properties["ReceiverName"];
            }
        }

        [Remote]
        public int SequenceNumber
        {
            get
            {
                base.CheckUninitializedProperty("SequenceNumber");
                return (int)base.ObjectData.Properties["SequenceNumber"];
            }
        }

        [Remote]
        public EventReceiverSynchronization Synchronization
        {
            get
            {
                base.CheckUninitializedProperty("Synchronization");
                return (EventReceiverSynchronization)base.ObjectData.Properties["Synchronization"];
            }
        }

        [Remote]
        public EventReceiverType EventType
        {
            get
            {
                base.CheckUninitializedProperty("EventType");
                return (EventReceiverType)base.ObjectData.Properties["EventType"];
            }
        }

        [Remote]
        public string ReceiverUrl
        {
            get
            {
                base.CheckUninitializedProperty("ReceiverUrl");
                return (string)base.ObjectData.Properties["ReceiverUrl"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public EventReceiverDefinition(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
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
                    base.ObjectData.Properties["ReceiverAssembly"] = reader.ReadString();
                    break;
                case "ReceiverClass":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReceiverClass"] = reader.ReadString();
                    break;
                case "ReceiverId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReceiverId"] = reader.ReadGuid();
                    break;
                case "ReceiverName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReceiverName"] = reader.ReadString();
                    break;
                case "SequenceNumber":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SequenceNumber"] = reader.ReadInt32();
                    break;
                case "Synchronization":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Synchronization"] = reader.ReadEnum<EventReceiverSynchronization>();
                    break;
                case "EventType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EventType"] = reader.ReadEnum<EventReceiverType>();
                    break;
                case "ReceiverUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReceiverUrl"] = reader.ReadString();
                    break;
            }
            return flag;
        }

        [Remote]
        public void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }
    }
}
