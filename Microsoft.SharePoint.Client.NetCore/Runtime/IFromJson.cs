using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public interface IFromJson
    {
        void FromJson(JsonReader reader);

        bool CustomFromJson(JsonReader reader);
    }
}
