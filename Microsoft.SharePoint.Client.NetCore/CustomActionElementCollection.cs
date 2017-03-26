using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.CustomActionElementCollection", ValueObject = true, ServerTypeId = "{8085c8a0-ac08-44c8-ac9f-8a35540b34d1}")]
    public sealed class CustomActionElementCollection : ClientValueObjectCollection<CustomActionElement>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{8085c8a0-ac08-44c8-ac9f-8a35540b34d1}";
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
