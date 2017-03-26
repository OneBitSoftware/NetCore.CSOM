using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RoleDefinitionCollection", ServerTypeId = "{964b9ab0-d026-4487-99d1-e06450963cc9}")]
    public sealed class RoleDefinitionCollection : ClientObjectCollection<RoleDefinition>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RoleDefinitionCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public RoleDefinition GetByName(string name)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (name == null)
                {
                    throw ClientUtility.CreateArgumentNullException("name");
                }
                if (name != null && name.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("name");
                }
                if (name != null && name.Length > 255)
                {
                    throw ClientUtility.CreateArgumentException("name");
                }
            }
            object obj;
            Dictionary<string, RoleDefinition> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByName", out obj))
            {
                dictionary = (Dictionary<string, RoleDefinition>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, RoleDefinition>();
                base.ObjectData.MethodReturnObjects["GetByName"] = dictionary;
            }
            RoleDefinition roleDefinition = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(name, out roleDefinition))
            {
                return roleDefinition;
            }
            roleDefinition = new RoleDefinition(context, new ObjectPathMethod(context, base.Path, "GetByName", new object[]
            {
                name
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[name] = roleDefinition;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(roleDefinition.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, roleDefinition);
            context.AddQuery(objectIdentityQuery);
            return roleDefinition;
        }

        [Remote]
        public RoleDefinition Add(RoleDefinitionCreationInformation parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (parameters == null)
                {
                    throw ClientUtility.CreateArgumentNullException("parameters");
                }
                if (parameters != null)
                {
                    if (parameters.Name == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("parameters.Name");
                    }
                    if (parameters.Name != null && parameters.Name.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Name");
                    }
                    if (parameters.Name != null && parameters.Name.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Name");
                    }
                    if (parameters.Name != null && !Regex.Match(parameters.Name, "^[^\\[\\]/\\\\:\\|<>\\+=;,\\?\\*'@]*$").Success)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Name");
                    }
                    if (parameters.Description != null && parameters.Description.Length > 512)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Description");
                    }
                    if (parameters.BasePermissions == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("parameters.BasePermissions");
                    }
                }
            }
            RoleDefinition roleDefinition = new RoleDefinition(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            roleDefinition.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(roleDefinition.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, roleDefinition);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(roleDefinition);
            roleDefinition.InitFromCreationInformation(parameters);
            return roleDefinition;
        }

        [Remote]
        public void RecreateMissingDefaultRoleDefinitions()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RecreateMissingDefaultRoleDefinitions", null);
            context.AddQuery(query);
        }

        [Remote]
        public RoleDefinition GetById(int id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<int, RoleDefinition> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<int, RoleDefinition>)obj;
            }
            else
            {
                dictionary = new Dictionary<int, RoleDefinition>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            RoleDefinition roleDefinition = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out roleDefinition))
            {
                return roleDefinition;
            }
            roleDefinition = new RoleDefinition(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = roleDefinition;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(roleDefinition.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, roleDefinition);
            context.AddQuery(objectIdentityQuery);
            return roleDefinition;
        }

        [Remote]
        public RoleDefinition GetByType(RoleType roleType)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<RoleType, RoleDefinition> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByType", out obj))
            {
                dictionary = (Dictionary<RoleType, RoleDefinition>)obj;
            }
            else
            {
                dictionary = new Dictionary<RoleType, RoleDefinition>();
                base.ObjectData.MethodReturnObjects["GetByType"] = dictionary;
            }
            RoleDefinition roleDefinition = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(roleType, out roleDefinition))
            {
                return roleDefinition;
            }
            roleDefinition = new RoleDefinition(context, new ObjectPathMethod(context, base.Path, "GetByType", new object[]
            {
                roleType
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[roleType] = roleDefinition;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(roleDefinition.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, roleDefinition);
            context.AddQuery(objectIdentityQuery);
            return roleDefinition;
        }
    }
}
