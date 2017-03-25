using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class CollectionNotInitializedException : InvalidOperationException
    {
        public CollectionNotInitializedException() : base(Resources.GetString("CollectionHasNotBeenInitialized"))
        {
        }

        public CollectionNotInitializedException(string message) : base(message)
        {
        }

        //private CollectionNotInitializedException(SerializationInfo info, StreamingContext context) : base(info, context)
        //{
        //}

        public CollectionNotInitializedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}