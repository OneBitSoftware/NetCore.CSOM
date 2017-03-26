using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore.Workflow
{
    [ScriptType("SP.Workflow.WorkflowAssociationCollection", ServerTypeId = "{4e1196ea-ce71-4aa9-b3c0-3f8da05deec9}")]
    public class WorkflowAssociationCollection : ClientObjectCollection<WorkflowAssociation>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WorkflowAssociationCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public virtual WorkflowAssociation GetById(Guid associationId)
        {
            ClientRuntimeContext context = base.Context;
            return new WorkflowAssociation(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                associationId
            }));
        }

        [Remote]
        public WorkflowAssociation Add(WorkflowAssociationCreationInformation parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && parameters == null)
            {
                throw ClientUtility.CreateArgumentNullException("parameters");
            }
            WorkflowAssociation workflowAssociation = new WorkflowAssociation(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            workflowAssociation.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(workflowAssociation.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, workflowAssociation);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(workflowAssociation);
            workflowAssociation.InitFromCreationInformation(parameters);
            return workflowAssociation;
        }

        [Remote]
        public WorkflowAssociation GetByName(string name)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<string, WorkflowAssociation> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByName", out obj))
            {
                dictionary = (Dictionary<string, WorkflowAssociation>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, WorkflowAssociation>();
                base.ObjectData.MethodReturnObjects["GetByName"] = dictionary;
            }
            WorkflowAssociation workflowAssociation = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(name, out workflowAssociation))
            {
                return workflowAssociation;
            }
            workflowAssociation = new WorkflowAssociation(context, new ObjectPathMethod(context, base.Path, "GetByName", new object[]
            {
                name
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[name] = workflowAssociation;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(workflowAssociation.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, workflowAssociation);
            context.AddQuery(objectIdentityQuery);
            return workflowAssociation;
        }
    }
}
