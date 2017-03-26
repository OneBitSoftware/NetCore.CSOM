using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public class ScriptTypeFactory : IScriptTypeFactory
    {
        public IFromJson CreateObjectFromScriptType(string scriptType, ClientRuntimeContext context)
        {
            if (scriptType == null)
            {
                throw new ArgumentNullException("scriptType");
            }
            switch (scriptType)
            {
                //case "SP.BusinessData.Runtime.EntityInstance":
                //    return new EntityInstance(context, null);
                //case "SP.BusinessData.Collections.EntityInstanceCollection":
                //    return new EntityInstanceCollection(context, null);
                //case "SP.AlternateUrl":
                //    return new AlternateUrl(context, null);
                //case "SP.CreatablesInfo":
                //    return new CreatablesInfo(context, null);
                //case "SP.BusinessData.Entity":
                //    return new Entity(context, null);
                //case "SP.BusinessData.Infrastructure.ExternalSubscriptionStore":
                //    return new ExternalSubscriptionStore(context, null);
                //case "SP.BusinessData.EntityField":
                //    return new EntityField(context, null);
                //case "SP.BusinessData.Collections.EntityFieldCollection":
                //    return new EntityFieldCollection(context, null);
                //case "SP.BusinessData.Runtime.EntityFieldValueDictionary":
                //    return new EntityFieldValueDictionary(context, null);
                //case "SP.BusinessData.Filter":
                //    return new Filter(context, null);
                //case "SP.BusinessData.Collections.FilterCollection":
                //    return new FilterCollection(context, null);
                //case "SP.BusinessData.EntityIdentifier":
                //    return new EntityIdentifier(context, null);
                //case "SP.BusinessData.Collections.EntityIdentifierCollection":
                //    return new EntityIdentifierCollection(context, null);
                //case "SP.BusinessData.Runtime.EntityIdentity":
                //    return new EntityIdentity(context, null);
                //case "SP.BusinessData.LobSystem":
                //    return new LobSystem(context, null);
                //case "SP.BusinessData.LobSystemInstance":
                //    return new LobSystemInstance(context, null);
                //case "SP.BusinessData.Collections.LobSystemInstanceCollection":
                //    return new LobSystemInstanceCollection(context, null);
                //case "SP.BusinessData.MethodExecutionResult":
                //    return new MethodExecutionResult(context, null);
                //case "SP.MicroService.MicroServiceManager":
                //    return new MicroServiceManager(context, null);
                //case "SP.MicroService.MicroServiceUtilities":
                //    return new MicroServiceUtilities(context, null);
                //case "Microsoft.SharePoint.WebControls.ModuleLink":
                //    return new ModuleLink(context, null);
                //case "SP.BusinessData.Runtime.NotificationCallback":
                //    return new NotificationCallback(context, null);
                //case "SP.ObjectSharingSettings":
                //    return new ObjectSharingSettings(context, null);
                //case "SP.UI.ApplicationPages.PickerEntityInformation":
                //    return new PickerEntityInformation(context, null);
                //case "SP.PickerSettings":
                //    return new PickerSettings(context, null);
                //case "SP.RelatedItemManager":
                //    return new RelatedItemManager(context, null);
                //case "Microsoft.SharePoint.WebControls.ResourceManifestInformation":
                //    return new ResourceManifestInformation(context, null);
                //case "SP.BusinessData.ReturnParameterCollection":
                //    return new ReturnParameterCollection(context, null);
                //case "SP.SharePointSharingSettings":
                //    return new SharePointSharingSettings(context, null);
                //case "SP.SharingPermissionInformation":
                //    return new SharingPermissionInformation(context, null);
                //case "SP.SharingResult":
                //    return new SharingResult(context, null);
                case "SP.Alert":
                    return new Alert(context, null);
                case "SP.AlertCollection":
                    return new AlertCollection(context, null);
                //case "SP.Analytics.AnalyticsUsageEntry":
                //    return new AnalyticsUsageEntry(context, null);
                //case "SP.App":
                //    return new App(context, null);
                //case "SP.BusinessData.AppBdcCatalog":
                //    return new AppBdcCatalog(context, null);
                //case "Microsoft.SharePoint.Packaging.AppDetails":
                //    return new AppDetails(context, null);
                //case "Microsoft.SharePoint.Packaging.AppIconInfo":
                //    return new AppIconInfo(context, null);
                //case "SP.AppInstance":
                //    return new AppInstance(context, null);
                //case "SP.AppInstanceErrorDetails":
                //    return new AppInstanceErrorDetails(context, null);
                //case "SP.AppPrincipal":
                //    return new AppPrincipal(context, null);
                //case "SP.AppPrincipalCredential":
                //    return new AppPrincipalCredential(context, null);
                //case "SP.AppPrincipalIdentityProvider":
                //    return new AppPrincipalIdentityProvider(context, null);
                //case "SP.AppPrincipalManager":
                //    return new AppPrincipalManager(context, null);
                //case "SP.AppPrincipalName":
                //    return new AppPrincipalName(context, null);
                //case "SP.AppTile":
                //    return new AppTile(context, null);
                //case "SP.AppTileCollection":
                //    return new AppTileCollection(context, null);
                //case "SP.Attachment":
                //    return new Attachment(context, null);
                //case "SP.AttachmentCollection":
                //    return new AttachmentCollection(context, null);
                //case "SP.Audit":
                //    return new Audit(context, null);
                //case "SP.Change":
                //    return new Change(context, null);
                //case "SP.ChangeAlert":
                //    return new ChangeAlert(context, null);
                //case "SP.ChangeCollection":
                //    return new ChangeCollection(context, null);
                //case "SP.ChangeContentType":
                //    return new ChangeContentType(context, null);
                //case "SP.ChangeField":
                //    return new ChangeField(context, null);
                //case "SP.ChangeFile":
                //    return new ChangeFile(context, null);
                //case "SP.ChangeFolder":
                //    return new ChangeFolder(context, null);
                //case "SP.ChangeGroup":
                //    return new ChangeGroup(context, null);
                //case "SP.ChangeItem":
                //    return new ChangeItem(context, null);
                //case "SP.ChangeList":
                //    return new ChangeList(context, null);
                //case "SP.ChangeSite":
                //    return new ChangeSite(context, null);
                //case "SP.ChangeUser":
                //    return new ChangeUser(context, null);
                //case "SP.ChangeView":
                //    return new ChangeView(context, null);
                //case "SP.ChangeWeb":
                //    return new ChangeWeb(context, null);
                //case "SP.RequestVariable":
                //    return new RequestVariable(context, null);
                //case "SP.CompatibilityRange":
                //    return new CompatibilityRange(context, null);
                //case "SP.APIHubConnector":
                //    return new APIHubConnector(context, null);
                //case "SP.ConnectorResult":
                //    return new ConnectorResult(context, null);
                //case "SP.ContentType":
                //    return new ContentType(context, null);
                //case "SP.ContentTypeCollection":
                //    return new ContentTypeCollection(context, null);
                case "SP.RequestContext":
                    return new RequestContext(context, null);
                //case "SP.SPDataLeakagePreventionStatusInfo":
                //    return new SPDataLeakagePreventionStatusInfo(context, null);
                //case "SP.DlpPolicyTip":
                //    return new DlpPolicyTip(context, null);
                //case "SP.EffectiveInformationRightsManagementSettings":
                //    return new EffectiveInformationRightsManagementSettings(context, null);
                //case "SP.EventReceiverDefinition":
                //    return new EventReceiverDefinition(context, null);
                //case "SP.EventReceiverDefinitionCollection":
                //    return new EventReceiverDefinitionCollection(context, null);
                //case "SP.Feature":
                //    return new Feature(context, null);
                //case "SP.FeatureCollection":
                //    return new FeatureCollection(context, null);
                //case "SP.Field":
                //    return new Field(context, null);
                //case "SP.FieldCalculated":
                //    return new FieldCalculated(context, null);
                //case "SP.FieldChoice":
                //    return new FieldChoice(context, null);
                //case "SP.FieldCollection":
                //    return new FieldCollection(context, null);
                //case "SP.FieldComputed":
                //    return new FieldComputed(context, null);
                //case "SP.FieldCurrency":
                //    return new FieldCurrency(context, null);
                //case "SP.FieldDateTime":
                //    return new FieldDateTime(context, null);
                //case "SP.FieldGeolocation":
                //    return new FieldGeolocation(context, null);
                //case "SP.FieldGuid":
                //    return new FieldGuid(context, null);
                //case "SP.FieldLink":
                //    return new FieldLink(context, null);
                //case "SP.FieldLinkCollection":
                //    return new FieldLinkCollection(context, null);
                //case "SP.FieldLookup":
                //    return new FieldLookup(context, null);
                //case "SP.FieldMultiChoice":
                //    return new FieldMultiChoice(context, null);
                //case "SP.FieldMultiLineText":
                //    return new FieldMultiLineText(context, null);
                //case "SP.FieldNumber":
                //    return new FieldNumber(context, null);
                //case "SP.FieldRatingScale":
                //    return new FieldRatingScale(context, null);
                //case "SP.FieldStringValues":
                //    return new FieldStringValues(context, null);
                //case "SP.FieldText":
                //    return new FieldText(context, null);
                //case "SP.FieldUrl":
                //    return new FieldUrl(context, null);
                //case "SP.FieldUser":
                //    return new FieldUser(context, null);
                //case "SP.File":
                //    return new File(context, null);
                //case "SP.FileCollection":
                //    return new FileCollection(context, null);
                //case "SP.Utilities.FileHandlerWopiProperties":
                //    return new FileHandlerWopiProperties(context, null);
                //case "SP.FileVersion":
                //    return new FileVersion(context, null);
                //case "SP.FileVersionCollection":
                //    return new FileVersionCollection(context, null);
                //case "SP.FileVersionEvent":
                //    return new FileVersionEvent(context, null);
                //case "SP.FileVersionEventCollection":
                //    return new FileVersionEventCollection(context, null);
                //case "SP.FlowSynchronizationResult":
                //    return new FlowSynchronizationResult(context, null);
                //case "SP.Folder":
                //    return new Folder(context, null);
                //case "SP.FolderCollection":
                //    return new FolderCollection(context, null);
                //case "SP.Form":
                //    return new Form(context, null);
                //case "SP.FormCollection":
                //    return new FormCollection(context, null);
                case "SP.Group":
                    return new Group(context, null);
                case "SP.GroupCollection":
                    return new GroupCollection(context, null);
                //case "SP.HashtagStoreManager":
                //    return new HashtagStoreManager(context, null);
                //case "SP.InformationRightsManagementFileSettings":
                //    return new InformationRightsManagementFileSettings(context, null);
                //case "SP.InformationRightsManagementSettings":
                //    return new InformationRightsManagementSettings(context, null);
                //case "SP.WebParts.LimitedWebPartManager":
                //    return new LimitedWebPartManager(context, null);
                //case "SP.List":
                //    return new List(context, null);
                //case "SP.ListCollection":
                //    return new ListCollection(context, null);
                //case "SP.ListItem":
                //    return new ListItem(context, null);
                //case "SP.ListItemCollection":
                //    return new ListItemCollection(context, null);
                //case "SP.ListItemEntityCollection":
                //    return new ListItemEntityCollection(context, null);
                //case "SP.ListTemplate":
                //    return new ListTemplate(context, null);
                //case "SP.ListTemplateCollection":
                //    return new ListTemplateCollection(context, null);
                //case "SP.SPMigrationJobStatus":
                //    return new SPMigrationJobStatus(context, null);
                //case "SP.SPMigrationJobStatusCollection":
                //    return new SPMigrationJobStatusCollection(context, null);
                //case "SP.MountedFolderInfo":
                //    return new MountedFolderInfo(context, null);
                //case "SP.MountPointInfo":
                //    return new MountPointInfo(context, null);
                //case "SP.Navigation":
                //    return new Navigation(context, null);
                //case "SP.NavigationNode":
                //    return new NavigationNode(context, null);
                //case "SP.NavigationNodeCollection":
                //    return new NavigationNodeCollection(context, null);
                //case "SP.OAuth.NativeClient":
                //    return new NativeClient(context, null);
                //case "SP.ObjectSharingInformation":
                //    return new ObjectSharingInformation(context, null);
                //case "SP.ObjectSharingInformationUser":
                //    return new ObjectSharingInformationUser(context, null);
                //case "SP.ObjectSharingInformationUserCollection":
                //    return new ObjectSharingInformationUserCollection(context, null);
                case "SP.Principal":
                    return new Principal(context, null);
                case "SP.PropertyValues":
                    return new PropertyValues(context, null);
                //case "SP.PushNotificationSubscriber":
                //    return new PushNotificationSubscriber(context, null);
                //case "SP.PushNotificationSubscriberCollection":
                //    return new PushNotificationSubscriberCollection(context, null);
                //case "SP.RecycleBinItem":
                //    return new RecycleBinItem(context, null);
                //case "SP.RecycleBinItemCollection":
                //    return new RecycleBinItemCollection(context, null);
                //case "SP.RegionalSettings":
                //    return new RegionalSettings(context, null);
                //case "SP.RelatedField":
                //    return new RelatedField(context, null);
                //case "SP.RelatedFieldCollection":
                //    return new RelatedFieldCollection(context, null);
                //case "SP.RemoteWeb":
                //    return new RemoteWeb(context, null);
                //case "SP.RequestUserContext":
                //    return new RequestUserContext(context, null);
                case "SP.RoleAssignment":
                    return new RoleAssignment(context, null);
                case "SP.RoleAssignmentCollection":
                    return new RoleAssignmentCollection(context, null);
                case "SP.RoleDefinition":
                    return new RoleDefinition(context, null);
                case "SP.RoleDefinitionBindingCollection":
                    return new RoleDefinitionBindingCollection(context, null);
                //case "SP.RoleDefinitionCollection":
                //    return new RoleDefinitionCollection(context, null);
                case "SP.SecurableObject":
                    return new SecurableObject(context, null);
                //case "SP.SharingPermissionInformationCollection":
                //    return new SharingPermissionInformationCollection(context, null);
                //case "SP.SharingUserCollection":
                //    return new SharingUserCollection(context, null);
                case "SP.Site":
                    return new Site(context, null);
                //case "SP.SiteHealth.SiteHealthSummary":
                //    return new SiteHealthSummary(context, null);
                //case "SP.SiteUrl":
                //    return new SiteUrl(context, null);
                //case "SP.StorageMetrics":
                //    return new StorageMetrics(context, null);
                //case "SP.TenantAppInstance":
                //    return new TenantAppInstance(context, null);
                //case "SP.ThemeInfo":
                //    return new ThemeInfo(context, null);
                //case "SP.TimeZone":
                //    return new TimeZone(context, null);
                //case "SP.TimeZoneCollection":
                //    return new TimeZoneCollection(context, null);
                case "SP.User":
                    return new User(context, null);
                //case "SP.UserCollection":
                //    return new UserCollection(context, null);
                //case "SP.UserCustomAction":
                //    return new UserCustomAction(context, null);
                //case "SP.UserCustomActionCollection":
                //    return new UserCustomActionCollection(context, null);
                //case "SP.UserResource":
                //    return new UserResource(context, null);
                //case "SP.View":
                //    return new View(context, null);
                //case "SP.ViewCollection":
                //    return new ViewCollection(context, null);
                //case "SP.ViewFieldCollection":
                //    return new ViewFieldCollection(context, null);
                //case "SP.VisualizationAppMappedViewCollection":
                //    return new VisualizationAppMappedViewCollection(context, null);
                //case "SP.VisualizationAppSynchronizationResult":
                //    return new VisualizationAppSynchronizationResult(context, null);
                case "SP.Web":
                    return new Web(context, null);
                case "SP.WebCollection":
                    return new WebCollection(context, null);
                case "SP.WebInformation":
                    return new WebInformation(context, null);
                //case "SP.WebParts.WebPartDefinition":
                //    return new WebPartDefinition(context, null);
                //case "SP.WebParts.WebPartDefinitionCollection":
                //    return new WebPartDefinitionCollection(context, null);
                //case "SP.WebTemplate":
                //    return new WebTemplate(context, null);
                //case "SP.WebTemplateCollection":
                //    return new WebTemplateCollection(context, null);
                //case "SP.Utilities.WopiProperties":
                //    return new WopiProperties(context, null);
                //case "SP.Workflow.WorkflowAssociation":
                //    return new WorkflowAssociation(context, null);
                //case "SP.Workflow.WorkflowAssociationCollection":
                //    return new WorkflowAssociationCollection(context, null);
                //case "SP.Workflow.WorkflowTemplate":
                //    return new WorkflowTemplate(context, null);
                //case "SP.Workflow.WorkflowTemplateCollection":
                //    return new WorkflowTemplateCollection(context, null);
                //case "SP.BusinessData.Runtime.Subscription":
                //    return new Subscription(context, null);
                //case "SP.TenantSettings":
                //    return new TenantSettings(context, null);
                //case "SP.BusinessData.TypeDescriptor":
                //    return new TypeDescriptor(context, null);
                //case "SP.BusinessData.Collections.TypeDescriptorCollection":
                //    return new TypeDescriptorCollection(context, null);
                //case "SP.Utilities.UploadStatus":
                //    return new UploadStatus(context, null);
                //case "SP.BusinessData.EntityView":
                //    return new EntityView(context, null);
                //case "SP.WebParts.WebPart":
                //    return new WebPart(context, null);
                //case "SP.UI.ApplicationPages.ClientPeoplePickerQueryParameters":
                //    return new ClientPeoplePickerQueryParameters();
                //case "SP.CreatableItemInfo":
                //    return new CreatableItemInfo();
                //case "SP.CreatableItemInfoCollection":
                //    return new CreatableItemInfoCollection();
                //case "SP.Utilities.EmailProperties":
                //    return new EmailProperties();
                case "SP.EncryptionOption":
                    return new EncryptionOption();
                case "SP.IngestionTaskKey":
                    return new IngestionTaskKey();
                //case "SP.MicroService.MicroServiceWorkItemProperties":
                //    return new MicroServiceWorkItemProperties();
                //case "SP.PageInstrumentation.PageImpressionClient":
                //    return new PageImpressionClient();
                //case "SP.UI.ApplicationPages.PeoplePickerQuerySettings":
                //    return new PeoplePickerQuerySettings();
                //case "SP.UI.ApplicationPages.PickerEntityInformationRequest":
                //    return new PickerEntityInformationRequest();
                //case "SP.RelatedItem":
                //    return new RelatedItem();
                //case "SP.Sharing.SharedWithMeViewItemRemovalResult":
                //    return new SharedWithMeViewItemRemovalResult();
                //case "SP.SharedWithUser":
                //    return new SharedWithUser();
                //case "SP.SharedWithUserCollection":
                //    return new SharedWithUserCollection();
                //case "SP.SharingLinkData":
                //    return new SharingLinkData();
                //case "SP.SharingLinkInfo":
                //    return new SharingLinkInfo();
                case "SP.AlertCreationInformation":
                    return new AlertCreationInformation();
                //case "SP.AppLicense":
                //    return new AppLicense();
                //case "SP.AppLicenseCollection":
                //    return new AppLicenseCollection();
                //case "SP.AppPrincipalConfiguration":
                //    return new AppPrincipalConfiguration();
                //case "SP.AppPrincipalCredentialReference":
                //    return new AppPrincipalCredentialReference();
                //case "SP.AppProperties":
                //    return new AppProperties();
                //case "SP.AppSiteContext":
                //    return new AppSiteContext();
                //case "SP.AppViewCreationInfo":
                //    return new AppViewCreationInfo();
                //case "SP.AttachmentCreationInformation":
                //    return new AttachmentCreationInformation();
                case "SP.BasePermissions":
                    return new BasePermissions();
                //case "SP.ChangeLogItemQuery":
                //    return new ChangeLogItemQuery();
                //case "SP.ChangeQuery":
                //    return new ChangeQuery();
                case "SP.ChangeToken":
                    return new ChangeToken();
                //case "SP.ContentTypeCreationInformation":
                //    return new ContentTypeCreationInformation();
                //case "SP.ContentTypeId":
                //    return new ContentTypeId();
                //case "SP.CopyJobProgress":
                //    return new CopyJobProgress();
                //case "SP.CopyMigrationInfo":
                //    return new CopyMigrationInfo();
                //case "SP.CopyMigrationOptions":
                //    return new CopyMigrationOptions();
                //case "SP.CustomActionElement":
                //    return new CustomActionElement();
                //case "SP.CustomActionElementCollection":
                //    return new CustomActionElementCollection();
                //case "SP.CustomerKeyInfo":
                //    return new CustomerKeyInfo();
                //case "SP.DocumentLibraryInformation":
                //    return new DocumentLibraryInformation();
                //case "SP.EventReceiverDefinitionCreationInformation":
                //    return new EventReceiverDefinitionCreationInformation();
                //case "SP.ExternalAppPrincipalCreationParameters":
                //    return new ExternalAppPrincipalCreationParameters();
                //case "SP.ListDataValidationFailure":
                //    return new ListDataValidationFailure();
                //case "SP.FieldCalculatedErrorValue":
                //    return new FieldCalculatedErrorValue();
                //case "SP.FieldGeolocationValue":
                //    return new FieldGeolocationValue();
                //case "SP.FieldLinkCreationInformation":
                //    return new FieldLinkCreationInformation();
                //case "SP.FieldLookupValue":
                //    return new FieldLookupValue();
                //case "SP.FieldRatingScaleQuestionAnswer":
                //    return new FieldRatingScaleQuestionAnswer();
                //case "SP.FieldUrlValue":
                //    return new FieldUrlValue();
                //case "SP.FieldUserValue":
                //    return new FieldUserValue();
                //case "SP.FileCollectionAddParameters":
                //    return new FileCollectionAddParameters();
                //case "SP.FileCreationInformation":
                //    return new FileCreationInformation();
                //case "SP.FileSaveBinaryInformation":
                //    return new FileSaveBinaryInformation();
                //case "SP.FolderCollectionAddParameters":
                //    return new FolderCollectionAddParameters();
                case "SP.GroupCreationInformation":
                    return new GroupCreationInformation();
                //case "SP.Hashtag":
                //    return new Hashtag();
                //case "SP.SPInvitationCreationResult":
                //    return new SPInvitationCreationResult();
                //case "SP.Language":
                //    return new Language();
                //case "SP.ListCreationInformation":
                //    return new ListCreationInformation();
                //case "SP.ListDataSource":
                //    return new ListDataSource();
                //case "SP.ListDataValidationExceptionValue":
                //    return new ListDataValidationExceptionValue();
                //case "SP.ListItemCollectionPosition":
                //    return new ListItemCollectionPosition();
                //case "SP.ListItemCreationInformation":
                //    return new ListItemCreationInformation();
                //case "SP.ListItemCreationInformationUsingPath":
                //    return new ListItemCreationInformationUsingPath();
                //case "SP.ListItemFormUpdateValue":
                //    return new ListItemFormUpdateValue();
                //case "SP.MoveCopyOptions":
                //    return new MoveCopyOptions();
                //case "SP.NavigationNodeCreationInformation":
                //    return new NavigationNodeCreationInformation();
                //case "SP.Utilities.PrincipalInfo":
                //    return new PrincipalInfo();
                //case "SP.ProvisionedMigrationContainersInfo":
                //    return new ProvisionedMigrationContainersInfo();
                //case "SP.ProvisionedMigrationQueueInfo":
                //    return new ProvisionedMigrationQueueInfo();
                //case "SP.CamlQuery":
                //    return new CamlQuery();
                //case "SP.RecycleBinQueryInformation":
                //    return new RecycleBinQueryInformation();
                //case "SP.RenderListContextMenuDataParameters":
                //    return new RenderListContextMenuDataParameters();
                //case "SP.RenderListDataOverrideParameters":
                //    return new RenderListDataOverrideParameters();
                //case "SP.RenderListDataParameters":
                //    return new RenderListDataParameters();
                //case "SP.RenderListFilterDataParameters":
                //    return new RenderListFilterDataParameters();
                case "SP.ResourcePath":
                    return new ResourcePath();
                case "SP.RoleDefinitionCreationInformation":
                    return new RoleDefinitionCreationInformation();
                //case "SP.SiteHealth.SiteHealthResult":
                //    return new SiteHealthResult();
                //case "SP.UpgradeInfo":
                //    return new UpgradeInfo();
                //case "SP.SubwebQuery":
                //    return new SubwebQuery();
                //case "SP.TenantAppInformation":
                //    return new TenantAppInformation();
                //case "SP.TimeZoneInformation":
                //    return new TimeZoneInformation();
                //case "SP.UsageInfo":
                //    return new UsageInfo();
                case "SP.UserCreationInformation":
                    return new UserCreationInformation();
                case "SP.UserIdInfo":
                    return new UserIdInfo();
                //case "SP.ViewCreationInformation":
                //    return new ViewCreationInformation();
                //case "SP.Visualization":
                //    return new Visualization();
                //case "SP.VisualizationAppInfo":
                //    return new VisualizationAppInfo();
                //case "SP.VisualizationField":
                //    return new VisualizationField();
                //case "SP.VisualizationStyleSet":
                //    return new VisualizationStyleSet();
                case "SP.WebCreationInformation":
                    return new WebCreationInformation();
                //case "SP.WebRequestInfo":
                //    return new WebRequestInfo();
                //case "SP.WebResponseInfo":
                //    return new WebResponseInfo();
                //case "SP.Utilities.WikiPageCreationInformation":
                //    return new WikiPageCreationInformation();
                //case "SP.Workflow.WorkflowAssociationCreationInformation":
                //    return new WorkflowAssociationCreationInformation();
                //case "Microsoft.SharePoint.TenantCdn.TenantCdnUrl":
                //    return new TenantCdnUrl();
                //case "SP.WebParts.TileData":
                //    return new TileData();
                //case "SP.Sharing.UserRoleAssignment":
                //    return new UserRoleAssignment();
                //case "SP.Sharing.UserSharingResult":
                //    return new UserSharingResult();
            }
            return null;
        }
    }
}
