using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.WebParts
{
    [ScriptType("SP.WebParts.WebPartDefinitionCollection", ServerTypeId = "{01c986b2-57a6-49fb-b8f1-df159f5b2349}")]
    public class WebPartDefinitionCollection : ClientObjectCollection<WebPartDefinition>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebPartDefinitionCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public WebPartDefinition GetById(Guid id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, WebPartDefinition> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, WebPartDefinition>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, WebPartDefinition>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            WebPartDefinition webPartDefinition = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out webPartDefinition))
            {
                return webPartDefinition;
            }
            webPartDefinition = new WebPartDefinition(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = webPartDefinition;
            }
            return webPartDefinition;
        }

        [Remote]
        public WebPartDefinition GetByControlId(string controlId)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<string, WebPartDefinition> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByControlId", out obj))
            {
                dictionary = (Dictionary<string, WebPartDefinition>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, WebPartDefinition>();
                base.ObjectData.MethodReturnObjects["GetByControlId"] = dictionary;
            }
            WebPartDefinition webPartDefinition = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(controlId, out webPartDefinition))
            {
                return webPartDefinition;
            }
            webPartDefinition = new WebPartDefinition(context, new ObjectPathMethod(context, base.Path, "GetByControlId", new object[]
            {
                controlId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[controlId] = webPartDefinition;
            }
            return webPartDefinition;
        }
    }
}
