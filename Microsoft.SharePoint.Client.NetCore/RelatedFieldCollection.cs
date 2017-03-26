using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RelatedFieldCollection", ServerTypeId = "{4703193f-e3ed-445b-8612-7c6218e0eb5a}")]
    public class RelatedFieldCollection : ClientObjectCollection<RelatedField>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RelatedFieldCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }
    }
}
