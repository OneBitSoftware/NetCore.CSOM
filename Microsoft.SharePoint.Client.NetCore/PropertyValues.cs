using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.PropertyValues", ServerTypeId = "{3973524d-2d5a-4683-aa39-38a2acc6e63c}")]
    public class PropertyValues : ClientObject
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyValues(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override void InitNonPropertyFieldFromJson(string peekedName, JsonReader reader)
        {
            KeyValuePair<string, object> keyValuePair = reader.ReadKeyValue();
            this.FieldValues[keyValuePair.Key] = keyValuePair.Value;
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
        internal virtual void SetFieldValue(string fieldName, object value)
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
    }
}
