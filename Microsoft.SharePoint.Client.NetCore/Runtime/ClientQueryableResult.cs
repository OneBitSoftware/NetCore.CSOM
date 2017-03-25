using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ClientQueryableResult<T> : IFromJson, IEnumerable<T>, IEnumerable where T : ClientObject
    {
        private List<T> m_data;

        void IFromJson.FromJson(JsonReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            this.m_data = new List<T>();
            if (reader.PeekTokenType() == JsonTokenType.Null)
            {
                reader.ReadObject();
                return;
            }
            if (reader.PeekTokenType() == JsonTokenType.ArrayStart)
            {
                object[] array = reader.ReadObjectArray(typeof(T));
                for (int i = 0; i < array.Length; i++)
                {
                    this.m_data.Add(array[i] as T);
                }
                return;
            }
            reader.ReadObjectStart();
            bool flag = false;
            while (reader.PeekTokenType() != JsonTokenType.ObjectEnd)
            {
                string a = reader.PeekName();
                if (a == "_Child_Items_")
                {
                    reader.ReadName();
                    object[] array2 = reader.ReadObjectArray(typeof(T));
                    if (!flag)
                    {
                        for (int j = 0; j < array2.Length; j++)
                        {
                            this.m_data.Add(array2[j] as T);
                        }
                        flag = true;
                    }
                }
                else
                {
                    reader.ReadName();
                    reader.ReadObject();
                }
            }
            reader.ReadObjectEnd();
        }

        bool IFromJson.CustomFromJson(JsonReader reader)
        {
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (this.m_data == null)
            {
                throw new ClientRequestException(Resources.GetString("QueryableResultNotAvailable"));
            }
            return this.m_data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
