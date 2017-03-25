using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ClientResult<T> : IFromJson
    {
        private T m_value;

        public T Value
        {
            get
            {
                return this.m_value;
            }
        }

        void IFromJson.FromJson(JsonReader reader)
        {
            this.m_value = reader.Read<T>();
        }

        bool IFromJson.CustomFromJson(JsonReader reader)
        {
            return false;
        }
    }
}
