using System;

namespace Microsoft.SharePoint.Client.NetCore
{
    [Flags]
    public enum RenderListFormDataOptions
    {
        None = 0,
        ExcludeListSchema = 1,
        IncludeAttachments = 2,
        IncludeListViewData = 4
    }
}
