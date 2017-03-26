using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class InformationRightsManagementFileSettingsPropertyNames
    {
        public const string AllowPrint = "AllowPrint";

        public const string AllowScript = "AllowScript";

        public const string AllowWriteCopy = "AllowWriteCopy";

        public const string DisableDocumentBrowserView = "DisableDocumentBrowserView";

        public const string DocumentAccessExpireDays = "DocumentAccessExpireDays";

        public const string EnableDocumentAccessExpire = "EnableDocumentAccessExpire";

        public const string EnableDocumentBrowserPublishingView = "EnableDocumentBrowserPublishingView";

        public const string EnableGroupProtection = "EnableGroupProtection";

        public const string EnableLicenseCacheExpire = "EnableLicenseCacheExpire";

        public const string GroupName = "GroupName";

        public const string IrmEnabled = "IrmEnabled";

        public const string LicenseCacheExpireDays = "LicenseCacheExpireDays";

        public const string PolicyDescription = "PolicyDescription";

        public const string PolicyTitle = "PolicyTitle";

        public const string TemplateId = "TemplateId";
    }
}
