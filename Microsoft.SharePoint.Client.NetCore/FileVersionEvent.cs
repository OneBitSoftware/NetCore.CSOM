using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FileVersionEvent", ServerTypeId = "{478a36fe-cd3d-4f97-99da-d373d2c2e6e4}")]
    public class FileVersionEvent : ClientObject
    {
        [Remote]
        public string Editor
        {
            get
            {
                base.CheckUninitializedProperty("Editor");
                return (string)base.ObjectData.Properties["Editor"];
            }
        }

        [Remote]
        public string EditorEmail
        {
            get
            {
                base.CheckUninitializedProperty("EditorEmail");
                return (string)base.ObjectData.Properties["EditorEmail"];
            }
        }

        [Remote]
        public SharedWithUser SharedByUser
        {
            get
            {
                base.CheckUninitializedProperty("SharedByUser");
                return (SharedWithUser)base.ObjectData.Properties["SharedByUser"];
            }
        }

        [Remote]
        public SharedWithUserCollection SharedWithUsers
        {
            get
            {
                base.CheckUninitializedProperty("SharedWithUsers");
                return (SharedWithUserCollection)base.ObjectData.Properties["SharedWithUsers"];
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

        [Remote]
        public FileVersionEventType EventType
        {
            get
            {
                base.CheckUninitializedProperty("EventType");
                return (FileVersionEventType)base.ObjectData.Properties["EventType"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileVersionEvent(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                if (!(peekedName == "Editor"))
                {
                    if (!(peekedName == "EditorEmail"))
                    {
                        if (!(peekedName == "SharedByUser"))
                        {
                            if (!(peekedName == "SharedWithUsers"))
                            {
                                if (!(peekedName == "Time"))
                                {
                                    if (peekedName == "EventType")
                                    {
                                        flag = true;
                                        reader.ReadName();
                                        base.ObjectData.Properties["EventType"] = reader.ReadEnum<FileVersionEventType>();
                                    }
                                }
                                else
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
                                base.ObjectData.Properties["SharedWithUsers"] = reader.Read<SharedWithUserCollection>();
                            }
                        }
                        else
                        {
                            flag = true;
                            reader.ReadName();
                            base.ObjectData.Properties["SharedByUser"] = reader.Read<SharedWithUser>();
                        }
                    }
                    else
                    {
                        flag = true;
                        reader.ReadName();
                        base.ObjectData.Properties["EditorEmail"] = reader.ReadString();
                    }
                }
                else
                {
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Editor"] = reader.ReadString();
                }
            }
            return flag;
        }
    }
}
