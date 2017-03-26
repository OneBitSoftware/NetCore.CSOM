using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Field", ServerTypeId = "{c4121b04-0f57-4b1d-a145-d25426b16480}")]
    public class Field : ClientObject
    {
        [Remote]
        public bool AutoIndexed
        {
            get
            {
                base.CheckUninitializedProperty("AutoIndexed");
                return (bool)base.ObjectData.Properties["AutoIndexed"];
            }
        }

        [Remote]
        public bool CanBeDeleted
        {
            get
            {
                base.CheckUninitializedProperty("CanBeDeleted");
                return (bool)base.ObjectData.Properties["CanBeDeleted"];
            }
        }

        [Remote]
        public Guid ClientSideComponentId
        {
            get
            {
                base.CheckUninitializedProperty("ClientSideComponentId");
                return (Guid)base.ObjectData.Properties["ClientSideComponentId"];
            }
            set
            {
                base.ObjectData.Properties["ClientSideComponentId"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ClientSideComponentId", value));
                }
            }
        }

        [Remote]
        public string DefaultValue
        {
            get
            {
                base.CheckUninitializedProperty("DefaultValue");
                return (string)base.ObjectData.Properties["DefaultValue"];
            }
            set
            {
                base.ObjectData.Properties["DefaultValue"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "DefaultValue", value));
                }
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
        public bool EnforceUniqueValues
        {
            get
            {
                base.CheckUninitializedProperty("EnforceUniqueValues");
                return (bool)base.ObjectData.Properties["EnforceUniqueValues"];
            }
            set
            {
                base.ObjectData.Properties["EnforceUniqueValues"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "EnforceUniqueValues", value));
                }
            }
        }

        [Remote]
        public string EntityPropertyName
        {
            get
            {
                base.CheckUninitializedProperty("EntityPropertyName");
                return (string)base.ObjectData.Properties["EntityPropertyName"];
            }
        }

        [Remote]
        public bool Filterable
        {
            get
            {
                base.CheckUninitializedProperty("Filterable");
                return (bool)base.ObjectData.Properties["Filterable"];
            }
        }

        [Remote]
        public bool FromBaseType
        {
            get
            {
                base.CheckUninitializedProperty("FromBaseType");
                return (bool)base.ObjectData.Properties["FromBaseType"];
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
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
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
        public Guid Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (Guid)base.ObjectData.Properties["Id"];
            }
        }

        [Remote]
        public bool Indexed
        {
            get
            {
                base.CheckUninitializedProperty("Indexed");
                return (bool)base.ObjectData.Properties["Indexed"];
            }
            set
            {
                base.ObjectData.Properties["Indexed"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Indexed", value));
                }
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
        public bool PinnedToFiltersPane
        {
            get
            {
                base.CheckUninitializedProperty("PinnedToFiltersPane");
                return (bool)base.ObjectData.Properties["PinnedToFiltersPane"];
            }
            set
            {
                base.ObjectData.Properties["PinnedToFiltersPane"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "PinnedToFiltersPane", value));
                }
            }
        }

        [Remote]
        public bool ReadOnlyField
        {
            get
            {
                base.CheckUninitializedProperty("ReadOnlyField");
                return (bool)base.ObjectData.Properties["ReadOnlyField"];
            }
            set
            {
                base.ObjectData.Properties["ReadOnlyField"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ReadOnlyField", value));
                }
            }
        }

        [Remote]
        public bool Required
        {
            get
            {
                base.CheckUninitializedProperty("Required");
                return (bool)base.ObjectData.Properties["Required"];
            }
            set
            {
                base.ObjectData.Properties["Required"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Required", value));
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
            set
            {
                base.ObjectData.Properties["SchemaXml"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "SchemaXml", value));
                }
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
        public bool Sortable
        {
            get
            {
                base.CheckUninitializedProperty("Sortable");
                return (bool)base.ObjectData.Properties["Sortable"];
            }
        }

        [Remote]
        public string StaticName
        {
            get
            {
                base.CheckUninitializedProperty("StaticName");
                return (string)base.ObjectData.Properties["StaticName"];
            }
            set
            {
                base.ObjectData.Properties["StaticName"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "StaticName", value));
                }
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
        public FieldType FieldTypeKind
        {
            get
            {
                base.CheckUninitializedProperty("FieldTypeKind");
                return (FieldType)base.ObjectData.Properties["FieldTypeKind"];
            }
            set
            {
                base.ObjectData.Properties["FieldTypeKind"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "FieldTypeKind", value));
                }
            }
        }

        [Remote]
        public string TypeAsString
        {
            get
            {
                base.CheckUninitializedProperty("TypeAsString");
                return (string)base.ObjectData.Properties["TypeAsString"];
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
                base.ObjectData.Properties["TypeAsString"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "TypeAsString", value));
                }
            }
        }

        [Remote]
        public string TypeDisplayName
        {
            get
            {
                base.CheckUninitializedProperty("TypeDisplayName");
                return (string)base.ObjectData.Properties["TypeDisplayName"];
            }
        }

        [Remote]
        public string TypeShortDescription
        {
            get
            {
                base.CheckUninitializedProperty("TypeShortDescription");
                return (string)base.ObjectData.Properties["TypeShortDescription"];
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
                if (base.Context.ValidateOnClient && value != null && value.Length > 1024)
                {
                    throw ClientUtility.CreateArgumentException("value");
                }
                base.ObjectData.Properties["ValidationMessage"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ValidationMessage", value));
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Field(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "AutoIndexed":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AutoIndexed"] = reader.ReadBoolean();
                    break;
                case "CanBeDeleted":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CanBeDeleted"] = reader.ReadBoolean();
                    break;
                case "ClientSideComponentId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ClientSideComponentId"] = reader.ReadGuid();
                    break;
                case "DefaultValue":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["DefaultValue"] = reader.ReadString();
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
                case "EnforceUniqueValues":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EnforceUniqueValues"] = reader.ReadBoolean();
                    break;
                case "EntityPropertyName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["EntityPropertyName"] = reader.ReadString();
                    break;
                case "Filterable":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Filterable"] = reader.ReadBoolean();
                    break;
                case "FromBaseType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["FromBaseType"] = reader.ReadBoolean();
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
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "Indexed":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Indexed"] = reader.ReadBoolean();
                    break;
                case "InternalName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["InternalName"] = reader.ReadString();
                    break;
                case "JSLink":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["JSLink"] = reader.ReadString();
                    break;
                case "NoCrawl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["NoCrawl"] = reader.ReadBoolean();
                    break;
                case "PinnedToFiltersPane":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PinnedToFiltersPane"] = reader.ReadBoolean();
                    break;
                case "ReadOnlyField":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ReadOnlyField"] = reader.ReadBoolean();
                    break;
                case "Required":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Required"] = reader.ReadBoolean();
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
                case "Sortable":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Sortable"] = reader.ReadBoolean();
                    break;
                case "StaticName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["StaticName"] = reader.ReadString();
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
                case "FieldTypeKind":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["FieldTypeKind"] = reader.ReadEnum<FieldType>();
                    break;
                case "TypeAsString":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TypeAsString"] = reader.ReadString();
                    break;
                case "TypeDisplayName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TypeDisplayName"] = reader.ReadString();
                    break;
                case "TypeShortDescription":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TypeShortDescription"] = reader.ReadString();
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
            }
            return flag;
        }

        [Remote]
        public void ValidateSetValue(ListItem item, string value)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && item == null)
            {
                throw ClientUtility.CreateArgumentNullException("item");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "ValidateSetValue", new object[]
            {
                item,
                value
            });
            context.AddQuery(query);
        }

        [Remote]
        public void UpdateAndPushChanges(bool pushChangesToLists)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "UpdateAndPushChanges", new object[]
            {
                pushChangesToLists
            });
            context.AddQuery(query);
        }

        [Remote]
        public virtual void Update()
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

        [Remote]
        public void SetShowInDisplayForm(bool value)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SetShowInDisplayForm", new object[]
            {
                value
            });
            context.AddQuery(query);
        }

        [Remote]
        public void SetShowInEditForm(bool value)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SetShowInEditForm", new object[]
            {
                value
            });
            context.AddQuery(query);
        }

        [Remote]
        public void SetShowInNewForm(bool value)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "SetShowInNewForm", new object[]
            {
                value
            });
            context.AddQuery(query);
        }
    }
}
