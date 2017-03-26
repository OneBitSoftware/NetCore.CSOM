using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.EventReceiverDefinitionCollection", ServerTypeId = "{8aef5b03-f05e-46e9-9537-6c3aad574b7a}")]
    public class EventReceiverDefinitionCollection : ClientObjectCollection<EventReceiverDefinition>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EventReceiverDefinitionCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public EventReceiverDefinition GetById(Guid eventReceiverId)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, EventReceiverDefinition> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, EventReceiverDefinition>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, EventReceiverDefinition>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            EventReceiverDefinition eventReceiverDefinition = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(eventReceiverId, out eventReceiverDefinition))
            {
                return eventReceiverDefinition;
            }
            eventReceiverDefinition = new EventReceiverDefinition(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                eventReceiverId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[eventReceiverId] = eventReceiverDefinition;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(eventReceiverDefinition.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, eventReceiverDefinition);
            context.AddQuery(objectIdentityQuery);
            return eventReceiverDefinition;
        }

        [Remote]
        public EventReceiverDefinition Add(EventReceiverDefinitionCreationInformation eventReceiverCreationInformation)
        {
            ClientRuntimeContext context = base.Context;
            return new EventReceiverDefinition(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                eventReceiverCreationInformation
            }));
        }
    }
}
