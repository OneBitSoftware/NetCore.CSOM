using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FieldLink", ServerTypeId = "{e2d99203-868f-4211-ac76-f6bca0ff94ee}")]
    public class FieldLink : ClientObject
    {
        [Remote]
        public string DisplayName
        {
            get
            {
                base.CheckUninitializedProperty("DisplayName");
                return (string)base.ObjectData.Properties["DisplayName"];
            }
            set
            {
                base.ObjectData.Properties["DisplayName"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DisplayName", value));
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
            set
            {
                base.ObjectData.Properties["Hidden"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Hidden", value));
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
        public string Name
        {
            get
            {
                base.CheckUninitializedProperty("Name");
                return (string)base.ObjectData.Properties["Name"];
            }
        }

        [Remote]
        public bool ReadOnly
        {
            get
            {
                base.CheckUninitializedProperty("ReadOnly");
                return (bool)base.ObjectData.Properties["ReadOnly"];
            }
            set
            {
                base.ObjectData.Properties["ReadOnly"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ReadOnly", value));
                }
            }
        }

        [Remote]
        public bool Required
        {
            get
            {
                base.CheckUninitializedProperty("Required");
                return (bool)base.ObjectData.Properties["Required"];
            }
            set
            {
                base.ObjectData.Properties["Required"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Required", value));
                }
            }
        }

        [Remote]
        public bool ShowInDisplayForm
        {
            get
            {
                base.CheckUninitializedProperty("ShowInDisplayForm");
                return (bool)base.ObjectData.Properties["ShowInDisplayForm"];
            }
            set
            {
                base.ObjectData.Properties["ShowInDisplayForm"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ShowInDisplayForm", value));
                }
            }
        }

        internal void InitFromCreationInformation(FieldLinkCreationInformation creation)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FieldLink(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "DisplayName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisplayName"] = reader.ReadString();
                    break;
                case "Hidden":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Hidden"] = reader.ReadBoolean();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "ReadOnly":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReadOnly"] = reader.ReadBoolean();
                    break;
                case "Required":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Required"] = reader.ReadBoolean();
                    break;
                case "ShowInDisplayForm":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ShowInDisplayForm"] = reader.ReadBoolean();
                    break;
            }
            return flag;
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
