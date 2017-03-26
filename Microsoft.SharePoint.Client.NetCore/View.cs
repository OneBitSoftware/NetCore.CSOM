using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.View", ServerTypeId = "{2399f45d-1784-4965-9a5f-a3415790a0d0}")]
    public class View : ClientObject
    {
        [Remote]
        public string Aggregations
        {
            get
            {
                base.CheckUninitializedProperty("Aggregations");
                return (string)base.ObjectData.Properties["Aggregations"];
            }
            set
            {
                base.ObjectData.Properties["Aggregations"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Aggregations", value));
                }
            }
        }

        [Remote]
        public string AggregationsStatus
        {
            get
            {
                base.CheckUninitializedProperty("AggregationsStatus");
                return (string)base.ObjectData.Properties["AggregationsStatus"];
            }
            set
            {
                base.ObjectData.Properties["AggregationsStatus"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "AggregationsStatus", value));
                }
            }
        }

        [Remote]
        public string BaseViewId
        {
            get
            {
                base.CheckUninitializedProperty("BaseViewId");
                return (string)base.ObjectData.Properties["BaseViewId"];
            }
        }

        [Remote]
        public ContentTypeId ContentTypeId
        {
            get
            {
                base.CheckUninitializedProperty("ContentTypeId");
                return (ContentTypeId)base.ObjectData.Properties["ContentTypeId"];
            }
            set
            {
                if (base.Context.ValidateOnClient && value != null && value.StringValue == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value.StringValue");
                }
                base.ObjectData.Properties["ContentTypeId"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ContentTypeId", value));
                }
            }
        }

        [Remote]
        public bool DefaultView
        {
            get
            {
                base.CheckUninitializedProperty("DefaultView");
                return (bool)base.ObjectData.Properties["DefaultView"];
            }
            set
            {
                base.ObjectData.Properties["DefaultView"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DefaultView", value));
                }
            }
        }

        [Remote]
        public bool DefaultViewForContentType
        {
            get
            {
                base.CheckUninitializedProperty("DefaultViewForContentType");
                return (bool)base.ObjectData.Properties["DefaultViewForContentType"];
            }
            set
            {
                base.ObjectData.Properties["DefaultViewForContentType"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DefaultViewForContentType", value));
                }
            }
        }

        [Remote]
        public bool EditorModified
        {
            get
            {
                base.CheckUninitializedProperty("EditorModified");
                return (bool)base.ObjectData.Properties["EditorModified"];
            }
            set
            {
                base.ObjectData.Properties["EditorModified"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EditorModified", value));
                }
            }
        }

        [Remote]
        public string Formats
        {
            get
            {
                base.CheckUninitializedProperty("Formats");
                return (string)base.ObjectData.Properties["Formats"];
            }
            set
            {
                base.ObjectData.Properties["Formats"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Formats", value));
                }
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
        public string HtmlSchemaXml
        {
            get
            {
                base.CheckUninitializedProperty("HtmlSchemaXml");
                return (string)base.ObjectData.Properties["HtmlSchemaXml"];
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
        }

        [Remote]
        public bool IncludeRootFolder
        {
            get
            {
                base.CheckUninitializedProperty("IncludeRootFolder");
                return (bool)base.ObjectData.Properties["IncludeRootFolder"];
            }
            set
            {
                base.ObjectData.Properties["IncludeRootFolder"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IncludeRootFolder", value));
                }
            }
        }

        [Remote]
        public string ViewJoins
        {
            get
            {
                base.CheckUninitializedProperty("ViewJoins");
                return (string)base.ObjectData.Properties["ViewJoins"];
            }
            set
            {
                base.ObjectData.Properties["ViewJoins"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ViewJoins", value));
                }
            }
        }

        [Remote]
        public string JSLink
        {
            get
            {
                base.CheckUninitializedProperty("JSLink");
                return (string)base.ObjectData.Properties["JSLink"];
            }
            set
            {
                base.ObjectData.Properties["JSLink"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "JSLink", value));
                }
            }
        }

        [Remote]
        public string ListViewXml
        {
            get
            {
                base.CheckUninitializedProperty("ListViewXml");
                return (string)base.ObjectData.Properties["ListViewXml"];
            }
            set
            {
                base.ObjectData.Properties["ListViewXml"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ListViewXml", value));
                }
            }
        }

        [Remote]
        public string Method
        {
            get
            {
                base.CheckUninitializedProperty("Method");
                return (string)base.ObjectData.Properties["Method"];
            }
            set
            {
                base.ObjectData.Properties["Method"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Method", value));
                }
            }
        }

        [Remote]
        public bool MobileDefaultView
        {
            get
            {
                base.CheckUninitializedProperty("MobileDefaultView");
                return (bool)base.ObjectData.Properties["MobileDefaultView"];
            }
            set
            {
                base.ObjectData.Properties["MobileDefaultView"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MobileDefaultView", value));
                }
            }
        }

        [Remote]
        public bool MobileView
        {
            get
            {
                base.CheckUninitializedProperty("MobileView");
                return (bool)base.ObjectData.Properties["MobileView"];
            }
            set
            {
                base.ObjectData.Properties["MobileView"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MobileView", value));
                }
            }
        }

        [Remote]
        public string ModerationType
        {
            get
            {
                base.CheckUninitializedProperty("ModerationType");
                return (string)base.ObjectData.Properties["ModerationType"];
            }
        }

        [Remote]
        public bool OrderedView
        {
            get
            {
                base.CheckUninitializedProperty("OrderedView");
                return (bool)base.ObjectData.Properties["OrderedView"];
            }
        }

        [Remote]
        public bool Paged
        {
            get
            {
                base.CheckUninitializedProperty("Paged");
                return (bool)base.ObjectData.Properties["Paged"];
            }
            set
            {
                base.ObjectData.Properties["Paged"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Paged", value));
                }
            }
        }

        [Remote]
        public bool PersonalView
        {
            get
            {
                base.CheckUninitializedProperty("PersonalView");
                return (bool)base.ObjectData.Properties["PersonalView"];
            }
        }

        [Remote]
        public string ViewProjectedFields
        {
            get
            {
                base.CheckUninitializedProperty("ViewProjectedFields");
                return (string)base.ObjectData.Properties["ViewProjectedFields"];
            }
            set
            {
                base.ObjectData.Properties["ViewProjectedFields"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ViewProjectedFields", value));
                }
            }
        }

        [Remote]
        public string ViewQuery
        {
            get
            {
                base.CheckUninitializedProperty("ViewQuery");
                return (string)base.ObjectData.Properties["ViewQuery"];
            }
            set
            {
                base.ObjectData.Properties["ViewQuery"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ViewQuery", value));
                }
            }
        }

        [Remote]
        public bool ReadOnlyView
        {
            get
            {
                base.CheckUninitializedProperty("ReadOnlyView");
                return (bool)base.ObjectData.Properties["ReadOnlyView"];
            }
        }

        [Remote]
        public bool RequiresClientIntegration
        {
            get
            {
                base.CheckUninitializedProperty("RequiresClientIntegration");
                return (bool)base.ObjectData.Properties["RequiresClientIntegration"];
            }
        }

        [Remote]
        public uint RowLimit
        {
            get
            {
                base.CheckUninitializedProperty("RowLimit");
                return (uint)base.ObjectData.Properties["RowLimit"];
            }
            set
            {
                if (base.Context.ValidateOnClient && value > 2147483647u)
                {
                    throw ClientUtility.CreateArgumentException("value");
                }
                base.ObjectData.Properties["RowLimit"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "RowLimit", value));
                }
            }
        }

        [Remote]
        public ViewScope Scope
        {
            get
            {
                base.CheckUninitializedProperty("Scope");
                return (ViewScope)base.ObjectData.Properties["Scope"];
            }
            set
            {
                base.ObjectData.Properties["Scope"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Scope", value));
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
        }

        [Remote]
        public string StyleId
        {
            get
            {
                base.CheckUninitializedProperty("StyleId");
                return (string)base.ObjectData.Properties["StyleId"];
            }
        }

        [Remote]
        public bool TabularView
        {
            get
            {
                base.CheckUninitializedProperty("TabularView");
                return (bool)base.ObjectData.Properties["TabularView"];
            }
            set
            {
                base.ObjectData.Properties["TabularView"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "TabularView", value));
                }
            }
        }

        [Remote]
        public bool Threaded
        {
            get
            {
                base.CheckUninitializedProperty("Threaded");
                return (bool)base.ObjectData.Properties["Threaded"];
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
        public string Toolbar
        {
            get
            {
                base.CheckUninitializedProperty("Toolbar");
                return (string)base.ObjectData.Properties["Toolbar"];
            }
            set
            {
                base.ObjectData.Properties["Toolbar"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Toolbar", value));
                }
            }
        }

        [Remote]
        public string ToolbarTemplateName
        {
            get
            {
                base.CheckUninitializedProperty("ToolbarTemplateName");
                return (string)base.ObjectData.Properties["ToolbarTemplateName"];
            }
        }

        [Remote]
        public string ViewType
        {
            get
            {
                base.CheckUninitializedProperty("ViewType");
                return (string)base.ObjectData.Properties["ViewType"];
            }
        }

        [Remote]
        public string ViewData
        {
            get
            {
                base.CheckUninitializedProperty("ViewData");
                return (string)base.ObjectData.Properties["ViewData"];
            }
            set
            {
                base.ObjectData.Properties["ViewData"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ViewData", value));
                }
            }
        }

        [Remote]
        public ViewFieldCollection ViewFields
        {
            get
            {
                object obj;
                ViewFieldCollection viewFieldCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ViewFields", out obj))
                {
                    viewFieldCollection = (ViewFieldCollection)obj;
                }
                else
                {
                    viewFieldCollection = new ViewFieldCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "ViewFields"));
                    base.ObjectData.ClientObjectProperties["ViewFields"] = viewFieldCollection;
                }
                return viewFieldCollection;
            }
        }

        [Remote]
        public Visualization VisualizationInfo
        {
            get
            {
                base.CheckUninitializedProperty("VisualizationInfo");
                return (Visualization)base.ObjectData.Properties["VisualizationInfo"];
            }
            set
            {
                base.ObjectData.Properties["VisualizationInfo"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "VisualizationInfo", value));
                }
            }
        }

        internal void InitFromCreationInformation(ViewCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Title"] = creation.Title;
                base.ObjectData.Properties["Paged"] = creation.Paged;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public View(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "Aggregations":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Aggregations"] = reader.ReadString();
                    break;
                case "AggregationsStatus":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AggregationsStatus"] = reader.ReadString();
                    break;
                case "BaseViewId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["BaseViewId"] = reader.ReadString();
                    break;
                case "ContentTypeId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ContentTypeId"] = reader.Read<ContentTypeId>();
                    break;
                case "DefaultView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultView"] = reader.ReadBoolean();
                    break;
                case "DefaultViewForContentType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultViewForContentType"] = reader.ReadBoolean();
                    break;
                case "EditorModified":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EditorModified"] = reader.ReadBoolean();
                    break;
                case "Formats":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Formats"] = reader.ReadString();
                    break;
                case "Hidden":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Hidden"] = reader.ReadBoolean();
                    break;
                case "HtmlSchemaXml":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["HtmlSchemaXml"] = reader.ReadString();
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
                case "IncludeRootFolder":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IncludeRootFolder"] = reader.ReadBoolean();
                    break;
                case "ViewJoins":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ViewJoins"] = reader.ReadString();
                    break;
                case "JSLink":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["JSLink"] = reader.ReadString();
                    break;
                case "ListViewXml":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListViewXml"] = reader.ReadString();
                    break;
                case "Method":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Method"] = reader.ReadString();
                    break;
                case "MobileDefaultView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MobileDefaultView"] = reader.ReadBoolean();
                    break;
                case "MobileView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MobileView"] = reader.ReadBoolean();
                    break;
                case "ModerationType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ModerationType"] = reader.ReadString();
                    break;
                case "OrderedView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["OrderedView"] = reader.ReadBoolean();
                    break;
                case "Paged":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Paged"] = reader.ReadBoolean();
                    break;
                case "PersonalView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PersonalView"] = reader.ReadBoolean();
                    break;
                case "ViewProjectedFields":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ViewProjectedFields"] = reader.ReadString();
                    break;
                case "ViewQuery":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ViewQuery"] = reader.ReadString();
                    break;
                case "ReadOnlyView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReadOnlyView"] = reader.ReadBoolean();
                    break;
                case "RequiresClientIntegration":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RequiresClientIntegration"] = reader.ReadBoolean();
                    break;
                case "RowLimit":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["RowLimit"] = reader.ReadUInt32();
                    break;
                case "Scope":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Scope"] = reader.ReadEnum<ViewScope>();
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
                case "StyleId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["StyleId"] = reader.ReadString();
                    break;
                case "TabularView":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TabularView"] = reader.ReadBoolean();
                    break;
                case "Threaded":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Threaded"] = reader.ReadBoolean();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                case "Toolbar":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Toolbar"] = reader.ReadString();
                    break;
                case "ToolbarTemplateName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ToolbarTemplateName"] = reader.ReadString();
                    break;
                case "ViewType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ViewType"] = reader.ReadString();
                    break;
                case "ViewData":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ViewData"] = reader.ReadString();
                    break;
                case "ViewFields":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ViewFields", this.ViewFields, reader);
                    this.ViewFields.FromJson(reader);
                    break;
                case "VisualizationInfo":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["VisualizationInfo"] = reader.Read<Visualization>();
                    break;
            }
            return flag;
        }

        [Remote]
        public ClientResult<string> RenderAsHtml()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "RenderAsHtml", null);
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
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
        public void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }
    }
}