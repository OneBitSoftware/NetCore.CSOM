using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ViewFieldCollection", ServerTypeId = "{af975f76-8a94-4e6d-8325-bd1e20b7c301}")]
    public class ViewFieldCollection : ClientObjectCollection<string>
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

        private void OnAdd(string fieldName)
        {
            base.Data.Add(fieldName);
        }

        private void OnRemove(string fieldName)
        {
            base.Data.Remove(fieldName);
        }

        private void OnRemoveAll()
        {
            List<object> data = base.Data;
            while (data.Count > 0)
            {
                data.RemoveAt(data.Count - 1);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ViewFieldCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
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
        public void MoveFieldTo(string field, int index)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (field == null)
                {
                    throw ClientUtility.CreateArgumentNullException("field");
                }
                if (index < 0)
                {
                    throw ClientUtility.CreateArgumentException("index");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "MoveFieldTo", new object[]
            {
                field,
                index
            });
            context.AddQuery(query);
        }

        [Remote]
        public void Add(string strField)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && strField == null)
            {
                throw ClientUtility.CreateArgumentNullException("strField");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "Add", new object[]
            {
                strField
            });
            context.AddQuery(query);
            this.OnAdd(strField);
        }

        [Remote]
        public void Remove(string strField)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && strField == null)
            {
                throw ClientUtility.CreateArgumentNullException("strField");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "Remove", new object[]
            {
                strField
            });
            context.AddQuery(query);
            this.OnRemove(strField);
        }

        [Remote]
        public void RemoveAll()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RemoveAll", null);
            context.AddQuery(query);
            this.OnRemoveAll();
        }
    }
}
