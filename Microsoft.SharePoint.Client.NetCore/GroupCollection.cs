using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.GroupCollection", ServerTypeId = "{0b9f0e6c-2c15-425e-b0b2-961f78bf1ecf}")]
    public class GroupCollection : ClientObjectCollection<Group>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public GroupCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public Group GetByName(string name)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<string, Group> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByName", out obj))
            {
                dictionary = (Dictionary<string, Group>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, Group>();
                base.ObjectData.MethodReturnObjects["GetByName"] = dictionary;
            }
            Group group = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(name, out group))
            {
                return group;
            }
            group = new Group(context, new ObjectPathMethod(context, base.Path, "GetByName", new object[]
            {
                name
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[name] = group;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(group.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, group);
            context.AddQuery(objectIdentityQuery);
            return group;
        }

        [Remote]
        public Group GetById(int id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<int, Group> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<int, Group>)obj;
            }
            else
            {
                dictionary = new Dictionary<int, Group>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            Group group = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out group))
            {
                return group;
            }
            group = new Group(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = group;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(group.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, group);
            context.AddQuery(objectIdentityQuery);
            return group;
        }

        [Remote]
        public Group Add(GroupCreationInformation parameters)
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
                    if (parameters.Title == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("parameters.Title");
                    }
                    if (parameters.Title != null && parameters.Title.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Title");
                    }
                    if (parameters.Title != null && parameters.Title.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Title");
                    }
                    if (parameters.Title != null && !Regex.Match(parameters.Title, "[^\\s\"/\\\\\\[\\]:|<>+=;,?*'@]+[^\"/\\\\\\[\\]:|<>+=;,?*'@]*").Success)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Title");
                    }
                    if (parameters.Description != null && parameters.Description.Length > 512)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Description");
                    }
                }
            }
            Group group = new Group(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            group.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(group.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, group);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(group);
            group.InitFromCreationInformation(parameters);
            return group;
        }

        [Remote]
        public void RemoveByLoginName(string loginName)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RemoveByLoginName", new object[]
            {
                loginName
            });
            context.AddQuery(query);
        }

        [Remote]
        public void RemoveById(int id)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RemoveById", new object[]
            {
                id
            });
            context.AddQuery(query);
        }

        [Remote]
        public void Remove(Group group)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && group == null)
            {
                throw ClientUtility.CreateArgumentNullException("group");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "Remove", new object[]
            {
                group
            });
            context.AddQuery(query);
            base.RemoveChild(group);
        }
    }
}
