using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.RelatedField", ServerTypeId = "{a91deb1a-2f24-4ac5-a1a6-3b1e530c307f}")]
    public class RelatedField : ClientObject
    {
        [Remote]
        public Guid FieldId
        {
            get
            {
                base.CheckUninitializedProperty("FieldId");
                return (Guid)base.ObjectData.Properties["FieldId"];
            }
        }

        [Remote]
        public Guid ListId
        {
            get
            {
                base.CheckUninitializedProperty("ListId");
                return (Guid)base.ObjectData.Properties["ListId"];
            }
        }

        [Remote]
        public List LookupList
        {
            get
            {
                object obj;
                List list;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("LookupList", out obj))
                {
                    list = (List)obj;
                }
                else
                {
                    list = new List(base.Context, new ObjectPathProperty(base.Context, base.Path, "LookupList"));
                    base.ObjectData.ClientObjectProperties["LookupList"] = list;
                }
                return list;
            }
        }

        [Remote]
        public RelationshipDeleteBehaviorType RelationshipDeleteBehavior
        {
            get
            {
                base.CheckUninitializedProperty("RelationshipDeleteBehavior");
                return (RelationshipDeleteBehaviorType)base.ObjectData.Properties["RelationshipDeleteBehavior"];
            }
        }

        [Remote]
        public Guid WebId
        {
            get
            {
                base.CheckUninitializedProperty("WebId");
                return (Guid)base.ObjectData.Properties["WebId"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RelatedField(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            if (peekedName != null)
            {
                if (!(peekedName == "FieldId"))
                {
                    if (!(peekedName == "ListId"))
                    {
                        if (!(peekedName == "LookupList"))
                        {
                            if (!(peekedName == "RelationshipDeleteBehavior"))
                            {
                                if (peekedName == "WebId")
                                {
                                    flag = true;
                                    reader.ReadName();
                                    base.ObjectData.Properties["WebId"] = reader.ReadGuid();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["RelationshipDeleteBehavior"] = reader.ReadEnum<RelationshipDeleteBehaviorType>();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.UpdateClientObjectPropertyType("LookupList", this.LookupList, reader);
                            this.LookupList.FromJson(reader);
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["ListId"] = reader.ReadGuid();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["FieldId"] = reader.ReadGuid();
                }
            }
            return flag;
        }
    }
}
