using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RoleDefinition", ServerTypeId = "{aa7ecb4a-9c7e-4ad9-bd20-58a2775e5ad7}")]
    public sealed class RoleDefinition : ClientObject
    {
        [Remote]
        public BasePermissions BasePermissions
        {
            get
            {
                base.CheckUninitializedProperty("BasePermissions");
                return (BasePermissions)base.ObjectData.Properties["BasePermissions"];
            }
            set
            {
                if (base.Context.ValidateOnClient && value == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value");
                }
                base.ObjectData.Properties["BasePermissions"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "BasePermissions", value));
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
                if (base.Context.ValidateOnClient && value != null && value.Length > 512)
                {
                    throw ClientUtility.CreateArgumentException("value");
                }
                base.ObjectData.Properties["Description"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Description", value));
                }
            }
        }

        [Remote]
        public bool Hidden
        {
            get
            {
                base.CheckUninitializedProperty("Hidden");
                return (bool)base.ObjectData.Properties["Hidden"];
            }
        }

        [Remote]
        public int Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (int)base.ObjectData.Properties["Id"];
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
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                    if (value != null && value.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["Name"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Name", value));
                }
            }
        }

        [Remote]
        public int Order
        {
            get
            {
                base.CheckUninitializedProperty("Order");
                return (int)base.ObjectData.Properties["Order"];
            }
            set
            {
                base.ObjectData.Properties["Order"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Order", value));
                }
            }
        }

        [Remote]
        public RoleType RoleTypeKind
        {
            get
            {
                base.CheckUninitializedProperty("RoleTypeKind");
                return (RoleType)base.ObjectData.Properties["RoleTypeKind"];
            }
        }

        internal void InitFromCreationInformation(RoleDefinitionCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Description"] = creation.Description;
                base.ObjectData.Properties["Name"] = creation.Name;
                base.ObjectData.Properties["Order"] = creation.Order;
                base.ObjectData.Properties["BasePermissions"] = creation.BasePermissions;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RoleDefinition(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "BasePermissions":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["BasePermissions"] = reader.Read<BasePermissions>();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "Hidden":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Hidden"] = reader.ReadBoolean();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadInt32();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "Order":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Order"] = reader.ReadInt32();
                    break;
                case "RoleTypeKind":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RoleTypeKind"] = reader.ReadEnum<RoleType>();
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
