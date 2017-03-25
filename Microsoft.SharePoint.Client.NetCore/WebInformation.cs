using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.WebInformation", ServerTypeId = "{f847686b-8e42-401c-88e4-b5ed4261a788}")]
    public class WebInformation : ClientObject
    {
        [Remote]
        public short Configuration
        {
            get
            {
                base.CheckUninitializedProperty("Configuration");
                return (short)base.ObjectData.Properties["Configuration"];
            }
        }

        [Remote]
        public DateTime Created
        {
            get
            {
                base.CheckUninitializedProperty("Created");
                return (DateTime)base.ObjectData.Properties["Created"];
            }
        }

        [Remote]
        public string Description
        {
            get
            {
                base.CheckUninitializedProperty("Description");
                return (string)base.ObjectData.Properties["Description"];
            }
        }

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
        public uint Language
        {
            get
            {
                base.CheckUninitializedProperty("Language");
                return (uint)base.ObjectData.Properties["Language"];
            }
        }

        [Remote]
        public DateTime LastItemModifiedDate
        {
            get
            {
                base.CheckUninitializedProperty("LastItemModifiedDate");
                return (DateTime)base.ObjectData.Properties["LastItemModifiedDate"];
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
        public string Title
        {
            get
            {
                base.CheckUninitializedProperty("Title");
                return (string)base.ObjectData.Properties["Title"];
            }
        }

        [Remote]
        public string WebTemplate
        {
            get
            {
                base.CheckUninitializedProperty("WebTemplate");
                return (string)base.ObjectData.Properties["WebTemplate"];
            }
        }

        [Remote]
        public int WebTemplateId
        {
            get
            {
                base.CheckUninitializedProperty("WebTemplateId");
                return (int)base.ObjectData.Properties["WebTemplateId"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebInformation(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            switch (peekedName)
            {
                case "Configuration":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Configuration"] = reader.ReadInt16();
                    break;
                case "Created":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Created"] = reader.ReadDateTime();
                    break;
                case "Description":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Description"] = reader.ReadString();
                    break;
                case "Id":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Id"] = reader.ReadGuid();
                    break;
                case "Language":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Language"] = reader.ReadUInt32();
                    break;
                case "LastItemModifiedDate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LastItemModifiedDate"] = reader.ReadDateTime();
                    break;
                case "ServerRelativeUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerRelativeUrl"] = reader.ReadString();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                case "WebTemplate":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["WebTemplate"] = reader.ReadString();
                    break;
                case "WebTemplateId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["WebTemplateId"] = reader.ReadInt32();
                    break;
            }
            return flag;
        }
    }
}