using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FolderCollection", ServerTypeId = "{b6b425aa-9e17-4205-a4aa-b82c2c3f884d}")]
    public class FolderCollection : ClientObjectCollection<Folder>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FolderCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public Folder GetByUrl(string url)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<string, Folder> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByUrl", out obj))
            {
                dictionary = (Dictionary<string, Folder>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, Folder>();
                base.ObjectData.MethodReturnObjects["GetByUrl"] = dictionary;
            }
            Folder folder = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(url, out folder))
            {
                return folder;
            }
            folder = new Folder(context, new ObjectPathMethod(context, base.Path, "GetByUrl", new object[]
            {
                url
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[url] = folder;
            }
            return folder;
        }

        [Remote]
        public Folder GetByPath(ResourcePath path)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && path == null)
            {
                throw ClientUtility.CreateArgumentNullException("path");
            }
            return new Folder(context, new ObjectPathMethod(context, base.Path, "GetByPath", new object[]
            {
                path
            }));
        }

        [Remote]
        public Folder Add(string url)
        {
            ClientRuntimeContext context = base.Context;
            Folder folder = new Folder(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                url
            }));
            folder.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(folder.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, folder);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(folder);
            return folder;
        }

        [Remote]
        public Folder AddUsingPath(ResourcePath path, FolderCollectionAddParameters parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && path == null)
            {
                throw ClientUtility.CreateArgumentNullException("path");
            }
            Folder folder = new Folder(context, new ObjectPathMethod(context, base.Path, "AddUsingPath", new object[]
            {
                path,
                parameters
            }));
            folder.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(folder.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, folder);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(folder);
            return folder;
        }

        [Remote]
        public Folder AddWithOverwrite(string url, bool overwrite)
        {
            ClientRuntimeContext context = base.Context;
            Folder folder = new Folder(context, new ObjectPathMethod(context, base.Path, "AddWithOverwrite", new object[]
            {
                url,
                overwrite
            }));
            folder.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(folder.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, folder);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(folder);
            return folder;
        }
    }
}
