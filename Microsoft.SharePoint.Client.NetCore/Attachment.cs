using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Attachment", ServerTypeId = "{abd102de-1731-4be2-ae7e-3515371cc5c7}")]
    public sealed class Attachment : ClientObject
    {
        [Remote]
        public string FileName
        {
            get
            {
                base.CheckUninitializedProperty("FileName");
                return (string)base.ObjectData.Properties["FileName"];
            }
        }

        [Remote]
        public ResourcePath FileNameAsPath
        {
            get
            {
                base.CheckUninitializedProperty("FileNameAsPath");
                return (ResourcePath)base.ObjectData.Properties["FileNameAsPath"];
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Attachment(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "FileName"))
                {
                    if (!(peekedName == "FileNameAsPath"))
                    {
                        if (!(peekedName == "ServerRelativePath"))
                        {
                            if (peekedName == "ServerRelativeUrl")
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["ServerRelativeUrl"] = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["ServerRelativePath"] = reader.Read<ResourcePath>();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["FileNameAsPath"] = reader.Read<ResourcePath>();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["FileName"] = reader.ReadString();
                }
            }
            return flag;
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
        public void RecycleObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RecycleObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }
    }
}
