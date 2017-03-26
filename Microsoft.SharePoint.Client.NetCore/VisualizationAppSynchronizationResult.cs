using Microsoft.SharePoint.Client.NetCore.Runtime;
using System.ComponentModel;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.VisualizationAppSynchronizationResult", ServerTypeId = "{ce91befa-b1c4-459e-bac5-18ceb35e037c}")]
    public class VisualizationAppSynchronizationResult : ClientObject
    {
        [Remote]
        public VisualizationAppMappedViewCollection AppMappedViews
        {
            get
            {
                object obj;
                VisualizationAppMappedViewCollection visualizationAppMappedViewCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("AppMappedViews", out obj))
                {
                    visualizationAppMappedViewCollection = (VisualizationAppMappedViewCollection)obj;
                }
                else
                {
                    visualizationAppMappedViewCollection = new VisualizationAppMappedViewCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "AppMappedViews"));
                    base.ObjectData.ClientObjectProperties["AppMappedViews"] = visualizationAppMappedViewCollection;
                }
                return visualizationAppMappedViewCollection;
            }
        }

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
        public VisualizationAppSynchronizationStatus SynchronizationStatus
        {
            get
            {
                base.CheckUninitializedProperty("SynchronizationStatus");
                return (VisualizationAppSynchronizationStatus)base.ObjectData.Properties["SynchronizationStatus"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public VisualizationAppSynchronizationResult(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "AppMappedViews"))
                {
                    if (!(peekedName == "SynchronizationData"))
                    {
                        if (peekedName == "SynchronizationStatus")
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["SynchronizationStatus"] = reader.ReadEnum<VisualizationAppSynchronizationStatus>();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["SynchronizationData"] = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("AppMappedViews", this.AppMappedViews, reader);
                    this.AppMappedViews.FromJson(reader);
                }
            }
            return flag;
        }
    }
}