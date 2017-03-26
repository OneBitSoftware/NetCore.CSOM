using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.VisualizationAppMappedViewCollection", ServerTypeId = "{97c60f7b-3061-47c1-a65d-444d8ead845d}")]
    public sealed class VisualizationAppMappedViewCollection : ClientObjectCollection<View>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualizationAppMappedViewCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }
    }
}