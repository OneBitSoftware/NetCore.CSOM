using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.InformationRightsManagementFileSettings", ServerTypeId = "{f920fbe4-9c61-4e05-bb11-702126533cb4}")]
    public sealed class InformationRightsManagementFileSettings : ClientObject
    {
        [Remote]
        public bool AllowPrint
        {
            get
            {
                base.CheckUninitializedProperty("AllowPrint");
                return (bool)base.ObjectData.Properties["AllowPrint"];
            }
            set
            {
                base.ObjectData.Properties["AllowPrint"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowPrint", value));
                }
            }
        }

        [Remote]
        public bool AllowScript
        {
            get
            {
                base.CheckUninitializedProperty("AllowScript");
                return (bool)base.ObjectData.Properties["AllowScript"];
            }
            set
            {
                base.ObjectData.Properties["AllowScript"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowScript", value));
                }
            }
        }

        [Remote]
        public bool AllowWriteCopy
        {
            get
            {
                base.CheckUninitializedProperty("AllowWriteCopy");
                return (bool)base.ObjectData.Properties["AllowWriteCopy"];
            }
            set
            {
                base.ObjectData.Properties["AllowWriteCopy"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowWriteCopy", value));
                }
            }
        }

        [Remote]
        public bool DisableDocumentBrowserView
        {
            get
            {
                base.CheckUninitializedProperty("DisableDocumentBrowserView");
                return (bool)base.ObjectData.Properties["DisableDocumentBrowserView"];
            }
            set
            {
                base.ObjectData.Properties["DisableDocumentBrowserView"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DisableDocumentBrowserView", value));
                }
            }
        }

        [Remote]
        public int DocumentAccessExpireDays
        {
            get
            {
                base.CheckUninitializedProperty("DocumentAccessExpireDays");
                return (int)base.ObjectData.Properties["DocumentAccessExpireDays"];
            }
            set
            {
                base.ObjectData.Properties["DocumentAccessExpireDays"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DocumentAccessExpireDays", value));
                }
            }
        }

        [Remote]
        public bool EnableDocumentAccessExpire
        {
            get
            {
                base.CheckUninitializedProperty("EnableDocumentAccessExpire");
                return (bool)base.ObjectData.Properties["EnableDocumentAccessExpire"];
            }
            set
            {
                base.ObjectData.Properties["EnableDocumentAccessExpire"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableDocumentAccessExpire", value));
                }
            }
        }

        [Remote]
        public bool EnableDocumentBrowserPublishingView
        {
            get
            {
                base.CheckUninitializedProperty("EnableDocumentBrowserPublishingView");
                return (bool)base.ObjectData.Properties["EnableDocumentBrowserPublishingView"];
            }
            set
            {
                base.ObjectData.Properties["EnableDocumentBrowserPublishingView"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableDocumentBrowserPublishingView", value));
                }
            }
        }

        [Remote]
        public bool EnableGroupProtection
        {
            get
            {
                base.CheckUninitializedProperty("EnableGroupProtection");
                return (bool)base.ObjectData.Properties["EnableGroupProtection"];
            }
            set
            {
                base.ObjectData.Properties["EnableGroupProtection"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableGroupProtection", value));
                }
            }
        }

        [Remote]
        public bool EnableLicenseCacheExpire
        {
            get
            {
                base.CheckUninitializedProperty("EnableLicenseCacheExpire");
                return (bool)base.ObjectData.Properties["EnableLicenseCacheExpire"];
            }
            set
            {
                base.ObjectData.Properties["EnableLicenseCacheExpire"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableLicenseCacheExpire", value));
                }
            }
        }

        [Remote]
        public string GroupName
        {
            get
            {
                base.CheckUninitializedProperty("GroupName");
                return (string)base.ObjectData.Properties["GroupName"];
            }
            set
            {
                base.ObjectData.Properties["GroupName"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "GroupName", value));
                }
            }
        }

        [Remote]
        public bool IrmEnabled
        {
            get
            {
                base.CheckUninitializedProperty("IrmEnabled");
                return (bool)base.ObjectData.Properties["IrmEnabled"];
            }
            set
            {
                base.ObjectData.Properties["IrmEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IrmEnabled", value));
                }
            }
        }

        [Remote]
        public int LicenseCacheExpireDays
        {
            get
            {
                base.CheckUninitializedProperty("LicenseCacheExpireDays");
                return (int)base.ObjectData.Properties["LicenseCacheExpireDays"];
            }
            set
            {
                base.ObjectData.Properties["LicenseCacheExpireDays"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "LicenseCacheExpireDays", value));
                }
            }
        }

        [Remote]
        public string PolicyDescription
        {
            get
            {
                base.CheckUninitializedProperty("PolicyDescription");
                return (string)base.ObjectData.Properties["PolicyDescription"];
            }
            set
            {
                base.ObjectData.Properties["PolicyDescription"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "PolicyDescription", value));
                }
            }
        }

        [Remote]
        public string PolicyTitle
        {
            get
            {
                base.CheckUninitializedProperty("PolicyTitle");
                return (string)base.ObjectData.Properties["PolicyTitle"];
            }
            set
            {
                base.ObjectData.Properties["PolicyTitle"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "PolicyTitle", value));
                }
            }
        }

        [Remote]
        public string TemplateId
        {
            get
            {
                base.CheckUninitializedProperty("TemplateId");
                return (string)base.ObjectData.Properties["TemplateId"];
            }
            set
            {
                base.ObjectData.Properties["TemplateId"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "TemplateId", value));
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public InformationRightsManagementFileSettings(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "AllowPrint":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowPrint"] = reader.ReadBoolean();
                    break;
                case "AllowScript":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowScript"] = reader.ReadBoolean();
                    break;
                case "AllowWriteCopy":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowWriteCopy"] = reader.ReadBoolean();
                    break;
                case "DisableDocumentBrowserView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisableDocumentBrowserView"] = reader.ReadBoolean();
                    break;
                case "DocumentAccessExpireDays":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DocumentAccessExpireDays"] = reader.ReadInt32();
                    break;
                case "EnableDocumentAccessExpire":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableDocumentAccessExpire"] = reader.ReadBoolean();
                    break;
                case "EnableDocumentBrowserPublishingView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableDocumentBrowserPublishingView"] = reader.ReadBoolean();
                    break;
                case "EnableGroupProtection":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableGroupProtection"] = reader.ReadBoolean();
                    break;
                case "EnableLicenseCacheExpire":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableLicenseCacheExpire"] = reader.ReadBoolean();
                    break;
                case "GroupName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["GroupName"] = reader.ReadString();
                    break;
                case "IrmEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IrmEnabled"] = reader.ReadBoolean();
                    break;
                case "LicenseCacheExpireDays":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LicenseCacheExpireDays"] = reader.ReadInt32();
                    break;
                case "PolicyDescription":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PolicyDescription"] = reader.ReadString();
                    break;
                case "PolicyTitle":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PolicyTitle"] = reader.ReadString();
                    break;
                case "TemplateId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TemplateId"] = reader.ReadString();
                    break;
            }
            return flag;
        }

        [Remote]
        public void Reset()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Reset", null);
            context.AddQuery(query);
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
