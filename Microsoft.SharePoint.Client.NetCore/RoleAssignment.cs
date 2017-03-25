using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{

    [ScriptType("SP.RoleAssignment", ServerTypeId = "{07da03be-4d19-48f3-9c5f-7c67b134a93b}")]
    public sealed class RoleAssignment : ClientObject
    {
        [Remote]
        public Principal Member
        {
            get
            {
                object obj;
                Principal principal;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Member", out obj))
                {
                    principal = (Principal)obj;
                }
                else
                {
                    principal = new Principal(base.Context, new ObjectPathProperty(base.Context, base.Path, "Member"));
                    base.ObjectData.ClientObjectProperties["Member"] = principal;
                }
                return principal;
            }
        }

        [Remote]
        public int PrincipalId
        {
            get
            {
                base.CheckUninitializedProperty("PrincipalId");
                return (int)base.ObjectData.Properties["PrincipalId"];
            }
        }

        [Remote]
        public RoleDefinitionBindingCollection RoleDefinitionBindings
        {
            get
            {
                object obj;
                RoleDefinitionBindingCollection roleDefinitionBindingCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("RoleDefinitionBindings", out obj))
                {
                    roleDefinitionBindingCollection = (RoleDefinitionBindingCollection)obj;
                }
                else
                {
                    roleDefinitionBindingCollection = new RoleDefinitionBindingCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "RoleDefinitionBindings"));
                    base.ObjectData.ClientObjectProperties["RoleDefinitionBindings"] = roleDefinitionBindingCollection;
                }
                return roleDefinitionBindingCollection;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RoleAssignment(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            if (peekedName != null)
            {
                if (!(peekedName == "Member"))
                {
                    if (!(peekedName == "PrincipalId"))
                    {
                        if (peekedName == "RoleDefinitionBindings")
                        {
                            flag = true;
                            reader.ReadName();
                            base.UpdateClientObjectPropertyType("RoleDefinitionBindings", this.RoleDefinitionBindings, reader);
                            this.RoleDefinitionBindings.FromJson(reader);
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["PrincipalId"] = reader.ReadInt32();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Member", this.Member, reader);
                    this.Member.FromJson(reader);
                }
            }
            return flag;
        }

        [Remote]
        public void ImportRoleDefinitionBindings(RoleDefinitionBindingCollection roleDefinitionBindings)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "ImportRoleDefinitionBindings", new object[]
            {
                roleDefinitionBindings
            });
            context.AddQuery(query);
        }

        [Remote]
        public void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }
    }
}
