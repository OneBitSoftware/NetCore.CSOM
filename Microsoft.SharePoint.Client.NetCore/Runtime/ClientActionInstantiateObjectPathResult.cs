using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ClientActionInstantiateObjectPathResult : IFromJson
    {
        private ObjectPath m_path;

        public ClientActionInstantiateObjectPathResult(ObjectPath path)
        {
            this.m_path = path;
        }

        void IFromJson.FromJson(JsonReader reader)
        {
            Dictionary<string, object> dictionary = reader.ReadDictionary();
            if (dictionary.ContainsKey("IsNull") && dictionary["IsNull"] is bool)
            {
                this.m_path.ServerObjectIsNull = new bool?((bool)dictionary["IsNull"]);
            }
        }

        bool IFromJson.CustomFromJson(JsonReader reader)
        {
            return false;
        }
    }
}
