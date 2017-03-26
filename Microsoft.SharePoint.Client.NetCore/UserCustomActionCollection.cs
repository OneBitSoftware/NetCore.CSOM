using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.UserCustomActionCollection", ServerTypeId = "{70d1cb2d-d304-4d96-9b54-74b3f400fa28}")]
    public sealed class UserCustomActionCollection : ClientObjectCollection<UserCustomAction>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UserCustomActionCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public UserCustomAction GetById(Guid id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, UserCustomAction> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, UserCustomAction>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, UserCustomAction>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            UserCustomAction userCustomAction = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out userCustomAction))
            {
                return userCustomAction;
            }
            userCustomAction = new UserCustomAction(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = userCustomAction;
            }
            return userCustomAction;
        }

        [Remote]
        public void Clear()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Clear", null);
            context.AddQuery(query);
        }

        [Remote]
        public UserCustomAction Add()
        {
            ClientRuntimeContext context = base.Context;
            UserCustomAction userCustomAction = new UserCustomAction(context, new ObjectPathMethod(context, base.Path, "Add", null));
            base.AddChild(userCustomAction);
            return userCustomAction;
        }
    }
}
