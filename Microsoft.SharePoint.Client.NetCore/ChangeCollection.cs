using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ChangeCollection", ServerTypeId = "{2ba7a459-eeda-42d0-90e2-fad3487ad0d3}")]
    public sealed class ChangeCollection : ClientObjectCollection<Change>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ChangeCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }
    }
}
