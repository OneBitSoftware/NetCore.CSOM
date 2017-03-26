using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FieldLinkCollection", ServerTypeId = "{6d87e76a-b8a8-4634-8170-082b1d454bfd}")]
    public class FieldLinkCollection : ClientObjectCollection<FieldLink>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FieldLinkCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public FieldLink GetById(Guid id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, FieldLink> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, FieldLink>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, FieldLink>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            FieldLink fieldLink = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out fieldLink))
            {
                return fieldLink;
            }
            fieldLink = new FieldLink(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = fieldLink;
            }
            return fieldLink;
        }

        [Remote]
        public FieldLink Add(FieldLinkCreationInformation parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (parameters == null)
                {
                    throw ClientUtility.CreateArgumentNullException("parameters");
                }
                if (parameters != null && parameters.Field == null)
                {
                    throw ClientUtility.CreateArgumentNullException("parameters.Field");
                }
            }
            FieldLink fieldLink = new FieldLink(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            fieldLink.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(fieldLink.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, fieldLink);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(fieldLink);
            fieldLink.InitFromCreationInformation(parameters);
            return fieldLink;
        }

        [Remote]
        public void Reorder(string[] internalNames)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Reorder", new object[]
            {
                internalNames
            });
            context.AddQuery(query);
        }
    }
}
