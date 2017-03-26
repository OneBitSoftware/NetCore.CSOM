using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.AttachmentCollection", ServerTypeId = "{f4e86471-7dab-4b47-b061-50a40e27140e}")]
    public sealed class AttachmentCollection : ClientObjectCollection<Attachment>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AttachmentCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public Attachment Add(AttachmentCreationInformation parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && parameters == null)
            {
                throw ClientUtility.CreateArgumentNullException("parameters");
            }
            Attachment attachment = new Attachment(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            base.AddChild(attachment);
            return attachment;
        }

        [Remote]
        public Attachment AddUsingPath(ResourcePath filename, Stream contentStream)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (filename == null)
                {
                    throw ClientUtility.CreateArgumentNullException("filename");
                }
                if (contentStream == null)
                {
                    throw ClientUtility.CreateArgumentNullException("contentStream");
                }
            }
            return new Attachment(context, new ObjectPathMethod(context, base.Path, "AddUsingPath", new object[]
            {
                filename,
                contentStream
            }));
        }

        [Remote]
        public Attachment GetByFileName(string fileName)
        {
            ClientRuntimeContext context = base.Context;
            return new Attachment(context, new ObjectPathMethod(context, base.Path, "GetByFileName", new object[]
            {
                fileName
            }));
        }

        [Remote]
        public Attachment GetByFileNameAsPath(ResourcePath fileName)
        {
            ClientRuntimeContext context = base.Context;
            return new Attachment(context, new ObjectPathMethod(context, base.Path, "GetByFileNameAsPath", new object[]
            {
                fileName
            }));
        }
    }
}
