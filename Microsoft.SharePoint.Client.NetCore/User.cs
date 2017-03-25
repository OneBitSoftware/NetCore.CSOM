using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.User", ServerTypeId = "{ae70d2a4-ec46-4ed9-9b1e-9d0245754463}")]
    public sealed class User : Principal
    {
        [Remote]
        public AlertCollection Alerts
        {
            get
            {
                object obj;
                AlertCollection alertCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Alerts", out obj))
                {
                    alertCollection = (AlertCollection)obj;
                }
                else
                {
                    alertCollection = new AlertCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Alerts"));
                    base.ObjectData.ClientObjectProperties["Alerts"] = alertCollection;
                }
                return alertCollection;
            }
        }

        [Remote]
        public string Email
        {
            get
            {
                base.CheckUninitializedProperty("Email");
                return (string)base.ObjectData.Properties["Email"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["Email"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Email", value));
                }
            }
        }

        [Remote]
        public GroupCollection Groups
        {
            get
            {
                object obj;
                GroupCollection groupCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Groups", out obj))
                {
                    groupCollection = (GroupCollection)obj;
                }
                else
                {
                    groupCollection = new GroupCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Groups"));
                    base.ObjectData.ClientObjectProperties["Groups"] = groupCollection;
                }
                return groupCollection;
            }
        }

        [Remote]
        public bool IsShareByEmailGuestUser
        {
            get
            {
                base.CheckUninitializedProperty("IsShareByEmailGuestUser");
                return (bool)base.ObjectData.Properties["IsShareByEmailGuestUser"];
            }
        }

        [Remote]
        public bool IsSiteAdmin
        {
            get
            {
                base.CheckUninitializedProperty("IsSiteAdmin");
                return (bool)base.ObjectData.Properties["IsSiteAdmin"];
            }
            set
            {
                base.ObjectData.Properties["IsSiteAdmin"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IsSiteAdmin", value));
                }
            }
        }

        [Remote]
        public UserIdInfo UserId
        {
            get
            {
                base.CheckUninitializedProperty("UserId");
                return (UserIdInfo)base.ObjectData.Properties["UserId"];
            }
        }

        internal void InitFromCreationInformation(UserCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Email"] = creation.Email;
                base.ObjectData.Properties["LoginName"] = creation.LoginName;
                base.ObjectData.Properties["Title"] = creation.Title;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public User(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
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
                if (!(peekedName == "Alerts"))
                {
                    if (!(peekedName == "Email"))
                    {
                        if (!(peekedName == "Groups"))
                        {
                            if (!(peekedName == "IsShareByEmailGuestUser"))
                            {
                                if (!(peekedName == "IsSiteAdmin"))
                                {
                                    if (peekedName == "UserId")
                                    {
                                        flag = true;
                                        reader.ReadName();
                                        base.ObjectData.Properties["UserId"] = reader.Read<UserIdInfo>();
                                    }
                                }
                                else
                                {
                                    flag = true;
                                    reader.ReadName();
                                    base.ObjectData.Properties["IsSiteAdmin"] = reader.ReadBoolean();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["IsShareByEmailGuestUser"] = reader.ReadBoolean();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.UpdateClientObjectPropertyType("Groups", this.Groups, reader);
                            this.Groups.FromJson(reader);
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["Email"] = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Alerts", this.Alerts, reader);
                    this.Alerts.FromJson(reader);
                }
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
    }
}