using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public interface IScriptTypeFactory
    {
        IFromJson CreateObjectFromScriptType(string scriptTypeName, ClientRuntimeContext context);
    }
}
