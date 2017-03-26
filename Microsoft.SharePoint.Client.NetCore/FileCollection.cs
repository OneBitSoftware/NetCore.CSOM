using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FileCollection", ServerTypeId = "{d367b17c-170b-4691-a1e3-8bccf7686ce4}")]
    public class FileCollection : ClientObjectCollection<File>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public File GetByUrl(string url)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<string, File> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByUrl", out obj))
            {
                dictionary = (Dictionary<string, File>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, File>();
                base.ObjectData.MethodReturnObjects["GetByUrl"] = dictionary;
            }
            File file = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(url, out file))
            {
                return file;
            }
            file = new File(context, new ObjectPathMethod(context, base.Path, "GetByUrl", new object[]
            {
                url
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[url] = file;
            }
            return file;
        }

        [Remote]
        public File Add(FileCreationInformation parameters)
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
                    if (parameters.Url == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("parameters.Url");
                    }
                    Uri uri;
                    if (parameters.Url != null && !Uri.TryCreate(parameters.Url, UriKind.RelativeOrAbsolute, out uri))
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Url");
                    }
                    if (parameters.Url != null && parameters.Url.Length < 1)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Url");
                    }
                }
            }
            File file = new File(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            file.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(file.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, file);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(file);
            file.InitFromCreationInformation(parameters);
            return file;
        }

        [Remote]
        public File AddTemplateFile(string urlOfFile, TemplateFileType templateFileType)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (urlOfFile == null)
                {
                    throw ClientUtility.CreateArgumentNullException("urlOfFile");
                }
                if (urlOfFile != null && urlOfFile.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("urlOfFile");
                }
                if (templateFileType != TemplateFileType.StandardPage && templateFileType != TemplateFileType.WikiPage && templateFileType != TemplateFileType.FormPage && templateFileType != TemplateFileType.ClientSidePage)
                {
                    throw ClientUtility.CreateArgumentException("templateFileType");
                }
            }
            File file = new File(context, new ObjectPathMethod(context, base.Path, "AddTemplateFile", new object[]
            {
                urlOfFile,
                templateFileType
            }));
            file.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(file.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, file);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(file);
            return file;
        }

        [Remote]
        public File AddUsingPath(ResourcePath path, FileCollectionAddParameters parameters, Stream contentStream)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && path == null)
            {
                throw ClientUtility.CreateArgumentNullException("path");
            }
            return new File(context, new ObjectPathMethod(context, base.Path, "AddUsingPath", new object[]
            {
                path,
                parameters,
                contentStream
            }));
        }
    }
}
