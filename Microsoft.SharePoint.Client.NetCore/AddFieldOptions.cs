using System;

namespace Microsoft.SharePoint.Client.NetCore
{
    [Flags]
    public enum AddFieldOptions
    {
        DefaultValue = 0,
        AddToDefaultContentType = 1,
        AddToNoContentType = 2,
        AddToAllContentTypes = 4,
        AddFieldInternalNameHint = 8,
        AddFieldToDefaultView = 16,
        AddFieldCheckDisplayName = 32
    }
}
