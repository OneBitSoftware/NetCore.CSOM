using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.Collections.Generic;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.ListItemCollection", ServerTypeId = "{1722df25-a4d3-44bb-a1c6-04dbb90e9d91}")]
    public class ListItemCollection : ClientObjectCollection<ListItem>
    {
        [Remote]
        public ListItemCollectionPosition ListItemCollectionPosition
        {
            get
            {
                base.CheckUninitializedProperty("ListItemCollectionPosition");
                return (ListItemCollectionPosition)base.ObjectData.Properties["ListItemCollectionPosition"];
            }
        }

        public ListItem GetById(string id)
        {
            return this.GetByStringId(id);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public ListItemCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            if (peekedName != null && peekedName == "ListItemCollectionPosition")
            {
                flag = true;
                reader.ReadName();
                base.ObjectData.Properties["ListItemCollectionPosition"] = reader.Read<ListItemCollectionPosition>();
            }
            return flag;
        }

        [Remote]
        public ListItem GetById(int id)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<int, ListItem> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<int, ListItem>)obj;
            }
            else
            {
                dictionary = new Dictionary<int, ListItem>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            ListItem listItem = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(id, out listItem))
            {
                return listItem;
            }
            listItem = new ListItem(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[id] = listItem;
            }
            return listItem;
        }

        [Remote]
        internal ListItem GetByStringId(string sId)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<string, ListItem> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByStringId", out obj))
            {
                dictionary = (Dictionary<string, ListItem>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, ListItem>();
                base.ObjectData.MethodReturnObjects["GetByStringId"] = dictionary;
            }
            ListItem listItem = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(sId, out listItem))
            {
                return listItem;
            }
            listItem = new ListItem(context, new ObjectPathMethod(context, base.Path, "GetByStringId", new object[]
            {
                sId
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[sId] = listItem;
            }
            return listItem;
        }
    }
}
