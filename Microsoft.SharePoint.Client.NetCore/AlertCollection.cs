using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.AlertCollection", ServerTypeId = "{86531f9b-b741-453d-96fc-5f05f038000a}")]
    public class AlertCollection : ClientObjectCollection<Alert>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AlertCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public Alert GetById(Guid idAlert)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, Alert> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, Alert>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, Alert>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            Alert alert = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(idAlert, out alert))
            {
                return alert;
            }
            alert = new Alert(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                idAlert
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[idAlert] = alert;
            }
            return alert;
        }

        [Remote]
        public ClientResult<bool> Contains(Guid idAlert)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "Contains", new object[]
            {
                idAlert
            });
            context.AddQuery(clientAction);
            ClientResult<bool> clientResult = new ClientResult<bool>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<Guid> Add(AlertCreationInformation alertCreationInformation)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (alertCreationInformation == null)
                {
                    throw ClientUtility.CreateArgumentNullException("alertCreationInformation");
                }
                if (alertCreationInformation != null && alertCreationInformation.User == null)
                {
                    throw ClientUtility.CreateArgumentNullException("alertCreationInformation.User");
                }
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "Add", new object[]
            {
                alertCreationInformation
            });
            context.AddQuery(clientAction);
            ClientResult<Guid> clientResult = new ClientResult<Guid>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public void DeleteAlertAtIndex(int index)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteAlertAtIndex", new object[]
            {
                index
            });
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteAlert(Guid idAlert)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteAlert", new object[]
            {
                idAlert
            });
            context.AddQuery(query);
        }
    }
}