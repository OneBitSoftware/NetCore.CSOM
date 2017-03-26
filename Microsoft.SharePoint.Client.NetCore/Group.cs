using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Group", ServerTypeId = "{e54ad5f1-ce4e-453b-b7f7-aea6556c9c40}")]
    public sealed class Group : Principal
    {
        [Remote]
        public bool AllowMembersEditMembership
        {
            get
            {
                base.CheckUninitializedProperty("AllowMembersEditMembership");
                return (bool)base.ObjectData.Properties["AllowMembersEditMembership"];
            }
            set
            {
                base.ObjectData.Properties["AllowMembersEditMembership"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowMembersEditMembership", value));
                }
            }
        }

        [Remote]
        public bool AllowRequestToJoinLeave
        {
            get
            {
                base.CheckUninitializedProperty("AllowRequestToJoinLeave");
                return (bool)base.ObjectData.Properties["AllowRequestToJoinLeave"];
            }
            set
            {
                base.ObjectData.Properties["AllowRequestToJoinLeave"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowRequestToJoinLeave", value));
                }
            }
        }

        [Remote]
        public bool AutoAcceptRequestToJoinLeave
        {
            get
            {
                base.CheckUninitializedProperty("AutoAcceptRequestToJoinLeave");
                return (bool)base.ObjectData.Properties["AutoAcceptRequestToJoinLeave"];
            }
            set
            {
                base.ObjectData.Properties["AutoAcceptRequestToJoinLeave"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AutoAcceptRequestToJoinLeave", value));
                }
            }
        }

        [Remote]
        public bool CanCurrentUserEditMembership
        {
            get
            {
                base.CheckUninitializedProperty("CanCurrentUserEditMembership");
                return (bool)base.ObjectData.Properties["CanCurrentUserEditMembership"];
            }
        }

        [Remote]
        public bool CanCurrentUserManageGroup
        {
            get
            {
                base.CheckUninitializedProperty("CanCurrentUserManageGroup");
                return (bool)base.ObjectData.Properties["CanCurrentUserManageGroup"];
            }
        }

        [Remote]
        public bool CanCurrentUserViewMembership
        {
            get
            {
                base.CheckUninitializedProperty("CanCurrentUserViewMembership");
                return (bool)base.ObjectData.Properties["CanCurrentUserViewMembership"];
            }
        }

        [Remote]
        public string Description
        {
            get
            {
                base.CheckUninitializedProperty("Description");
                return (string)base.ObjectData.Properties["Description"];
            }
            set
            {
                base.ObjectData.Properties["Description"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Description", value));
                }
            }
        }

        [Remote]
        public bool OnlyAllowMembersViewMembership
        {
            get
            {
                base.CheckUninitializedProperty("OnlyAllowMembersViewMembership");
                return (bool)base.ObjectData.Properties["OnlyAllowMembersViewMembership"];
            }
            set
            {
                base.ObjectData.Properties["OnlyAllowMembersViewMembership"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "OnlyAllowMembersViewMembership", value));
                }
            }
        }

        [Remote]
        public Principal Owner
        {
            get
            {
                object obj;
                Principal principal;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Owner", out obj))
                {
                    principal = (Principal)obj;
                }
                else
                {
                    principal = new Principal(base.Context, new ObjectPathProperty(base.Context, base.Path, "Owner"));
                    base.ObjectData.ClientObjectProperties["Owner"] = principal;
                }
                return principal;
            }
            set
            {
                base.ObjectData.ClientObjectProperties["Owner"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Owner", value));
                }
            }
        }

        [Remote]
        public string OwnerTitle
        {
            get
            {
                base.CheckUninitializedProperty("OwnerTitle");
                return (string)base.ObjectData.Properties["OwnerTitle"];
            }
        }

        [Remote]
        public string RequestToJoinLeaveEmailSetting
        {
            get
            {
                base.CheckUninitializedProperty("RequestToJoinLeaveEmailSetting");
                return (string)base.ObjectData.Properties["RequestToJoinLeaveEmailSetting"];
            }
            set
            {
                base.ObjectData.Properties["RequestToJoinLeaveEmailSetting"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "RequestToJoinLeaveEmailSetting", value));
                }
            }
        }

        [Remote]
        public UserCollection Users
        {
            get
            {
                object obj;
                UserCollection userCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Users", out obj))
                {
                    userCollection = (UserCollection)obj;
                }
                else
                {
                    userCollection = new UserCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Users"));
                    base.ObjectData.ClientObjectProperties["Users"] = userCollection;
                }
                return userCollection;
            }
        }

        internal void InitFromCreationInformation(GroupCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Title"] = creation.Title;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Group(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "AllowMembersEditMembership":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowMembersEditMembership"] = reader.ReadBoolean();
                    break;
                case "AllowRequestToJoinLeave":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowRequestToJoinLeave"] = reader.ReadBoolean();
                    break;
                case "AutoAcceptRequestToJoinLeave":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AutoAcceptRequestToJoinLeave"] = reader.ReadBoolean();
                    break;
                case "CanCurrentUserEditMembership":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CanCurrentUserEditMembership"] = reader.ReadBoolean();
                    break;
                case "CanCurrentUserManageGroup":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CanCurrentUserManageGroup"] = reader.ReadBoolean();
                    break;
                case "CanCurrentUserViewMembership":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CanCurrentUserViewMembership"] = reader.ReadBoolean();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "OnlyAllowMembersViewMembership":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["OnlyAllowMembersViewMembership"] = reader.ReadBoolean();
                    break;
                case "Owner":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Owner", this.Owner, reader);
                    this.Owner.FromJson(reader);
                    break;
                case "OwnerTitle":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["OwnerTitle"] = reader.ReadString();
                    break;
                case "RequestToJoinLeaveEmailSetting":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RequestToJoinLeaveEmailSetting"] = reader.ReadString();
                    break;
                case "Users":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Users", this.Users, reader);
                    this.Users.FromJson(reader);
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
    }
}