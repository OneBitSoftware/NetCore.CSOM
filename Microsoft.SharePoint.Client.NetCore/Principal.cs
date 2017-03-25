using Microsoft.SharePoint.Client.NetCore.Runtime;
using Microsoft.SharePoint.Client.NetCoreUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Principal", ServerTypeId = "{8a76e712-17a1-4a40-b2df-cca7c060d78f}")]
    public class Principal : ClientObject
    {
        [Remote]
        public int Id
        {
            get
            {
                base.CheckUninitializedProperty("Id");
                return (int)base.ObjectData.Properties["Id"];
            }
        }

        [Remote]
        public bool IsHiddenInUI
        {
            get
            {
                base.CheckUninitializedProperty("IsHiddenInUI");
                return (bool)base.ObjectData.Properties["IsHiddenInUI"];
            }
        }

        [Remote]
        public string LoginName
        {
            get
            {
                base.CheckUninitializedProperty("LoginName");
                return (string)base.ObjectData.Properties["LoginName"];
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
                if (base.Context.ValidateOnClient)
                {
                    if (value == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("value");
                    }
                    if (value != null && value.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("value");
                    }
                }
                base.ObjectData.Properties["Title"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Title", value));
                }
            }
        }

        [Remote]
        public PrincipalType PrincipalType
        {
            get
            {
                base.CheckUninitializedProperty("PrincipalType");
                return (PrincipalType)base.ObjectData.Properties["PrincipalType"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Principal(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                    if (!(peekedName == "IsHiddenInUI"))
                    {
                        if (!(peekedName == "LoginName"))
                        {
                            if (!(peekedName == "Title"))
                            {
                                if (peekedName == "PrincipalType")
                                {
                                    flag = true;
                                    reader.ReadName();
                                    base.ObjectData.Properties["PrincipalType"] = reader.ReadEnum<PrincipalType>();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["Title"] = reader.ReadString();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["LoginName"] = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["IsHiddenInUI"] = reader.ReadBoolean();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadInt32();
                }
            }
            return flag;
        }
    }
}
