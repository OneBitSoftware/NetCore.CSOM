using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.WebParts
{
    [ScriptType("SP.WebParts.LimitedWebPartManager", ServerTypeId = "{ac641ade-62df-49c9-af8e-abda6278e920}")]
    public sealed class LimitedWebPartManager : ClientObject
    {
        [Remote]
        public bool HasPersonalizedParts
        {
            get
            {
                base.CheckUninitializedProperty("HasPersonalizedParts");
                return (bool)base.ObjectData.Properties["HasPersonalizedParts"];
            }
        }

        [Remote]
        public PersonalizationScope Scope
        {
            get
            {
                base.CheckUninitializedProperty("Scope");
                return (PersonalizationScope)base.ObjectData.Properties["Scope"];
            }
        }

        [Remote]
        public WebPartDefinitionCollection WebParts
        {
            get
            {
                object obj;
                WebPartDefinitionCollection webPartDefinitionCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("WebParts", out obj))
                {
                    webPartDefinitionCollection = (WebPartDefinitionCollection)obj;
                }
                else
                {
                    webPartDefinitionCollection = new WebPartDefinitionCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "WebParts"));
                    base.ObjectData.ClientObjectProperties["WebParts"] = webPartDefinitionCollection;
                }
                return webPartDefinitionCollection;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public LimitedWebPartManager(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "HasPersonalizedParts"))
                {
                    if (!(peekedName == "Scope"))
                    {
                        if (peekedName == "WebParts")
                        {
                            flag = true;
                            reader.ReadName();
                            base.UpdateClientObjectPropertyType("WebParts", this.WebParts, reader);
                            this.WebParts.FromJson(reader);
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["Scope"] = reader.ReadEnum<PersonalizationScope>();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["HasPersonalizedParts"] = reader.ReadBoolean();
                }
            }
            return flag;
        }

        [Remote]
        public WebPartDefinition AddWebPart(WebPart webPart, string zoneId, int zoneIndex)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (webPart == null)
                {
                    throw ClientUtility.CreateArgumentNullException("webPart");
                }
                if (zoneId == null)
                {
                    throw ClientUtility.CreateArgumentNullException("zoneId");
                }
                if (zoneId != null && zoneId.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("zoneId");
                }
                if (zoneId != null && zoneId.Length > 64)
                {
                    throw ClientUtility.CreateArgumentException("zoneId");
                }
                if (zoneIndex < 0)
                {
                    throw ClientUtility.CreateArgumentException("zoneIndex");
                }
            }
            WebPartDefinition webPartDefinition = new WebPartDefinition(context, new ObjectPathMethod(context, base.Path, "AddWebPart", new object[]
            {
                webPart,
                zoneId,
                zoneIndex
            }));
            webPartDefinition.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(webPartDefinition.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, webPartDefinition);
            context.AddQuery(objectIdentityQuery);
            return webPartDefinition;
        }

        [Remote]
        public ClientResult<string> ExportWebPart(Guid webPartId)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && webPartId == Guid.Empty)
            {
                throw ClientUtility.CreateArgumentException("webPartId");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "ExportWebPart", new object[]
            {
                webPartId
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public WebPartDefinition ImportWebPart(string webPartXml)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (webPartXml == null)
                {
                    throw ClientUtility.CreateArgumentNullException("webPartXml");
                }
                if (webPartXml != null && webPartXml.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("webPartXml");
                }
            }
            WebPartDefinition webPartDefinition = new WebPartDefinition(context, new ObjectPathMethod(context, base.Path, "ImportWebPart", new object[]
            {
                webPartXml
            }));
            webPartDefinition.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(webPartDefinition.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, webPartDefinition);
            context.AddQuery(objectIdentityQuery);
            return webPartDefinition;
        }
    }
}