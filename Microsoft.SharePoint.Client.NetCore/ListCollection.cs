using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListCollection", ServerTypeId = "{1e78b736-61f0-441c-a785-10fc25387c8d}")]
    public class ListCollection : ClientObjectCollection<List>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public List GetByTitle(string title)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (title == null)
                {
                    throw ClientUtility.CreateArgumentNullException("title");
                }
                if (title != null && title.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("title");
                }
                if (title != null && title.Length > 255)
                {
                    throw ClientUtility.CreateArgumentException("title");
                }
            }
            object obj;
            Dictionary<string, List> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByTitle", out obj))
            {
                dictionary = (Dictionary<string, List>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, List>(StringComparer.OrdinalIgnoreCase);
                base.ObjectData.MethodReturnObjects["GetByTitle"] = dictionary;
            }
            List list = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(title, out list))
            {
                return list;
            }
            list = new List(context, new ObjectPathMethod(context, base.Path, "GetByTitle", new object[]
            {
                title
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[title] = list;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(list.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, list);
            context.AddQuery(objectIdentityQuery);
            return list;
        }

        [Remote]
        public List GetById(Guid id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, List> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, List>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, List>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            List list = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out list))
            {
                return list;
            }
            list = new List(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = list;
            }
            return list;
        }

        [Remote]
        public List Add(ListCreationInformation parameters)
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
                    if (parameters.Title != null && parameters.Title.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Title");
                    }
                }
            }
            List list = new List(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            list.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(list.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, list);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(list);
            list.InitFromCreationInformation(parameters);
            return list;
        }

        [Remote]
        public List EnsureSitePagesLibrary()
        {
            ClientRuntimeContext context = base.Context;
            List list = new List(context, new ObjectPathMethod(context, base.Path, "EnsureSitePagesLibrary", null));
            list.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(list.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, list);
            context.AddQuery(objectIdentityQuery);
            return list;
        }

        [Remote]
        public List EnsureSiteAssetsLibrary()
        {
            ClientRuntimeContext context = base.Context;
            List list = new List(context, new ObjectPathMethod(context, base.Path, "EnsureSiteAssetsLibrary", null));
            list.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(list.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, list);
            context.AddQuery(objectIdentityQuery);
            return list;
        }
    }
}
