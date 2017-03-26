using Microsoft.SharePoint.Client.NetCore;
using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.WebParts
{
    [ScriptType("SP.WebParts.WebPartDefinition", ServerTypeId = "{44bf1024-6127-432a-8e3d-fb317fb4541e}")]
    public class WebPartDefinition : ClientObject
    {
        [Remote]
        public Guid Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (Guid)base.ObjectData.Properties["Id"];
            }
        }

        [Remote]
        public WebPart WebPart
        {
            get
            {
                object obj;
                WebPart webPart;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("WebPart", out obj))
                {
                    webPart = (WebPart)obj;
                }
                else
                {
                    webPart = new WebPart(base.Context, new ObjectPathProperty(base.Context, base.Path, "WebPart"));
                    base.ObjectData.ClientObjectProperties["WebPart"] = webPart;
                }
                return webPart;
            }
        }

        [Remote]
        public string ZoneId
        {
            get
            {
                base.CheckUninitializedProperty("ZoneId");
                return (string)base.ObjectData.Properties["ZoneId"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebPartDefinition(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "Id"))
                {
                    if (!(peekedName == "WebPart"))
                    {
                        if (peekedName == "ZoneId")
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["ZoneId"] = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.UpdateClientObjectPropertyType("WebPart", this.WebPart, reader);
                        this.WebPart.FromJson(reader);
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                }
            }
            return flag;
        }

        [Remote]
        public void SaveWebPartChanges()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SaveWebPartChanges", null);
            context.AddQuery(query);
        }

        [Remote]
        public void CloseWebPart()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "CloseWebPart", null);
            context.AddQuery(query);
        }

        [Remote]
        public void OpenWebPart()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "OpenWebPart", null);
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteWebPart()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteWebPart", null);
            context.AddQuery(query);
        }

        [Remote]
        public void MoveWebPartTo(string zoneID, int zoneIndex)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (zoneID == null)
                {
                    throw ClientUtility.CreateArgumentNullException("zoneID");
                }
                if (zoneID != null && zoneID.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("zoneID");
                }
                if (zoneID != null && zoneID.Length > 64)
                {
                    throw ClientUtility.CreateArgumentException("zoneID");
                }
                if (zoneIndex < 0)
                {
                    throw ClientUtility.CreateArgumentException("zoneIndex");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "MoveWebPartTo", new object[]
            {
                zoneID,
                zoneIndex
            });
            context.AddQuery(query);
        }
    }
}
