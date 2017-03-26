namespace Microsoft.SharePoint.Client.NetCore
{
    public enum ViewType
    {
        None,
        Html,
        Grid = 2048,
        Calendar = 524288,
        Recurrence = 8193,
        Chart = 131072,
        Gantt = 67108864
    }
}
