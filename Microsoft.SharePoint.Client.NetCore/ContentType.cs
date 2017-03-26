using Microsoft.SharePoint.Client.NetCore.Runtime;
using Microsoft.SharePoint.Client.NetCore.Workflow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ContentType", ServerTypeId = "{91b5bd2d-e133-486f-b727-197ce5eb2c0d}")]
    public sealed class ContentType : ClientObject
    {
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
        public string DisplayFormTemplateName
        {
            get
            {
                base.CheckUninitializedProperty("DisplayFormTemplateName");
                return (string)base.ObjectData.Properties["DisplayFormTemplateName"];
            }
            set
            {
                base.ObjectData.Properties["DisplayFormTemplateName"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DisplayFormTemplateName", value));
                }
            }
        }

        [Remote]
        public string DisplayFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("DisplayFormUrl");
                return (string)base.ObjectData.Properties["DisplayFormUrl"];
            }
            set
            {
                base.ObjectData.Properties["DisplayFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DisplayFormUrl", value));
                }
            }
        }

        [Remote]
        public string DocumentTemplate
        {
            get
            {
                base.CheckUninitializedProperty("DocumentTemplate");
                return (string)base.ObjectData.Properties["DocumentTemplate"];
            }
            set
            {
                if (base.Context.ValidateOnClient && value == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value");
                }
                base.ObjectData.Properties["DocumentTemplate"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DocumentTemplate", value));
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
        }

        [Remote]
        public string EditFormTemplateName
        {
            get
            {
                base.CheckUninitializedProperty("EditFormTemplateName");
                return (string)base.ObjectData.Properties["EditFormTemplateName"];
            }
            set
            {
                base.ObjectData.Properties["EditFormTemplateName"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EditFormTemplateName", value));
                }
            }
        }

        [Remote]
        public string EditFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("EditFormUrl");
                return (string)base.ObjectData.Properties["EditFormUrl"];
            }
            set
            {
                base.ObjectData.Properties["EditFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EditFormUrl", value));
                }
            }
        }

        [Remote]
        public FieldLinkCollection FieldLinks
        {
            get
            {
                object obj;
                FieldLinkCollection fieldLinkCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("FieldLinks", out obj))
                {
                    fieldLinkCollection = (FieldLinkCollection)obj;
                }
                else
                {
                    fieldLinkCollection = new FieldLinkCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "FieldLinks"));
                    base.ObjectData.ClientObjectProperties["FieldLinks"] = fieldLinkCollection;
                }
                return fieldLinkCollection;
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
        public string Group
        {
            get
            {
                base.CheckUninitializedProperty("Group");
                return (string)base.ObjectData.Properties["Group"];
            }
            set
            {
                if (base.Context.ValidateOnClient)
                {
                    if (value != null && value.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                    if (value != null && value.Length > 128)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["Group"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Group", value));
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
        public ContentTypeId Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (ContentTypeId)base.ObjectData.Properties["Id"];
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
        public string MobileDisplayFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("MobileDisplayFormUrl");
                return (string)base.ObjectData.Properties["MobileDisplayFormUrl"];
            }
            set
            {
                base.ObjectData.Properties["MobileDisplayFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MobileDisplayFormUrl", value));
                }
            }
        }

        [Remote]
        public string MobileEditFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("MobileEditFormUrl");
                return (string)base.ObjectData.Properties["MobileEditFormUrl"];
            }
            set
            {
                base.ObjectData.Properties["MobileEditFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MobileEditFormUrl", value));
                }
            }
        }

        [Remote]
        public string MobileNewFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("MobileNewFormUrl");
                return (string)base.ObjectData.Properties["MobileNewFormUrl"];
            }
            set
            {
                base.ObjectData.Properties["MobileNewFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "MobileNewFormUrl", value));
                }
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
            set
            {
                if (base.Context.ValidateOnClient && value == null)
                {
                    throw ClientUtility.CreateArgumentNullException("value");
                }
                base.ObjectData.Properties["Name"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Name", value));
                }
            }
        }

        [Remote]
        public UserResource NameResource
        {
            get
            {
                object obj;
                UserResource userResource;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("NameResource", out obj))
                {
                    userResource = (UserResource)obj;
                }
                else
                {
                    userResource = new UserResource(base.Context, new ObjectPathProperty(base.Context, base.Path, "NameResource"));
                    base.ObjectData.ClientObjectProperties["NameResource"] = userResource;
                }
                return userResource;
            }
        }

        [Remote]
        public string NewFormTemplateName
        {
            get
            {
                base.CheckUninitializedProperty("NewFormTemplateName");
                return (string)base.ObjectData.Properties["NewFormTemplateName"];
            }
            set
            {
                base.ObjectData.Properties["NewFormTemplateName"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "NewFormTemplateName", value));
                }
            }
        }

        [Remote]
        public string NewFormUrl
        {
            get
            {
                base.CheckUninitializedProperty("NewFormUrl");
                return (string)base.ObjectData.Properties["NewFormUrl"];
            }
            set
            {
                base.ObjectData.Properties["NewFormUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "NewFormUrl", value));
                }
            }
        }

        [Remote]
        public ContentType Parent
        {
            get
            {
                object obj;
                ContentType contentType;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Parent", out obj))
                {
                    contentType = (ContentType)obj;
                }
                else
                {
                    contentType = new ContentType(base.Context, new ObjectPathProperty(base.Context, base.Path, "Parent"));
                    base.ObjectData.ClientObjectProperties["Parent"] = contentType;
                }
                return contentType;
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
            set
            {
                base.ObjectData.Properties["ReadOnly"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ReadOnly", value));
                }
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
        public string SchemaXmlWithResourceTokens
        {
            get
            {
                base.CheckUninitializedProperty("SchemaXmlWithResourceTokens");
                return (string)base.ObjectData.Properties["SchemaXmlWithResourceTokens"];
            }
            set
            {
                base.ObjectData.Properties["SchemaXmlWithResourceTokens"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "SchemaXmlWithResourceTokens", value));
                }
            }
        }

        [Remote]
        public string Scope
        {
            get
            {
                base.CheckUninitializedProperty("Scope");
                return (string)base.ObjectData.Properties["Scope"];
            }
        }

        [Remote]
        public bool Sealed
        {
            get
            {
                base.CheckUninitializedProperty("Sealed");
                return (bool)base.ObjectData.Properties["Sealed"];
            }
            set
            {
                base.ObjectData.Properties["Sealed"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Sealed", value));
                }
            }
        }

        [Remote]
        public string StringId
        {
            get
            {
                base.CheckUninitializedProperty("StringId");
                return (string)base.ObjectData.Properties["StringId"];
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

        internal void InitFromCreationInformation(ContentTypeCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Description"] = creation.Description;
                base.ObjectData.Properties["Group"] = creation.Group;
                base.ObjectData.Properties["Name"] = creation.Name;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ContentType(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "DisplayFormTemplateName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisplayFormTemplateName"] = reader.ReadString();
                    break;
                case "DisplayFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DisplayFormUrl"] = reader.ReadString();
                    break;
                case "DocumentTemplate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DocumentTemplate"] = reader.ReadString();
                    break;
                case "DocumentTemplateUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DocumentTemplateUrl"] = reader.ReadString();
                    break;
                case "EditFormTemplateName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EditFormTemplateName"] = reader.ReadString();
                    break;
                case "EditFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EditFormUrl"] = reader.ReadString();
                    break;
                case "FieldLinks":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("FieldLinks", this.FieldLinks, reader);
                    this.FieldLinks.FromJson(reader);
                    break;
                case "Fields":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Fields", this.Fields, reader);
                    this.Fields.FromJson(reader);
                    break;
                case "Group":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Group"] = reader.ReadString();
                    break;
                case "Hidden":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Hidden"] = reader.ReadBoolean();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.Read<ContentTypeId>();
                    break;
                case "JSLink":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["JSLink"] = reader.ReadString();
                    break;
                case "MobileDisplayFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MobileDisplayFormUrl"] = reader.ReadString();
                    break;
                case "MobileEditFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MobileEditFormUrl"] = reader.ReadString();
                    break;
                case "MobileNewFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MobileNewFormUrl"] = reader.ReadString();
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "NameResource":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("NameResource", this.NameResource, reader);
                    this.NameResource.FromJson(reader);
                    break;
                case "NewFormTemplateName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NewFormTemplateName"] = reader.ReadString();
                    break;
                case "NewFormUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NewFormUrl"] = reader.ReadString();
                    break;
                case "Parent":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Parent", this.Parent, reader);
                    this.Parent.FromJson(reader);
                    break;
                case "ReadOnly":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReadOnly"] = reader.ReadBoolean();
                    break;
                case "SchemaXml":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SchemaXml"] = reader.ReadString();
                    break;
                case "SchemaXmlWithResourceTokens":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SchemaXmlWithResourceTokens"] = reader.ReadString();
                    break;
                case "Scope":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Scope"] = reader.ReadString();
                    break;
                case "Sealed":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Sealed"] = reader.ReadBoolean();
                    break;
                case "StringId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["StringId"] = reader.ReadString();
                    break;
                case "WorkflowAssociations":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("WorkflowAssociations", this.WorkflowAssociations, reader);
                    this.WorkflowAssociations.FromJson(reader);
                    break;
            }
            return flag;
        }

        [Remote]
        public void Update(bool updateChildren)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", new object[]
            {
                updateChildren
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
    }
}