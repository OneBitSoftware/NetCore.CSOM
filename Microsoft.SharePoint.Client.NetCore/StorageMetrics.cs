using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.StorageMetrics", ServerTypeId = "{33c58b88-4af3-4ef1-a310-6ba3ef255058}")]
    public class StorageMetrics : ClientObject
    {
        [Remote]
        public DateTime LastModified
        {
            get
            {
                base.CheckUninitializedProperty("LastModified");
                return (DateTime)base.ObjectData.Properties["LastModified"];
            }
        }

        [Remote]
        public long TotalFileCount
        {
            get
            {
                base.CheckUninitializedProperty("TotalFileCount");
                return (long)base.ObjectData.Properties["TotalFileCount"];
            }
        }

        [Remote]
        public long TotalFileStreamSize
        {
            get
            {
                base.CheckUninitializedProperty("TotalFileStreamSize");
                return (long)base.ObjectData.Properties["TotalFileStreamSize"];
            }
        }

        [Remote]
        public long TotalSize
        {
            get
            {
                base.CheckUninitializedProperty("TotalSize");
                return (long)base.ObjectData.Properties["TotalSize"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public StorageMetrics(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "LastModified"))
                {
                    if (!(peekedName == "TotalFileCount"))
                    {
                        if (!(peekedName == "TotalFileStreamSize"))
                        {
                            if (peekedName == "TotalSize")
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["TotalSize"] = reader.ReadInt64();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["TotalFileStreamSize"] = reader.ReadInt64();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["TotalFileCount"] = reader.ReadInt64();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LastModified"] = reader.ReadDateTime();
                }
            }
            return flag;
        }
    }
}
