using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FieldCollection", ServerTypeId = "{d449d756-e113-4d27-a5e7-609cbc3eba7e}")]
    public class FieldCollection : ClientObjectCollection<Field>
    {
        [Remote]
        public string SchemaXml
        {
            get
            {
                base.CheckUninitializedProperty("SchemaXml");
                return (string)base.ObjectData.Properties["SchemaXml"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FieldCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public Field GetByTitle(string title)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (title == null)
                {
                    throw ClientUtility.CreateArgumentNullException("title");
                }
                if (title != null && title.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("title");
                }
            }
            object obj;
            Dictionary<string, Field> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByTitle", out obj))
            {
                dictionary = (Dictionary<string, Field>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, Field>();
                base.ObjectData.MethodReturnObjects["GetByTitle"] = dictionary;
            }
            Field field = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(title, out field))
            {
                return field;
            }
            field = new Field(context, new ObjectPathMethod(context, base.Path, "GetByTitle", new object[]
            {
                title
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[title] = field;
            }
            return field;
        }

        [Remote]
        public Field GetById(Guid id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<Guid, Field> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<Guid, Field>)obj;
            }
            else
            {
                dictionary = new Dictionary<Guid, Field>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            Field field = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out field))
            {
                return field;
            }
            field = new Field(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = field;
            }
            return field;
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            if (peekedName != null && peekedName == "SchemaXml")
            {
                flag = true;
                reader.ReadName();
                base.ObjectData.Properties["SchemaXml"] = reader.ReadString();
            }
            return flag;
        }

        [Remote]
        public Field Add(Field field)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && field == null)
            {
                throw ClientUtility.CreateArgumentNullException("field");
            }
            Field field2 = new Field(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                field
            }));
            field2.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(field2.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, field2);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(field2);
            return field2;
        }

        [Remote]
        public Field AddDependentLookup(string displayName, Field primaryLookupField, string lookupField)
        {
            ClientRuntimeContext context = base.Context;
            Field field = new Field(context, new ObjectPathMethod(context, base.Path, "AddDependentLookup", new object[]
            {
                displayName,
                primaryLookupField,
                lookupField
            }));
            field.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(field.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, field);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(field);
            return field;
        }

        [Remote]
        public Field AddFieldAsXml(string schemaXml, bool addToDefaultView, AddFieldOptions options)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (schemaXml == null)
                {
                    throw ClientUtility.CreateArgumentNullException("schemaXml");
                }
                if (schemaXml != null && schemaXml.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("schemaXml");
                }
            }
            Field field = new Field(context, new ObjectPathMethod(context, base.Path, "AddFieldAsXml", new object[]
            {
                schemaXml,
                addToDefaultView,
                options
            }));
            field.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(field.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, field);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(field);
            return field;
        }

        [Remote]
        public Field GetByInternalNameOrTitle(string strName)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (strName == null)
                {
                    throw ClientUtility.CreateArgumentNullException("strName");
                }
                if (strName != null && strName.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("strName");
                }
            }
            object obj;
            Dictionary<string, Field> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByInternalNameOrTitle", out obj))
            {
                dictionary = (Dictionary<string, Field>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, Field>();
                base.ObjectData.MethodReturnObjects["GetByInternalNameOrTitle"] = dictionary;
            }
            Field field = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(strName, out field))
            {
                return field;
            }
            field = new Field(context, new ObjectPathMethod(context, base.Path, "GetByInternalNameOrTitle", new object[]
            {
                strName
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[strName] = field;
            }
            return field;
        }
    }
}