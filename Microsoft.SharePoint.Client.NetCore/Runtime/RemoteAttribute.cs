using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class RemoteAttribute : Attribute
    {
        public string Name
        {
            get;
            set;
        }
    }
}