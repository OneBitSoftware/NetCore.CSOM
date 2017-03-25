using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreMime
{
    internal static class DiagnosticUtility
    {
        public static class ExceptionUtility
        {
            public static Exception ThrowHelperError(Exception ex)
            {
                return ex;
            }

            public static Exception ThrowHelperArgumentNull(string argumentName)
            {
                return new ArgumentNullException(argumentName);
            }
        }
    }
}
