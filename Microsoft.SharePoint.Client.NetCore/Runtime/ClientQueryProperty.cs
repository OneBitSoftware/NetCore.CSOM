using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ClientQueryProperty
    {
        public bool ScalarProperty;

        public bool ScalarPropertySet;

        public bool SelectAll;

        public bool SelectAllSet;

        public ClientQueryInternal Query;
    }
}
