using Microsoft.SharePoint.Client.NetCore.Runtime;
using Microsoft.SharePoint.Client.NetCore.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListItem", ServerTypeId = "{53cc48c0-1777-47b7-99ca-729390f06602}")]
    public class ListItem : SecurableObject
    {
        public Dictionary<string, object> FieldValues
        {
            get
            {
                Dictionary<string, object> dictionary = null;
                object obj = null;
                if (base.ObjectData.MethodReturnObjects.TryGetValue("$m_dict", out obj))
                {
                    dictionary = (obj as Dictionary<string, object>);
                }
                if (dictionary == null)
                {
                    dictionary = new Dictionary<string, object>();
                    base.ObjectData.MethodReturnObjects["$m_dict"] = dictionary;
                }
                return dictionary;
            }
        }

        public object this[string fieldName]
        {
            [PseudoRemote(Name = "GetFieldValue")]
            get
            {
                return this.GetFieldValue(fieldName);
            }
            [Remote(Name = "SetFieldValue")]
            set
            {
                this.SetFieldValue(fieldName, value);
            }
        }

        [Remote]
        public AttachmentCollection AttachmentFiles
        {
            get
            {
                object obj;
                AttachmentCollection attachmentCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AttachmentFiles", out obj))
                {
                    attachmentCollection = (AttachmentCollection)obj;
                }
                else
                {
                    attachmentCollection = new AttachmentCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "AttachmentFiles"));
                    base.ObjectData.ClientObjectProperties["AttachmentFiles"] = attachmentCollection;
                }
                return attachmentCollection;
            }
        }

        [Remote]
        public ContentType ContentType
        {
            get
            {
                object obj;
                ContentType contentType;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ContentType", out obj))
                {
                    contentType = (ContentType)obj;
                }
                else
                {
                    contentType = new ContentType(base.Context, new ObjectPathProperty(base.Context, base.Path, "ContentType"));
                    base.ObjectData.ClientObjectProperties["ContentType"] = contentType;
                }
                return contentType;
            }
        }

        [Remote]
        public string DisplayName
        {
            get
            {
                base.CheckUninitializedProperty("DisplayName");
                return (string)base.ObjectData.Properties["DisplayName"];
            }
        }

        [Remote]
        public DlpPolicyTip GetDlpPolicyTip
        {
            get
            {
                object obj;
                DlpPolicyTip dlpPolicyTip;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("GetDlpPolicyTip", out obj))
                {
                    dlpPolicyTip = (DlpPolicyTip)obj;
                }
                else
                {
                    dlpPolicyTip = new DlpPolicyTip(base.Context, new ObjectPathProperty(base.Context, base.Path, "GetDlpPolicyTip"));
                    base.ObjectData.ClientObjectProperties["GetDlpPolicyTip"] = dlpPolicyTip;
                }
                return dlpPolicyTip;
            }
        }

        [Remote]
        public BasePermissions EffectiveBasePermissions
        {
            get
            {
                base.CheckUninitializedProperty("EffectiveBasePermissions");
                return (BasePermissions)base.ObjectData.Properties["EffectiveBasePermissions"];
            }
        }

        [Remote]
        public BasePermissions EffectiveBasePermissionsForUI
        {
            get
            {
                base.CheckUninitializedProperty("EffectiveBasePermissionsForUI");
                return (BasePermissions)base.ObjectData.Properties["EffectiveBasePermissionsForUI"];
            }
        }

        [Remote]
        public FieldStringValues FieldValuesAsHtml
        {
            get
            {
                object obj;
                FieldStringValues fieldStringValues;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("FieldValuesAsHtml", out obj))
                {
                    fieldStringValues = (FieldStringValues)obj;
                }
                else
                {
                    fieldStringValues = new FieldStringValues(base.Context, new ObjectPathProperty(base.Context, base.Path, "FieldValuesAsHtml"));
                    base.ObjectData.ClientObjectProperties["FieldValuesAsHtml"] = fieldStringValues;
                }
                return fieldStringValues;
            }
        }

        [Remote]
        public FieldStringValues FieldValuesAsText
        {
            get
            {
                object obj;
                FieldStringValues fieldStringValues;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("FieldValuesAsText", out obj))
                {
                    fieldStringValues = (FieldStringValues)obj;
                }
                else
                {
                    fieldStringValues = new FieldStringValues(base.Context, new ObjectPathProperty(base.Context, base.Path, "FieldValuesAsText"));
                    base.ObjectData.ClientObjectProperties["FieldValuesAsText"] = fieldStringValues;
                }
                return fieldStringValues;
            }
        }

        [Remote]
        public FieldStringValues FieldValuesForEdit
        {
            get
            {
                object obj;
                FieldStringValues fieldStringValues;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("FieldValuesForEdit", out obj))
                {
                    fieldStringValues = (FieldStringValues)obj;
                }
                else
                {
                    fieldStringValues = new FieldStringValues(base.Context, new ObjectPathProperty(base.Context, base.Path, "FieldValuesForEdit"));
                    base.ObjectData.ClientObjectProperties["FieldValuesForEdit"] = fieldStringValues;
                }
                return fieldStringValues;
            }
        }

        [Remote]
        public File File
        {
            get
            {
                object obj;
                File file;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("File", out obj))
                {
                    file = (File)obj;
                }
                else
                {
                    file = new File(base.Context, new ObjectPathProperty(base.Context, base.Path, "File"));
                    base.ObjectData.ClientObjectProperties["File"] = file;
                }
                return file;
            }
        }

        [Remote]
        public FileSystemObjectType FileSystemObjectType
        {
            get
            {
                base.CheckUninitializedProperty("FileSystemObjectType");
                return (FileSystemObjectType)base.ObjectData.Properties["FileSystemObjectType"];
            }
        }

        [Remote]
        public Folder Folder
        {
            get
            {
                object obj;
                Folder folder;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Folder", out obj))
                {
                    folder = (Folder)obj;
                }
                else
                {
                    folder = new Folder(base.Context, new ObjectPathProperty(base.Context, base.Path, "Folder"));
                    base.ObjectData.ClientObjectProperties["Folder"] = folder;
                }
                return folder;
            }
        }

        [Remote]
        public string IconOverlay
        {
            get
            {
                base.CheckUninitializedProperty("IconOverlay");
                return (string)base.ObjectData.Properties["IconOverlay"];
            }
            set
            {
                base.ObjectData.Properties["IconOverlay"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IconOverlay", value));
                }
            }
        }

        [Remote]
        public int Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (int)base.ObjectData.Properties["Id"];
            }
        }

        [Remote]
        public List ParentList
        {
            get
            {
                object obj;
                List list;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ParentList", out obj))
                {
                    list = (List)obj;
                }
                else
                {
                    list = new List(base.Context, new ObjectPathProperty(base.Context, base.Path, "ParentList"));
                    base.ObjectData.ClientObjectProperties["ParentList"] = list;
                }
                return list;
            }
        }

        [Remote]
        public PropertyValues Properties
        {
            get
            {
                object obj;
                PropertyValues propertyValues;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Properties", out obj))
                {
                    propertyValues = (PropertyValues)obj;
                }
                else
                {
                    propertyValues = new PropertyValues(base.Context, new ObjectPathProperty(base.Context, base.Path, "Properties"));
                    base.ObjectData.ClientObjectProperties["Properties"] = propertyValues;
                }
                return propertyValues;
            }
        }

        [Remote]
        public string ServerRedirectedEmbedUri
        {
            get
            {
                base.CheckUninitializedProperty("ServerRedirectedEmbedUri");
                return (string)base.ObjectData.Properties["ServerRedirectedEmbedUri"];
            }
        }

        [Remote]
        public string ServerRedirectedEmbedUrl
        {
            get
            {
                base.CheckUninitializedProperty("ServerRedirectedEmbedUrl");
                return (string)base.ObjectData.Properties["ServerRedirectedEmbedUrl"];
            }
        }

        [Remote]
        public string Client_Title
        {
            get
            {
                base.CheckUninitializedProperty("Client_Title");
                return (string)base.ObjectData.Properties["Client_Title"];
            }
        }

        internal void InitFromCreationInformation(ListItemCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["FileSystemObjectType"] = creation.UnderlyingObjectType;
                base.ObjectData.Properties["Id"] = -1;
            }
        }

        internal void InitFromCreationInformationUsingPath(ListItemCreationInformationUsingPath creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["FileSystemObjectType"] = creation.UnderlyingObjectType;
                base.ObjectData.Properties["Id"] = -1;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItem(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override void InitNonPropertyFieldFromJson(string peekedName, JsonReader reader)
        {
            KeyValuePair<string, object> keyValuePair = reader.ReadKeyValue();
            this.FieldValues[keyValuePair.Key] = keyValuePair.Value;
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
                case "AttachmentFiles":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AttachmentFiles", this.AttachmentFiles, reader);
                    this.AttachmentFiles.FromJson(reader);
                    break;
                case "ContentType":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ContentType", this.ContentType, reader);
                    this.ContentType.FromJson(reader);
                    break;
                case "DisplayName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisplayName"] = reader.ReadString();
                    break;
                case "GetDlpPolicyTip":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("GetDlpPolicyTip", this.GetDlpPolicyTip, reader);
                    this.GetDlpPolicyTip.FromJson(reader);
                    break;
                case "EffectiveBasePermissions":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EffectiveBasePermissions"] = reader.Read<BasePermissions>();
                    break;
                case "EffectiveBasePermissionsForUI":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EffectiveBasePermissionsForUI"] = reader.Read<BasePermissions>();
                    break;
                case "FieldValuesAsHtml":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("FieldValuesAsHtml", this.FieldValuesAsHtml, reader);
                    this.FieldValuesAsHtml.FromJson(reader);
                    break;
                case "FieldValuesAsText":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("FieldValuesAsText", this.FieldValuesAsText, reader);
                    this.FieldValuesAsText.FromJson(reader);
                    break;
                case "FieldValuesForEdit":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("FieldValuesForEdit", this.FieldValuesForEdit, reader);
                    this.FieldValuesForEdit.FromJson(reader);
                    break;
                case "File":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("File", this.File, reader);
                    this.File.FromJson(reader);
                    break;
                case "FileSystemObjectType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["FileSystemObjectType"] = reader.ReadEnum<FileSystemObjectType>();
                    break;
                case "Folder":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Folder", this.Folder, reader);
                    this.Folder.FromJson(reader);
                    break;
                case "IconOverlay":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IconOverlay"] = reader.ReadString();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadInt32();
                    break;
                case "ParentList":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ParentList", this.ParentList, reader);
                    this.ParentList.FromJson(reader);
                    break;
                case "Properties":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Properties", this.Properties, reader);
                    this.Properties.FromJson(reader);
                    break;
                case "ServerRedirectedEmbedUri":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerRedirectedEmbedUri"] = reader.ReadString();
                    break;
                case "ServerRedirectedEmbedUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerRedirectedEmbedUrl"] = reader.ReadString();
                    break;
                case "Client_Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Client_Title"] = reader.ReadString();
                    break;
            }
            return flag;
        }

        [PseudoRemote]
        internal object GetFieldValue(string fieldName)
        {
            object result = null;
            if (this.FieldValues.TryGetValue(fieldName, out result))
            {
                return result;
            }
            throw new PropertyOrFieldNotInitializedException();
        }

        public override void RefreshLoad()
        {
            base.RefreshLoad();
            this.LoadExpandoFields();
        }

        protected override void LoadExpandoFields()
        {
            foreach (string current in this.FieldValues.Keys)
            {
                base.Retrieve(new string[]
                {
                    current
                });
            }
        }

        [Remote]
        public void UpdateOverwriteVersion()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "UpdateOverwriteVersion", null);
            context.AddQuery(query);
        }

        [Remote]
        public virtual void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }

        [Remote]
        public IList<Hashtag> GetHashtags()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetHashtags", null);
            context.AddQuery(clientAction);
            IList<Hashtag> list = new List<Hashtag>();
            context.AddQueryIdAndResultObject(clientAction.Id, new ClientListResultHandler<Hashtag>(list));
            return list;
        }

        [Remote]
        public IList<Hashtag> UpdateHashtags(IList<Hashtag> hashtagsToAdd, IList<Hashtag> hashtagsToRemove)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "UpdateHashtags", new object[]
            {
                hashtagsToAdd,
                hashtagsToRemove
            });
            context.AddQuery(clientAction);
            IList<Hashtag> list = new List<Hashtag>();
            context.AddQueryIdAndResultObject(clientAction.Id, new ClientListResultHandler<Hashtag>(list));
            return list;
        }

        [Remote]
        public ClientResult<Guid> Recycle()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "Recycle", null);
            context.AddQuery(clientAction);
            ClientResult<Guid> clientResult = new ClientResult<Guid>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            base.RemoveFromParentCollection();
            return clientResult;
        }

        [Remote]
        public ClientResult<BasePermissions> GetUserEffectivePermissions(string userName)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && userName == null)
            {
                throw ClientUtility.CreateArgumentNullException("userName");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetUserEffectivePermissions", new object[]
            {
                userName
            });
            context.AddQuery(clientAction);
            ClientResult<BasePermissions> clientResult = new ClientResult<BasePermissions>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<PolicyTipUserActionResult> OverridePolicyTip(PolicyTipUserAction userAction, string justification)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "OverridePolicyTip", new object[]
            {
                userAction,
                justification
            });
            context.AddQuery(clientAction);
            ClientResult<PolicyTipUserActionResult> clientResult = new ClientResult<PolicyTipUserActionResult>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<string> GetWOPIFrameUrl(SPWOPIFrameAction action)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetWOPIFrameUrl", new object[]
            {
                action
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public virtual void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
            this.RefreshLoad();
        }

        [Remote]
        public void SystemUpdate()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SystemUpdate", null);
            context.AddQuery(query);
            this.RefreshLoad();
        }

        [Remote]
        public ChangeCollection GetChanges(ChangeQuery query)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && query == null)
            {
                throw ClientUtility.CreateArgumentNullException("query");
            }
            return new ChangeCollection(context, new ObjectPathMethod(context, base.Path, "GetChanges", new object[]
            {
                query
            }));
        }

        [Remote]
        public void SetComplianceTagWithHold(string complianceTag)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && complianceTag == null)
            {
                throw ClientUtility.CreateArgumentNullException("complianceTag");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "SetComplianceTagWithHold", new object[]
            {
                complianceTag
            });
            context.AddQuery(query);
        }

        [Remote]
        public void SetComplianceTagWithRecord(string complianceTag)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && complianceTag == null)
            {
                throw ClientUtility.CreateArgumentNullException("complianceTag");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "SetComplianceTagWithRecord", new object[]
            {
                complianceTag
            });
            context.AddQuery(query);
        }

        [Remote]
        public void SetComplianceTagWithNoHold(string complianceTag)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SetComplianceTagWithNoHold", new object[]
            {
                complianceTag
            });
            context.AddQuery(query);
        }

        [Remote]
        internal void SetFieldValue(string fieldName, object value)
        {
            ClientRuntimeContext context = base.Context;
            this.FieldValues[fieldName] = value;
            ClientAction query = new ClientActionInvokeMethod(this, "SetFieldValue", new object[]
            {
                fieldName,
                value
            });
            if (context != null)
            {
                context.AddQuery(query);
            }
        }

        [Remote]
        public void ParseAndSetFieldValue(string fieldName, string value)
        {
            ClientRuntimeContext context = base.Context;
            this.FieldValues[fieldName] = value;
            ClientAction query = new ClientActionInvokeMethod(this, "ParseAndSetFieldValue", new object[]
            {
                fieldName,
                value
            });
            if (context != null)
            {
                context.AddQuery(query);
            }
        }

        [Remote]
        public IList<ListItemFormUpdateValue> ValidateUpdateListItem(IList<ListItemFormUpdateValue> formValues, bool bNewDocumentUpdate, string checkInComment)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && formValues == null)
            {
                throw ClientUtility.CreateArgumentNullException("formValues");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "ValidateUpdateListItem", new object[]
            {
                formValues,
                bNewDocumentUpdate,
                checkInComment
            });
            context.AddQuery(clientAction);
            IList<ListItemFormUpdateValue> list = new List<ListItemFormUpdateValue>();
            context.AddQueryIdAndResultObject(clientAction.Id, new ClientListResultHandler<ListItemFormUpdateValue>(list));
            return list;
        }
    }
}
