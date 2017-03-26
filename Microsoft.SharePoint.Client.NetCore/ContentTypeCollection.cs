using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ContentTypeCollection", ServerTypeId = "{653e9412-6245-4a3f-829b-cfdbf7fd86a5}")]
    public sealed class ContentTypeCollection : ClientObjectCollection<ContentType>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentTypeCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public ContentType GetById(string contentTypeId)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (contentTypeId == null)
                {
                    throw ClientUtility.CreateArgumentNullException("contentTypeId");
                }
                if (contentTypeId != null && !Regex.Match(contentTypeId, "0x(([1-9a-fA-F][0-9a-fA-F])|(0[1-9a-fA-F]))*(00([0-9a-fA-F][0-9a-fA-F]){16})*").Success)
                {
                    throw ClientUtility.CreateArgumentException("contentTypeId");
                }
            }
            object obj;
            Dictionary<string, ContentType> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<string, ContentType>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, ContentType>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            ContentType contentType = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(contentTypeId, out contentType))
            {
                return contentType;
            }
            contentType = new ContentType(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                contentTypeId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[contentTypeId] = contentType;
            }
            return contentType;
        }

        [Remote]
        public ContentType AddExistingContentType(ContentType contentType)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && contentType == null)
            {
                throw ClientUtility.CreateArgumentNullException("contentType");
            }
            ContentType contentType2 = new ContentType(context, new ObjectPathMethod(context, base.Path, "AddExistingContentType", new object[]
            {
                contentType
            }));
            contentType2.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(contentType2.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, contentType2);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(contentType2);
            return contentType2;
        }

        [Remote]
        public ContentType Add(ContentTypeCreationInformation parameters)
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
                    if (parameters.Name == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("parameters.Name");
                    }
                    if (parameters.Group != null && parameters.Group.Length < 1)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Group");
                    }
                    if (parameters.Group != null && parameters.Group.Length > 128)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Group");
                    }
                }
            }
            ContentType contentType = new ContentType(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            contentType.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(contentType.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, contentType);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(contentType);
            contentType.InitFromCreationInformation(parameters);
            return contentType;
        }
    }
}
