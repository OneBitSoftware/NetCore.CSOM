using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.SecurableObject", ServerTypeId = "{1b1bf348-994e-44fd-823f-0748f5ad94c8}")]
    public class SecurableObject : ClientObject
    {
        [Remote]
        public SecurableObject FirstUniqueAncestorSecurableObject
        {
            get
            {
                object obj;
                SecurableObject securableObject;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("FirstUniqueAncestorSecurableObject", out obj))
                {
                    securableObject = (SecurableObject)obj;
                }
                else
                {
                    securableObject = new SecurableObject(base.Context, new ObjectPathProperty(base.Context, base.Path, "FirstUniqueAncestorSecurableObject"));
                    base.ObjectData.ClientObjectProperties["FirstUniqueAncestorSecurableObject"] = securableObject;
                }
                return securableObject;
            }
        }

        [Remote]
        public bool HasUniqueRoleAssignments
        {
            get
            {
                base.CheckUninitializedProperty("HasUniqueRoleAssignments");
                return (bool)base.ObjectData.Properties["HasUniqueRoleAssignments"];
            }
        }

        [Remote]
        public RoleAssignmentCollection RoleAssignments
        {
            get
            {
                object obj;
                RoleAssignmentCollection roleAssignmentCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("RoleAssignments", out obj))
                {
                    roleAssignmentCollection = (RoleAssignmentCollection)obj;
                }
                else
                {
                    roleAssignmentCollection = new RoleAssignmentCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "RoleAssignments"));
                    base.ObjectData.ClientObjectProperties["RoleAssignments"] = roleAssignmentCollection;
                }
                return roleAssignmentCollection;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public SecurableObject(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "FirstUniqueAncestorSecurableObject"))
                {
                    if (!(peekedName == "HasUniqueRoleAssignments"))
                    {
                        if (peekedName == "RoleAssignments")
                        {
                            flag = true;
                            reader.ReadName();
                            base.UpdateClientObjectPropertyType("RoleAssignments", this.RoleAssignments, reader);
                            this.RoleAssignments.FromJson(reader);
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["HasUniqueRoleAssignments"] = reader.ReadBoolean();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("FirstUniqueAncestorSecurableObject", this.FirstUniqueAncestorSecurableObject, reader);
                    this.FirstUniqueAncestorSecurableObject.FromJson(reader);
                }
            }
            return flag;
        }

        [Remote]
        public virtual void ResetRoleInheritance()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "ResetRoleInheritance", null);
            context.AddQuery(query);
        }

        [Remote]
        public virtual void BreakRoleInheritance(bool copyRoleAssignments, bool clearSubscopes)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "BreakRoleInheritance", new object[]
            {
                copyRoleAssignments,
                clearSubscopes
            });
            context.AddQuery(query);
        }
    }
}

