using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class GroupPropertyNames
    {
        public const string AllowMembersEditMembership = "AllowMembersEditMembership";

        public const string AllowRequestToJoinLeave = "AllowRequestToJoinLeave";

        public const string AutoAcceptRequestToJoinLeave = "AutoAcceptRequestToJoinLeave";

        public const string CanCurrentUserEditMembership = "CanCurrentUserEditMembership";

        public const string CanCurrentUserManageGroup = "CanCurrentUserManageGroup";

        public const string CanCurrentUserViewMembership = "CanCurrentUserViewMembership";

        public const string Description = "Description";

        public const string OnlyAllowMembersViewMembership = "OnlyAllowMembersViewMembership";

        public const string OwnerTitle = "OwnerTitle";

        public const string RequestToJoinLeaveEmailSetting = "RequestToJoinLeaveEmailSetting";
    }
}
