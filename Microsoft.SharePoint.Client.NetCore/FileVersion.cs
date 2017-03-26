using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FileVersion", ServerTypeId = "{96e4bc1b-e67f-4967-9327-36b79e20aebc}")]
    public class FileVersion : ClientObject
    {
        [Remote]
        public string CheckInComment
        {
            get
            {
                base.CheckUninitializedProperty("CheckInComment");
                return (string)base.ObjectData.Properties["CheckInComment"];
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
        public User CreatedBy
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("CreatedBy", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "CreatedBy"));
                    base.ObjectData.ClientObjectProperties["CreatedBy"] = user;
                }
                return user;
            }
        }

        [Remote]
        public int ID
        {
            get
            {
                base.CheckUninitializedProperty("ID");
                return (int)base.ObjectData.Properties["ID"];
            }
        }

        [Remote]
        public bool IsCurrentVersion
        {
            get
            {
                base.CheckUninitializedProperty("IsCurrentVersion");
                return (bool)base.ObjectData.Properties["IsCurrentVersion"];
            }
        }

        [Remote]
        public long Length
        {
            get
            {
                base.CheckUninitializedProperty("Length");
                return (long)base.ObjectData.Properties["Length"];
            }
        }

        [Remote]
        public int Size
        {
            get
            {
                base.CheckUninitializedProperty("Size");
                return (int)base.ObjectData.Properties["Size"];
            }
        }

        [Remote]
        public string Url
        {
            get
            {
                base.CheckUninitializedProperty("Url");
                return (string)base.ObjectData.Properties["Url"];
            }
        }

        [Remote]
        public string VersionLabel
        {
            get
            {
                base.CheckUninitializedProperty("VersionLabel");
                return (string)base.ObjectData.Properties["VersionLabel"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileVersion(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "CheckInComment":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CheckInComment"] = reader.ReadString();
                    break;
                case "Created":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Created"] = reader.ReadDateTime();
                    break;
                case "CreatedBy":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("CreatedBy", this.CreatedBy, reader);
                    this.CreatedBy.FromJson(reader);
                    break;
                case "ID":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ID"] = reader.ReadInt32();
                    break;
                case "IsCurrentVersion":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsCurrentVersion"] = reader.ReadBoolean();
                    break;
                case "Length":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Length"] = reader.ReadInt64();
                    break;
                case "Size":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Size"] = reader.ReadInt32();
                    break;
                case "Url":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Url"] = reader.ReadString();
                    break;
                case "VersionLabel":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["VersionLabel"] = reader.ReadString();
                    break;
            }
            return flag;
        }

        [Remote]
        public ClientResult<Stream> OpenBinaryStream()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "OpenBinaryStream", null);
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }
    }
}
