using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Net;
using Microsoft.SharePoint.Client.NetCore.Workflow;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Web", ServerTypeId = "{a489add2-5d3a-4de8-9445-49259462dceb}")]
    public class Web : SecurableObject
    {
        [Remote]
        public AlertCollection Alerts
        {
            get
            {
                object obj;
                AlertCollection alertCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Alerts", out obj))
                {
                    alertCollection = (AlertCollection)obj;
                }
                else
                {
                    alertCollection = new AlertCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Alerts"));
                    base.ObjectData.ClientObjectProperties["Alerts"] = alertCollection;
                }
                return alertCollection;
            }
        }

        [Remote]
        public bool AllowAutomaticASPXPageIndexing
        {
            get
            {
                base.CheckUninitializedProperty("AllowAutomaticASPXPageIndexing");
                return (bool)base.ObjectData.Properties["AllowAutomaticASPXPageIndexing"];
            }
            set
            {
                base.ObjectData.Properties["AllowAutomaticASPXPageIndexing"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowAutomaticASPXPageIndexing", value));
                }
            }
        }

        [Remote]
        public bool AllowCreateDeclarativeWorkflowForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("AllowCreateDeclarativeWorkflowForCurrentUser");
                return (bool)base.ObjectData.Properties["AllowCreateDeclarativeWorkflowForCurrentUser"];
            }
        }

        [Remote]
        public bool AllowDesignerForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("AllowDesignerForCurrentUser");
                return (bool)base.ObjectData.Properties["AllowDesignerForCurrentUser"];
            }
        }

        [Remote]
        public bool AllowMasterPageEditingForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("AllowMasterPageEditingForCurrentUser");
                return (bool)base.ObjectData.Properties["AllowMasterPageEditingForCurrentUser"];
            }
        }

        [Remote]
        public bool AllowRevertFromTemplateForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("AllowRevertFromTemplateForCurrentUser");
                return (bool)base.ObjectData.Properties["AllowRevertFromTemplateForCurrentUser"];
            }
        }

        [Remote]
        public bool AllowRssFeeds
        {
            get
            {
                base.CheckUninitializedProperty("AllowRssFeeds");
                return (bool)base.ObjectData.Properties["AllowRssFeeds"];
            }
        }

        [Remote]
        public bool AllowSaveDeclarativeWorkflowAsTemplateForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("AllowSaveDeclarativeWorkflowAsTemplateForCurrentUser");
                return (bool)base.ObjectData.Properties["AllowSaveDeclarativeWorkflowAsTemplateForCurrentUser"];
            }
        }

        [Remote]
        public bool AllowSavePublishDeclarativeWorkflowForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("AllowSavePublishDeclarativeWorkflowForCurrentUser");
                return (bool)base.ObjectData.Properties["AllowSavePublishDeclarativeWorkflowForCurrentUser"];
            }
        }

        [Remote]
        public PropertyValues AllProperties
        {
            get
            {
                object obj;
                PropertyValues propertyValues;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AllProperties", out obj))
                {
                    propertyValues = (PropertyValues)obj;
                }
                else
                {
                    propertyValues = new PropertyValues(base.Context, new ObjectPathProperty(base.Context, base.Path, "AllProperties"));
                    base.ObjectData.ClientObjectProperties["AllProperties"] = propertyValues;
                }
                return propertyValues;
            }
        }

        [Remote]
        public string AlternateCssUrl
        {
            get
            {
                base.CheckUninitializedProperty("AlternateCssUrl");
                return (string)base.ObjectData.Properties["AlternateCssUrl"];
            }
            set
            {
                base.ObjectData.Properties["AlternateCssUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AlternateCssUrl", value));
                }
            }
        }

        [Remote]
        public Guid AppInstanceId
        {
            get
            {
                base.CheckUninitializedProperty("AppInstanceId");
                return (Guid)base.ObjectData.Properties["AppInstanceId"];
            }
        }

        //[Remote]
        //public AppTileCollection AppTiles
        //{
        //    get
        //    {
        //        object obj;
        //        AppTileCollection appTileCollection;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("AppTiles", out obj))
        //        {
        //            appTileCollection = (AppTileCollection)obj;
        //        }
        //        else
        //        {
        //            appTileCollection = new AppTileCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "AppTiles"));
        //            base.ObjectData.ClientObjectProperties["AppTiles"] = appTileCollection;
        //        }
        //        return appTileCollection;
        //    }
        //}

        [Remote]
        public Group AssociatedMemberGroup
        {
            get
            {
                object obj;
                Group group;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AssociatedMemberGroup", out obj))
                {
                    group = (Group)obj;
                }
                else
                {
                    group = new Group(base.Context, new ObjectPathProperty(base.Context, base.Path, "AssociatedMemberGroup"));
                    base.ObjectData.ClientObjectProperties["AssociatedMemberGroup"] = group;
                }
                return group;
            }
            set
            {
                base.ObjectData.ClientObjectProperties["AssociatedMemberGroup"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AssociatedMemberGroup", value));
                }
            }
        }

        [Remote]
        public Group AssociatedOwnerGroup
        {
            get
            {
                object obj;
                Group group;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AssociatedOwnerGroup", out obj))
                {
                    group = (Group)obj;
                }
                else
                {
                    group = new Group(base.Context, new ObjectPathProperty(base.Context, base.Path, "AssociatedOwnerGroup"));
                    base.ObjectData.ClientObjectProperties["AssociatedOwnerGroup"] = group;
                }
                return group;
            }
            set
            {
                base.ObjectData.ClientObjectProperties["AssociatedOwnerGroup"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AssociatedOwnerGroup", value));
                }
            }
        }

        [Remote]
        public Group AssociatedVisitorGroup
        {
            get
            {
                object obj;
                Group group;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AssociatedVisitorGroup", out obj))
                {
                    group = (Group)obj;
                }
                else
                {
                    group = new Group(base.Context, new ObjectPathProperty(base.Context, base.Path, "AssociatedVisitorGroup"));
                    base.ObjectData.ClientObjectProperties["AssociatedVisitorGroup"] = group;
                }
                return group;
            }
            set
            {
                base.ObjectData.ClientObjectProperties["AssociatedVisitorGroup"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AssociatedVisitorGroup", value));
                }
            }
        }

        [Remote]
        public User Author
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Author", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "Author"));
                    base.ObjectData.ClientObjectProperties["Author"] = user;
                }
                return user;
            }
        }

        [Remote]
        public ContentTypeCollection AvailableContentTypes
        {
            get
            {
                object obj;
                ContentTypeCollection contentTypeCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AvailableContentTypes", out obj))
                {
                    contentTypeCollection = (ContentTypeCollection)obj;
                }
                else
                {
                    contentTypeCollection = new ContentTypeCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "AvailableContentTypes"));
                    base.ObjectData.ClientObjectProperties["AvailableContentTypes"] = contentTypeCollection;
                }
                return contentTypeCollection;
            }
        }

        [Remote]
        public FieldCollection AvailableFields
        {
            get
            {
                object obj;
                FieldCollection fieldCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AvailableFields", out obj))
                {
                    fieldCollection = (FieldCollection)obj;
                }
                else
                {
                    fieldCollection = new FieldCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "AvailableFields"));
                    base.ObjectData.ClientObjectProperties["AvailableFields"] = fieldCollection;
                }
                return fieldCollection;
            }
        }

        [Remote]
        public short Configuration
        {
            get
            {
                base.CheckUninitializedProperty("Configuration");
                return (short)base.ObjectData.Properties["Configuration"];
            }
        }

        [Remote]
        public bool ContainsConfidentialInfo
        {
            get
            {
                base.CheckUninitializedProperty("ContainsConfidentialInfo");
                return (bool)base.ObjectData.Properties["ContainsConfidentialInfo"];
            }
            set
            {
                base.ObjectData.Properties["ContainsConfidentialInfo"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ContainsConfidentialInfo", value));
                }
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
        public User CurrentUser
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("CurrentUser", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "CurrentUser"));
                    base.ObjectData.ClientObjectProperties["CurrentUser"] = user;
                }
                return user;
            }
        }

        [Remote]
        public string CustomMasterUrl
        {
            get
            {
                base.CheckUninitializedProperty("CustomMasterUrl");
                return (string)base.ObjectData.Properties["CustomMasterUrl"];
            }
            set
            {
                base.ObjectData.Properties["CustomMasterUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "CustomMasterUrl", value));
                }
            }
        }

        //[Remote]
        //public SPDataLeakagePreventionStatusInfo DataLeakagePreventionStatusInfo
        //{
        //    get
        //    {
        //        object obj;
        //        SPDataLeakagePreventionStatusInfo sPDataLeakagePreventionStatusInfo;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("DataLeakagePreventionStatusInfo", out obj))
        //        {
        //            sPDataLeakagePreventionStatusInfo = (SPDataLeakagePreventionStatusInfo)obj;
        //        }
        //        else
        //        {
        //            sPDataLeakagePreventionStatusInfo = new SPDataLeakagePreventionStatusInfo(base.Context, new ObjectPathProperty(base.Context, base.Path, "DataLeakagePreventionStatusInfo"));
        //            base.ObjectData.ClientObjectProperties["DataLeakagePreventionStatusInfo"] = sPDataLeakagePreventionStatusInfo;
        //        }
        //        return sPDataLeakagePreventionStatusInfo;
        //    }
        //}

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
        public string DesignerDownloadUrlForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("DesignerDownloadUrlForCurrentUser");
                return (string)base.ObjectData.Properties["DesignerDownloadUrlForCurrentUser"];
            }
        }

        [Remote]
        public Guid DesignPackageId
        {
            get
            {
                base.CheckUninitializedProperty("DesignPackageId");
                return (Guid)base.ObjectData.Properties["DesignPackageId"];
            }
            set
            {
                base.ObjectData.Properties["DesignPackageId"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DesignPackageId", value));
                }
            }
        }

        [Remote]
        public bool DisableAppViews
        {
            get
            {
                base.CheckUninitializedProperty("DisableAppViews");
                return (bool)base.ObjectData.Properties["DisableAppViews"];
            }
            set
            {
                base.ObjectData.Properties["DisableAppViews"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DisableAppViews", value));
                }
            }
        }

        [Remote]
        public bool DisableFlows
        {
            get
            {
                base.CheckUninitializedProperty("DisableFlows");
                return (bool)base.ObjectData.Properties["DisableFlows"];
            }
            set
            {
                base.ObjectData.Properties["DisableFlows"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DisableFlows", value));
                }
            }
        }

        [Remote]
        public bool DocumentLibraryCalloutOfficeWebAppPreviewersDisabled
        {
            get
            {
                base.CheckUninitializedProperty("DocumentLibraryCalloutOfficeWebAppPreviewersDisabled");
                return (bool)base.ObjectData.Properties["DocumentLibraryCalloutOfficeWebAppPreviewersDisabled"];
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
        public bool EnableMinimalDownload
        {
            get
            {
                base.CheckUninitializedProperty("EnableMinimalDownload");
                return (bool)base.ObjectData.Properties["EnableMinimalDownload"];
            }
            set
            {
                base.ObjectData.Properties["EnableMinimalDownload"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnableMinimalDownload", value));
                }
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

        //[Remote]
        //public FeatureCollection Features
        //{
        //    get
        //    {
        //        object obj;
        //        FeatureCollection featureCollection;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("Features", out obj))
        //        {
        //            featureCollection = (FeatureCollection)obj;
        //        }
        //        else
        //        {
        //            featureCollection = new FeatureCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Features"));
        //            base.ObjectData.ClientObjectProperties["Features"] = featureCollection;
        //        }
        //        return featureCollection;
        //    }
        //}

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
        public Guid Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (Guid)base.ObjectData.Properties["Id"];
            }
        }

        [Remote]
        public bool IsMultilingual
        {
            get
            {
                base.CheckUninitializedProperty("IsMultilingual");
                return (bool)base.ObjectData.Properties["IsMultilingual"];
            }
            set
            {
                base.ObjectData.Properties["IsMultilingual"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IsMultilingual", value));
                }
            }
        }

        [Remote]
        public uint Language
        {
            get
            {
                base.CheckUninitializedProperty("Language");
                return (uint)base.ObjectData.Properties["Language"];
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
        }

        [Remote]
        public DateTime LastItemUserModifiedDate
        {
            get
            {
                base.CheckUninitializedProperty("LastItemUserModifiedDate");
                return (DateTime)base.ObjectData.Properties["LastItemUserModifiedDate"];
            }
        }

        [Remote]
        public ListCollection Lists
        {
            get
            {
                object obj;
                ListCollection listCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Lists", out obj))
                {
                    listCollection = (ListCollection)obj;
                }
                else
                {
                    listCollection = new ListCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Lists"));
                    base.ObjectData.ClientObjectProperties["Lists"] = listCollection;
                }
                return listCollection;
            }
        }

        [Remote]
        public ListTemplateCollection ListTemplates
        {
            get
            {
                object obj;
                ListTemplateCollection listTemplateCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ListTemplates", out obj))
                {
                    listTemplateCollection = (ListTemplateCollection)obj;
                }
                else
                {
                    listTemplateCollection = new ListTemplateCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "ListTemplates"));
                    base.ObjectData.ClientObjectProperties["ListTemplates"] = listTemplateCollection;
                }
                return listTemplateCollection;
            }
        }

        [Remote]
        public string MasterUrl
        {
            get
            {
                base.CheckUninitializedProperty("MasterUrl");
                return (string)base.ObjectData.Properties["MasterUrl"];
            }
            set
            {
                base.ObjectData.Properties["MasterUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MasterUrl", value));
                }
            }
        }

        [Remote]
        public bool MembersCanShare
        {
            get
            {
                base.CheckUninitializedProperty("MembersCanShare");
                return (bool)base.ObjectData.Properties["MembersCanShare"];
            }
            set
            {
                base.ObjectData.Properties["MembersCanShare"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MembersCanShare", value));
                }
            }
        }

        //[Remote]
        //public Navigation Navigation
        //{
        //    get
        //    {
        //        object obj;
        //        Navigation navigation;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("Navigation", out obj))
        //        {
        //            navigation = (Navigation)obj;
        //        }
        //        else
        //        {
        //            navigation = new Navigation(base.Context, new ObjectPathProperty(base.Context, base.Path, "Navigation"));
        //            base.ObjectData.ClientObjectProperties["Navigation"] = navigation;
        //        }
        //        return navigation;
        //    }
        //}

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
        public bool NotificationsInOneDriveForBusinessEnabled
        {
            get
            {
                base.CheckUninitializedProperty("NotificationsInOneDriveForBusinessEnabled");
                return (bool)base.ObjectData.Properties["NotificationsInOneDriveForBusinessEnabled"];
            }
        }

        [Remote]
        public bool NotificationsInSharePointEnabled
        {
            get
            {
                base.CheckUninitializedProperty("NotificationsInSharePointEnabled");
                return (bool)base.ObjectData.Properties["NotificationsInSharePointEnabled"];
            }
        }

        [Remote]
        public bool OverwriteTranslationsOnChange
        {
            get
            {
                base.CheckUninitializedProperty("OverwriteTranslationsOnChange");
                return (bool)base.ObjectData.Properties["OverwriteTranslationsOnChange"];
            }
            set
            {
                base.ObjectData.Properties["OverwriteTranslationsOnChange"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "OverwriteTranslationsOnChange", value));
                }
            }
        }

        [Remote]
        public WebInformation ParentWeb
        {
            get
            {
                object obj;
                WebInformation webInformation;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ParentWeb", out obj))
                {
                    webInformation = (WebInformation)obj;
                }
                else
                {
                    webInformation = new WebInformation(base.Context, new ObjectPathProperty(base.Context, base.Path, "ParentWeb"));
                    base.ObjectData.ClientObjectProperties["ParentWeb"] = webInformation;
                }
                return webInformation;
            }
        }

        [Remote]
        public ResourcePath ResourcePath
        {
            get
            {
                base.CheckUninitializedProperty("ResourcePath");
                return (ResourcePath)base.ObjectData.Properties["ResourcePath"];
            }
        }

        [Remote]
        public bool PreviewFeaturesEnabled
        {
            get
            {
                base.CheckUninitializedProperty("PreviewFeaturesEnabled");
                return (bool)base.ObjectData.Properties["PreviewFeaturesEnabled"];
            }
        }

        //[Remote]
        //public PushNotificationSubscriberCollection PushNotificationSubscribers
        //{
        //    get
        //    {
        //        object obj;
        //        PushNotificationSubscriberCollection pushNotificationSubscriberCollection;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("PushNotificationSubscribers", out obj))
        //        {
        //            pushNotificationSubscriberCollection = (PushNotificationSubscriberCollection)obj;
        //        }
        //        else
        //        {
        //            pushNotificationSubscriberCollection = new PushNotificationSubscriberCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "PushNotificationSubscribers"));
        //            base.ObjectData.ClientObjectProperties["PushNotificationSubscribers"] = pushNotificationSubscriberCollection;
        //        }
        //        return pushNotificationSubscriberCollection;
        //    }
        //}

        [Remote]
        public bool QuickLaunchEnabled
        {
            get
            {
                base.CheckUninitializedProperty("QuickLaunchEnabled");
                return (bool)base.ObjectData.Properties["QuickLaunchEnabled"];
            }
            set
            {
                base.ObjectData.Properties["QuickLaunchEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "QuickLaunchEnabled", value));
                }
            }
        }

        //[Remote]
        //public RecycleBinItemCollection RecycleBin
        //{
        //    get
        //    {
        //        object obj;
        //        RecycleBinItemCollection recycleBinItemCollection;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("RecycleBin", out obj))
        //        {
        //            recycleBinItemCollection = (RecycleBinItemCollection)obj;
        //        }
        //        else
        //        {
        //            recycleBinItemCollection = new RecycleBinItemCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "RecycleBin"));
        //            base.ObjectData.ClientObjectProperties["RecycleBin"] = recycleBinItemCollection;
        //        }
        //        return recycleBinItemCollection;
        //    }
        //}

        [Remote]
        public bool RecycleBinEnabled
        {
            get
            {
                base.CheckUninitializedProperty("RecycleBinEnabled");
                return (bool)base.ObjectData.Properties["RecycleBinEnabled"];
            }
        }

        //[Remote]
        //public RegionalSettings RegionalSettings
        //{
        //    get
        //    {
        //        object obj;
        //        RegionalSettings regionalSettings;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("RegionalSettings", out obj))
        //        {
        //            regionalSettings = (RegionalSettings)obj;
        //        }
        //        else
        //        {
        //            regionalSettings = new RegionalSettings(base.Context, new ObjectPathProperty(base.Context, base.Path, "RegionalSettings"));
        //            base.ObjectData.ClientObjectProperties["RegionalSettings"] = regionalSettings;
        //        }
        //        return regionalSettings;
        //    }
        //}

        [Remote]
        public string RequestAccessEmail
        {
            get
            {
                base.CheckUninitializedProperty("RequestAccessEmail");
                return (string)base.ObjectData.Properties["RequestAccessEmail"];
            }
            set
            {
                base.ObjectData.Properties["RequestAccessEmail"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "RequestAccessEmail", value));
                }
            }
        }

        [Remote]
        public RoleDefinitionCollection RoleDefinitions
        {
            get
            {
                object obj;
                RoleDefinitionCollection roleDefinitionCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("RoleDefinitions", out obj))
                {
                    roleDefinitionCollection = (RoleDefinitionCollection)obj;
                }
                else
                {
                    roleDefinitionCollection = new RoleDefinitionCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "RoleDefinitions"));
                    base.ObjectData.ClientObjectProperties["RoleDefinitions"] = roleDefinitionCollection;
                }
                return roleDefinitionCollection;
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
        public bool SaveSiteAsTemplateEnabled
        {
            get
            {
                base.CheckUninitializedProperty("SaveSiteAsTemplateEnabled");
                return (bool)base.ObjectData.Properties["SaveSiteAsTemplateEnabled"];
            }
            set
            {
                base.ObjectData.Properties["SaveSiteAsTemplateEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "SaveSiteAsTemplateEnabled", value));
                }
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
            set
            {
                if (base.Context.ValidateOnClient && value == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value");
                }
                base.ObjectData.Properties["ServerRelativeUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ServerRelativeUrl", value));
                }
            }
        }

        [Remote]
        public bool ShowUrlStructureForCurrentUser
        {
            get
            {
                base.CheckUninitializedProperty("ShowUrlStructureForCurrentUser");
                return (bool)base.ObjectData.Properties["ShowUrlStructureForCurrentUser"];
            }
        }

        [Remote]
        public GroupCollection SiteGroups
        {
            get
            {
                object obj;
                GroupCollection groupCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("SiteGroups", out obj))
                {
                    groupCollection = (GroupCollection)obj;
                }
                else
                {
                    groupCollection = new GroupCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "SiteGroups"));
                    base.ObjectData.ClientObjectProperties["SiteGroups"] = groupCollection;
                }
                return groupCollection;
            }
        }

        [Remote]
        public string SiteLogoDescription
        {
            get
            {
                base.CheckUninitializedProperty("SiteLogoDescription");
                return (string)base.ObjectData.Properties["SiteLogoDescription"];
            }
            set
            {
                base.ObjectData.Properties["SiteLogoDescription"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "SiteLogoDescription", value));
                }
            }
        }

        [Remote]
        public string SiteLogoUrl
        {
            get
            {
                base.CheckUninitializedProperty("SiteLogoUrl");
                return (string)base.ObjectData.Properties["SiteLogoUrl"];
            }
            set
            {
                base.ObjectData.Properties["SiteLogoUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "SiteLogoUrl", value));
                }
            }
        }

        [Remote]
        public List SiteUserInfoList
        {
            get
            {
                object obj;
                List list;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("SiteUserInfoList", out obj))
                {
                    list = (List)obj;
                }
                else
                {
                    list = new List(base.Context, new ObjectPathProperty(base.Context, base.Path, "SiteUserInfoList"));
                    base.ObjectData.ClientObjectProperties["SiteUserInfoList"] = list;
                }
                return list;
            }
        }

        [Remote]
        public UserCollection SiteUsers
        {
            get
            {
                object obj;
                UserCollection userCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("SiteUsers", out obj))
                {
                    userCollection = (UserCollection)obj;
                }
                else
                {
                    userCollection = new UserCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "SiteUsers"));
                    base.ObjectData.ClientObjectProperties["SiteUsers"] = userCollection;
                }
                return userCollection;
            }
        }

        [Remote]
        public IEnumerable<int> SupportedUILanguageIds
        {
            get
            {
                base.CheckUninitializedProperty("SupportedUILanguageIds");
                return (IEnumerable<int>)base.ObjectData.Properties["SupportedUILanguageIds"];
            }
        }

        [Remote]
        public bool SyndicationEnabled
        {
            get
            {
                base.CheckUninitializedProperty("SyndicationEnabled");
                return (bool)base.ObjectData.Properties["SyndicationEnabled"];
            }
            set
            {
                base.ObjectData.Properties["SyndicationEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "SyndicationEnabled", value));
                }
            }
        }

        [Remote]
        public bool TenantTagPolicyEnabled
        {
            get
            {
                base.CheckUninitializedProperty("TenantTagPolicyEnabled");
                return (bool)base.ObjectData.Properties["TenantTagPolicyEnabled"];
            }
        }

        [Remote]
        public string ThemedCssFolderUrl
        {
            get
            {
                base.CheckUninitializedProperty("ThemedCssFolderUrl");
                return (string)base.ObjectData.Properties["ThemedCssFolderUrl"];
            }
            set
            {
                base.ObjectData.Properties["ThemedCssFolderUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ThemedCssFolderUrl", value));
                }
            }
        }

        //[Remote]
        //public ThemeInfo ThemeInfo
        //{
        //    get
        //    {
        //        object obj;
        //        ThemeInfo themeInfo;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("ThemeInfo", out obj))
        //        {
        //            themeInfo = (ThemeInfo)obj;
        //        }
        //        else
        //        {
        //            themeInfo = new ThemeInfo(base.Context, new ObjectPathProperty(base.Context, base.Path, "ThemeInfo"));
        //            base.ObjectData.ClientObjectProperties["ThemeInfo"] = themeInfo;
        //        }
        //        return themeInfo;
        //    }
        //}

        [Remote]
        public bool ThirdPartyMdmEnabled
        {
            get
            {
                base.CheckUninitializedProperty("ThirdPartyMdmEnabled");
                return (bool)base.ObjectData.Properties["ThirdPartyMdmEnabled"];
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
                if (base.Context.ValidateOnClient && value != null && value.Length > 255)
                {
                    throw ClientUtility.CreateArgumentException("value");
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
        public bool TreeViewEnabled
        {
            get
            {
                base.CheckUninitializedProperty("TreeViewEnabled");
                return (bool)base.ObjectData.Properties["TreeViewEnabled"];
            }
            set
            {
                base.ObjectData.Properties["TreeViewEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "TreeViewEnabled", value));
                }
            }
        }

        [Remote]
        public int UIVersion
        {
            get
            {
                base.CheckUninitializedProperty("UIVersion");
                return (int)base.ObjectData.Properties["UIVersion"];
            }
            set
            {
                base.ObjectData.Properties["UIVersion"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "UIVersion", value));
                }
            }
        }

        [Remote]
        public bool UIVersionConfigurationEnabled
        {
            get
            {
                base.CheckUninitializedProperty("UIVersionConfigurationEnabled");
                return (bool)base.ObjectData.Properties["UIVersionConfigurationEnabled"];
            }
            set
            {
                base.ObjectData.Properties["UIVersionConfigurationEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "UIVersionConfigurationEnabled", value));
                }
            }
        }

        [Remote]
        public string Url
        {
            get
            {
                base.CheckUninitializedProperty("Url");
                return (string)base.ObjectData.Properties["Url"];
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
        public WebCollection Webs
        {
            get
            {
                object obj;
                WebCollection webCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Webs", out obj))
                {
                    webCollection = (WebCollection)obj;
                }
                else
                {
                    webCollection = new WebCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Webs"));
                    base.ObjectData.ClientObjectProperties["Webs"] = webCollection;
                }
                return webCollection;
            }
        }

        [Remote]
        public string WebTemplate
        {
            get
            {
                base.CheckUninitializedProperty("WebTemplate");
                return (string)base.ObjectData.Properties["WebTemplate"];
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

        //[Remote]
        //public WorkflowTemplateCollection WorkflowTemplates
        //{
        //    get
        //    {
        //        object obj;
        //        WorkflowTemplateCollection workflowTemplateCollection;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("WorkflowTemplates", out obj))
        //        {
        //            workflowTemplateCollection = (WorkflowTemplateCollection)obj;
        //        }
        //        else
        //        {
        //            workflowTemplateCollection = new WorkflowTemplateCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "WorkflowTemplates"));
        //            base.ObjectData.ClientObjectProperties["WorkflowTemplates"] = workflowTemplateCollection;
        //        }
        //        return workflowTemplateCollection;
        //    }
        //}

        internal void InitFromCreationInformation(WebCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Description"] = creation.Description;
                base.ObjectData.Properties["Title"] = creation.Title;
            }
        }

        public static Uri WebUrlFromPageUrlDirect(ClientContext context, Uri pageFullUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (pageFullUrl == null)
            {
                throw new ArgumentNullException("pageFullUrl");
            }
            if (context.HasPendingRequest)
            {
                throw new ClientRequestException(Resources.GetString("NoDirectRequest"));
            }
            ClientResult<string> webUrlFromPageUrl = Web.GetWebUrlFromPageUrl(context, pageFullUrl.ToString());
            context.ExecuteQuery();
            return new Uri(webUrlFromPageUrl.Value);
        }

        public static Uri WebUrlFromFolderUrlDirect(ClientContext context, Uri folderFullUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (folderFullUrl == null)
            {
                throw new ArgumentNullException("folderFullUrl");
            }
            if (!folderFullUrl.IsAbsoluteUri)
            {
                throw ClientUtility.CreateArgumentException("folderFullUrl");
            }
            string text = folderFullUrl.AbsoluteUri;
            if (!text.EndsWith("/", StringComparison.Ordinal))
            {
                text += "/";
            }
            text += "_api/contextinfo";
            WebRequestExecutor webRequestExecutor = context.WebRequestExecutorFactory.CreateWebRequestExecutor(context, text);
            webRequestExecutor.RequestMethod = "POST";
            webRequestExecutor.RequestContentType = "application/xml";
            context.FireExecutingWebRequestEventInternal(new WebRequestEventArgs(webRequestExecutor));
            if (context.AuthenticationMode == ClientAuthenticationMode.Default)
            {
                webRequestExecutor.RequestHeaders["X-RequestForceAuthentication"] = "true";
            }
            webRequestExecutor.GetRequestStream().Dispose();// Close();
            try
            {
                webRequestExecutor.Execute();
            }
            catch (WebException webEx)
            {
                string text2 = Web.TryExtractODataError(webEx);
                if (string.IsNullOrEmpty(text2))
                {
                    throw;
                }
                throw new ClientRequestException(Resources.GetString("CannotContactSiteWithDetails", new object[]
                {
                    folderFullUrl,
                    text2
                }));
            }
            if (webRequestExecutor.StatusCode != HttpStatusCode.OK || webRequestExecutor.ResponseContentType.IndexOf("xml", StringComparison.OrdinalIgnoreCase) < 0)
            {
                throw new ClientRequestException(Resources.GetString("CannotContactSite", new object[]
                {
                    folderFullUrl.ToString()
                }));
            }
            Uri result = null;
            using (StreamReader streamReader = new StreamReader(webRequestExecutor.GetResponseStream()))
            {
                throw new NotImplementedException("Not yet ported to .NET Core");
                //Edited for .NET Core
                //XmlDocument xmlDocument = SPClientUtility.LoadXml(streamReader);
                //XmlNode xmlNode = xmlDocument.SelectSingleNode("d:GetContextWebInformation/d:WebFullUrl", SPClientUtility.ODataNamespaceManager);
                //if (xmlNode == null)
                //{
                //    throw new ClientRequestException(Resources.GetString("CannotContactSite", new object[]
                //    {
                //        folderFullUrl.ToString()
                //    }));
                //}
                //Uri uri = new Uri(xmlNode.InnerText);
                //if (!uri.IsAbsoluteUri)
                //{
                //    throw new ClientRequestException(Resources.GetString("CannotContactSite", new object[]
                //    {
                //        folderFullUrl.ToString()
                //    }));
                //}
                //result = uri;
            }
            return result;
        }

        private static string TryExtractODataError(WebException webEx)
        {
            try
            {
                HttpWebResponse httpWebResponse = webEx.Response as HttpWebResponse;
                if (httpWebResponse != null && httpWebResponse.StatusCode == HttpStatusCode.InternalServerError && httpWebResponse.ContentType.IndexOf("xml", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
                    {
                        XmlDocument xmlDocument = SPClientUtility.LoadXml(streamReader);
                        //Edited for .NET Core
                        throw new NotImplementedException("Not yet ported to .NET Core");
                        //XmlNode xmlNode = xmlDocument.SelectSingleNode("m:error/m:message", SPClientUtility.ODataNamespaceManager);
                        //if (xmlNode != null)
                        //{
                        //    return xmlNode.InnerText;
                        //}
                    }
                }
            }
            catch (WebException)
            {
            }
            catch (XmlException)
            {
            }
            return null;
        }

        [System.ComponentModel.EditorBrowsable(EditorBrowsableState.Never)]
        public Web(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "Alerts":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Alerts", this.Alerts, reader);
                    this.Alerts.FromJson(reader);
                    break;
                case "AllowAutomaticASPXPageIndexing":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowAutomaticASPXPageIndexing"] = reader.ReadBoolean();
                    break;
                case "AllowCreateDeclarativeWorkflowForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowCreateDeclarativeWorkflowForCurrentUser"] = reader.ReadBoolean();
                    break;
                case "AllowDesignerForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowDesignerForCurrentUser"] = reader.ReadBoolean();
                    break;
                case "AllowMasterPageEditingForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowMasterPageEditingForCurrentUser"] = reader.ReadBoolean();
                    break;
                case "AllowRevertFromTemplateForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowRevertFromTemplateForCurrentUser"] = reader.ReadBoolean();
                    break;
                case "AllowRssFeeds":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowRssFeeds"] = reader.ReadBoolean();
                    break;
                case "AllowSaveDeclarativeWorkflowAsTemplateForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowSaveDeclarativeWorkflowAsTemplateForCurrentUser"] = reader.ReadBoolean();
                    break;
                case "AllowSavePublishDeclarativeWorkflowForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowSavePublishDeclarativeWorkflowForCurrentUser"] = reader.ReadBoolean();
                    break;
                case "AllProperties":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AllProperties", this.AllProperties, reader);
                    this.AllProperties.FromJson(reader);
                    break;
                case "AlternateCssUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AlternateCssUrl"] = reader.ReadString();
                    break;
                case "AppInstanceId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AppInstanceId"] = reader.ReadGuid();
                    break;
                //case "AppTiles":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("AppTiles", this.AppTiles, reader);
                //    this.AppTiles.FromJson(reader);
                //    break;
                case "AssociatedMemberGroup":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AssociatedMemberGroup", this.AssociatedMemberGroup, reader);
                    this.AssociatedMemberGroup.FromJson(reader);
                    break;
                case "AssociatedOwnerGroup":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AssociatedOwnerGroup", this.AssociatedOwnerGroup, reader);
                    this.AssociatedOwnerGroup.FromJson(reader);
                    break;
                case "AssociatedVisitorGroup":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AssociatedVisitorGroup", this.AssociatedVisitorGroup, reader);
                    this.AssociatedVisitorGroup.FromJson(reader);
                    break;
                case "Author":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Author", this.Author, reader);
                    this.Author.FromJson(reader);
                    break;
                case "AvailableContentTypes":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AvailableContentTypes", this.AvailableContentTypes, reader);
                    this.AvailableContentTypes.FromJson(reader);
                    break;
                case "AvailableFields":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AvailableFields", this.AvailableFields, reader);
                    this.AvailableFields.FromJson(reader);
                    break;
                case "Configuration":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Configuration"] = reader.ReadInt16();
                    break;
                case "ContainsConfidentialInfo":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ContainsConfidentialInfo"] = reader.ReadBoolean();
                    break;
                case "ContentTypes":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ContentTypes", this.ContentTypes, reader);
                    this.ContentTypes.FromJson(reader);
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
                case "CurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("CurrentUser", this.CurrentUser, reader);
                    this.CurrentUser.FromJson(reader);
                    break;
                case "CustomMasterUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CustomMasterUrl"] = reader.ReadString();
                    break;
                //case "DataLeakagePreventionStatusInfo":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("DataLeakagePreventionStatusInfo", this.DataLeakagePreventionStatusInfo, reader);
                //    this.DataLeakagePreventionStatusInfo.FromJson(reader);
                //    break;
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
                case "DesignerDownloadUrlForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DesignerDownloadUrlForCurrentUser"] = reader.ReadString();
                    break;
                case "DesignPackageId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DesignPackageId"] = reader.ReadGuid();
                    break;
                case "DisableAppViews":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisableAppViews"] = reader.ReadBoolean();
                    break;
                case "DisableFlows":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisableFlows"] = reader.ReadBoolean();
                    break;
                case "DocumentLibraryCalloutOfficeWebAppPreviewersDisabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DocumentLibraryCalloutOfficeWebAppPreviewersDisabled"] = reader.ReadBoolean();
                    break;
                case "EffectiveBasePermissions":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EffectiveBasePermissions"] = reader.Read<BasePermissions>();
                    break;
                case "EnableMinimalDownload":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnableMinimalDownload"] = reader.ReadBoolean();
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
                //case "Features":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("Features", this.Features, reader);
                //    this.Features.FromJson(reader);
                //    break;
                case "Fields":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Fields", this.Fields, reader);
                    this.Fields.FromJson(reader);
                    break;
                case "Folders":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Folders", this.Folders, reader);
                    this.Folders.FromJson(reader);
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "IsMultilingual":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsMultilingual"] = reader.ReadBoolean();
                    break;
                case "Language":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Language"] = reader.ReadUInt32();
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
                case "Lists":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Lists", this.Lists, reader);
                    this.Lists.FromJson(reader);
                    break;
                case "ListTemplates":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ListTemplates", this.ListTemplates, reader);
                    this.ListTemplates.FromJson(reader);
                    break;
                case "MasterUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MasterUrl"] = reader.ReadString();
                    break;
                case "MembersCanShare":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MembersCanShare"] = reader.ReadBoolean();
                    break;
                //case "Navigation":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("Navigation", this.Navigation, reader);
                //    this.Navigation.FromJson(reader);
                //    break;
                case "NoCrawl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NoCrawl"] = reader.ReadBoolean();
                    break;
                case "NotificationsInOneDriveForBusinessEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NotificationsInOneDriveForBusinessEnabled"] = reader.ReadBoolean();
                    break;
                case "NotificationsInSharePointEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NotificationsInSharePointEnabled"] = reader.ReadBoolean();
                    break;
                case "OverwriteTranslationsOnChange":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["OverwriteTranslationsOnChange"] = reader.ReadBoolean();
                    break;
                case "ParentWeb":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ParentWeb", this.ParentWeb, reader);
                    this.ParentWeb.FromJson(reader);
                    break;
                case "ResourcePath":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ResourcePath"] = reader.Read<ResourcePath>();
                    break;
                case "PreviewFeaturesEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PreviewFeaturesEnabled"] = reader.ReadBoolean();
                    break;
                //case "PushNotificationSubscribers":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("PushNotificationSubscribers", this.PushNotificationSubscribers, reader);
                //    this.PushNotificationSubscribers.FromJson(reader);
                //    break;
                case "QuickLaunchEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["QuickLaunchEnabled"] = reader.ReadBoolean();
                    break;
                //case "RecycleBin":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("RecycleBin", this.RecycleBin, reader);
                //    this.RecycleBin.FromJson(reader);
                //    break;
                case "RecycleBinEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RecycleBinEnabled"] = reader.ReadBoolean();
                    break;
                //case "RegionalSettings":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("RegionalSettings", this.RegionalSettings, reader);
                //    this.RegionalSettings.FromJson(reader);
                //    break;
                case "RequestAccessEmail":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RequestAccessEmail"] = reader.ReadString();
                    break;
                case "RoleDefinitions":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("RoleDefinitions", this.RoleDefinitions, reader);
                    this.RoleDefinitions.FromJson(reader);
                    break;
                case "RootFolder":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("RootFolder", this.RootFolder, reader);
                    this.RootFolder.FromJson(reader);
                    break;
                case "SaveSiteAsTemplateEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SaveSiteAsTemplateEnabled"] = reader.ReadBoolean();
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
                case "ShowUrlStructureForCurrentUser":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ShowUrlStructureForCurrentUser"] = reader.ReadBoolean();
                    break;
                case "SiteGroups":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("SiteGroups", this.SiteGroups, reader);
                    this.SiteGroups.FromJson(reader);
                    break;
                case "SiteLogoDescription":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SiteLogoDescription"] = reader.ReadString();
                    break;
                case "SiteLogoUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SiteLogoUrl"] = reader.ReadString();
                    break;
                case "SiteUserInfoList":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("SiteUserInfoList", this.SiteUserInfoList, reader);
                    this.SiteUserInfoList.FromJson(reader);
                    break;
                case "SiteUsers":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("SiteUsers", this.SiteUsers, reader);
                    this.SiteUsers.FromJson(reader);
                    break;
                case "SupportedUILanguageIds":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SupportedUILanguageIds"] = reader.ReadList<int>();
                    break;
                case "SyndicationEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SyndicationEnabled"] = reader.ReadBoolean();
                    break;
                case "TenantTagPolicyEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TenantTagPolicyEnabled"] = reader.ReadBoolean();
                    break;
                case "ThemedCssFolderUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ThemedCssFolderUrl"] = reader.ReadString();
                    break;
                //case "ThemeInfo":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("ThemeInfo", this.ThemeInfo, reader);
                //    this.ThemeInfo.FromJson(reader);
                //    break;
                case "ThirdPartyMdmEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ThirdPartyMdmEnabled"] = reader.ReadBoolean();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                //case "TitleResource":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("TitleResource", this.TitleResource, reader);
                //    this.TitleResource.FromJson(reader);
                //    break;
                case "TreeViewEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TreeViewEnabled"] = reader.ReadBoolean();
                    break;
                case "UIVersion":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UIVersion"] = reader.ReadInt32();
                    break;
                case "UIVersionConfigurationEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UIVersionConfigurationEnabled"] = reader.ReadBoolean();
                    break;
                case "Url":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Url"] = reader.ReadString();
                    break;
                case "UserCustomActions":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("UserCustomActions", this.UserCustomActions, reader);
                    this.UserCustomActions.FromJson(reader);
                    break;
                case "Webs":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Webs", this.Webs, reader);
                    this.Webs.FromJson(reader);
                    break;
                case "WebTemplate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["WebTemplate"] = reader.ReadString();
                    break;
                case "WorkflowAssociations":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("WorkflowAssociations", this.WorkflowAssociations, reader);
                    this.WorkflowAssociations.FromJson(reader);
                    break;
                    //case "WorkflowTemplates":
                    //    flag = true;
                    //    reader.ReadName();
                    //    base.UpdateClientObjectPropertyType("WorkflowTemplates", this.WorkflowTemplates, reader);
                    //    this.WorkflowTemplates.FromJson(reader);
                    //    break;
            }
            return flag;
        }

        [Remote]
        public ClientResult<bool> DoesUserHavePermissions(BasePermissions permissionMask)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && permissionMask == null)
            {
                throw ClientUtility.CreateArgumentNullException("permissionMask");
            }
            ClientAction clientAction = new ClientActionInvokeMethod(this, "DoesUserHavePermissions", new object[]
            {
                permissionMask
            });
            context.AddQuery(clientAction);
            ClientResult<bool> clientResult = new ClientResult<bool>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
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
        public void CreateDefaultAssociatedGroups(string userLogin, string userLogin2, string groupNameSeed)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "CreateDefaultAssociatedGroups", new object[]
            {
                userLogin,
                userLogin2,
                groupNameSeed
            });
            context.AddQuery(query);
        }

        //[Remote]
        //public static SharingResult UnshareObject(ClientRuntimeContext context, string url)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    return new SharingResult(context, new ObjectPathStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "UnshareObject", new object[]
        //    {
        //        url
        //    }));
        //}

        //[Remote]
        //public static ObjectSharingSettings GetObjectSharingSettings(ClientRuntimeContext context, string objectUrl, int groupId, bool useSimplifiedRoles)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    return new ObjectSharingSettings(context, new ObjectPathStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "GetObjectSharingSettings", new object[]
        //    {
        //        objectUrl,
        //        groupId,
        //        useSimplifiedRoles
        //    }));
        //}

        [Remote]
        public static ClientResult<string> CreateAnonymousLink(ClientRuntimeContext context, string url, bool isEditLink)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "CreateAnonymousLink", new object[]
            {
                url,
                isEditLink
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public static ClientResult<string> CreateAnonymousLinkWithExpiration(ClientRuntimeContext context, string url, bool isEditLink, string expirationString)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "CreateAnonymousLinkWithExpiration", new object[]
            {
                url,
                isEditLink,
                expirationString
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public static void DeleteAllAnonymousLinksForObject(ClientRuntimeContext context, string url)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction query = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "DeleteAllAnonymousLinksForObject", new object[]
            {
                url
            });
            context.AddQuery(query);
        }

        [Remote]
        public static void DeleteAnonymousLinkForObject(ClientRuntimeContext context, string url, bool isEditLink, bool removeAssociatedSharingLinkGroup)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction query = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "DeleteAnonymousLinkForObject", new object[]
            {
                url,
                isEditLink,
                removeAssociatedSharingLinkGroup
            });
            context.AddQuery(query);
        }

        [Remote]
        public static ClientResult<string> CreateOrganizationSharingLink(ClientRuntimeContext context, string url, bool isEditLink)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "CreateOrganizationSharingLink", new object[]
            {
                url,
                isEditLink
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public static void DestroyOrganizationSharingLink(ClientRuntimeContext context, string url, bool isEditLink, bool removeAssociatedSharingLinkGroup)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction query = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "DestroyOrganizationSharingLink", new object[]
            {
                url,
                isEditLink,
                removeAssociatedSharingLinkGroup
            });
            context.AddQuery(query);
        }

        //[Remote]
        //public static ClientResult<SharingLinkKind> GetSharingLinkKind(ClientRuntimeContext context, string fileUrl)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    if (context.ValidateOnClient && fileUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("fileUrl");
        //    }
        //    ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "GetSharingLinkKind", new object[]
        //    {
        //        fileUrl
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<SharingLinkKind> clientResult = new ClientResult<SharingLinkKind>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        //[Remote]
        //public ClientResult<SharingLinkData> GetSharingLinkData(string linkUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && linkUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("linkUrl");
        //    }
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "GetSharingLinkData", new object[]
        //    {
        //        linkUrl
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<SharingLinkData> clientResult = new ClientResult<SharingLinkData>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        //[Remote]
        //public ClientResult<string> MapToIcon(string fileName, string progId, IconSize size)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "MapToIcon", new object[]
        //    {
        //        fileName,
        //        progId,
        //        size
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<string> clientResult = new ClientResult<string>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        [Remote]
        public static ClientResult<string> GetWebUrlFromPageUrl(ClientRuntimeContext context, string pageFullUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Uri uri;
            if (context.ValidateOnClient && pageFullUrl != null && !Uri.TryCreate(pageFullUrl, UriKind.Absolute, out uri))
            {
                throw ClientUtility.CreateArgumentException("pageFullUrl");
            }
            ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "GetWebUrlFromPageUrl", new object[]
            {
                pageFullUrl
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        //[Remote]
        //public PushNotificationSubscriber RegisterPushNotificationSubscriber(Guid deviceAppInstanceId, string serviceToken)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient)
        //    {
        //        if (serviceToken == null)
        //        {
        //            throw ClientUtility.CreateArgumentNullException("serviceToken");
        //        }
        //        if (serviceToken != null && serviceToken.Length == 0)
        //        {
        //            throw ClientUtility.CreateArgumentException("serviceToken");
        //        }
        //    }
        //    return new PushNotificationSubscriber(context, new ObjectPathMethod(context, base.Path, "RegisterPushNotificationSubscriber", new object[]
        //    {
        //        deviceAppInstanceId,
        //        serviceToken
        //    }));
        //}

        //[Remote]
        //public void UnregisterPushNotificationSubscriber(Guid deviceAppInstanceId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction query = new ClientActionInvokeMethod(this, "UnregisterPushNotificationSubscriber", new object[]
        //    {
        //        deviceAppInstanceId
        //    });
        //    context.AddQuery(query);
        //}

        //[Remote]
        //public PushNotificationSubscriberCollection GetPushNotificationSubscribersByArgs(string customArgs)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new PushNotificationSubscriberCollection(context, new ObjectPathMethod(context, base.Path, "GetPushNotificationSubscribersByArgs", new object[]
        //    {
        //        customArgs
        //    }));
        //}

        //[Remote]
        //public PushNotificationSubscriberCollection GetPushNotificationSubscribersByUser(string userName)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient)
        //    {
        //        if (userName == null)
        //        {
        //            throw ClientUtility.CreateArgumentNullException("userName");
        //        }
        //        if (userName != null && userName.Length == 0)
        //        {
        //            throw ClientUtility.CreateArgumentException("userName");
        //        }
        //    }
        //    return new PushNotificationSubscriberCollection(context, new ObjectPathMethod(context, base.Path, "GetPushNotificationSubscribersByUser", new object[]
        //    {
        //        userName
        //    }));
        //}

        //[Remote]
        //public ClientResult<bool> DoesPushNotificationSubscriberExist(Guid deviceAppInstanceId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "DoesPushNotificationSubscriberExist", new object[]
        //    {
        //        deviceAppInstanceId
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<bool> clientResult = new ClientResult<bool>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        //[Remote]
        //public PushNotificationSubscriber GetPushNotificationSubscriber(Guid deviceAppInstanceId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new PushNotificationSubscriber(context, new ObjectPathMethod(context, base.Path, "GetPushNotificationSubscriber", new object[]
        //    {
        //        deviceAppInstanceId
        //    }));
        //}

        [Remote]
        public User GetUserById(int userId)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<int, User> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetUserById", out obj))
            {
                dictionary = (Dictionary<int, User>)obj;
            }
            else
            {
                dictionary = new Dictionary<int, User>();
                base.ObjectData.MethodReturnObjects["GetUserById"] = dictionary;
            }
            User user = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(userId, out user))
            {
                return user;
            }
            user = new User(context, new ObjectPathMethod(context, base.Path, "GetUserById", new object[]
            {
                userId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[userId] = user;
            }
            return user;
        }

        //[Remote]
        //public RecycleBinItemCollection GetRecycleBinItems(string pagingInfo, int rowLimit, bool isAscending, RecycleBinOrderBy orderBy, RecycleBinItemState itemState)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new RecycleBinItemCollection(context, new ObjectPathMethod(context, base.Path, "GetRecycleBinItems", new object[]
        //    {
        //        pagingInfo,
        //        rowLimit,
        //        isAscending,
        //        orderBy,
        //        itemState
        //    }));
        //}

        //[Remote]
        //public RecycleBinItemCollection GetRecycleBinItemsByQueryInfo(RecycleBinQueryInformation queryInfo)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && queryInfo == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("queryInfo");
        //    }
        //    return new RecycleBinItemCollection(context, new ObjectPathMethod(context, base.Path, "GetRecycleBinItemsByQueryInfo", new object[]
        //    {
        //        queryInfo
        //    }));
        //}

        //[Remote]
        //public ChangeCollection GetChanges(ChangeQuery query)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && query == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("query");
        //    }
        //    return new ChangeCollection(context, new ObjectPathMethod(context, base.Path, "GetChanges", new object[]
        //    {
        //        query
        //    }));
        //}

        //[Remote]
        //public static SharingResult ShareObject(ClientRuntimeContext context, string url, string peoplePickerInput, string roleValue, int groupId, bool propagateAcl, bool sendEmail, bool includeAnonymousLinkInEmail, string emailSubject, string emailBody, bool useSimplifiedRoles)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    return new SharingResult(context, new ObjectPathStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "ShareObject", new object[]
        //    {
        //        url,
        //        peoplePickerInput,
        //        roleValue,
        //        groupId,
        //        propagateAcl,
        //        sendEmail,
        //        includeAnonymousLinkInEmail,
        //        emailSubject,
        //        emailBody,
        //        useSimplifiedRoles
        //    }));
        //}

        //[Remote]
        //public static SharingResult ForwardObjectLink(ClientRuntimeContext context, string url, string peoplePickerInput, string emailSubject, string emailBody)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    return new SharingResult(context, new ObjectPathStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "ForwardObjectLink", new object[]
        //    {
        //        url,
        //        peoplePickerInput,
        //        emailSubject,
        //        emailBody
        //    }));
        //}

        //[Remote]
        //public List GetList(string strUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    object obj;
        //    Dictionary<string, List> dictionary;
        //    if (base.ObjectData.MethodReturnObjects.TryGetValue("GetList", out obj))
        //    {
        //        dictionary = (Dictionary<string, List>)obj;
        //    }
        //    else
        //    {
        //        dictionary = new Dictionary<string, List>();
        //        base.ObjectData.MethodReturnObjects["GetList"] = dictionary;
        //    }
        //    List list = null;
        //    if (!context.DisableReturnValueCache && dictionary.TryGetValue(strUrl, out list))
        //    {
        //        return list;
        //    }
        //    list = new List(context, new ObjectPathMethod(context, base.Path, "GetList", new object[]
        //    {
        //        strUrl
        //    }));
        //    if (!context.DisableReturnValueCache)
        //    {
        //        dictionary[strUrl] = list;
        //    }
        //    return list;
        //}

        //[Remote]
        //public List GetListUsingPath(ResourcePath path)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && path == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("path");
        //    }
        //    return new List(context, new ObjectPathMethod(context, base.Path, "GetListUsingPath", new object[]
        //    {
        //        path
        //    }));
        //}

        //[Remote]
        //public ListItem GetListItem(string strUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new ListItem(context, new ObjectPathMethod(context, base.Path, "GetListItem", new object[]
        //    {
        //        strUrl
        //    }));
        //}

        //[Remote]
        //public ListItem GetListItemUsingPath(ResourcePath path)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && path == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("path");
        //    }
        //    return new ListItem(context, new ObjectPathMethod(context, base.Path, "GetListItemUsingPath", new object[]
        //    {
        //        path
        //    }));
        //}

        //[Remote]
        //public Entity GetEntity(string @namespace, string name)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new Entity(context, new ObjectPathMethod(context, base.Path, "GetEntity", new object[]
        //    {
        //        @namespace,
        //        name
        //    }));
        //}

        //[Remote]
        //public AppBdcCatalog GetAppBdcCatalogForAppInstance(Guid appInstanceId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && appInstanceId == Guid.Empty)
        //    {
        //        throw ClientUtility.CreateArgumentException("appInstanceId");
        //    }
        //    return new AppBdcCatalog(context, new ObjectPathMethod(context, base.Path, "GetAppBdcCatalogForAppInstance", new object[]
        //    {
        //        appInstanceId
        //    }));
        //}

        //[Remote]
        //public AppBdcCatalog GetAppBdcCatalog()
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new AppBdcCatalog(context, new ObjectPathMethod(context, base.Path, "GetAppBdcCatalog", null));
        //}

        //[Remote]
        //public WebCollection GetSubwebsForCurrentUser(SubwebQuery query)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new WebCollection(context, new ObjectPathMethod(context, base.Path, "GetSubwebsForCurrentUser", new object[]
        //    {
        //        query
        //    }));
        //}

        //[Remote]
        //public WebTemplateCollection GetAvailableWebTemplates(uint lcid, bool doIncludeCrossLanguage)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new WebTemplateCollection(context, new ObjectPathMethod(context, base.Path, "GetAvailableWebTemplates", new object[]
        //    {
        //        lcid,
        //        doIncludeCrossLanguage
        //    }));
        //}

        //[Remote]
        //public List GetCatalog(int typeCatalog)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    object obj;
        //    Dictionary<int, List> dictionary;
        //    if (base.ObjectData.MethodReturnObjects.TryGetValue("GetCatalog", out obj))
        //    {
        //        dictionary = (Dictionary<int, List>)obj;
        //    }
        //    else
        //    {
        //        dictionary = new Dictionary<int, List>();
        //        base.ObjectData.MethodReturnObjects["GetCatalog"] = dictionary;
        //    }
        //    List list = null;
        //    if (!context.DisableReturnValueCache && dictionary.TryGetValue(typeCatalog, out list))
        //    {
        //        return list;
        //    }
        //    list = new List(context, new ObjectPathMethod(context, base.Path, "GetCatalog", new object[]
        //    {
        //        typeCatalog
        //    }));
        //    if (!context.DisableReturnValueCache)
        //    {
        //        dictionary[typeCatalog] = list;
        //    }
        //    return list;
        //}

        [Remote]
        public void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }

        [Remote]
        public void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
        }

        //[Remote]
        //public View GetViewFromUrl(string listUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new View(context, new ObjectPathMethod(context, base.Path, "GetViewFromUrl", new object[]
        //    {
        //        listUrl
        //    }));
        //}

        //[Remote]
        //public View GetViewFromPath(ResourcePath listPath)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new View(context, new ObjectPathMethod(context, base.Path, "GetViewFromPath", new object[]
        //    {
        //        listPath
        //    }));
        //}

        //[Remote]
        //public File GetFileByServerRelativeUrl(string serverRelativeUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient)
        //    {
        //        if (serverRelativeUrl == null)
        //        {
        //            throw ClientUtility.CreateArgumentNullException("serverRelativeUrl");
        //        }
        //        if (serverRelativeUrl != null && serverRelativeUrl.Length == 0)
        //        {
        //            throw ClientUtility.CreateArgumentException("serverRelativeUrl");
        //        }
        //    }
        //    object obj;
        //    Dictionary<string, File> dictionary;
        //    if (base.ObjectData.MethodReturnObjects.TryGetValue("GetFileByServerRelativeUrl", out obj))
        //    {
        //        dictionary = (Dictionary<string, File>)obj;
        //    }
        //    else
        //    {
        //        dictionary = new Dictionary<string, File>(StringComparer.OrdinalIgnoreCase);
        //        base.ObjectData.MethodReturnObjects["GetFileByServerRelativeUrl"] = dictionary;
        //    }
        //    File file = null;
        //    if (!context.DisableReturnValueCache && dictionary.TryGetValue(serverRelativeUrl, out file))
        //    {
        //        return file;
        //    }
        //    file = new File(context, new ObjectPathMethod(context, base.Path, "GetFileByServerRelativeUrl", new object[]
        //    {
        //        serverRelativeUrl
        //    }));
        //    if (!context.DisableReturnValueCache)
        //    {
        //        dictionary[serverRelativeUrl] = file;
        //    }
        //    ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(file.Path);
        //    context.AddQueryIdAndResultObject(objectIdentityQuery.Id, file);
        //    context.AddQuery(objectIdentityQuery);
        //    return file;
        //}

        //[Remote]
        //public File GetFileByServerRelativePath(ResourcePath serverRelativePath)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && serverRelativePath == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("serverRelativePath");
        //    }
        //    return new File(context, new ObjectPathMethod(context, base.Path, "GetFileByServerRelativePath", new object[]
        //    {
        //        serverRelativePath
        //    }));
        //}

        //[Remote]
        //public static IList<DocumentLibraryInformation> GetDocumentLibraries(ClientRuntimeContext context, string webFullUrl)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    Uri uri;
        //    if (context.ValidateOnClient && webFullUrl != null && !Uri.TryCreate(webFullUrl, UriKind.Absolute, out uri))
        //    {
        //        throw ClientUtility.CreateArgumentException("webFullUrl");
        //    }
        //    ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "GetDocumentLibraries", new object[]
        //    {
        //        webFullUrl
        //    });
        //    context.AddQuery(clientAction);
        //    IList<DocumentLibraryInformation> list = new List<DocumentLibraryInformation>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, new ClientListResultHandler<DocumentLibraryInformation>(list));
        //    return list;
        //}

        //[Remote]
        //public static IList<DocumentLibraryInformation> GetDocumentAndMediaLibraries(ClientRuntimeContext context, string webFullUrl)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException("context");
        //    }
        //    Uri uri;
        //    if (context.ValidateOnClient && webFullUrl != null && !Uri.TryCreate(webFullUrl, UriKind.Absolute, out uri))
        //    {
        //        throw ClientUtility.CreateArgumentException("webFullUrl");
        //    }
        //    ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{a489add2-5d3a-4de8-9445-49259462dceb}", "GetDocumentAndMediaLibraries", new object[]
        //    {
        //        webFullUrl
        //    });
        //    context.AddQuery(clientAction);
        //    IList<DocumentLibraryInformation> list = new List<DocumentLibraryInformation>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, new ClientListResultHandler<DocumentLibraryInformation>(list));
        //    return list;
        //}

        //[Remote]
        //public List DefaultDocumentLibrary()
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new List(context, new ObjectPathMethod(context, base.Path, "DefaultDocumentLibrary", null));
        //}

        //[Remote]
        //public File GetFileById(Guid uniqueId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new File(context, new ObjectPathMethod(context, base.Path, "GetFileById", new object[]
        //    {
        //        uniqueId
        //    }));
        //}

        //[Remote]
        //public Folder GetFolderById(Guid uniqueId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new Folder(context, new ObjectPathMethod(context, base.Path, "GetFolderById", new object[]
        //    {
        //        uniqueId
        //    }));
        //}

        //[Remote]
        //public File GetFileByLinkingUrl(string linkingUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && linkingUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("linkingUrl");
        //    }
        //    return new File(context, new ObjectPathMethod(context, base.Path, "GetFileByLinkingUrl", new object[]
        //    {
        //        linkingUrl
        //    }));
        //}

        //[Remote]
        //public File GetFileByGuestUrl(string guestUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && guestUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("guestUrl");
        //    }
        //    return new File(context, new ObjectPathMethod(context, base.Path, "GetFileByGuestUrl", new object[]
        //    {
        //        guestUrl
        //    }));
        //}

        //[Remote]
        //public File GetFileByGuestUrlEnsureAccess(string guestUrl, bool ensureAccess)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && guestUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("guestUrl");
        //    }
        //    return new File(context, new ObjectPathMethod(context, base.Path, "GetFileByGuestUrlEnsureAccess", new object[]
        //    {
        //        guestUrl,
        //        ensureAccess
        //    }));
        //}

        //[Remote]
        //public File GetFileByWOPIFrameUrl(string wopiFrameUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && wopiFrameUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("wopiFrameUrl");
        //    }
        //    return new File(context, new ObjectPathMethod(context, base.Path, "GetFileByWOPIFrameUrl", new object[]
        //    {
        //        wopiFrameUrl
        //    }));
        //}

        //[Remote]
        //public File GetFileByUrl(string fileUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && fileUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("fileUrl");
        //    }
        //    return new File(context, new ObjectPathMethod(context, base.Path, "GetFileByUrl", new object[]
        //    {
        //        fileUrl
        //    }));
        //}

        //[Remote]
        //public Folder GetFolderByServerRelativeUrl(string serverRelativeUrl)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && serverRelativeUrl == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("serverRelativeUrl");
        //    }
        //    object obj;
        //    Dictionary<string, Folder> dictionary;
        //    if (base.ObjectData.MethodReturnObjects.TryGetValue("GetFolderByServerRelativeUrl", out obj))
        //    {
        //        dictionary = (Dictionary<string, Folder>)obj;
        //    }
        //    else
        //    {
        //        dictionary = new Dictionary<string, Folder>(StringComparer.OrdinalIgnoreCase);
        //        base.ObjectData.MethodReturnObjects["GetFolderByServerRelativeUrl"] = dictionary;
        //    }
        //    Folder folder = null;
        //    if (!context.DisableReturnValueCache && dictionary.TryGetValue(serverRelativeUrl, out folder))
        //    {
        //        return folder;
        //    }
        //    folder = new Folder(context, new ObjectPathMethod(context, base.Path, "GetFolderByServerRelativeUrl", new object[]
        //    {
        //        serverRelativeUrl
        //    }));
        //    if (!context.DisableReturnValueCache)
        //    {
        //        dictionary[serverRelativeUrl] = folder;
        //    }
        //    ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(folder.Path);
        //    context.AddQueryIdAndResultObject(objectIdentityQuery.Id, folder);
        //    context.AddQuery(objectIdentityQuery);
        //    return folder;
        //}

        //[Remote]
        //public Folder GetFolderByServerRelativePath(ResourcePath serverRelativePath)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    if (base.Context.ValidateOnClient && serverRelativePath == null)
        //    {
        //        throw ClientUtility.CreateArgumentNullException("serverRelativePath");
        //    }
        //    return new Folder(context, new ObjectPathMethod(context, base.Path, "GetFolderByServerRelativePath", new object[]
        //    {
        //        serverRelativePath
        //    }));
        //}

        [Remote]
        public void ApplyWebTemplate(string webTemplate)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "ApplyWebTemplate", new object[]
            {
                webTemplate
            });
            context.AddQuery(query);
        }

        //[Remote]
        //public AppInstance GetAppInstanceById(Guid appInstanceId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new AppInstance(context, new ObjectPathMethod(context, base.Path, "GetAppInstanceById", new object[]
        //    {
        //        appInstanceId
        //    }));
        //}

        //[Remote]
        //public ClientObjectList<AppInstance> GetAppInstancesByProductId(Guid productId)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new ClientObjectList<AppInstance>(context, new ObjectPathMethod(context, base.Path, "GetAppInstancesByProductId", new object[]
        //    {
        //        productId
        //    }));
        //}

        //[Remote]
        //public AppInstance LoadAndInstallAppInSpecifiedLocale(Stream appPackageStream, int installationLocaleLCID)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    AppInstance appInstance = new AppInstance(context, new ObjectPathMethod(context, base.Path, "LoadAndInstallAppInSpecifiedLocale", new object[]
        //    {
        //        appPackageStream,
        //        installationLocaleLCID
        //    }));
        //    appInstance.Path.SetPendingReplace();
        //    ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(appInstance.Path);
        //    context.AddQueryIdAndResultObject(objectIdentityQuery.Id, appInstance);
        //    context.AddQuery(objectIdentityQuery);
        //    return appInstance;
        //}

        //[Remote]
        //public AppInstance LoadApp(Stream appPackageStream, int installationLocaleLCID)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    AppInstance appInstance = new AppInstance(context, new ObjectPathMethod(context, base.Path, "LoadApp", new object[]
        //    {
        //        appPackageStream,
        //        installationLocaleLCID
        //    }));
        //    appInstance.Path.SetPendingReplace();
        //    ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(appInstance.Path);
        //    context.AddQueryIdAndResultObject(objectIdentityQuery.Id, appInstance);
        //    context.AddQuery(objectIdentityQuery);
        //    return appInstance;
        //}

        //[Remote]
        //public AppInstance LoadAndInstallApp(Stream appPackageStream)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    AppInstance appInstance = new AppInstance(context, new ObjectPathMethod(context, base.Path, "LoadAndInstallApp", new object[]
        //    {
        //        appPackageStream
        //    }));
        //    appInstance.Path.SetPendingReplace();
        //    ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(appInstance.Path);
        //    context.AddQueryIdAndResultObject(objectIdentityQuery.Id, appInstance);
        //    context.AddQuery(objectIdentityQuery);
        //    return appInstance;
        //}

        [Remote]
        public void AddSupportedUILanguage(int lcid)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "AddSupportedUILanguage", new object[]
            {
                lcid
            });
            context.AddQuery(query);
        }

        [Remote]
        public void RemoveSupportedUILanguage(int lcid)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RemoveSupportedUILanguage", new object[]
            {
                lcid
            });
            context.AddQuery(query);
        }

        [Remote]
        public User EnsureUser(string logonName)
        {
            ClientRuntimeContext context = base.Context;
            return new User(context, new ObjectPathMethod(context, base.Path, "EnsureUser", new object[]
            {
                logonName
            }));
        }

        [Remote]
        public void ApplyTheme(string colorPaletteUrl, string fontSchemeUrl, string backgroundImageUrl, bool shareGenerated)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (colorPaletteUrl == null)
                {
                    throw ClientUtility.CreateArgumentNullException("colorPaletteUrl");
                }
                if (colorPaletteUrl != null && colorPaletteUrl.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("colorPaletteUrl");
                }
                Uri uri;
                if (colorPaletteUrl != null && (!colorPaletteUrl.StartsWith("/", StringComparison.Ordinal) || !Uri.TryCreate(colorPaletteUrl, UriKind.Relative, out uri)))
                {
                    throw ClientUtility.CreateArgumentException("colorPaletteUrl");
                }
                Uri uri2;
                if (fontSchemeUrl != null && (!fontSchemeUrl.StartsWith("/", StringComparison.Ordinal) || !Uri.TryCreate(fontSchemeUrl, UriKind.Relative, out uri2)))
                {
                    throw ClientUtility.CreateArgumentException("fontSchemeUrl");
                }
                Uri uri3;
                if (backgroundImageUrl != null && (!backgroundImageUrl.StartsWith("/", StringComparison.Ordinal) || !Uri.TryCreate(backgroundImageUrl, UriKind.Relative, out uri3)))
                {
                    throw ClientUtility.CreateArgumentException("backgroundImageUrl");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "ApplyTheme", new object[]
            {
                colorPaletteUrl,
                fontSchemeUrl,
                backgroundImageUrl,
                shareGenerated
            });
            context.AddQuery(query);
        }

        [Remote]
        public void IncrementSiteClientTag()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "IncrementSiteClientTag", null);
            context.AddQuery(query);
        }
    }
}
