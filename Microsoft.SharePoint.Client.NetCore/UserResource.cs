using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.UserResource", ServerTypeId = "{2b2affeb-3ccd-4996-9864-211c960e647c}")]
    public sealed class UserResource : ClientObject
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UserResource(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public ClientResult<string> GetValueForUICulture(string cultureName)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (cultureName == null)
                {
                    throw ClientUtility.CreateArgumentNullException("cultureName");
                }
                if (cultureName != null && cultureName.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("cultureName");
                }
            }
            object obj;
            Dictionary<string, ClientResult<string>> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetValueForUICulture", out obj))
            {
                dictionary = (Dictionary<string, ClientResult<string>>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, ClientResult<string>>();
                base.ObjectData.MethodReturnObjects["GetValueForUICulture"] = dictionary;
            }
            ClientResult<string> clientResult = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(cultureName, out clientResult))
            {
                return clientResult;
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetValueForUICulture", new object[]
            {
                cultureName
            });
            context.AddQuery(clientAction);
            clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            if (!context.DisableReturnValueCache)
            {
                dictionary[cultureName] = clientResult;
            }
            return clientResult;
        }

        [Remote]
        public void SetValueForUICulture(string cultureName, string value)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (cultureName == null)
                {
                    throw ClientUtility.CreateArgumentNullException("cultureName");
                }
                if (cultureName != null && cultureName.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("cultureName");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "SetValueForUICulture", new object[]
            {
                cultureName,
                value
            });
            context.AddQuery(query);
        }
    }
}