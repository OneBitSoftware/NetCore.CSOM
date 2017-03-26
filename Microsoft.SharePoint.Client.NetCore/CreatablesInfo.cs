using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.CreatablesInfo", ServerTypeId = "{9ec9b742-583b-4a15-b1e8-23c8e0d7b6df}")]
    public sealed class CreatablesInfo : ClientObject
    {
        [Remote]
        public bool CanCreateFolders
        {
            get
            {
                base.CheckUninitializedProperty("CanCreateFolders");
                return (bool)base.ObjectData.Properties["CanCreateFolders"];
            }
        }

        [Remote]
        public bool CanCreateItems
        {
            get
            {
                base.CheckUninitializedProperty("CanCreateItems");
                return (bool)base.ObjectData.Properties["CanCreateItems"];
            }
        }

        [Remote]
        public bool CanUploadFiles
        {
            get
            {
                base.CheckUninitializedProperty("CanUploadFiles");
                return (bool)base.ObjectData.Properties["CanUploadFiles"];
            }
        }

        [Remote]
        public CreatableItemInfoCollection CreatablesCollection
        {
            get
            {
                base.CheckUninitializedProperty("CreatablesCollection");
                return (CreatableItemInfoCollection)base.ObjectData.Properties["CreatablesCollection"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CreatablesInfo(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "CanCreateFolders"))
                {
                    if (!(peekedName == "CanCreateItems"))
                    {
                        if (!(peekedName == "CanUploadFiles"))
                        {
                            if (peekedName == "CreatablesCollection")
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["CreatablesCollection"] = reader.Read<CreatableItemInfoCollection>();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["CanUploadFiles"] = reader.ReadBoolean();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["CanCreateItems"] = reader.ReadBoolean();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CanCreateFolders"] = reader.ReadBoolean();
                }
            }
            return flag;
        }
    }
}
