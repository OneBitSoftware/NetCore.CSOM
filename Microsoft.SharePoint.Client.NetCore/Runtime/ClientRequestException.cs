using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    //Edited for .NET Core
    //[Serializable]
    public class ClientRequestException : Exception
    {
        public ClientRequestException(string message) : base(message)
        {
        }

        public ClientRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }

        //Edited for .NET Core
        //protected ClientRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}
    }
}
