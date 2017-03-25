using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client.NetCore.Runtime;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RequestContext", ServerTypeId = "{3747adcd-a3c3-41b9-bfab-4a64dd2f1e0a}")]
    internal sealed class RequestContext : ClientObject
    {
        //[Remote]
        //public List List
        //{
        //    get
        //    {
        //        object obj;
        //        List list;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("List", out obj))
        //        {
        //            list = (List)obj;
        //        }
        //        else
        //        {
        //            list = new List(base.Context, new ObjectPathProperty(base.Context, base.Path, "List"));
        //            base.ObjectData.ClientObjectProperties["List"] = list;
        //        }
        //        return list;
        //    }
        //}

        [Remote]
        public Site Site
        {
            get
            {
                object obj;
                Site site;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Site", out obj))
                {
                    site = (Site)obj;
                }
                else
                {
                    site = new Site(base.Context, new ObjectPathProperty(base.Context, base.Path, "Site"));
                    base.ObjectData.ClientObjectProperties["Site"] = site;
                }
                return site;
            }
        }

        [Remote]
        public Web Web
        {
            get
            {
                object obj;
                Web web;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Web", out obj))
                {
                    web = (Web)obj;
                }
                else
                {
                    web = new Web(base.Context, new ObjectPathProperty(base.Context, base.Path, "Web"));
                    base.ObjectData.ClientObjectProperties["Web"] = web;
                }
                return web;
            }
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public RequestContext(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "List"))
                {
                    if (!(peekedName == "Site"))
                    {
                        if (peekedName == "Web")
                        {
                            flag = true;
                            reader.ReadName();
                            base.UpdateClientObjectPropertyType("Web", this.Web, reader);
                            this.Web.FromJson(reader);
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.UpdateClientObjectPropertyType("Site", this.Site, reader);
                        this.Site.FromJson(reader);
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    throw new NotImplementedException("Not yet ported to .NET Core");
                    //Edited for .NET Core
                    //base.UpdateClientObjectPropertyType("List", this.List, reader);
                    //Edited for .NET Core
                    //this.List.FromJson(reader);
                }
            }
            return flag;
        }

        [Remote]
        public RequestContext GetRemoteContext()
        {
            ClientRuntimeContext context = base.Context;
            return new RequestContext(context, new ObjectPathMethod(context, base.Path, "GetRemoteContext", null));
        }

        [Remote]
        public static RequestContext GetCurrent(ClientRuntimeContext Context)
        {
            object obj = null;
            if (!Context.StaticObjects.TryGetValue("Microsoft$SharePoint$SPContext$Current", out obj))
            {
                obj = new RequestContext(Context, new ObjectPathStaticProperty(Context, "{3747adcd-a3c3-41b9-bfab-4a64dd2f1e0a}", "Current"));
                Context.StaticObjects["Microsoft$SharePoint$SPContext$Current"] = obj;
            }
            return (RequestContext)obj;
        }
    }
}