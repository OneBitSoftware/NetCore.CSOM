using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Workflow
{
    [ScriptType("SP.Workflow.WorkflowAssociation", ServerTypeId = "{5b590642-3966-4f67-b937-c1db8528a1d3}")]
    public sealed class WorkflowAssociation : ClientObject
    {
        [Remote]
        public bool AllowManual
        {
            get
            {
                base.CheckUninitializedProperty("AllowManual");
                return (bool)base.ObjectData.Properties["AllowManual"];
            }
            set
            {
                base.ObjectData.Properties["AllowManual"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowManual", value));
                }
            }
        }

        [Remote]
        public string AssociationData
        {
            get
            {
                base.CheckUninitializedProperty("AssociationData");
                return (string)base.ObjectData.Properties["AssociationData"];
            }
            set
            {
                base.ObjectData.Properties["AssociationData"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AssociationData", value));
                }
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
            set
            {
                base.ObjectData.Properties["AutoStartChange"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AutoStartChange", value));
                }
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
            set
            {
                base.ObjectData.Properties["AutoStartCreate"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AutoStartCreate", value));
                }
            }
        }

        [Remote]
        public Guid BaseId
        {
            get
            {
                base.CheckUninitializedProperty("BaseId");
                return (Guid)base.ObjectData.Properties["BaseId"];
            }
        }

        [Remote]
        public DateTime Created
        {
            get
            {
                base.CheckUninitializedProperty("Created");
                return (DateTime)base.ObjectData.Properties["Created"];
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
        public bool Enabled
        {
            get
            {
                base.CheckUninitializedProperty("Enabled");
                return (bool)base.ObjectData.Properties["Enabled"];
            }
            set
            {
                base.ObjectData.Properties["Enabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Enabled", value));
                }
            }
        }

        [Remote]
        public string HistoryListTitle
        {
            get
            {
                base.CheckUninitializedProperty("HistoryListTitle");
                return (string)base.ObjectData.Properties["HistoryListTitle"];
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
                base.ObjectData.Properties["HistoryListTitle"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "HistoryListTitle", value));
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
        public string InstantiationUrl
        {
            get
            {
                base.CheckUninitializedProperty("InstantiationUrl");
                return (string)base.ObjectData.Properties["InstantiationUrl"];
            }
        }

        [Remote]
        public string InternalName
        {
            get
            {
                base.CheckUninitializedProperty("InternalName");
                return (string)base.ObjectData.Properties["InternalName"];
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
        public Guid ListId
        {
            get
            {
                base.CheckUninitializedProperty("ListId");
                return (Guid)base.ObjectData.Properties["ListId"];
            }
        }

        [Remote]
        public DateTime Modified
        {
            get
            {
                base.CheckUninitializedProperty("Modified");
                return (DateTime)base.ObjectData.Properties["Modified"];
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
        public string TaskListTitle
        {
            get
            {
                base.CheckUninitializedProperty("TaskListTitle");
                return (string)base.ObjectData.Properties["TaskListTitle"];
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
                base.ObjectData.Properties["TaskListTitle"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "TaskListTitle", value));
                }
            }
        }

        [Remote]
        public Guid WebId
        {
            get
            {
                base.CheckUninitializedProperty("WebId");
                return (Guid)base.ObjectData.Properties["WebId"];
            }
        }

        internal void InitFromCreationInformation(WorkflowAssociationCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Name"] = creation.Name;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WorkflowAssociation(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "AssociationData":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AssociationData"] = reader.ReadString();
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
                case "BaseId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["BaseId"] = reader.ReadGuid();
                    break;
                case "Created":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Created"] = reader.ReadDateTime();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "Enabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Enabled"] = reader.ReadBoolean();
                    break;
                case "HistoryListTitle":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["HistoryListTitle"] = reader.ReadString();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "InstantiationUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["InstantiationUrl"] = reader.ReadString();
                    break;
                case "InternalName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["InternalName"] = reader.ReadString();
                    break;
                case "IsDeclarative":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsDeclarative"] = reader.ReadBoolean();
                    break;
                case "ListId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListId"] = reader.ReadGuid();
                    break;
                case "Modified":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Modified"] = reader.ReadDateTime();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "TaskListTitle":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TaskListTitle"] = reader.ReadString();
                    break;
                case "WebId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["WebId"] = reader.ReadGuid();
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
            this.RefreshLoad();
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
