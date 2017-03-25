using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ServerUnauthorizedAccessException : ServerException
    {
        internal ServerUnauthorizedAccessException(string message, string serverStackTrace, int serverErrorCode, string serverErrorValue, string serverErrorTypeName, object serverErrorDetails, string serverErrorTraceCorrelationId) : base(message, serverStackTrace, serverErrorCode, serverErrorValue, serverErrorTypeName, serverErrorDetails, serverErrorTraceCorrelationId)
        {
        }
    }
}
