using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FormCollection", ServerTypeId = "{078611ea-ce4d-45c0-9b7a-d4b1b46cc327}")]
    public class FormCollection : ClientObjectCollection<Form>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FormCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public Form GetByPageType(PageType formType)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<PageType, Form> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByPageType", out obj))
            {
                dictionary = (Dictionary<PageType, Form>)obj;
            }
            else
            {
                dictionary = new Dictionary<PageType, Form>();
                base.ObjectData.MethodReturnObjects["GetByPageType"] = dictionary;
            }
            Form form = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(formType, out form))
            {
                return form;
            }
            form = new Form(context, new ObjectPathMethod(context, base.Path, "GetByPageType", new object[]
            {
                formType
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[formType] = form;
            }
            return form;
        }

        [Remote]
        public Form GetById(Guid id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, Form> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, Form>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, Form>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            Form form = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out form))
            {
                return form;
            }
            form = new Form(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = form;
            }
            return form;
        }
    }
}
