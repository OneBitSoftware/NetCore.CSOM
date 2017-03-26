using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.SharedWithUserCollection", ValueObject = true, ServerTypeId = "{c60fa59c-1de9-4b4f-a6ed-2b4b625ff300}")]
    public sealed class SharedWithUserCollection : ClientValueObjectCollection<SharedWithUser>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{c60fa59c-1de9-4b4f-a6ed-2b4b625ff300}";
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (serializationContext == null)
            {
                throw new ArgumentNullException("serializationContext");
            }
            base.WriteToXml(writer, serializationContext);
        }
    }
}
