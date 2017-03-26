using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FileVersionEventCollection", ServerTypeId = "{098c4937-812c-449a-9d93-f4bb34e22323}")]
    public class FileVersionEventCollection : ClientObjectCollection<FileVersionEvent>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileVersionEventCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }
    }
}
