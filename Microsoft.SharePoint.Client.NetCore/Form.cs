using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Form", ServerTypeId = "{50aaca3c-fa54-47d2-b946-a2839ee956a9}")]
    public class Form : ClientObject
    {
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
        public ResourcePath ResourcePath
        {
            get
            {
                base.CheckUninitializedProperty("ResourcePath");
                return (ResourcePath)base.ObjectData.Properties["ResourcePath"];
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

        [Remote]
        public PageType FormType
        {
            get
            {
                base.CheckUninitializedProperty("FormType");
                return (PageType)base.ObjectData.Properties["FormType"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Form(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "Id"))
                {
                    if (!(peekedName == "ResourcePath"))
                    {
                        if (!(peekedName == "ServerRelativeUrl"))
                        {
                            if (peekedName == "FormType")
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["FormType"] = reader.ReadEnum<PageType>();
                            }
                        }
                        else
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
                        base.ObjectData.Properties["ResourcePath"] = reader.Read<ResourcePath>();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                }
            }
            return flag;
        }
    }
}
