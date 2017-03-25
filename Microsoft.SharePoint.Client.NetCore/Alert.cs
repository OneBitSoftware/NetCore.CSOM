using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Alert", ServerTypeId = "{004daa6c-acc5-48fc-877a-2604a2cb3358}")]
    public sealed class Alert : ClientObject
    {
        [Remote]
        public AlertFrequency AlertFrequency
        {
            get
            {
                base.CheckUninitializedProperty("AlertFrequency");
                return (AlertFrequency)base.ObjectData.Properties["AlertFrequency"];
            }
            set
            {
                base.ObjectData.Properties["AlertFrequency"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AlertFrequency", value));
                }
            }
        }

        [Remote]
        public string AlertTemplateName
        {
            get
            {
                base.CheckUninitializedProperty("AlertTemplateName");
                return (string)base.ObjectData.Properties["AlertTemplateName"];
            }
        }

        [Remote]
        public DateTime AlertTime
        {
            get
            {
                base.CheckUninitializedProperty("AlertTime");
                return (DateTime)base.ObjectData.Properties["AlertTime"];
            }
            set
            {
                base.ObjectData.Properties["AlertTime"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AlertTime", value));
                }
            }
        }

        [Remote]
        public AlertType AlertType
        {
            get
            {
                base.CheckUninitializedProperty("AlertType");
                return (AlertType)base.ObjectData.Properties["AlertType"];
            }
        }

        [Remote]
        public bool AlwaysNotify
        {
            get
            {
                base.CheckUninitializedProperty("AlwaysNotify");
                return (bool)base.ObjectData.Properties["AlwaysNotify"];
            }
            set
            {
                base.ObjectData.Properties["AlwaysNotify"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AlwaysNotify", value));
                }
            }
        }

        [Remote]
        public AlertDeliveryChannel DeliveryChannels
        {
            get
            {
                base.CheckUninitializedProperty("DeliveryChannels");
                return (AlertDeliveryChannel)base.ObjectData.Properties["DeliveryChannels"];
            }
            set
            {
                base.ObjectData.Properties["DeliveryChannels"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DeliveryChannels", value));
                }
            }
        }

        [Remote]
        public AlertEventType EventType
        {
            get
            {
                base.CheckUninitializedProperty("EventType");
                return (AlertEventType)base.ObjectData.Properties["EventType"];
            }
            set
            {
                base.ObjectData.Properties["EventType"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EventType", value));
                }
            }
        }

        [Remote]
        public string Filter
        {
            get
            {
                base.CheckUninitializedProperty("Filter");
                return (string)base.ObjectData.Properties["Filter"];
            }
            set
            {
                base.ObjectData.Properties["Filter"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Filter", value));
                }
            }
        }

        [Remote]
        public Guid ID
        {
            get
            {
                base.CheckUninitializedProperty("ID");
                return (Guid)base.ObjectData.Properties["ID"];
            }
        }

        //[Remote]
        //public ListItem Item
        //{
        //    get
        //    {
        //        object obj;
        //        ListItem listItem;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("Item", out obj))
        //        {
        //            listItem = (ListItem)obj;
        //        }
        //        else
        //        {
        //            listItem = new ListItem(base.Context, new ObjectPathProperty(base.Context, base.Path, "Item"));
        //            base.ObjectData.ClientObjectProperties["Item"] = listItem;
        //        }
        //        return listItem;
        //    }
        //}

        [Remote]
        public int ItemID
        {
            get
            {
                base.CheckUninitializedProperty("ItemID");
                return (int)base.ObjectData.Properties["ItemID"];
            }
        }

        //[Remote]
        //public List List
        //{
        //    get
        //    {
        //        object obj;
        //        List list;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("List", out obj))
        //        {
        //            list = (List)obj;
        //        }
        //        else
        //        {
        //            list = new List(base.Context, new ObjectPathProperty(base.Context, base.Path, "List"));
        //            base.ObjectData.ClientObjectProperties["List"] = list;
        //        }
        //        return list;
        //    }
        //}

        [Remote]
        public Guid ListID
        {
            get
            {
                base.CheckUninitializedProperty("ListID");
                return (Guid)base.ObjectData.Properties["ListID"];
            }
        }

        [Remote]
        public string ListUrl
        {
            get
            {
                base.CheckUninitializedProperty("ListUrl");
                return (string)base.ObjectData.Properties["ListUrl"];
            }
        }

        [Remote]
        public IDictionary<string, string> Properties
        {
            get
            {
                base.CheckUninitializedProperty("Properties");
                return (IDictionary<string, string>)base.ObjectData.Properties["Properties"];
            }
        }

        [Remote]
        public AlertStatus Status
        {
            get
            {
                base.CheckUninitializedProperty("Status");
                return (AlertStatus)base.ObjectData.Properties["Status"];
            }
            set
            {
                base.ObjectData.Properties["Status"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Status", value));
                }
            }
        }

        [Remote]
        public string Title
        {
            get
            {
                base.CheckUninitializedProperty("Title");
                return (string)base.ObjectData.Properties["Title"];
            }
            set
            {
                base.ObjectData.Properties["Title"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Title", value));
                }
            }
        }

        [Remote]
        public User User
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("User", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "User"));
                    base.ObjectData.ClientObjectProperties["User"] = user;
                }
                return user;
            }
        }

        [Remote]
        public int UserId
        {
            get
            {
                base.CheckUninitializedProperty("UserId");
                return (int)base.ObjectData.Properties["UserId"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Alert(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                //case "AlertFrequency":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["AlertFrequency"] = reader.ReadEnum<AlertFrequency>();
                //    break;
                case "AlertTemplateName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AlertTemplateName"] = reader.ReadString();
                    break;
                case "AlertTime":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AlertTime"] = reader.ReadDateTime();
                    break;
                //case "AlertType":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["AlertType"] = reader.ReadEnum<AlertType>();
                //    break;
                case "AlwaysNotify":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AlwaysNotify"] = reader.ReadBoolean();
                    break;
                //case "DeliveryChannels":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["DeliveryChannels"] = reader.ReadEnum<AlertDeliveryChannel>();
                //    break;
                //case "EventType":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["EventType"] = reader.ReadEnum<AlertEventType>();
                //    break;
                case "Filter":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Filter"] = reader.ReadString();
                    break;
                case "ID":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ID"] = reader.ReadGuid();
                    break;
                //case "Item":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("Item", this.Item, reader);
                //    this.Item.FromJson(reader);
                //    break;
                case "ItemID":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ItemID"] = reader.ReadInt32();
                    break;
                //case "List":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("List", this.List, reader);
                //    this.List.FromJson(reader);
                //    break;
                case "ListID":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListID"] = reader.ReadGuid();
                    break;
                case "ListUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListUrl"] = reader.ReadString();
                    break;
                case "Properties":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Properties"] = reader.ReadDictionary<string>();
                    break;
                //case "Status":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["Status"] = reader.ReadEnum<AlertStatus>();
                //    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                case "User":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("User", this.User, reader);
                    this.User.FromJson(reader);
                    break;
                case "UserId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UserId"] = reader.ReadInt32();
                    break;
            }
            return flag;
        }

        [Remote]
        public void UpdateAlert()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "UpdateAlert", null);
            context.AddQuery(query);
        }
    }
}