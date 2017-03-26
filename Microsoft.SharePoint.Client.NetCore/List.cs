using Microsoft.SharePoint.Client.NetCore.Runtime;
using Microsoft.SharePoint.Client.NetCore.Workflow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.List", ServerTypeId = "{d89f0b18-614e-4b4a-bac0-fd6142b55448}")]
    public class List : SecurableObject
    {
        [Remote]
        public bool AllowContentTypes
        {
            get
            {
                base.CheckUninitializedProperty("AllowContentTypes");
                return (bool)base.ObjectData.Properties["AllowContentTypes"];
            }
        }

        [Remote]
        public bool AllowDeletion
        {
            get
            {
                base.CheckUninitializedProperty("AllowDeletion");
                return (bool)base.ObjectData.Properties["AllowDeletion"];
            }
            set
            {
                base.ObjectData.Properties["AllowDeletion"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowDeletion", value));
                }
            }
        }

        [Remote]
        public int BaseTemplate
        {
            get
            {
                base.CheckUninitializedProperty("BaseTemplate");
                return (int)base.ObjectData.Properties["BaseTemplate"];
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
        public BrowserFileHandling BrowserFileHandling
        {
            get
            {
                base.CheckUninitializedProperty("BrowserFileHandling");
                return (BrowserFileHandling)base.ObjectData.Properties["BrowserFileHandling"];
            }
        }

        [Remote]
        public ContentTypeCollection ContentTypes
        {
            get
            {
                object obj;
                ContentTypeCollection contentTypeCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ContentTypes", out obj))
                {
                    contentTypeCollection = (ContentTypeCollection)obj;
                }
                else
                {
                    contentTypeCollection = new ContentTypeCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "ContentTypes"));
                    base.ObjectData.ClientObjectProperties["ContentTypes"] = contentTypeCollection;
                }
                return contentTypeCollection;
            }
        }

        [Remote]
        public bool ContentTypesEnabled
        {
            get
            {
                base.CheckUninitializedProperty("ContentTypesEnabled");
                return (bool)base.ObjectData.Properties["ContentTypesEnabled"];
            }
            set
            {
                base.ObjectData.Properties["ContentTypesEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ContentTypesEnabled", value));
                }
            }
        }

        [Remote]
        public bool CrawlNonDefaultViews
        {
            get
            {
                base.CheckUninitializedProperty("CrawlNonDefaultViews");
                return (bool)base.ObjectData.Properties["CrawlNonDefaultViews"];
            }
            set
            {
                base.ObjectData.Properties["CrawlNonDefaultViews"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "CrawlNonDefaultViews", value));
                }
            }
        }

        [Remote]
        public CreatablesInfo CreatablesInfo
        {
            get
            {
                object obj;
                CreatablesInfo creatablesInfo;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("CreatablesInfo", out obj))
                {
                    creatablesInfo = (CreatablesInfo)obj;
                }
                else
                {
                    creatablesInfo = new CreatablesInfo(base.Context, new ObjectPathProperty(base.Context, base.Path, "CreatablesInfo"));
                    base.ObjectData.ClientObjectProperties["CreatablesInfo"] = creatablesInfo;
                }
                return creatablesInfo;
            }
        }

        [Remote]
        public DateTime Created
        {
            get
            {
                base.CheckUninitializedProperty("Created");
                return (DateTime)base.ObjectData.Properties["Created"];
            }
        }

        [Remote]
        public ChangeToken CurrentChangeToken
        {
            get
            {
                base.CheckUninitializedProperty("CurrentChangeToken");
                return (ChangeToken)base.ObjectData.Properties["CurrentChangeToken"];
            }
        }

        [Remote]
        public CustomActionElementCollection CustomActionElements
        {
            get
            {
                base.CheckUninitializedProperty("CustomActionElements");
                return (CustomActionElementCollection)base.ObjectData.Properties["CustomActionElements"];
            }
        }

        [Remote]
        public ListDataSource DataSource
        {
            get
            {
                base.CheckUninitializedProperty("DataSource");
                return (ListDataSource)base.ObjectData.Properties["DataSource"];
            }
        }

        [Remote]
        public Guid DefaultContentApprovalWorkflowId
        {
            get
            {
                base.CheckUninitializedProperty("DefaultContentApprovalWorkflowId");
                return (Guid)base.ObjectData.Properties["DefaultContentApprovalWorkflowId"];
            }
            set
            {
                base.ObjectData.Properties["DefaultContentApprovalWorkflowId"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DefaultContentApprovalWorkflowId", value));
                }
            }
        }

        [Remote]
        public string DefaultDisplayFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("DefaultDisplayFormUrl");
                return (string)base.ObjectData.Properties["DefaultDisplayFormUrl"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["DefaultDisplayFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DefaultDisplayFormUrl", value));
                }
            }
        }

        [Remote]
        public string DefaultEditFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("DefaultEditFormUrl");
                return (string)base.ObjectData.Properties["DefaultEditFormUrl"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["DefaultEditFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DefaultEditFormUrl", value));
                }
            }
        }

        [Remote]
        public string DefaultNewFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("DefaultNewFormUrl");
                return (string)base.ObjectData.Properties["DefaultNewFormUrl"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["DefaultNewFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DefaultNewFormUrl", value));
                }
            }
        }

        [Remote]
        public View DefaultView
        {
            get
            {
                object obj;
                View view;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("DefaultView", out obj))
                {
                    view = (View)obj;
                }
                else
                {
                    view = new View(base.Context, new ObjectPathProperty(base.Context, base.Path, "DefaultView"));
                    base.ObjectData.ClientObjectProperties["DefaultView"] = view;
                }
                return view;
            }
        }

        [Remote]
        public ResourcePath DefaultViewPath
        {
            get
            {
                base.CheckUninitializedProperty("DefaultViewPath");
                return (ResourcePath)base.ObjectData.Properties["DefaultViewPath"];
            }
        }

        [Remote]
        public string DefaultViewUrl
        {
            get
            {
                base.CheckUninitializedProperty("DefaultViewUrl");
                return (string)base.ObjectData.Properties["DefaultViewUrl"];
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
            set
            {
                if (base.Context.ValidateOnClient && value == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value");
                }
                base.ObjectData.Properties["Description"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Description", value));
                }
            }
        }

        [Remote]
        public UserResource DescriptionResource
        {
            get
            {
                object obj;
                UserResource userResource;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("DescriptionResource", out obj))
                {
                    userResource = (UserResource)obj;
                }
                else
                {
                    userResource = new UserResource(base.Context, new ObjectPathProperty(base.Context, base.Path, "DescriptionResource"));
                    base.ObjectData.ClientObjectProperties["DescriptionResource"] = userResource;
                }
                return userResource;
            }
        }

        [Remote]
        public string Direction
        {
            get
            {
                base.CheckUninitializedProperty("Direction");
                return (string)base.ObjectData.Properties["Direction"];
            }
            set
            {
                base.ObjectData.Properties["Direction"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Direction", value));
                }
            }
        }

        [Remote]
        public string DocumentTemplateUrl
        {
            get
            {
                base.CheckUninitializedProperty("DocumentTemplateUrl");
                return (string)base.ObjectData.Properties["DocumentTemplateUrl"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value != null && value.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                    Uri uri;
                    if (value != null && (!value.StartsWith("/", StringComparison.Ordinal) || !Uri.TryCreate(value, UriKind.Relative, out uri)))
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["DocumentTemplateUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DocumentTemplateUrl", value));
                }
            }
        }

        [Remote]
        public DraftVisibilityType DraftVersionVisibility
        {
            get
            {
                base.CheckUninitializedProperty("DraftVersionVisibility");
                return (DraftVisibilityType)base.ObjectData.Properties["DraftVersionVisibility"];
            }
            set
            {
                base.ObjectData.Properties["DraftVersionVisibility"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DraftVersionVisibility", value));
                }
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
        public bool EnableAssignToEmail
        {
            get
            {
                base.CheckUninitializedProperty("EnableAssignToEmail");
                return (bool)base.ObjectData.Properties["EnableAssignToEmail"];
            }
            set
            {
                base.ObjectData.Properties["EnableAssignToEmail"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableAssignToEmail", value));
                }
            }
        }

        [Remote]
        public bool EnableAttachments
        {
            get
            {
                base.CheckUninitializedProperty("EnableAttachments");
                return (bool)base.ObjectData.Properties["EnableAttachments"];
            }
            set
            {
                base.ObjectData.Properties["EnableAttachments"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableAttachments", value));
                }
            }
        }

        [Remote]
        public bool EnableFolderCreation
        {
            get
            {
                base.CheckUninitializedProperty("EnableFolderCreation");
                return (bool)base.ObjectData.Properties["EnableFolderCreation"];
            }
            set
            {
                base.ObjectData.Properties["EnableFolderCreation"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableFolderCreation", value));
                }
            }
        }

        [Remote]
        public bool EnableMinorVersions
        {
            get
            {
                base.CheckUninitializedProperty("EnableMinorVersions");
                return (bool)base.ObjectData.Properties["EnableMinorVersions"];
            }
            set
            {
                base.ObjectData.Properties["EnableMinorVersions"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableMinorVersions", value));
                }
            }
        }

        [Remote]
        public bool EnableModeration
        {
            get
            {
                base.CheckUninitializedProperty("EnableModeration");
                return (bool)base.ObjectData.Properties["EnableModeration"];
            }
            set
            {
                base.ObjectData.Properties["EnableModeration"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableModeration", value));
                }
            }
        }

        [Remote]
        public bool EnableVersioning
        {
            get
            {
                base.CheckUninitializedProperty("EnableVersioning");
                return (bool)base.ObjectData.Properties["EnableVersioning"];
            }
            set
            {
                base.ObjectData.Properties["EnableVersioning"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableVersioning", value));
                }
            }
        }

        [Remote]
        public string EntityTypeName
        {
            get
            {
                base.CheckUninitializedProperty("EntityTypeName");
                return (string)base.ObjectData.Properties["EntityTypeName"];
            }
        }

        [Remote]
        public EventReceiverDefinitionCollection EventReceivers
        {
            get
            {
                object obj;
                EventReceiverDefinitionCollection eventReceiverDefinitionCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("EventReceivers", out obj))
                {
                    eventReceiverDefinitionCollection = (EventReceiverDefinitionCollection)obj;
                }
                else
                {
                    eventReceiverDefinitionCollection = new EventReceiverDefinitionCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "EventReceivers"));
                    base.ObjectData.ClientObjectProperties["EventReceivers"] = eventReceiverDefinitionCollection;
                }
                return eventReceiverDefinitionCollection;
            }
        }

        [Remote]
        public bool ExcludeFromOfflineClient
        {
            get
            {
                base.CheckUninitializedProperty("ExcludeFromOfflineClient");
                return (bool)base.ObjectData.Properties["ExcludeFromOfflineClient"];
            }
            set
            {
                base.ObjectData.Properties["ExcludeFromOfflineClient"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ExcludeFromOfflineClient", value));
                }
            }
        }

        [Remote]
        public bool ExemptFromBlockDownloadOfNonViewableFiles
        {
            get
            {
                base.CheckUninitializedProperty("ExemptFromBlockDownloadOfNonViewableFiles");
                return (bool)base.ObjectData.Properties["ExemptFromBlockDownloadOfNonViewableFiles"];
            }
            set
            {
                base.ObjectData.Properties["ExemptFromBlockDownloadOfNonViewableFiles"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ExemptFromBlockDownloadOfNonViewableFiles", value));
                }
            }
        }

        [Remote]
        public FieldCollection Fields
        {
            get
            {
                object obj;
                FieldCollection fieldCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Fields", out obj))
                {
                    fieldCollection = (FieldCollection)obj;
                }
                else
                {
                    fieldCollection = new FieldCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Fields"));
                    base.ObjectData.ClientObjectProperties["Fields"] = fieldCollection;
                }
                return fieldCollection;
            }
        }

        [Remote]
        public bool FileSavePostProcessingEnabled
        {
            get
            {
                base.CheckUninitializedProperty("FileSavePostProcessingEnabled");
                return (bool)base.ObjectData.Properties["FileSavePostProcessingEnabled"];
            }
        }

        [Remote]
        public bool ForceCheckout
        {
            get
            {
                base.CheckUninitializedProperty("ForceCheckout");
                return (bool)base.ObjectData.Properties["ForceCheckout"];
            }
            set
            {
                base.ObjectData.Properties["ForceCheckout"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ForceCheckout", value));
                }
            }
        }

        [Remote]
        public FormCollection Forms
        {
            get
            {
                object obj;
                FormCollection formCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Forms", out obj))
                {
                    formCollection = (FormCollection)obj;
                }
                else
                {
                    formCollection = new FormCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Forms"));
                    base.ObjectData.ClientObjectProperties["Forms"] = formCollection;
                }
                return formCollection;
            }
        }

        [Remote]
        public bool HasExternalDataSource
        {
            get
            {
                base.CheckUninitializedProperty("HasExternalDataSource");
                return (bool)base.ObjectData.Properties["HasExternalDataSource"];
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
            set
            {
                base.ObjectData.Properties["Hidden"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Hidden", value));
                }
            }
        }

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
        public string ImageUrl
        {
            get
            {
                base.CheckUninitializedProperty("ImageUrl");
                return (string)base.ObjectData.Properties["ImageUrl"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["ImageUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ImageUrl", value));
                }
            }
        }

        [Remote]
        public InformationRightsManagementSettings InformationRightsManagementSettings
        {
            get
            {
                object obj;
                InformationRightsManagementSettings informationRightsManagementSettings;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("InformationRightsManagementSettings", out obj))
                {
                    informationRightsManagementSettings = (InformationRightsManagementSettings)obj;
                }
                else
                {
                    informationRightsManagementSettings = new InformationRightsManagementSettings(base.Context, new ObjectPathProperty(base.Context, base.Path, "InformationRightsManagementSettings"));
                    base.ObjectData.ClientObjectProperties["InformationRightsManagementSettings"] = informationRightsManagementSettings;
                }
                return informationRightsManagementSettings;
            }
        }

        [Remote]
        public bool IrmEnabled
        {
            get
            {
                base.CheckUninitializedProperty("IrmEnabled");
                return (bool)base.ObjectData.Properties["IrmEnabled"];
            }
            set
            {
                base.ObjectData.Properties["IrmEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IrmEnabled", value));
                }
            }
        }

        [Remote]
        public bool IrmExpire
        {
            get
            {
                base.CheckUninitializedProperty("IrmExpire");
                return (bool)base.ObjectData.Properties["IrmExpire"];
            }
            set
            {
                base.ObjectData.Properties["IrmExpire"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IrmExpire", value));
                }
            }
        }

        [Remote]
        public bool IrmReject
        {
            get
            {
                base.CheckUninitializedProperty("IrmReject");
                return (bool)base.ObjectData.Properties["IrmReject"];
            }
            set
            {
                base.ObjectData.Properties["IrmReject"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IrmReject", value));
                }
            }
        }

        [Remote]
        public bool IsApplicationList
        {
            get
            {
                base.CheckUninitializedProperty("IsApplicationList");
                return (bool)base.ObjectData.Properties["IsApplicationList"];
            }
            set
            {
                base.ObjectData.Properties["IsApplicationList"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IsApplicationList", value));
                }
            }
        }

        [Remote]
        public bool IsCatalog
        {
            get
            {
                base.CheckUninitializedProperty("IsCatalog");
                return (bool)base.ObjectData.Properties["IsCatalog"];
            }
        }

        [Remote]
        public bool IsPrivate
        {
            get
            {
                base.CheckUninitializedProperty("IsPrivate");
                return (bool)base.ObjectData.Properties["IsPrivate"];
            }
        }

        [Remote]
        public bool IsSiteAssetsLibrary
        {
            get
            {
                base.CheckUninitializedProperty("IsSiteAssetsLibrary");
                return (bool)base.ObjectData.Properties["IsSiteAssetsLibrary"];
            }
        }

        [Remote]
        public bool IsSystemList
        {
            get
            {
                base.CheckUninitializedProperty("IsSystemList");
                return (bool)base.ObjectData.Properties["IsSystemList"];
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
        public DateTime LastItemDeletedDate
        {
            get
            {
                base.CheckUninitializedProperty("LastItemDeletedDate");
                return (DateTime)base.ObjectData.Properties["LastItemDeletedDate"];
            }
        }

        [Remote]
        public DateTime LastItemModifiedDate
        {
            get
            {
                base.CheckUninitializedProperty("LastItemModifiedDate");
                return (DateTime)base.ObjectData.Properties["LastItemModifiedDate"];
            }
            set
            {
                base.ObjectData.Properties["LastItemModifiedDate"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "LastItemModifiedDate", value));
                }
            }
        }

        [Remote]
        public DateTime LastItemUserModifiedDate
        {
            get
            {
                base.CheckUninitializedProperty("LastItemUserModifiedDate");
                return (DateTime)base.ObjectData.Properties["LastItemUserModifiedDate"];
            }
            set
            {
                base.ObjectData.Properties["LastItemUserModifiedDate"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "LastItemUserModifiedDate", value));
                }
            }
        }

        [Remote]
        public ListExperience ListExperienceOptions
        {
            get
            {
                base.CheckUninitializedProperty("ListExperienceOptions");
                return (ListExperience)base.ObjectData.Properties["ListExperienceOptions"];
            }
            set
            {
                base.ObjectData.Properties["ListExperienceOptions"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ListExperienceOptions", value));
                }
            }
        }

        [Remote]
        public string ListItemEntityTypeFullName
        {
            get
            {
                base.CheckUninitializedProperty("ListItemEntityTypeFullName");
                return (string)base.ObjectData.Properties["ListItemEntityTypeFullName"];
            }
        }

        [Remote]
        public int MajorVersionLimit
        {
            get
            {
                base.CheckUninitializedProperty("MajorVersionLimit");
                return (int)base.ObjectData.Properties["MajorVersionLimit"];
            }
            set
            {
                base.ObjectData.Properties["MajorVersionLimit"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MajorVersionLimit", value));
                }
            }
        }

        [Remote]
        public int MajorWithMinorVersionsLimit
        {
            get
            {
                base.CheckUninitializedProperty("MajorWithMinorVersionsLimit");
                return (int)base.ObjectData.Properties["MajorWithMinorVersionsLimit"];
            }
            set
            {
                base.ObjectData.Properties["MajorWithMinorVersionsLimit"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MajorWithMinorVersionsLimit", value));
                }
            }
        }

        [Remote]
        public bool MultipleDataList
        {
            get
            {
                base.CheckUninitializedProperty("MultipleDataList");
                return (bool)base.ObjectData.Properties["MultipleDataList"];
            }
            set
            {
                base.ObjectData.Properties["MultipleDataList"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MultipleDataList", value));
                }
            }
        }

        [Remote]
        public bool NoCrawl
        {
            get
            {
                base.CheckUninitializedProperty("NoCrawl");
                return (bool)base.ObjectData.Properties["NoCrawl"];
            }
            set
            {
                base.ObjectData.Properties["NoCrawl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "NoCrawl", value));
                }
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
            set
            {
                base.ObjectData.Properties["OnQuickLaunch"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "OnQuickLaunch", value));
                }
            }
        }

        [Remote]
        public Web ParentWeb
        {
            get
            {
                object obj;
                Web web;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ParentWeb", out obj))
                {
                    web = (Web)obj;
                }
                else
                {
                    web = new Web(base.Context, new ObjectPathProperty(base.Context, base.Path, "ParentWeb"));
                    base.ObjectData.ClientObjectProperties["ParentWeb"] = web;
                }
                return web;
            }
        }

        [Remote]
        public ResourcePath ParentWebPath
        {
            get
            {
                base.CheckUninitializedProperty("ParentWebPath");
                return (ResourcePath)base.ObjectData.Properties["ParentWebPath"];
            }
        }

        [Remote]
        public string ParentWebUrl
        {
            get
            {
                base.CheckUninitializedProperty("ParentWebUrl");
                return (string)base.ObjectData.Properties["ParentWebUrl"];
            }
        }

        [Remote]
        public bool ParserDisabled
        {
            get
            {
                base.CheckUninitializedProperty("ParserDisabled");
                return (bool)base.ObjectData.Properties["ParserDisabled"];
            }
            set
            {
                base.ObjectData.Properties["ParserDisabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ParserDisabled", value));
                }
            }
        }

        [Remote]
        public int ReadSecurity
        {
            get
            {
                base.CheckUninitializedProperty("ReadSecurity");
                return (int)base.ObjectData.Properties["ReadSecurity"];
            }
            set
            {
                base.ObjectData.Properties["ReadSecurity"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ReadSecurity", value));
                }
            }
        }

        [Remote]
        public Folder RootFolder
        {
            get
            {
                object obj;
                Folder folder;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("RootFolder", out obj))
                {
                    folder = (Folder)obj;
                }
                else
                {
                    folder = new Folder(base.Context, new ObjectPathProperty(base.Context, base.Path, "RootFolder"));
                    base.ObjectData.ClientObjectProperties["RootFolder"] = folder;
                }
                return folder;
            }
        }

        [Remote]
        public string SchemaXml
        {
            get
            {
                base.CheckUninitializedProperty("SchemaXml");
                return (string)base.ObjectData.Properties["SchemaXml"];
            }
        }

        [Remote]
        public bool ServerTemplateCanCreateFolders
        {
            get
            {
                base.CheckUninitializedProperty("ServerTemplateCanCreateFolders");
                return (bool)base.ObjectData.Properties["ServerTemplateCanCreateFolders"];
            }
        }

        [Remote]
        public Guid TemplateFeatureId
        {
            get
            {
                base.CheckUninitializedProperty("TemplateFeatureId");
                return (Guid)base.ObjectData.Properties["TemplateFeatureId"];
            }
        }

        [Remote]
        public string Title
        {
            get
            {
                base.CheckUninitializedProperty("Title");
                return (string)base.ObjectData.Properties["Title"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["Title"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Title", value));
                }
            }
        }

        [Remote]
        public UserResource TitleResource
        {
            get
            {
                object obj;
                UserResource userResource;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("TitleResource", out obj))
                {
                    userResource = (UserResource)obj;
                }
                else
                {
                    userResource = new UserResource(base.Context, new ObjectPathProperty(base.Context, base.Path, "TitleResource"));
                    base.ObjectData.ClientObjectProperties["TitleResource"] = userResource;
                }
                return userResource;
            }
        }

        [Remote]
        public UserCustomActionCollection UserCustomActions
        {
            get
            {
                object obj;
                UserCustomActionCollection userCustomActionCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("UserCustomActions", out obj))
                {
                    userCustomActionCollection = (UserCustomActionCollection)obj;
                }
                else
                {
                    userCustomActionCollection = new UserCustomActionCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "UserCustomActions"));
                    base.ObjectData.ClientObjectProperties["UserCustomActions"] = userCustomActionCollection;
                }
                return userCustomActionCollection;
            }
        }

        [Remote]
        public string ValidationFormula
        {
            get
            {
                base.CheckUninitializedProperty("ValidationFormula");
                return (string)base.ObjectData.Properties["ValidationFormula"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length > 1023)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["ValidationFormula"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ValidationFormula", value));
                }
            }
        }

        [Remote]
        public string ValidationMessage
        {
            get
            {
                base.CheckUninitializedProperty("ValidationMessage");
                return (string)base.ObjectData.Properties["ValidationMessage"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length > 1024)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["ValidationMessage"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ValidationMessage", value));
                }
            }
        }

        [Remote]
        public ViewCollection Views
        {
            get
            {
                object obj;
                ViewCollection viewCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Views", out obj))
                {
                    viewCollection = (ViewCollection)obj;
                }
                else
                {
                    viewCollection = new ViewCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Views"));
                    base.ObjectData.ClientObjectProperties["Views"] = viewCollection;
                }
                return viewCollection;
            }
        }

        [Remote]
        public WorkflowAssociationCollection WorkflowAssociations
        {
            get
            {
                object obj;
                WorkflowAssociationCollection workflowAssociationCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("WorkflowAssociations", out obj))
                {
                    workflowAssociationCollection = (WorkflowAssociationCollection)obj;
                }
                else
                {
                    workflowAssociationCollection = new WorkflowAssociationCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "WorkflowAssociations"));
                    base.ObjectData.ClientObjectProperties["WorkflowAssociations"] = workflowAssociationCollection;
                }
                return workflowAssociationCollection;
            }
        }

        [Remote]
        public int WriteSecurity
        {
            get
            {
                base.CheckUninitializedProperty("WriteSecurity");
                return (int)base.ObjectData.Properties["WriteSecurity"];
            }
            set
            {
                base.ObjectData.Properties["WriteSecurity"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "WriteSecurity", value));
                }
            }
        }

        internal void InitFromCreationInformation(ListCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Description"] = creation.Description;
                base.ObjectData.Properties["TemplateFeatureId"] = creation.TemplateFeatureId;
                base.ObjectData.Properties["Title"] = creation.Title;
            }
        }

        public ListItem GetItemById(string id)
        {
            return this.GetItemByStringId(id);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public List(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "AllowContentTypes":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowContentTypes"] = reader.ReadBoolean();
                    break;
                case "AllowDeletion":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowDeletion"] = reader.ReadBoolean();
                    break;
                case "BaseTemplate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["BaseTemplate"] = reader.ReadInt32();
                    break;
                case "BaseType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["BaseType"] = reader.ReadEnum<BaseType>();
                    break;
                case "BrowserFileHandling":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["BrowserFileHandling"] = reader.ReadEnum<BrowserFileHandling>();
                    break;
                case "ContentTypes":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ContentTypes", this.ContentTypes, reader);
                    this.ContentTypes.FromJson(reader);
                    break;
                case "ContentTypesEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ContentTypesEnabled"] = reader.ReadBoolean();
                    break;
                case "CrawlNonDefaultViews":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CrawlNonDefaultViews"] = reader.ReadBoolean();
                    break;
                case "CreatablesInfo":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("CreatablesInfo", this.CreatablesInfo, reader);
                    this.CreatablesInfo.FromJson(reader);
                    break;
                case "Created":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Created"] = reader.ReadDateTime();
                    break;
                case "CurrentChangeToken":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CurrentChangeToken"] = reader.Read<ChangeToken>();
                    break;
                case "CustomActionElements":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CustomActionElements"] = reader.Read<CustomActionElementCollection>();
                    break;
                case "DataSource":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DataSource"] = reader.Read<ListDataSource>();
                    break;
                case "DefaultContentApprovalWorkflowId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultContentApprovalWorkflowId"] = reader.ReadGuid();
                    break;
                case "DefaultDisplayFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultDisplayFormUrl"] = reader.ReadString();
                    break;
                case "DefaultEditFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultEditFormUrl"] = reader.ReadString();
                    break;
                case "DefaultNewFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultNewFormUrl"] = reader.ReadString();
                    break;
                case "DefaultView":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("DefaultView", this.DefaultView, reader);
                    this.DefaultView.FromJson(reader);
                    break;
                case "DefaultViewPath":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultViewPath"] = reader.Read<ResourcePath>();
                    break;
                case "DefaultViewUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultViewUrl"] = reader.ReadString();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "DescriptionResource":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("DescriptionResource", this.DescriptionResource, reader);
                    this.DescriptionResource.FromJson(reader);
                    break;
                case "Direction":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Direction"] = reader.ReadString();
                    break;
                case "DocumentTemplateUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DocumentTemplateUrl"] = reader.ReadString();
                    break;
                case "DraftVersionVisibility":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DraftVersionVisibility"] = reader.ReadEnum<DraftVisibilityType>();
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
                case "EnableAssignToEmail":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableAssignToEmail"] = reader.ReadBoolean();
                    break;
                case "EnableAttachments":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableAttachments"] = reader.ReadBoolean();
                    break;
                case "EnableFolderCreation":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableFolderCreation"] = reader.ReadBoolean();
                    break;
                case "EnableMinorVersions":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableMinorVersions"] = reader.ReadBoolean();
                    break;
                case "EnableModeration":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableModeration"] = reader.ReadBoolean();
                    break;
                case "EnableVersioning":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableVersioning"] = reader.ReadBoolean();
                    break;
                case "EntityTypeName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EntityTypeName"] = reader.ReadString();
                    break;
                case "EventReceivers":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("EventReceivers", this.EventReceivers, reader);
                    this.EventReceivers.FromJson(reader);
                    break;
                case "ExcludeFromOfflineClient":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ExcludeFromOfflineClient"] = reader.ReadBoolean();
                    break;
                case "ExemptFromBlockDownloadOfNonViewableFiles":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ExemptFromBlockDownloadOfNonViewableFiles"] = reader.ReadBoolean();
                    break;
                case "Fields":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Fields", this.Fields, reader);
                    this.Fields.FromJson(reader);
                    break;
                case "FileSavePostProcessingEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["FileSavePostProcessingEnabled"] = reader.ReadBoolean();
                    break;
                case "ForceCheckout":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ForceCheckout"] = reader.ReadBoolean();
                    break;
                case "Forms":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Forms", this.Forms, reader);
                    this.Forms.FromJson(reader);
                    break;
                case "HasExternalDataSource":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["HasExternalDataSource"] = reader.ReadBoolean();
                    break;
                case "Hidden":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Hidden"] = reader.ReadBoolean();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "ImageUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ImageUrl"] = reader.ReadString();
                    break;
                case "InformationRightsManagementSettings":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("InformationRightsManagementSettings", this.InformationRightsManagementSettings, reader);
                    this.InformationRightsManagementSettings.FromJson(reader);
                    break;
                case "IrmEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IrmEnabled"] = reader.ReadBoolean();
                    break;
                case "IrmExpire":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IrmExpire"] = reader.ReadBoolean();
                    break;
                case "IrmReject":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IrmReject"] = reader.ReadBoolean();
                    break;
                case "IsApplicationList":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsApplicationList"] = reader.ReadBoolean();
                    break;
                case "IsCatalog":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsCatalog"] = reader.ReadBoolean();
                    break;
                case "IsPrivate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsPrivate"] = reader.ReadBoolean();
                    break;
                case "IsSiteAssetsLibrary":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsSiteAssetsLibrary"] = reader.ReadBoolean();
                    break;
                case "IsSystemList":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsSystemList"] = reader.ReadBoolean();
                    break;
                case "ItemCount":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ItemCount"] = reader.ReadInt32();
                    break;
                case "LastItemDeletedDate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LastItemDeletedDate"] = reader.ReadDateTime();
                    break;
                case "LastItemModifiedDate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LastItemModifiedDate"] = reader.ReadDateTime();
                    break;
                case "LastItemUserModifiedDate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LastItemUserModifiedDate"] = reader.ReadDateTime();
                    break;
                case "ListExperienceOptions":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListExperienceOptions"] = reader.ReadEnum<ListExperience>();
                    break;
                case "ListItemEntityTypeFullName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListItemEntityTypeFullName"] = reader.ReadString();
                    break;
                case "MajorVersionLimit":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MajorVersionLimit"] = reader.ReadInt32();
                    break;
                case "MajorWithMinorVersionsLimit":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MajorWithMinorVersionsLimit"] = reader.ReadInt32();
                    break;
                case "MultipleDataList":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MultipleDataList"] = reader.ReadBoolean();
                    break;
                case "NoCrawl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NoCrawl"] = reader.ReadBoolean();
                    break;
                case "OnQuickLaunch":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["OnQuickLaunch"] = reader.ReadBoolean();
                    break;
                case "ParentWeb":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ParentWeb", this.ParentWeb, reader);
                    this.ParentWeb.FromJson(reader);
                    break;
                case "ParentWebPath":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ParentWebPath"] = reader.Read<ResourcePath>();
                    break;
                case "ParentWebUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ParentWebUrl"] = reader.ReadString();
                    break;
                case "ParserDisabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ParserDisabled"] = reader.ReadBoolean();
                    break;
                case "ReadSecurity":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReadSecurity"] = reader.ReadInt32();
                    break;
                case "RootFolder":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("RootFolder", this.RootFolder, reader);
                    this.RootFolder.FromJson(reader);
                    break;
                case "SchemaXml":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SchemaXml"] = reader.ReadString();
                    break;
                case "ServerTemplateCanCreateFolders":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerTemplateCanCreateFolders"] = reader.ReadBoolean();
                    break;
                case "TemplateFeatureId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TemplateFeatureId"] = reader.ReadGuid();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                case "TitleResource":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("TitleResource", this.TitleResource, reader);
                    this.TitleResource.FromJson(reader);
                    break;
                case "UserCustomActions":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("UserCustomActions", this.UserCustomActions, reader);
                    this.UserCustomActions.FromJson(reader);
                    break;
                case "ValidationFormula":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ValidationFormula"] = reader.ReadString();
                    break;
                case "ValidationMessage":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ValidationMessage"] = reader.ReadString();
                    break;
                case "Views":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Views", this.Views, reader);
                    this.Views.FromJson(reader);
                    break;
                case "WorkflowAssociations":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("WorkflowAssociations", this.WorkflowAssociations, reader);
                    this.WorkflowAssociations.FromJson(reader);
                    break;
                case "WriteSecurity":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["WriteSecurity"] = reader.ReadInt32();
                    break;
            }
            return flag;
        }

        [Remote]
        public ClientResult<string> SaveAsNewView(string oldName, string newName, bool privateView, string uri)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "SaveAsNewView", new object[]
            {
                oldName,
                newName,
                privateView,
                uri
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public View CreateMappedView(AppViewCreationInfo appViewCreationInfo, VisualizationAppTarget visualizationTarget)
        {
            ClientRuntimeContext context = base.Context;
            return new View(context, new ObjectPathMethod(context, base.Path, "CreateMappedView", new object[]
            {
                appViewCreationInfo,
                visualizationTarget
            }));
        }

        [Remote]
        public View PublishMappedView(Guid appId, VisualizationAppTarget visualizationTarget)
        {
            ClientRuntimeContext context = base.Context;
            return new View(context, new ObjectPathMethod(context, base.Path, "PublishMappedView", new object[]
            {
                appId,
                visualizationTarget
            }));
        }

        [Remote]
        public View UnpublishMappedView(Guid appId, VisualizationAppTarget visualizationTarget)
        {
            ClientRuntimeContext context = base.Context;
            return new View(context, new ObjectPathMethod(context, base.Path, "UnpublishMappedView", new object[]
            {
                appId,
                visualizationTarget
            }));
        }

        [Remote]
        public VisualizationAppSynchronizationResult GetMappedApp(Guid appId, VisualizationAppTarget visualizationAppTarget)
        {
            ClientRuntimeContext context = base.Context;
            return new VisualizationAppSynchronizationResult(context, new ObjectPathMethod(context, base.Path, "GetMappedApp", new object[]
            {
                appId,
                visualizationAppTarget
            }));
        }

        [Remote]
        public VisualizationAppSynchronizationResult GetMappedApps(VisualizationAppTarget visualizationAppTarget)
        {
            ClientRuntimeContext context = base.Context;
            return new VisualizationAppSynchronizationResult(context, new ObjectPathMethod(context, base.Path, "GetMappedApps", new object[]
            {
                visualizationAppTarget
            }));
        }

        [Remote]
        public FlowSynchronizationResult SyncFlowTemplates()
        {
            ClientRuntimeContext context = base.Context;
            return new FlowSynchronizationResult(context, new ObjectPathMethod(context, base.Path, "SyncFlowTemplates", null));
        }

        [Remote]
        public FlowSynchronizationResult SyncFlowInstances()
        {
            ClientRuntimeContext context = base.Context;
            return new FlowSynchronizationResult(context, new ObjectPathMethod(context, base.Path, "SyncFlowInstances", null));
        }

        [Remote]
        public FlowSynchronizationResult SyncFlowCallbackUrl(string flowId)
        {
            ClientRuntimeContext context = base.Context;
            return new FlowSynchronizationResult(context, new ObjectPathMethod(context, base.Path, "SyncFlowCallbackUrl", new object[]
            {
                flowId
            }));
        }

        [Remote]
        public ClientResult<string> CreateDocumentAndGetEditLink(string fileName, string folderPath, int documentTemplateType, string templateUrl)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "CreateDocumentAndGetEditLink", new object[]
            {
                fileName,
                folderPath,
                documentTemplateType,
                templateUrl
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<string> CreateDocumentWithDefaultName(string folderPath, string extension)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "CreateDocumentWithDefaultName", new object[]
            {
                folderPath,
                extension
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ListItem CreateDocument(string fileName, Folder targetFolder, DocumentTemplateType templateType)
        {
            ClientRuntimeContext context = base.Context;
            return new ListItem(context, new ObjectPathMethod(context, base.Path, "CreateDocument", new object[]
            {
                fileName,
                targetFolder,
                templateType
            }));
        }

        [Remote]
        public ListItem CreateDocumentFromTemplateStream(string fileName, Folder targetFolder, string extension, Stream templateStream)
        {
            ClientRuntimeContext context = base.Context;
            return new ListItem(context, new ObjectPathMethod(context, base.Path, "CreateDocumentFromTemplateStream", new object[]
            {
                fileName,
                targetFolder,
                extension,
                templateStream
            }));
        }

        [Remote]
        public ListItem CreateDocumentFromTemplateBytes(string fileName, Folder targetFolder, byte[] templateBytes, string extension)
        {
            ClientRuntimeContext context = base.Context;
            return new ListItem(context, new ObjectPathMethod(context, base.Path, "CreateDocumentFromTemplateBytes", new object[]
            {
                fileName,
                targetFolder,
                templateBytes,
                extension
            }));
        }

        [Remote]
        public ListItem CreateDocumentFromTemplate(string fileName, Folder targetFolder, string templateUrl)
        {
            ClientRuntimeContext context = base.Context;
            return new ListItem(context, new ObjectPathMethod(context, base.Path, "CreateDocumentFromTemplate", new object[]
            {
                fileName,
                targetFolder,
                templateUrl
            }));
        }

        [Remote]
        public ClientResult<string> GetSpecialFolderUrl(SpecialFolderType type, bool bForceCreate, Guid existingFolderGuid)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetSpecialFolderUrl", new object[]
            {
                type,
                bForceCreate,
                existingFolderGuid
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<string> GetWebDavUrl(string sourceUrl)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetWebDavUrl", new object[]
            {
                sourceUrl
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
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
        public static ClientResult<Stream> GetListDataAsStream(ClientRuntimeContext context, string listFullUrl, RenderListDataParameters parameters, RenderListDataOverrideParameters overrideParameters)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.ValidateOnClient && parameters == null)
            {
                throw ClientUtility.CreateArgumentNullException("parameters");
            }
            ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{d89f0b18-614e-4b4a-bac0-fd6142b55448}", "GetListDataAsStream", new object[]
            {
                listFullUrl,
                parameters,
                overrideParameters
            });
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<Stream> RenderListDataAsStream(RenderListDataParameters parameters, RenderListDataOverrideParameters overrideParameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && parameters == null)
            {
                throw ClientUtility.CreateArgumentNullException("parameters");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "RenderListDataAsStream", new object[]
            {
                parameters,
                overrideParameters
            });
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<Stream> RenderListFilterData(RenderListFilterDataParameters parameters)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "RenderListFilterData", new object[]
            {
                parameters
            });
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<Stream> RenderListContextMenuData(RenderListContextMenuDataParameters parameters)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "RenderListContextMenuData", new object[]
            {
                parameters
            });
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public void SaveAsTemplate(string strFileName, string strName, string strDescription, bool bSaveData)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SaveAsTemplate", new object[]
            {
                strFileName,
                strName,
                strDescription,
                bSaveData
            });
            context.AddQuery(query);
        }

        [Remote]
        public ClientResult<int> ReserveListItemId()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "ReserveListItemId", null);
            context.AddQuery(clientAction);
            ClientResult<int> clientResult = new ClientResult<int>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
        }

        [Remote]
        public View GetView(Guid viewGuid)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, View> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetView", out obj))
            {
                dictionary = (Dictionary<Guid, View>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, View>();
                base.ObjectData.MethodReturnObjects["GetView"] = dictionary;
            }
            View view = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(viewGuid, out view))
            {
                return view;
            }
            view = new View(context, new ObjectPathMethod(context, base.Path, "GetView", new object[]
            {
                viewGuid
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[viewGuid] = view;
            }
            return view;
        }

        [Remote]
        public ListItemCollection GetItems(CamlQuery query)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (query == null)
                {
                    throw ClientUtility.CreateArgumentNullException("query");
                }
                Uri uri;
                if (query != null && query.FolderServerRelativeUrl != null && (!query.FolderServerRelativeUrl.StartsWith("/", StringComparison.Ordinal) || !Uri.TryCreate(query.FolderServerRelativeUrl, UriKind.Relative, out uri)))
                {
                    throw ClientUtility.CreateArgumentException("query.FolderServerRelativeUrl");
                }
            }
            return new ListItemCollection(context, new ObjectPathMethod(context, base.Path, "GetItems", new object[]
            {
                query
            }));
        }

        [Remote]
        public ListItem GetItemById(int id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<int, ListItem> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetItemById", out obj))
            {
                dictionary = (Dictionary<int, ListItem>)obj;
            }
            else
            {
                dictionary = new Dictionary<int, ListItem>();
                base.ObjectData.MethodReturnObjects["GetItemById"] = dictionary;
            }
            ListItem listItem = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out listItem))
            {
                return listItem;
            }
            listItem = new ListItem(context, new ObjectPathMethod(context, base.Path, "GetItemById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = listItem;
            }
            return listItem;
        }

        [Remote]
        internal ListItem GetItemByStringId(string sId)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (sId == null)
                {
                    throw ClientUtility.CreateArgumentNullException("sId");
                }
                if (sId != null && sId.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("sId");
                }
            }
            object obj;
            Dictionary<string, ListItem> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetItemByStringId", out obj))
            {
                dictionary = (Dictionary<string, ListItem>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, ListItem>();
                base.ObjectData.MethodReturnObjects["GetItemByStringId"] = dictionary;
            }
            ListItem listItem = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(sId, out listItem))
            {
                return listItem;
            }
            listItem = new ListItem(context, new ObjectPathMethod(context, base.Path, "GetItemByStringId", new object[]
            {
                sId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[sId] = listItem;
            }
            return listItem;
        }

        [Remote]
        public void SetExemptFromBlockDownloadOfNonViewableFiles(bool value)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SetExemptFromBlockDownloadOfNonViewableFiles", new object[]
            {
                value
            });
            context.AddQuery(query);
        }

        [Remote]
        public ListItem GetItemByUniqueId(Guid uniqueId)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, ListItem> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetItemByUniqueId", out obj))
            {
                dictionary = (Dictionary<Guid, ListItem>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, ListItem>();
                base.ObjectData.MethodReturnObjects["GetItemByUniqueId"] = dictionary;
            }
            ListItem listItem = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(uniqueId, out listItem))
            {
                return listItem;
            }
            listItem = new ListItem(context, new ObjectPathMethod(context, base.Path, "GetItemByUniqueId", new object[]
            {
                uniqueId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[uniqueId] = listItem;
            }
            return listItem;
        }

        [Remote]
        public RelatedFieldCollection GetRelatedFields()
        {
            ClientRuntimeContext context = base.Context;
            return new RelatedFieldCollection(context, new ObjectPathMethod(context, base.Path, "GetRelatedFields", null));
        }

        [Remote]
        public ClientResult<string> RenderExtendedListFormData(int itemId, string formId, int mode, RenderListFormDataOptions options)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && formId == null)
            {
                throw ClientUtility.CreateArgumentNullException("formId");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "RenderExtendedListFormData", new object[]
            {
                itemId,
                formId,
                mode,
                options
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<string> RenderListFormData(int itemId, string formId, int mode)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && formId == null)
            {
                throw ClientUtility.CreateArgumentNullException("formId");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "RenderListFormData", new object[]
            {
                itemId,
                formId,
                mode
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<string> RenderListData(string viewXml)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && viewXml == null)
            {
                throw ClientUtility.CreateArgumentNullException("viewXml");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "RenderListData", new object[]
            {
                viewXml
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ListItem AddItem(ListItemCreationInformation parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && parameters != null && parameters.LeafName != null && parameters.LeafName.Length > 128)
            {
                throw ClientUtility.CreateArgumentException("parameters.LeafName");
            }
            ListItem listItem = new ListItem(context, new ObjectPathMethod(context, base.Path, "AddItem", new object[]
            {
                parameters
            }));
            listItem.InitFromCreationInformation(parameters);
            return listItem;
        }

        [Remote]
        public ListItem AddItemUsingPath(ListItemCreationInformationUsingPath parameters)
        {
            ClientRuntimeContext context = base.Context;
            ListItem listItem = new ListItem(context, new ObjectPathMethod(context, base.Path, "AddItemUsingPath", new object[]
            {
                parameters
            }));
            listItem.InitFromCreationInformationUsingPath(parameters);
            return listItem;
        }
    }
}
