using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Folder", ServerTypeId = "{dbe8175a-505d-4eff-bec4-6c809709808b}")]
    public class Folder : ClientObject
    {
        [Remote]
        public IList<ContentTypeId> ContentTypeOrder
        {
            get
            {
                base.CheckUninitializedProperty("ContentTypeOrder");
                return (IList<ContentTypeId>)base.ObjectData.Properties["ContentTypeOrder"];
            }
        }

        [Remote]
        public bool Exists
        {
            get
            {
                base.CheckUninitializedProperty("Exists");
                return (bool)base.ObjectData.Properties["Exists"];
            }
        }

        [Remote]
        public FileCollection Files
        {
            get
            {
                object obj;
                FileCollection fileCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Files", out obj))
                {
                    fileCollection = (FileCollection)obj;
                }
                else
                {
                    fileCollection = new FileCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Files"));
                    base.ObjectData.ClientObjectProperties["Files"] = fileCollection;
                }
                return fileCollection;
            }
        }

        [Remote]
        public bool IsWOPIEnabled
        {
            get
            {
                base.CheckUninitializedProperty("IsWOPIEnabled");
                return (bool)base.ObjectData.Properties["IsWOPIEnabled"];
            }
        }

        [Remote]
        public ListItem ListItemAllFields
        {
            get
            {
                object obj;
                ListItem listItem;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ListItemAllFields", out obj))
                {
                    listItem = (ListItem)obj;
                }
                else
                {
                    listItem = new ListItem(base.Context, new ObjectPathProperty(base.Context, base.Path, "ListItemAllFields"));
                    base.ObjectData.ClientObjectProperties["ListItemAllFields"] = listItem;
                }
                return listItem;
            }
        }

        [Remote]
        public int ItemCount
        {
            get
            {
                base.CheckUninitializedProperty("ItemCount");
                return (int)base.ObjectData.Properties["ItemCount"];
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
        public Folder ParentFolder
        {
            get
            {
                object obj;
                Folder folder;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ParentFolder", out obj))
                {
                    folder = (Folder)obj;
                }
                else
                {
                    folder = new Folder(base.Context, new ObjectPathProperty(base.Context, base.Path, "ParentFolder"));
                    base.ObjectData.ClientObjectProperties["ParentFolder"] = folder;
                }
                return folder;
            }
        }

        [Remote]
        public string ProgID
        {
            get
            {
                base.CheckUninitializedProperty("ProgID");
                return (string)base.ObjectData.Properties["ProgID"];
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
        public ResourcePath ServerRelativePath
        {
            get
            {
                base.CheckUninitializedProperty("ServerRelativePath");
                return (ResourcePath)base.ObjectData.Properties["ServerRelativePath"];
            }
        }

        [Remote]
        public string ServerRelativeUrl
        {
            get
            {
                base.CheckUninitializedProperty("ServerRelativeUrl");
                return (string)base.ObjectData.Properties["ServerRelativeUrl"];
            }
        }

        [Remote]
        public StorageMetrics StorageMetrics
        {
            get
            {
                object obj;
                StorageMetrics storageMetrics;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("StorageMetrics", out obj))
                {
                    storageMetrics = (StorageMetrics)obj;
                }
                else
                {
                    storageMetrics = new StorageMetrics(base.Context, new ObjectPathProperty(base.Context, base.Path, "StorageMetrics"));
                    base.ObjectData.ClientObjectProperties["StorageMetrics"] = storageMetrics;
                }
                return storageMetrics;
            }
        }

        [Remote]
        public FolderCollection Folders
        {
            get
            {
                object obj;
                FolderCollection folderCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Folders", out obj))
                {
                    folderCollection = (FolderCollection)obj;
                }
                else
                {
                    folderCollection = new FolderCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Folders"));
                    base.ObjectData.ClientObjectProperties["Folders"] = folderCollection;
                }
                return folderCollection;
            }
        }

        [Remote]
        public DateTime TimeCreated
        {
            get
            {
                base.CheckUninitializedProperty("TimeCreated");
                return (DateTime)base.ObjectData.Properties["TimeCreated"];
            }
        }

        [Remote]
        public DateTime TimeLastModified
        {
            get
            {
                base.CheckUninitializedProperty("TimeLastModified");
                return (DateTime)base.ObjectData.Properties["TimeLastModified"];
            }
        }

        [Remote]
        public IList<ContentTypeId> UniqueContentTypeOrder
        {
            get
            {
                base.CheckUninitializedProperty("UniqueContentTypeOrder");
                return (IList<ContentTypeId>)base.ObjectData.Properties["UniqueContentTypeOrder"];
            }
            set
            {
                base.ObjectData.Properties["UniqueContentTypeOrder"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "UniqueContentTypeOrder", value));
                }
            }
        }

        [Remote]
        public Guid UniqueId
        {
            get
            {
                base.CheckUninitializedProperty("UniqueId");
                return (Guid)base.ObjectData.Properties["UniqueId"];
            }
        }

        [Remote]
        public string WelcomePage
        {
            get
            {
                base.CheckUninitializedProperty("WelcomePage");
                return (string)base.ObjectData.Properties["WelcomePage"];
            }
            set
            {
                if (base.Context.ValidateOnClient && value == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value");
                }
                base.ObjectData.Properties["WelcomePage"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "WelcomePage", value));
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Folder(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "ContentTypeOrder":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ContentTypeOrder"] = reader.ReadList<ContentTypeId>();
                    break;
                case "Exists":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Exists"] = reader.ReadBoolean();
                    break;
                case "Files":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Files", this.Files, reader);
                    this.Files.FromJson(reader);
                    break;
                case "IsWOPIEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsWOPIEnabled"] = reader.ReadBoolean();
                    break;
                case "ListItemAllFields":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ListItemAllFields", this.ListItemAllFields, reader);
                    this.ListItemAllFields.FromJson(reader);
                    break;
                case "ItemCount":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ItemCount"] = reader.ReadInt32();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "ParentFolder":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ParentFolder", this.ParentFolder, reader);
                    this.ParentFolder.FromJson(reader);
                    break;
                case "ProgID":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ProgID"] = reader.ReadString();
                    break;
                case "Properties":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Properties", this.Properties, reader);
                    this.Properties.FromJson(reader);
                    break;
                case "ServerRelativePath":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerRelativePath"] = reader.Read<ResourcePath>();
                    break;
                case "ServerRelativeUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerRelativeUrl"] = reader.ReadString();
                    break;
                case "StorageMetrics":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("StorageMetrics", this.StorageMetrics, reader);
                    this.StorageMetrics.FromJson(reader);
                    break;
                case "Folders":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Folders", this.Folders, reader);
                    this.Folders.FromJson(reader);
                    break;
                case "TimeCreated":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TimeCreated"] = reader.ReadDateTime();
                    break;
                case "TimeLastModified":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TimeLastModified"] = reader.ReadDateTime();
                    break;
                case "UniqueContentTypeOrder":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UniqueContentTypeOrder"] = reader.ReadList<ContentTypeId>();
                    break;
                case "UniqueId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UniqueId"] = reader.ReadGuid();
                    break;
                case "WelcomePage":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["WelcomePage"] = reader.ReadString();
                    break;
            }
            return flag;
        }

        [Remote]
        public ChangeCollection GetListItemChanges(ChangeQuery query)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && query == null)
            {
                throw ClientUtility.CreateArgumentNullException("query");
            }
            return new ChangeCollection(context, new ObjectPathMethod(context, base.Path, "GetListItemChanges", new object[]
            {
                query
            }));
        }

        [Remote]
        public void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
        }

        [Remote]
        public void MoveTo(string newUrl)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "MoveTo", new object[]
            {
                newUrl
            });
            context.AddQuery(query);
        }

        [Remote]
        public void MoveToUsingPath(ResourcePath newPath)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && newPath == null)
            {
                throw ClientUtility.CreateArgumentNullException("newPath");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "MoveToUsingPath", new object[]
            {
                newPath
            });
            context.AddQuery(query);
        }

        [Remote]
        public void AddSubFolder(string leafName)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "AddSubFolder", new object[]
            {
                leafName
            });
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
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
    }
}
