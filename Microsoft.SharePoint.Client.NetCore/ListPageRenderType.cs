using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public enum ListPageRenderType
    {
        Undefined,
        MultipeWePart,
        JSLinkCustomization,
        XslLinkCustomization,
        NoSPList,
        HasBusinessDataField,
        HasTaskOutcomeField,
        HasPublishingfield,
        HasGeolocationField,
        HasCustomActionWithCode,
        HasMetadataNavFeature,
        SpecialViewType,
        ListTypeNoSupportForModernMode,
        AnonymousUser,
        ListSettingOff,
        SiteSettingOff,
        WebSettingOff,
        TenantSettingOff,
        CustomizedForm,
        DocLibNewForm,
        UnsupportedFieldTypeInForm,
        InvalidFieldTypeInForm,
        InvalidControModeInForm,
        CustomizedPage,
        ListTemplateNotSupported,
        Modern = 100
    }
}
