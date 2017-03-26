using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Utilities
{
    [ScriptType("SP.Utilities.UploadStatus", ServerTypeId = "{b67bb458-2b47-4e3c-8a50-f7ae33a1d7d3}")]
    public class UploadStatus : ClientObject
    {
        [Remote]
        public string ExpectedContentRange
        {
            get
            {
                base.CheckUninitializedProperty("ExpectedContentRange");
                return (string)base.ObjectData.Properties["ExpectedContentRange"];
            }
        }

        [Remote]
        public DateTime ExpirationDateTime
        {
            get
            {
                base.CheckUninitializedProperty("ExpirationDateTime");
                return (DateTime)base.ObjectData.Properties["ExpirationDateTime"];
            }
            set
            {
                base.ObjectData.Properties["ExpirationDateTime"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ExpirationDateTime", value));
                }
            }
        }

        [Remote]
        public Guid UploadId
        {
            get
            {
                base.CheckUninitializedProperty("UploadId");
                return (Guid)base.ObjectData.Properties["UploadId"];
            }
            set
            {
                base.ObjectData.Properties["UploadId"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "UploadId", value));
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public UploadStatus(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "ExpectedContentRange"))
                {
                    if (!(peekedName == "ExpirationDateTime"))
                    {
                        if (peekedName == "UploadId")
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["UploadId"] = reader.ReadGuid();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["ExpirationDateTime"] = reader.ReadDateTime();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ExpectedContentRange"] = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
