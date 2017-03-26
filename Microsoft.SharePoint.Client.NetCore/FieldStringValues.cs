using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FieldStringValues", ServerTypeId = "{542fa9df-ac22-4fdb-8ba3-dab6060c2de4}")]
    public class FieldStringValues : ClientObject
    {
        public Dictionary<string, string> FieldValues
        {
            get
            {
                Dictionary<string, string> dictionary = null;
                object obj = null;
                if (base.ObjectData.MethodReturnObjects.TryGetValue("$m_dict", out obj))
                {
                    dictionary = (obj as Dictionary<string, string>);
                }
                if (dictionary == null)
                {
                    dictionary = new Dictionary<string, string>();
                    base.ObjectData.MethodReturnObjects["$m_dict"] = dictionary;
                }
                return dictionary;
            }
        }

        public string this[string fieldName]
        {
            [PseudoRemote(Name = "GetFieldValue")]
            get
            {
                return this.GetFieldValue(fieldName);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FieldStringValues(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override void InitNonPropertyFieldFromJson(string peekedName, JsonReader reader)
        {
            KeyValuePair<string, object> keyValuePair = reader.ReadKeyValue();
            this.FieldValues[keyValuePair.Key] = (string)keyValuePair.Value;
        }

        [PseudoRemote]
        internal string GetFieldValue(string fieldName)
        {
            string result = null;
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
    }
}