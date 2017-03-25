using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RoleAssignmentCollection", ServerTypeId = "{2690207a-e174-4d49-b2ca-cff663225dc1}")]
    public sealed class RoleAssignmentCollection : ClientObjectCollection<RoleAssignment>
    {
        [Remote]
        public GroupCollection Groups
        {
            get
            {
                object obj;
                GroupCollection groupCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Groups", out obj))
                {
                    groupCollection = (GroupCollection)obj;
                }
                else
                {
                    groupCollection = new GroupCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Groups"));
                    base.ObjectData.ClientObjectProperties["Groups"] = groupCollection;
                }
                return groupCollection;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RoleAssignmentCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            if (peekedName != null && peekedName == "Groups")
            {
                flag = true;
                reader.ReadName();
                base.UpdateClientObjectPropertyType("Groups", this.Groups, reader);
                this.Groups.FromJson(reader);
            }
            return flag;
        }

        [Remote]
        public RoleAssignment GetByPrincipal(Principal principalToFind)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && principalToFind == null)
            {
                throw ClientUtility.CreateArgumentNullException("principalToFind");
            }
            RoleAssignment roleAssignment = new RoleAssignment(context, new ObjectPathMethod(context, base.Path, "GetByPrincipal", new object[]
            {
                principalToFind
            }));
            roleAssignment.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(roleAssignment.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, roleAssignment);
            context.AddQuery(objectIdentityQuery);
            return roleAssignment;
        }

        [Remote]
        public RoleAssignment GetByPrincipalId(int principalId)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<int, RoleAssignment> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByPrincipalId", out obj))
            {
                dictionary = (Dictionary<int, RoleAssignment>)obj;
            }
            else
            {
                dictionary = new Dictionary<int, RoleAssignment>();
                base.ObjectData.MethodReturnObjects["GetByPrincipalId"] = dictionary;
            }
            RoleAssignment roleAssignment = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(principalId, out roleAssignment))
            {
                return roleAssignment;
            }
            roleAssignment = new RoleAssignment(context, new ObjectPathMethod(context, base.Path, "GetByPrincipalId", new object[]
            {
                principalId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[principalId] = roleAssignment;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(roleAssignment.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, roleAssignment);
            context.AddQuery(objectIdentityQuery);
            return roleAssignment;
        }

        [Remote]
        public RoleAssignment Add(Principal principal, RoleDefinitionBindingCollection roleBindings)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (principal == null)
                {
                    throw ClientUtility.CreateArgumentNullException("principal");
                }
                if (roleBindings == null)
                {
                    throw ClientUtility.CreateArgumentNullException("roleBindings");
                }
            }
            RoleAssignment roleAssignment = new RoleAssignment(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                principal,
                roleBindings
            }));
            roleAssignment.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(roleAssignment.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, roleAssignment);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(roleAssignment);
            return roleAssignment;
        }
    }
}
