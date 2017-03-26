using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListTemplateCollection", ServerTypeId = "{23748d10-16a1-4946-a38b-98fdec0e0ec8}")]
    public class ListTemplateCollection : ClientObjectCollection<ListTemplate>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListTemplateCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public ListTemplate GetByName(string name)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<string, ListTemplate> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByName", out obj))
            {
                dictionary = (Dictionary<string, ListTemplate>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, ListTemplate>();
                base.ObjectData.MethodReturnObjects["GetByName"] = dictionary;
            }
            ListTemplate listTemplate = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(name, out listTemplate))
            {
                return listTemplate;
            }
            listTemplate = new ListTemplate(context, new ObjectPathMethod(context, base.Path, "GetByName", new object[]
            {
                name
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[name] = listTemplate;
            }
            return listTemplate;
        }
    }
}
