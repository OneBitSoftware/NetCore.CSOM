using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ClientActionInstantiateObjectPath : ClientAction
    {
        public ClientActionInstantiateObjectPath(ObjectPath path) : base(ClientRuntimeContext.GetContextFromObjectPath(path), path, null)
        {
        }

        internal override void WriteToXml(XmlWriter writer, SerializationContext serializationContext)
        {
            writer.WriteStartElement("ObjectPath");
            writer.WriteAttributeString("Id", base.Id.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("ObjectPathId", base.Path.Id.ToString(CultureInfo.InvariantCulture));
            serializationContext.AddObjectPath(base.Path);
            writer.WriteEndElement();
        }
    }
}
