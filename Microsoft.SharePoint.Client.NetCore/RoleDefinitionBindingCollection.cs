using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RoleDefinitionBindingCollection", ServerTypeId = "{07bf1941-6953-4761-b114-58374b4aaf57}")]
    public sealed class RoleDefinitionBindingCollection : ClientObjectCollection<RoleDefinition>
    {
        private void OnRemoveAll()
        {
            List<object> data = base.Data;
            while (data.Count > 0)
            {
                data.RemoveAt(data.Count - 1);
            }
        }

        public RoleDefinitionBindingCollection(ClientRuntimeContext context) : this(context, new ObjectPathConstructor(context, "{07bf1941-6953-4761-b114-58374b4aaf57}", null))
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RoleDefinitionBindingCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public void Add(RoleDefinition roleDefinition)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && roleDefinition == null)
            {
                throw ClientUtility.CreateArgumentNullException("roleDefinition");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "Add", new object[]
            {
                roleDefinition
            });
            context.AddQuery(query);
            base.AddChild(roleDefinition);
        }

        [Remote]
        public void Remove(RoleDefinition roleDefinition)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && roleDefinition == null)
            {
                throw ClientUtility.CreateArgumentNullException("roleDefinition");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "Remove", new object[]
            {
                roleDefinition
            });
            context.AddQuery(query);
            base.RemoveChild(roleDefinition);
        }

        [Remote]
        public void RemoveAll()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RemoveAll", null);
            context.AddQuery(query);
            this.OnRemoveAll();
        }
    }
}