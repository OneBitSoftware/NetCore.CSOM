using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.Change", ServerTypeId = "{c717121b-f82f-4afb-a2b7-25f67522120f}")]
    public class Change : ClientObject
    {
        [Remote]
        public ChangeToken ChangeToken
        {
            get
            {
                base.CheckUninitializedProperty("ChangeToken");
                return (ChangeToken)base.ObjectData.Properties["ChangeToken"];
            }
        }

        [Remote]
        public ChangeType ChangeType
        {
            get
            {
                base.CheckUninitializedProperty("ChangeType");
                return (ChangeType)base.ObjectData.Properties["ChangeType"];
            }
        }

        [Remote]
        public string RelativeTime
        {
            get
            {
                base.CheckUninitializedProperty("RelativeTime");
                return (string)base.ObjectData.Properties["RelativeTime"];
            }
        }

        [Remote]
        public Guid SiteId
        {
            get
            {
                base.CheckUninitializedProperty("SiteId");
                return (Guid)base.ObjectData.Properties["SiteId"];
            }
        }

        [Remote]
        public DateTime Time
        {
            get
            {
                base.CheckUninitializedProperty("Time");
                return (DateTime)base.ObjectData.Properties["Time"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Change(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "ChangeToken"))
                {
                    if (!(peekedName == "ChangeType"))
                    {
                        if (!(peekedName == "RelativeTime"))
                        {
                            if (!(peekedName == "SiteId"))
                            {
                                if (peekedName == "Time")
                                {
                                    flag = true;
                                    reader.ReadName();
                                    base.ObjectData.Properties["Time"] = reader.ReadDateTime();
                                }
                            }
                            else
                            {
                                flag = true;
                                reader.ReadName();
                                base.ObjectData.Properties["SiteId"] = reader.ReadGuid();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["RelativeTime"] = reader.ReadString();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["ChangeType"] = reader.ReadEnum<ChangeType>();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ChangeToken"] = reader.Read<ChangeToken>();
                }
            }
            return flag;
        }
    }
}