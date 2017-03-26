using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Workflow
{

    [ScriptType("SP.Workflow.WorkflowTemplate", ServerTypeId = "{36de6dbb-60d6-4131-b47f-e895798e1e93}")]
    public sealed class WorkflowTemplate : ClientObject
    {
        [Remote]
        public bool AllowManual
        {
            get
            {
                base.CheckUninitializedProperty("AllowManual");
                return (bool)base.ObjectData.Properties["AllowManual"];
            }
        }

        [Remote]
        public string AssociationUrl
        {
            get
            {
                base.CheckUninitializedProperty("AssociationUrl");
                return (string)base.ObjectData.Properties["AssociationUrl"];
            }
        }

        [Remote]
        public bool AutoStartChange
        {
            get
            {
                base.CheckUninitializedProperty("AutoStartChange");
                return (bool)base.ObjectData.Properties["AutoStartChange"];
            }
        }

        [Remote]
        public bool AutoStartCreate
        {
            get
            {
                base.CheckUninitializedProperty("AutoStartCreate");
                return (bool)base.ObjectData.Properties["AutoStartCreate"];
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
        public bool IsDeclarative
        {
            get
            {
                base.CheckUninitializedProperty("IsDeclarative");
                return (bool)base.ObjectData.Properties["IsDeclarative"];
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
        }

        [Remote]
        public BasePermissions PermissionsManual
        {
            get
            {
                base.CheckUninitializedProperty("PermissionsManual");
                return (BasePermissions)base.ObjectData.Properties["PermissionsManual"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WorkflowTemplate(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "AllowManual":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowManual"] = reader.ReadBoolean();
                    break;
                case "AssociationUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AssociationUrl"] = reader.ReadString();
                    break;
                case "AutoStartChange":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AutoStartChange"] = reader.ReadBoolean();
                    break;
                case "AutoStartCreate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AutoStartCreate"] = reader.ReadBoolean();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "IsDeclarative":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsDeclarative"] = reader.ReadBoolean();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "PermissionsManual":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PermissionsManual"] = reader.Read<BasePermissions>();
                    break;
            }
            return flag;
        }
    }
}
