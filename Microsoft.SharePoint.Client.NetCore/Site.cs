using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Site", ServerTypeId = "{e1bb82e8-0d1e-4e52-b90c-684802ab4ef6}")]
    public class Site : ClientObject
    {
        [Remote]
        public bool AllowCreateDeclarativeWorkflow
        {
            get
            {
                base.CheckUninitializedProperty("AllowCreateDeclarativeWorkflow");
                return (bool)base.ObjectData.Properties["AllowCreateDeclarativeWorkflow"];
            }
            set
            {
                base.ObjectData.Properties["AllowCreateDeclarativeWorkflow"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowCreateDeclarativeWorkflow", value));
                }
            }
        }

        [Remote]
        public bool AllowDesigner
        {
            get
            {
                base.CheckUninitializedProperty("AllowDesigner");
                return (bool)base.ObjectData.Properties["AllowDesigner"];
            }
            set
            {
                base.ObjectData.Properties["AllowDesigner"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowDesigner", value));
                }
            }
        }

        [Remote]
        public bool AllowMasterPageEditing
        {
            get
            {
                base.CheckUninitializedProperty("AllowMasterPageEditing");
                return (bool)base.ObjectData.Properties["AllowMasterPageEditing"];
            }
            set
            {
                base.ObjectData.Properties["AllowMasterPageEditing"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowMasterPageEditing", value));
                }
            }
        }

        [Remote]
        public bool AllowRevertFromTemplate
        {
            get
            {
                base.CheckUninitializedProperty("AllowRevertFromTemplate");
                return (bool)base.ObjectData.Properties["AllowRevertFromTemplate"];
            }
            set
            {
                base.ObjectData.Properties["AllowRevertFromTemplate"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowRevertFromTemplate", value));
                }
            }
        }

        [Remote]
        public bool AllowSaveDeclarativeWorkflowAsTemplate
        {
            get
            {
                base.CheckUninitializedProperty("AllowSaveDeclarativeWorkflowAsTemplate");
                return (bool)base.ObjectData.Properties["AllowSaveDeclarativeWorkflowAsTemplate"];
            }
            set
            {
                base.ObjectData.Properties["AllowSaveDeclarativeWorkflowAsTemplate"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowSaveDeclarativeWorkflowAsTemplate", value));
                }
            }
        }

        [Remote]
        public bool AllowSavePublishDeclarativeWorkflow
        {
            get
            {
                base.CheckUninitializedProperty("AllowSavePublishDeclarativeWorkflow");
                return (bool)base.ObjectData.Properties["AllowSavePublishDeclarativeWorkflow"];
            }
            set
            {
                base.ObjectData.Properties["AllowSavePublishDeclarativeWorkflow"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowSavePublishDeclarativeWorkflow", value));
                }
            }
        }

        [Remote]
        public bool AllowSelfServiceUpgrade
        {
            get
            {
                base.CheckUninitializedProperty("AllowSelfServiceUpgrade");
                return (bool)base.ObjectData.Properties["AllowSelfServiceUpgrade"];
            }
            set
            {
                base.ObjectData.Properties["AllowSelfServiceUpgrade"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowSelfServiceUpgrade", value));
                }
            }
        }

        [Remote]
        public bool AllowSelfServiceUpgradeEvaluation
        {
            get
            {
                base.CheckUninitializedProperty("AllowSelfServiceUpgradeEvaluation");
                return (bool)base.ObjectData.Properties["AllowSelfServiceUpgradeEvaluation"];
            }
            set
            {
                base.ObjectData.Properties["AllowSelfServiceUpgradeEvaluation"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AllowSelfServiceUpgradeEvaluation", value));
                }
            }
        }

        //[Remote]
        //public Audit Audit
        //{
        //    get
        //    {
        //        object obj;
        //        Audit audit;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("Audit", out obj))
        //        {
        //            audit = (Audit)obj;
        //        }
        //        else
        //        {
        //            audit = new Audit(base.Context, new ObjectPathProperty(base.Context, base.Path, "Audit"));
        //            base.ObjectData.ClientObjectProperties["Audit"] = audit;
        //        }
        //        return audit;
        //    }
        //}

        [Remote]
        public int AuditLogTrimmingRetention
        {
            get
            {
                base.CheckUninitializedProperty("AuditLogTrimmingRetention");
                return (int)base.ObjectData.Properties["AuditLogTrimmingRetention"];
            }
            set
            {
                base.ObjectData.Properties["AuditLogTrimmingRetention"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AuditLogTrimmingRetention", value));
                }
            }
        }

        [Remote]
        public bool CanUpgrade
        {
            get
            {
                base.CheckUninitializedProperty("CanUpgrade");
                return (bool)base.ObjectData.Properties["CanUpgrade"];
            }
        }

        [Remote]
        public string Classification
        {
            get
            {
                base.CheckUninitializedProperty("Classification");
                return (string)base.ObjectData.Properties["Classification"];
            }
            set
            {
                base.ObjectData.Properties["Classification"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Classification", value));
                }
            }
        }

        [Remote]
        public int CompatibilityLevel
        {
            get
            {
                base.CheckUninitializedProperty("CompatibilityLevel");
                return (int)base.ObjectData.Properties["CompatibilityLevel"];
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
        public bool DisableCompanyWideSharingLinks
        {
            get
            {
                base.CheckUninitializedProperty("DisableCompanyWideSharingLinks");
                return (bool)base.ObjectData.Properties["DisableCompanyWideSharingLinks"];
            }
            set
            {
                base.ObjectData.Properties["DisableCompanyWideSharingLinks"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DisableCompanyWideSharingLinks", value));
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

        //[Remote]
        //public EventReceiverDefinitionCollection EventReceivers
        //{
        //    get
        //    {
        //        object obj;
        //        EventReceiverDefinitionCollection eventReceiverDefinitionCollection;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("EventReceivers", out obj))
        //        {
        //            eventReceiverDefinitionCollection = (EventReceiverDefinitionCollection)obj;
        //        }
        //        else
        //        {
        //            eventReceiverDefinitionCollection = new EventReceiverDefinitionCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "EventReceivers"));
        //            base.ObjectData.ClientObjectProperties["EventReceivers"] = eventReceiverDefinitionCollection;
        //        }
        //        return eventReceiverDefinitionCollection;
        //    }
        //}

        [Remote]
        public bool ExternalSharingTipsEnabled
        {
            get
            {
                base.CheckUninitializedProperty("ExternalSharingTipsEnabled");
                return (bool)base.ObjectData.Properties["ExternalSharingTipsEnabled"];
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
        public Guid GroupId
        {
            get
            {
                base.CheckUninitializedProperty("GroupId");
                return (Guid)base.ObjectData.Properties["GroupId"];
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
        public string LockIssue
        {
            get
            {
                base.CheckUninitializedProperty("LockIssue");
                return (string)base.ObjectData.Properties["LockIssue"];
            }
        }

        [Remote]
        public uint MaxItemsPerThrottledOperation
        {
            get
            {
                base.CheckUninitializedProperty("MaxItemsPerThrottledOperation");
                return (uint)base.ObjectData.Properties["MaxItemsPerThrottledOperation"];
            }
        }

        [Remote]
        public bool NeedsB2BUpgrade
        {
            get
            {
                base.CheckUninitializedProperty("NeedsB2BUpgrade");
                return (bool)base.ObjectData.Properties["NeedsB2BUpgrade"];
            }
            set
            {
                base.ObjectData.Properties["NeedsB2BUpgrade"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "NeedsB2BUpgrade", value));
                }
            }
        }

        //[Remote]
        //public User Owner
        //{
        //    get
        //    {
        //        object obj;
        //        User user;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("Owner", out obj))
        //        {
        //            user = (User)obj;
        //        }
        //        else
        //        {
        //            user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "Owner"));
        //            base.ObjectData.ClientObjectProperties["Owner"] = user;
        //        }
        //        return user;
        //    }
        //    set
        //    {
        //        base.ObjectData.ClientObjectProperties["Owner"] = value;
        //        if (base.Context != null)
        //        {
        //            base.Context.AddQuery(new ClientActionSetProperty(this, "Owner", value));
        //        }
        //    }
        //}

        //[Remote]
        //public ResourcePath ResourcePath
        //{
        //    get
        //    {
        //        base.CheckUninitializedProperty("ResourcePath");
        //        return (ResourcePath)base.ObjectData.Properties["ResourcePath"];
        //    }
        //}

        [Remote]
        public string PrimaryUri
        {
            get
            {
                base.CheckUninitializedProperty("PrimaryUri");
                return (string)base.ObjectData.Properties["PrimaryUri"];
            }
        }

        [Remote]
        public bool ReadOnly
        {
            get
            {
                base.CheckUninitializedProperty("ReadOnly");
                return (bool)base.ObjectData.Properties["ReadOnly"];
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
        public string RequiredDesignerVersion
        {
            get
            {
                base.CheckUninitializedProperty("RequiredDesignerVersion");
                return (string)base.ObjectData.Properties["RequiredDesignerVersion"];
            }
        }

        [Remote]
        public Web RootWeb
        {
            get
            {
                object obj;
                Web web;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("RootWeb", out obj))
                {
                    web = (Web)obj;
                }
                else
                {
                    web = new Web(base.Context, new ObjectPathProperty(base.Context, base.Path, "RootWeb"));
                    base.ObjectData.ClientObjectProperties["RootWeb"] = web;
                }
                return web;
            }
        }

        //[Remote]
        //public SandboxedCodeActivationCapabilities SandboxedCodeActivationCapability
        //{
        //    get
        //    {
        //        base.CheckUninitializedProperty("SandboxedCodeActivationCapability");
        //        return (SandboxedCodeActivationCapabilities)base.ObjectData.Properties["SandboxedCodeActivationCapability"];
        //    }
        //    set
        //    {
        //        base.ObjectData.Properties["SandboxedCodeActivationCapability"] = value;
        //        if (base.Context != null)
        //        {
        //            base.Context.AddQuery(new ClientActionSetProperty(this, "SandboxedCodeActivationCapability", value));
        //        }
        //    }
        //}

        //[Remote]
        //public User SecondaryContact
        //{
        //    get
        //    {
        //        object obj;
        //        User user;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("SecondaryContact", out obj))
        //        {
        //            user = (User)obj;
        //        }
        //        else
        //        {
        //            user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "SecondaryContact"));
        //            base.ObjectData.ClientObjectProperties["SecondaryContact"] = user;
        //        }
        //        return user;
        //    }
        //    set
        //    {
        //        base.ObjectData.ClientObjectProperties["SecondaryContact"] = value;
        //        if (base.Context != null)
        //        {
        //            base.Context.AddQuery(new ClientActionSetProperty(this, "SecondaryContact", value));
        //        }
        //    }
        //}

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
        public bool ShareByEmailEnabled
        {
            get
            {
                base.CheckUninitializedProperty("ShareByEmailEnabled");
                return (bool)base.ObjectData.Properties["ShareByEmailEnabled"];
            }
            set
            {
                base.ObjectData.Properties["ShareByEmailEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ShareByEmailEnabled", value));
                }
            }
        }

        [Remote]
        public bool ShareByLinkEnabled
        {
            get
            {
                base.CheckUninitializedProperty("ShareByLinkEnabled");
                return (bool)base.ObjectData.Properties["ShareByLinkEnabled"];
            }
        }

        [Remote]
        public bool ShowPeoplePickerSuggestionsForGuestUsers
        {
            get
            {
                base.CheckUninitializedProperty("ShowPeoplePickerSuggestionsForGuestUsers");
                return (bool)base.ObjectData.Properties["ShowPeoplePickerSuggestionsForGuestUsers"];
            }
            set
            {
                base.ObjectData.Properties["ShowPeoplePickerSuggestionsForGuestUsers"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ShowPeoplePickerSuggestionsForGuestUsers", value));
                }
            }
        }

        [Remote]
        public bool ShowUrlStructure
        {
            get
            {
                base.CheckUninitializedProperty("ShowUrlStructure");
                return (bool)base.ObjectData.Properties["ShowUrlStructure"];
            }
            set
            {
                base.ObjectData.Properties["ShowUrlStructure"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ShowUrlStructure", value));
                }
            }
        }

        [Remote]
        public string StatusBarLink
        {
            get
            {
                base.CheckUninitializedProperty("StatusBarLink");
                return (string)base.ObjectData.Properties["StatusBarLink"];
            }
            set
            {
                base.ObjectData.Properties["StatusBarLink"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "StatusBarLink", value));
                }
            }
        }

        [Remote]
        public string StatusBarText
        {
            get
            {
                base.CheckUninitializedProperty("StatusBarText");
                return (string)base.ObjectData.Properties["StatusBarText"];
            }
            set
            {
                base.ObjectData.Properties["StatusBarText"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "StatusBarText", value));
                }
            }
        }

        [Remote]
        public bool TrimAuditLog
        {
            get
            {
                base.CheckUninitializedProperty("TrimAuditLog");
                return (bool)base.ObjectData.Properties["TrimAuditLog"];
            }
            set
            {
                base.ObjectData.Properties["TrimAuditLog"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "TrimAuditLog", value));
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

        //[Remote]
        //public UpgradeInfo UpgradeInfo
        //{
        //    get
        //    {
        //        base.CheckUninitializedProperty("UpgradeInfo");
        //        return (UpgradeInfo)base.ObjectData.Properties["UpgradeInfo"];
        //    }
        //}

        [Remote]
        public DateTime UpgradeReminderDate
        {
            get
            {
                base.CheckUninitializedProperty("UpgradeReminderDate");
                return (DateTime)base.ObjectData.Properties["UpgradeReminderDate"];
            }
        }

        [Remote]
        public bool UpgradeScheduled
        {
            get
            {
                base.CheckUninitializedProperty("UpgradeScheduled");
                return (bool)base.ObjectData.Properties["UpgradeScheduled"];
            }
            set
            {
                base.ObjectData.Properties["UpgradeScheduled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "UpgradeScheduled", value));
                }
            }
        }

        [Remote]
        public DateTime UpgradeScheduledDate
        {
            get
            {
                base.CheckUninitializedProperty("UpgradeScheduledDate");
                return (DateTime)base.ObjectData.Properties["UpgradeScheduledDate"];
            }
            set
            {
                base.ObjectData.Properties["UpgradeScheduledDate"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "UpgradeScheduledDate", value));
                }
            }
        }

        [Remote]
        public bool Upgrading
        {
            get
            {
                base.CheckUninitializedProperty("Upgrading");
                return (bool)base.ObjectData.Properties["Upgrading"];
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

        //[Remote]
        //public UsageInfo Usage
        //{
        //    get
        //    {
        //        base.CheckUninitializedProperty("Usage");
        //        return (UsageInfo)base.ObjectData.Properties["Usage"];
        //    }
        //}

        //[Remote]
        //public UserCustomActionCollection UserCustomActions
        //{
        //    get
        //    {
        //        object obj;
        //        UserCustomActionCollection userCustomActionCollection;
        //        if (base.ObjectData.ClientObjectProperties.TryGetValue("UserCustomActions", out obj))
        //        {
        //            userCustomActionCollection = (UserCustomActionCollection)obj;
        //        }
        //        else
        //        {
        //            userCustomActionCollection = new UserCustomActionCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "UserCustomActions"));
        //            base.ObjectData.ClientObjectProperties["UserCustomActions"] = userCustomActionCollection;
        //        }
        //        return userCustomActionCollection;
        //    }
        //}

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Site(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "AllowCreateDeclarativeWorkflow":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowCreateDeclarativeWorkflow"] = reader.ReadBoolean();
                    break;
                case "AllowDesigner":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowDesigner"] = reader.ReadBoolean();
                    break;
                case "AllowMasterPageEditing":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowMasterPageEditing"] = reader.ReadBoolean();
                    break;
                case "AllowRevertFromTemplate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowRevertFromTemplate"] = reader.ReadBoolean();
                    break;
                case "AllowSaveDeclarativeWorkflowAsTemplate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowSaveDeclarativeWorkflowAsTemplate"] = reader.ReadBoolean();
                    break;
                case "AllowSavePublishDeclarativeWorkflow":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowSavePublishDeclarativeWorkflow"] = reader.ReadBoolean();
                    break;
                case "AllowSelfServiceUpgrade":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowSelfServiceUpgrade"] = reader.ReadBoolean();
                    break;
                case "AllowSelfServiceUpgradeEvaluation":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AllowSelfServiceUpgradeEvaluation"] = reader.ReadBoolean();
                    break;
        //Edited for .NET Core
                //case "Audit":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("Audit", this.Audit, reader);
                //    this.Audit.FromJson(reader);
                //    break;
                case "AuditLogTrimmingRetention":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AuditLogTrimmingRetention"] = reader.ReadInt32();
                    break;
                case "CanUpgrade":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CanUpgrade"] = reader.ReadBoolean();
                    break;
                case "Classification":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Classification"] = reader.ReadString();
                    break;
                case "CompatibilityLevel":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CompatibilityLevel"] = reader.ReadInt32();
                    break;
                //case "CurrentChangeToken":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["CurrentChangeToken"] = reader.Read<ChangeToken>();
                //    break;
                case "DisableAppViews":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisableAppViews"] = reader.ReadBoolean();
                    break;
                case "DisableCompanyWideSharingLinks":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisableCompanyWideSharingLinks"] = reader.ReadBoolean();
                    break;
                case "DisableFlows":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisableFlows"] = reader.ReadBoolean();
                    break;
        //Edited for .NET Core
                //case "EventReceivers":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("EventReceivers", this.EventReceivers, reader);
                //    this.EventReceivers.FromJson(reader);
                //    break;
                case "ExternalSharingTipsEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ExternalSharingTipsEnabled"] = reader.ReadBoolean();
                    break;
        //Edited for .NET Core
                //case "Features":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("Features", this.Features, reader);
                //    this.Features.FromJson(reader);
                    //break;
                case "GroupId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["GroupId"] = reader.ReadGuid();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "LockIssue":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LockIssue"] = reader.ReadString();
                    break;
                case "MaxItemsPerThrottledOperation":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MaxItemsPerThrottledOperation"] = reader.ReadUInt32();
                    break;
                case "NeedsB2BUpgrade":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NeedsB2BUpgrade"] = reader.ReadBoolean();
                    break;
        //Edited for .NET Core
                //case "Owner":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("Owner", this.Owner, reader);
                //    this.Owner.FromJson(reader);
                //    break;
                //case "ResourcePath":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["ResourcePath"] = reader.Read<ResourcePath>();
                //    break;
                case "PrimaryUri":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PrimaryUri"] = reader.ReadString();
                    break;
                case "ReadOnly":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReadOnly"] = reader.ReadBoolean();
                    break;
        //Edited for .NET Core
                //case "RecycleBin":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("RecycleBin", this.RecycleBin, reader);
                //    this.RecycleBin.FromJson(reader);
                //    break;
                case "RequiredDesignerVersion":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RequiredDesignerVersion"] = reader.ReadString();
                    break;
                case "RootWeb":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("RootWeb", this.RootWeb, reader);
                    this.RootWeb.FromJson(reader);
                    break;
                //case "SandboxedCodeActivationCapability":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["SandboxedCodeActivationCapability"] = reader.ReadEnum<SandboxedCodeActivationCapabilities>();
                //    break;
                //Edited for .NET Core
                //case "SecondaryContact":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("SecondaryContact", this.SecondaryContact, reader);
                //    this.SecondaryContact.FromJson(reader);
                //    break;
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
                case "ShareByEmailEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ShareByEmailEnabled"] = reader.ReadBoolean();
                    break;
                case "ShareByLinkEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ShareByLinkEnabled"] = reader.ReadBoolean();
                    break;
                case "ShowPeoplePickerSuggestionsForGuestUsers":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ShowPeoplePickerSuggestionsForGuestUsers"] = reader.ReadBoolean();
                    break;
                case "ShowUrlStructure":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ShowUrlStructure"] = reader.ReadBoolean();
                    break;
                case "StatusBarLink":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["StatusBarLink"] = reader.ReadString();
                    break;
                case "StatusBarText":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["StatusBarText"] = reader.ReadString();
                    break;
                case "TrimAuditLog":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TrimAuditLog"] = reader.ReadBoolean();
                    break;
                case "UIVersionConfigurationEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UIVersionConfigurationEnabled"] = reader.ReadBoolean();
                    break;
        //Edited for .NET Core
                //case "UpgradeInfo":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["UpgradeInfo"] = reader.Read<UpgradeInfo>();
                //    break;
                case "UpgradeReminderDate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UpgradeReminderDate"] = reader.ReadDateTime();
                    break;
                case "UpgradeScheduled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UpgradeScheduled"] = reader.ReadBoolean();
                    break;
                case "UpgradeScheduledDate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UpgradeScheduledDate"] = reader.ReadDateTime();
                    break;
                case "Upgrading":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Upgrading"] = reader.ReadBoolean();
                    break;
                case "Url":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Url"] = reader.ReadString();
                    break;
        //Edited for .NET Core
                //case "Usage":
                //    flag = true;
                //    reader.ReadName();
                //    base.ObjectData.Properties["Usage"] = reader.Read<UsageInfo>();
                //    break;
        //Edited for .NET Core
                //case "UserCustomActions":
                //    flag = true;
                //    reader.ReadName();
                //    base.UpdateClientObjectPropertyType("UserCustomActions", this.UserCustomActions, reader);
                //    this.UserCustomActions.FromJson(reader);
                //    break;
            }
            return flag;
        }

        [Remote]
        public ClientResult<bool> NeedsUpgradeByType(bool versionUpgrade, bool recursive)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "NeedsUpgradeByType", new object[]
            {
                versionUpgrade,
                recursive
            });
            context.AddQuery(clientAction);
            ClientResult<bool> clientResult = new ClientResult<bool>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        //[Remote]
        //public SiteHealthSummary RunHealthCheck(Guid ruleId, bool bRepair, bool bRunAlways)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new SiteHealthSummary(context, new ObjectPathMethod(context, base.Path, "RunHealthCheck", new object[]
        //    {
        //        ruleId,
        //        bRepair,
        //        bRunAlways
        //    }));
        //}

        [Remote]
        public void CreatePreviewSPSite(bool upgrade, bool sendemail)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "CreatePreviewSPSite", new object[]
            {
                upgrade,
                sendemail
            });
            context.AddQuery(query);
        }

        [Remote]
        public void RunUpgradeSiteSession(bool versionUpgrade, bool queueOnly, bool sendEmail)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RunUpgradeSiteSession", new object[]
            {
                versionUpgrade,
                queueOnly,
                sendEmail
            });
            context.AddQuery(query);
        }

        [Remote]
        public ClientResult<bool> DeleteMigrationJob(Guid id)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "DeleteMigrationJob", new object[]
            {
                id
            });
            context.AddQuery(clientAction);
            ClientResult<bool> clientResult = new ClientResult<bool>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        //[Remote]
        //public SPMigrationJobStatusCollection GetMigrationStatus()
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new SPMigrationJobStatusCollection(context, new ObjectPathMethod(context, base.Path, "GetMigrationStatus", null));
        //}

        //[Remote]
        //public ClientResult<MigrationJobState> GetMigrationJobStatus(Guid id)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "GetMigrationJobStatus", new object[]
        //    {
        //        id
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<MigrationJobState> clientResult = new ClientResult<MigrationJobState>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        [Remote]
        public ClientResult<Guid> CreateMigrationJob(Guid gWebId, string azureContainerSourceUri, string azureContainerManifestUri, string azureQueueReportUri)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "CreateMigrationJob", new object[]
            {
                gWebId,
                azureContainerSourceUri,
                azureContainerManifestUri,
                azureQueueReportUri
            });
            context.AddQuery(clientAction);
            ClientResult<Guid> clientResult = new ClientResult<Guid>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<Guid> CreateMigrationJobEncrypted(Guid gWebId, string azureContainerSourceUri, string azureContainerManifestUri, string azureQueueReportUri, EncryptionOption options)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "CreateMigrationJobEncrypted", new object[]
            {
                gWebId,
                azureContainerSourceUri,
                azureContainerManifestUri,
                azureQueueReportUri,
                options
            });
            context.AddQuery(clientAction);
            ClientResult<Guid> clientResult = new ClientResult<Guid>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<Guid> CreateMigrationIngestionJob(Guid gWebId, string azureContainerSourceUri, string azureContainerManifestUri, string azureQueueReportUri, IngestionTaskKey ingestionTaskKey)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "CreateMigrationIngestionJob", new object[]
            {
                gWebId,
                azureContainerSourceUri,
                azureContainerManifestUri,
                azureQueueReportUri,
                ingestionTaskKey
            });
            context.AddQuery(clientAction);
            ClientResult<Guid> clientResult = new ClientResult<Guid>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        //[Remote]
        //public ClientResult<CopyMigrationInfo> CreateCopyJob(string[] exportObjectUris, string destinationUri, CopyMigrationOptions options)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "CreateCopyJob", new object[]
        //    {
        //        exportObjectUris,
        //        destinationUri,
        //        options
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<CopyMigrationInfo> clientResult = new ClientResult<CopyMigrationInfo>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        //[Remote]
        //public IList<CopyMigrationInfo> CreateCopyJobs(string[] exportObjectUris, string destinationUri, CopyMigrationOptions options)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "CreateCopyJobs", new object[]
        //    {
        //        exportObjectUris,
        //        destinationUri,
        //        options
        //    });
        //    context.AddQuery(clientAction);
        //    IList<CopyMigrationInfo> list = new List<CopyMigrationInfo>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, new ClientListResultHandler<CopyMigrationInfo>(list));
        //    return list;
        //}

        //[Remote]
        //public ClientResult<CopyJobProgress> GetCopyJobProgress(CopyMigrationInfo copyJobInfo)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "GetCopyJobProgress", new object[]
        //    {
        //        copyJobInfo
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<CopyJobProgress> clientResult = new ClientResult<CopyJobProgress>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        //[Remote]
        //public ClientResult<ProvisionedMigrationContainersInfo> ProvisionMigrationContainers()
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "ProvisionMigrationContainers", null);
        //    context.AddQuery(clientAction);
        //    ClientResult<ProvisionedMigrationContainersInfo> clientResult = new ClientResult<ProvisionedMigrationContainersInfo>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        //[Remote]
        //public ClientResult<ProvisionedMigrationQueueInfo> ProvisionMigrationQueue()
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "ProvisionMigrationQueue", null);
        //    context.AddQuery(clientAction);
        //    ClientResult<ProvisionedMigrationQueueInfo> clientResult = new ClientResult<ProvisionedMigrationQueueInfo>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        //[Remote]
        //public ClientResult<bool> OnboardTenantForBringYourOwnKey(CustomerKeyInfo keyInfo)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    ClientAction clientAction = new ClientActionInvokeMethod(this, "OnboardTenantForBringYourOwnKey", new object[]
        //    {
        //        keyInfo
        //    });
        //    context.AddQuery(clientAction);
        //    ClientResult<bool> clientResult = new ClientResult<bool>();
        //    context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
        //    return clientResult;
        //}

        [Remote]
        public void UpdateClientObjectModelUseRemoteAPIsPermissionSetting(bool requireUseRemoteAPIs)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "UpdateClientObjectModelUseRemoteAPIsPermissionSetting", new object[]
            {
                requireUseRemoteAPIs
            });
            context.AddQuery(query);
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
        //public ChangeCollection GetChanges(ChangeQuery query)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new ChangeCollection(context, new ObjectPathMethod(context, base.Path, "GetChanges", new object[]
        //    {
        //        query
        //    }));
        //}

        [Remote]
        public ClientResult<ResourcePath> GetWebPath(Guid siteId, Guid webId)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetWebPath", new object[]
            {
                siteId,
                webId
            });
            context.AddQuery(clientAction);
            ClientResult<ResourcePath> clientResult = new ClientResult<ResourcePath>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public Web OpenWeb(string strUrl)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && strUrl == null)
            {
                throw ClientUtility.CreateArgumentNullException("strUrl");
            }
            object obj;
            Dictionary<string, Web> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("OpenWeb", out obj))
            {
                dictionary = (Dictionary<string, Web>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, Web>(StringComparer.OrdinalIgnoreCase);
                base.ObjectData.MethodReturnObjects["OpenWeb"] = dictionary;
            }
            Web web = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(strUrl, out web))
            {
                return web;
            }
            web = new Web(context, new ObjectPathMethod(context, base.Path, "OpenWeb", new object[]
            {
                strUrl
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[strUrl] = web;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(web.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, web);
            context.AddQuery(objectIdentityQuery);
            return web;
        }

        [Remote]
        public Web OpenWebUsingPath(ResourcePath path)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && path == null)
            {
                throw ClientUtility.CreateArgumentNullException("path");
            }
            return new Web(context, new ObjectPathMethod(context, base.Path, "OpenWebUsingPath", new object[]
            {
                path
            }));
        }

        [Remote]
        public Web OpenWebById(Guid gWebId)
        {
            ClientRuntimeContext context = base.Context;
            return new Web(context, new ObjectPathMethod(context, base.Path, "OpenWebById", new object[]
            {
                gWebId
            }));
        }

        //[Remote]
        //public WebTemplateCollection GetWebTemplates(uint LCID, int overrideCompatLevel)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new WebTemplateCollection(context, new ObjectPathMethod(context, base.Path, "GetWebTemplates", new object[]
        //    {
        //        LCID,
        //        overrideCompatLevel
        //    }));
        //}

        //[Remote]
        //public ListTemplateCollection GetCustomListTemplates(Web web)
        //{
        //    ClientRuntimeContext context = base.Context;
        //    return new ListTemplateCollection(context, new ObjectPathMethod(context, base.Path, "GetCustomListTemplates", new object[]
        //    {
        //        web
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
        public void ExtendUpgradeReminderDate()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "ExtendUpgradeReminderDate", null);
            context.AddQuery(query);
        }

        [Remote]
        public virtual void Invalidate()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Invalidate", null);
            context.AddQuery(query);
        }

        [Remote]
        public static ClientResult<bool> Exists(ClientRuntimeContext context, string url)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{e1bb82e8-0d1e-4e52-b90c-684802ab4ef6}", "Exists", new object[]
            {
                url
            });
            context.AddQuery(clientAction);
            ClientResult<bool> clientResult = new ClientResult<bool>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }
    }
}
