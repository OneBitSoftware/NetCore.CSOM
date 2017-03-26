using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.FileVersionCollection", ServerTypeId = "{3826e282-67a6-4861-88fb-474e8aac897b}")]
    public class FileVersionCollection : ClientObjectCollection<FileVersion>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FileVersionCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public FileVersion GetById(int versionid)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<int, FileVersion> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetById", out obj))
            {
                dictionary = (Dictionary<int, FileVersion>)obj;
            }
            else
            {
                dictionary = new Dictionary<int, FileVersion>();
                base.ObjectData.MethodReturnObjects["GetById"] = dictionary;
            }
            FileVersion fileVersion = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(versionid, out fileVersion))
            {
                return fileVersion;
            }
            fileVersion = new FileVersion(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                versionid
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[versionid] = fileVersion;
            }
            return fileVersion;
        }

        [Remote]
        public void DeleteByID(int vid)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteByID", new object[]
            {
                vid
            });
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteByLabel(string versionlabel)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (versionlabel == null)
                {
                    throw ClientUtility.CreateArgumentNullException("versionlabel");
                }
                if (versionlabel != null && versionlabel.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("versionlabel");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteByLabel", new object[]
            {
                versionlabel
            });
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteAll()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteAll", null);
            context.AddQuery(query);
        }

        [Remote]
        public void RestoreByLabel(string versionlabel)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (versionlabel == null)
                {
                    throw ClientUtility.CreateArgumentNullException("versionlabel");
                }
                if (versionlabel != null && versionlabel.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("versionlabel");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "RestoreByLabel", new object[]
            {
                versionlabel
            });
            context.AddQuery(query);
        }
    }
}
