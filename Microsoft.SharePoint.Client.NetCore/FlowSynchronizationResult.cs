using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FlowSynchronizationResult", ServerTypeId = "{d9f77691-3136-41e7-8aac-0bfc7736d842}")]
    public class FlowSynchronizationResult : ClientObject
    {
        [Remote]
        public string SynchronizationData
        {
            get
            {
                base.CheckUninitializedProperty("SynchronizationData");
                return (string)base.ObjectData.Properties["SynchronizationData"];
            }
        }

        [Remote]
        public FlowSynchronizationStatus SynchronizationStatus
        {
            get
            {
                base.CheckUninitializedProperty("SynchronizationStatus");
                return (FlowSynchronizationStatus)base.ObjectData.Properties["SynchronizationStatus"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FlowSynchronizationResult(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "SynchronizationData"))
                {
                    if (peekedName == "SynchronizationStatus")
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["SynchronizationStatus"] = reader.ReadEnum<FlowSynchronizationStatus>();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SynchronizationData"] = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
