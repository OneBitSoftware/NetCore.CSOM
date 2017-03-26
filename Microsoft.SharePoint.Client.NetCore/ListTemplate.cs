using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.IO;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListTemplate", ServerTypeId = "{d772ecd1-daa3-4cb1-9ea1-feea1e383fb2}")]
    public class ListTemplate : ClientObject
    {
        [Remote]
        public bool AllowsFolderCreation
        {
            get
            {
                base.CheckUninitializedProperty("AllowsFolderCreation");
                return (bool)base.ObjectData.Properties["AllowsFolderCreation"];
            }
        }

        [Remote]
        public BaseType BaseType
        {
            get
            {
                base.CheckUninitializedProperty("BaseType");
                return (BaseType)base.ObjectData.Properties["BaseType"];
            }
        }

        [Remote]
        public string Description
        {
            get
            {
                base.CheckUninitializedProperty("Description");
                return (string)base.ObjectData.Properties["Description"];
            }
        }

        [Remote]
        public Guid FeatureId
        {
            get
            {
                base.CheckUninitializedProperty("FeatureId");
                return (Guid)base.ObjectData.Properties["FeatureId"];
            }
        }

        [Remote]
        public bool Hidden
        {
            get
            {
                base.CheckUninitializedProperty("Hidden");
                return (bool)base.ObjectData.Properties["Hidden"];
            }
        }

        [Remote]
        public string ImageUrl
        {
            get
            {
                base.CheckUninitializedProperty("ImageUrl");
                return (string)base.ObjectData.Properties["ImageUrl"];
            }
        }

        [Remote]
        public string InternalName
        {
            get
            {
                base.CheckUninitializedProperty("InternalName");
                return (string)base.ObjectData.Properties["InternalName"];
            }
        }

        [Remote]
        public bool IsCustomTemplate
        {
            get
            {
                base.CheckUninitializedProperty("IsCustomTemplate");
                return (bool)base.ObjectData.Properties["IsCustomTemplate"];
            }
        }

        [Remote]
        public string Name
        {
            get
            {
                base.CheckUninitializedProperty("Name");
                return (string)base.ObjectData.Properties["Name"];
            }
        }

        [Remote]
        public bool OnQuickLaunch
        {
            get
            {
                base.CheckUninitializedProperty("OnQuickLaunch");
                return (bool)base.ObjectData.Properties["OnQuickLaunch"];
            }
        }

        [Remote]
        public int ListTemplateTypeKind
        {
            get
            {
                base.CheckUninitializedProperty("ListTemplateTypeKind");
                return (int)base.ObjectData.Properties["ListTemplateTypeKind"];
            }
        }

        [Remote]
        public bool Unique
        {
            get
            {
                base.CheckUninitializedProperty("Unique");
                return (bool)base.ObjectData.Properties["Unique"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListTemplate(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            switch (peekedName)
            {
                case "AllowsFolderCreation":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowsFolderCreation"] = reader.ReadBoolean();
                    break;
                case "BaseType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["BaseType"] = reader.ReadEnum<BaseType>();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "FeatureId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["FeatureId"] = reader.ReadGuid();
                    break;
                case "Hidden":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Hidden"] = reader.ReadBoolean();
                    break;
                case "ImageUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ImageUrl"] = reader.ReadString();
                    break;
                case "InternalName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["InternalName"] = reader.ReadString();
                    break;
                case "IsCustomTemplate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsCustomTemplate"] = reader.ReadBoolean();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "OnQuickLaunch":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["OnQuickLaunch"] = reader.ReadBoolean();
                    break;
                case "ListTemplateTypeKind":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListTemplateTypeKind"] = reader.ReadInt32();
                    break;
                case "Unique":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Unique"] = reader.ReadBoolean();
                    break;
            }
            return flag;
        }

        [Remote]
        public ClientResult<Stream> GetGlobalSchemaXml()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetGlobalSchemaXml", null);
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }
    }
}
