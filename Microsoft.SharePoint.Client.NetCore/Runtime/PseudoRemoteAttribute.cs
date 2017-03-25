using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class PseudoRemoteAttribute : Attribute
    {
        public string Name
        {
            get;
            set;
        }
    }
}