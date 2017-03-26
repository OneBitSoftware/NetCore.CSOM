using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.UserCustomAction", ServerTypeId = "{232f8709-5dfd-44cf-a35b-7d8538c9336e}")]
    public class UserCustomAction : ClientObject
    {
        [Remote]
        public string CommandUIExtension
        {
            get
            {
                base.CheckUninitializedProperty("CommandUIExtension");
                return (string)base.ObjectData.Properties["CommandUIExtension"];
            }
            set
            {
                base.ObjectData.Properties["CommandUIExtension"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "CommandUIExtension", value));
                }
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
        public UserResource DescriptionResource
        {
            get
            {
                object obj;
                UserResource userResource;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("DescriptionResource", out obj))
                {
                    userResource = (UserResource)obj;
                }
                else
                {
                    userResource = new UserResource(base.Context, new ObjectPathProperty(base.Context, base.Path, "DescriptionResource"));
                    base.ObjectData.ClientObjectProperties["DescriptionResource"] = userResource;
                }
                return userResource;
            }
        }

        [Remote]
        public string Group
        {
            get
            {
                base.CheckUninitializedProperty("Group");
                return (string)base.ObjectData.Properties["Group"];
            }
            set
            {
                base.ObjectData.Properties["Group"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Group", value));
                }
            }
        }

        [Remote]
        public Guid Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (Guid)base.ObjectData.Properties["Id"];
            }
        }

        [Remote]
        public string ImageUrl
        {
            get
            {
                base.CheckUninitializedProperty("ImageUrl");
                return (string)base.ObjectData.Properties["ImageUrl"];
            }
            set
            {
                base.ObjectData.Properties["ImageUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ImageUrl", value));
                }
            }
        }

        [Remote]
        public string Location
        {
            get
            {
                base.CheckUninitializedProperty("Location");
                return (string)base.ObjectData.Properties["Location"];
            }
            set
            {
                base.ObjectData.Properties["Location"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Location", value));
                }
            }
        }

        [Remote]
        public string Name
        {
            get
            {
                base.CheckUninitializedProperty("Name");
                return (string)base.ObjectData.Properties["Name"];
            }
            set
            {
                base.ObjectData.Properties["Name"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Name", value));
                }
            }
        }

        [Remote]
        public string RegistrationId
        {
            get
            {
                base.CheckUninitializedProperty("RegistrationId");
                return (string)base.ObjectData.Properties["RegistrationId"];
            }
            set
            {
                base.ObjectData.Properties["RegistrationId"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "RegistrationId", value));
                }
            }
        }

        [Remote]
        public UserCustomActionRegistrationType RegistrationType
        {
            get
            {
                base.CheckUninitializedProperty("RegistrationType");
                return (UserCustomActionRegistrationType)base.ObjectData.Properties["RegistrationType"];
            }
            set
            {
                base.ObjectData.Properties["RegistrationType"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "RegistrationType", value));
                }
            }
        }

        [Remote]
        public BasePermissions Rights
        {
            get
            {
                base.CheckUninitializedProperty("Rights");
                return (BasePermissions)base.ObjectData.Properties["Rights"];
            }
            set
            {
                if (base.Context.ValidateOnClient && value == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value");
                }
                base.ObjectData.Properties["Rights"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Rights", value));
                }
            }
        }

        [Remote]
        public UserCustomActionScope Scope
        {
            get
            {
                base.CheckUninitializedProperty("Scope");
                return (UserCustomActionScope)base.ObjectData.Properties["Scope"];
            }
        }

        [Remote]
        public string ScriptBlock
        {
            get
            {
                base.CheckUninitializedProperty("ScriptBlock");
                return (string)base.ObjectData.Properties["ScriptBlock"];
            }
            set
            {
                base.ObjectData.Properties["ScriptBlock"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ScriptBlock", value));
                }
            }
        }

        [Remote]
        public string ScriptSrc
        {
            get
            {
                base.CheckUninitializedProperty("ScriptSrc");
                return (string)base.ObjectData.Properties["ScriptSrc"];
            }
            set
            {
                base.ObjectData.Properties["ScriptSrc"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ScriptSrc", value));
                }
            }
        }

        [Remote]
        public int Sequence
        {
            get
            {
                base.CheckUninitializedProperty("Sequence");
                return (int)base.ObjectData.Properties["Sequence"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value < 0)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                    if (value > 65536)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["Sequence"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Sequence", value));
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
        public UserResource TitleResource
        {
            get
            {
                object obj;
                UserResource userResource;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("TitleResource", out obj))
                {
                    userResource = (UserResource)obj;
                }
                else
                {
                    userResource = new UserResource(base.Context, new ObjectPathProperty(base.Context, base.Path, "TitleResource"));
                    base.ObjectData.ClientObjectProperties["TitleResource"] = userResource;
                }
                return userResource;
            }
        }

        [Remote]
        public string Url
        {
            get
            {
                base.CheckUninitializedProperty("Url");
                return (string)base.ObjectData.Properties["Url"];
            }
            set
            {
                base.ObjectData.Properties["Url"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Url", value));
                }
            }
        }

        [Remote]
        public string VersionOfUserCustomAction
        {
            get
            {
                base.CheckUninitializedProperty("VersionOfUserCustomAction");
                return (string)base.ObjectData.Properties["VersionOfUserCustomAction"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UserCustomAction(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "CommandUIExtension":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CommandUIExtension"] = reader.ReadString();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "DescriptionResource":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("DescriptionResource", this.DescriptionResource, reader);
                    this.DescriptionResource.FromJson(reader);
                    break;
                case "Group":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Group"] = reader.ReadString();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "ImageUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ImageUrl"] = reader.ReadString();
                    break;
                case "Location":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Location"] = reader.ReadString();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "RegistrationId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RegistrationId"] = reader.ReadString();
                    break;
                case "RegistrationType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RegistrationType"] = reader.ReadEnum<UserCustomActionRegistrationType>();
                    break;
                case "Rights":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Rights"] = reader.Read<BasePermissions>();
                    break;
                case "Scope":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Scope"] = reader.ReadEnum<UserCustomActionScope>();
                    break;
                case "ScriptBlock":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ScriptBlock"] = reader.ReadString();
                    break;
                case "ScriptSrc":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ScriptSrc"] = reader.ReadString();
                    break;
                case "Sequence":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Sequence"] = reader.ReadInt32();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                case "TitleResource":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("TitleResource", this.TitleResource, reader);
                    this.TitleResource.FromJson(reader);
                    break;
                case "Url":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Url"] = reader.ReadString();
                    break;
                case "VersionOfUserCustomAction":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["VersionOfUserCustomAction"] = reader.ReadString();
                    break;
            }
            return flag;
        }

        [Remote]
        public virtual void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
            this.RefreshLoad();
        }

        [Remote]
        public virtual void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }
    }
}
