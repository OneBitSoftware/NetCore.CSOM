using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public abstract class WebRequestExecutorFactory
    {
        public abstract WebRequestExecutor CreateWebRequestExecutor(ClientRuntimeContext context, string requestUrl);
    }
}