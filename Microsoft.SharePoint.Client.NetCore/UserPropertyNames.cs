using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class UserPropertyNames
    {
        public const string Email = "Email";

        public const string IsShareByEmailGuestUser = "IsShareByEmailGuestUser";

        public const string IsSiteAdmin = "IsSiteAdmin";

        public const string UserId = "UserId";
    }
}
