using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ViewCollection", ServerTypeId = "{03c5d7a9-9541-4482-9919-ca0cccf565a0}")]
    public class ViewCollection : ClientObjectCollection<View>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public View GetByTitle(string strTitle)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && strTitle == null)
            {
                throw ClientUtility.CreateArgumentNullException("strTitle");
            }
            object obj;
            Dictionary<string, View> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByTitle", out obj))
            {
                dictionary = (Dictionary<string, View>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, View>();
                base.ObjectData.MethodReturnObjects["GetByTitle"] = dictionary;
            }
            View view = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(strTitle, out view))
            {
                return view;
            }
            view = new View(context, new ObjectPathMethod(context, base.Path, "GetByTitle", new object[]
            {
                strTitle
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[strTitle] = view;
            }
            return view;
        }

        [Remote]
        public View GetById(Guid guidId)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, View> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, View>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, View>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            View view = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(guidId, out view))
            {
                return view;
            }
            view = new View(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                guidId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[guidId] = view;
            }
            return view;
        }

        [Remote]
        public View Add(ViewCreationInformation parameters)
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
                    if (parameters.Title != null && parameters.Title.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Title");
                    }
                    if (parameters.RowLimit > 2147483647u)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.RowLimit");
                    }
                }
            }
            View view = new View(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            view.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(view.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, view);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(view);
            view.InitFromCreationInformation(parameters);
            return view;
        }
    }
}
