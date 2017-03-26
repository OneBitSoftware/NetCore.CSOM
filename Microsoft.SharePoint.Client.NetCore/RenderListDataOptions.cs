using System;

namespace Microsoft.SharePoint.Client.NetCore
{
    [Flags]
    public enum RenderListDataOptions
    {
        None = 0,
        ContextInfo = 1,
        ListData = 2,
        ListSchema = 4,
        MenuView = 8,
        ListContentType = 16,
        FileSystemItemId = 32,
        ClientFormSchema = 64,
        QuickLaunch = 128,
        Spotlight = 256,
        Visualization = 512,
        ViewMetadata = 1024,
        DisableAutoHyperlink = 2048,
        EnableMediaTAUrls = 4096,
        ParentInfo = 8192,
        PageContextInfo = 16384,
        ClientSideComponentManifest = 32768
    }
}