using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.ComponentModel;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.CreatableItemInfoCollection", ValueObject = true, ServerTypeId = "{9b16c27e-29b9-46db-acb0-9e36d3ab244a}")]
    public sealed class CreatableItemInfoCollection : ClientValueObjectCollection<CreatableItemInfo>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string TypeId
        {
            get
            {
                return "{9b16c27e-29b9-46db-acb0-9e36d3ab244a}";
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
