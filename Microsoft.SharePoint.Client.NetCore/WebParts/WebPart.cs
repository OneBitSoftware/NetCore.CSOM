using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.WebParts
{
    [ScriptType("SP.WebParts.WebPart", ServerTypeId = "{612a6bd9-6c99-43c9-813a-8d7e19702118}")]
    public class WebPart : ClientObject
    {
        [Remote]
        public WebPartExportMode ExportMode
        {
            get
            {
                base.CheckUninitializedProperty("ExportMode");
                return (WebPartExportMode)base.ObjectData.Properties["ExportMode"];
            }
            set
            {
                base.ObjectData.Properties["ExportMode"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "ExportMode", value));
                }
            }
        }

        [Remote]
        public bool Hidden
        {
            get
            {
                base.CheckUninitializedProperty("Hidden");
                return (bool)base.ObjectData.Properties["Hidden"];
            }
            set
            {
                base.ObjectData.Properties["Hidden"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Hidden", value));
                }
            }
        }

        [Remote]
        public bool IsClosed
        {
            get
            {
                base.CheckUninitializedProperty("IsClosed");
                return (bool)base.ObjectData.Properties["IsClosed"];
            }
        }

        [Remote]
        public PropertyValues Properties
        {
            get
            {
                object obj;
                PropertyValues propertyValues;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Properties", out obj))
                {
                    propertyValues = (PropertyValues)obj;
                }
                else
                {
                    propertyValues = new PropertyValues(base.Context, new ObjectPathProperty(base.Context, base.Path, "Properties"));
                    base.ObjectData.ClientObjectProperties["Properties"] = propertyValues;
                }
                return propertyValues;
            }
        }

        [Remote]
        public string Subtitle
        {
            get
            {
                base.CheckUninitializedProperty("Subtitle");
                return (string)base.ObjectData.Properties["Subtitle"];
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
                base.ObjectData.Properties["Title"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "Title", value));
                }
            }
        }

        [Remote]
        public string TitleUrl
        {
            get
            {
                base.CheckUninitializedProperty("TitleUrl");
                return (string)base.ObjectData.Properties["TitleUrl"];
            }
            set
            {
                base.ObjectData.Properties["TitleUrl"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "TitleUrl", value));
                }
            }
        }

        [Remote]
        public int ZoneIndex
        {
            get
            {
                base.CheckUninitializedProperty("ZoneIndex");
                return (int)base.ObjectData.Properties["ZoneIndex"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebPart(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "ExportMode":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ExportMode"] = reader.ReadEnum<WebPartExportMode>();
                    break;
                case "Hidden":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Hidden"] = reader.ReadBoolean();
                    break;
                case "IsClosed":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IsClosed"] = reader.ReadBoolean();
                    break;
                case "Properties":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Properties", this.Properties, reader);
                    this.Properties.FromJson(reader);
                    break;
                case "Subtitle":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Subtitle"] = reader.ReadString();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                case "TitleUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TitleUrl"] = reader.ReadString();
                    break;
                case "ZoneIndex":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ZoneIndex"] = reader.ReadInt32();
                    break;
            }
            return flag;
        }
    }
}
