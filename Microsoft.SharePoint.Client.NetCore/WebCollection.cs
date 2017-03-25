using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.WebCollection", ServerTypeId = "{c197d59e-d070-43bf-ad5e-10d6152e38a6}")]
    public class WebCollection : ClientObjectCollection<Web>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public Web Add(WebCreationInformation parameters)
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
                    if (parameters.Url != null && parameters.Url.Length > 128)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Url");
                    }
                    if (parameters.Url.StartsWith("/", StringComparison.OrdinalIgnoreCase) || parameters.Url.StartsWith(".", StringComparison.OrdinalIgnoreCase) || parameters.Url.EndsWith("/", StringComparison.OrdinalIgnoreCase) || parameters.Url.EndsWith(".", StringComparison.OrdinalIgnoreCase))
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Url");
                    }
                    if (parameters.Url.IndexOf("//", StringComparison.OrdinalIgnoreCase) >= 0 || parameters.Url.IndexOf("..", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Url");
                    }
                    if (parameters.Url.IndexOf("/wpresources", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Url");
                    }
                    if (parameters.Title != null && parameters.Title.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Title");
                    }
                }
            }
            Web web = new Web(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            web.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(web.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, web);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(web);
            web.InitFromCreationInformation(parameters);
            return web;
        }
    }
}
