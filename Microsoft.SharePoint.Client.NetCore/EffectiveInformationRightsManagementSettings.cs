using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.EffectiveInformationRightsManagementSettings", ServerTypeId = "{7763bd9a-b98e-491d-82a8-252cbf76c64e}")]
    public sealed class EffectiveInformationRightsManagementSettings : ClientObject
    {
        [Remote]
        public bool AllowPrint
        {
            get
            {
                base.CheckUninitializedProperty("AllowPrint");
                return (bool)base.ObjectData.Properties["AllowPrint"];
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
        }

        [Remote]
        public bool AllowWriteCopy
        {
            get
            {
                base.CheckUninitializedProperty("AllowWriteCopy");
                return (bool)base.ObjectData.Properties["AllowWriteCopy"];
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
        }

        [Remote]
        public int DocumentAccessExpireDays
        {
            get
            {
                base.CheckUninitializedProperty("DocumentAccessExpireDays");
                return (int)base.ObjectData.Properties["DocumentAccessExpireDays"];
            }
        }

        [Remote]
        public DateTime DocumentLibraryProtectionExpireDate
        {
            get
            {
                base.CheckUninitializedProperty("DocumentLibraryProtectionExpireDate");
                return (DateTime)base.ObjectData.Properties["DocumentLibraryProtectionExpireDate"];
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
        }

        [Remote]
        public bool EnableDocumentBrowserPublishingView
        {
            get
            {
                base.CheckUninitializedProperty("EnableDocumentBrowserPublishingView");
                return (bool)base.ObjectData.Properties["EnableDocumentBrowserPublishingView"];
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
        }

        [Remote]
        public bool EnableLicenseCacheExpire
        {
            get
            {
                base.CheckUninitializedProperty("EnableLicenseCacheExpire");
                return (bool)base.ObjectData.Properties["EnableLicenseCacheExpire"];
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
        }

        [Remote]
        public bool IrmEnabled
        {
            get
            {
                base.CheckUninitializedProperty("IrmEnabled");
                return (bool)base.ObjectData.Properties["IrmEnabled"];
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
        }

        [Remote]
        public string PolicyDescription
        {
            get
            {
                base.CheckUninitializedProperty("PolicyDescription");
                return (string)base.ObjectData.Properties["PolicyDescription"];
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
        }

        [Remote]
        public SPEffectiveInformationRightsManagementSettingsSource SettingSource
        {
            get
            {
                base.CheckUninitializedProperty("SettingSource");
                return (SPEffectiveInformationRightsManagementSettingsSource)base.ObjectData.Properties["SettingSource"];
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
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public EffectiveInformationRightsManagementSettings(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "DocumentLibraryProtectionExpireDate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DocumentLibraryProtectionExpireDate"] = reader.ReadDateTime();
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
                case "SettingSource":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SettingSource"] = reader.ReadEnum<SPEffectiveInformationRightsManagementSettingsSource>();
                    break;
                case "TemplateId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TemplateId"] = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}
