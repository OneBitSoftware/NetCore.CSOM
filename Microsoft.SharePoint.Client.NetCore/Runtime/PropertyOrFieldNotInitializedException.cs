using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    //Edited for .NET Core
    //[Serializable]
    public sealed class PropertyOrFieldNotInitializedException : InvalidOperationException
    {
        public PropertyOrFieldNotInitializedException() : base(Resources.GetString("PropertyHasNotBeenInitialized"))
        {
        }

        public PropertyOrFieldNotInitializedException(string message) : base(message)
        {
        }

        //Edited for .NET Core
        //private PropertyOrFieldNotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}

        public PropertyOrFieldNotInitializedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}