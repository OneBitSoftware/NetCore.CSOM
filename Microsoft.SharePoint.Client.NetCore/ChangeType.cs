using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public enum ChangeType
    {
        NoChange,
        Add,
        Update,
        DeleteObject,
        Rename,
        MoveAway,
        MoveInto,
        Restore,
        RoleAdd,
        RoleDelete,
        RoleUpdate,
        AssignmentAdd,
        AssignmentDelete,
        MemberAdd,
        MemberDelete,
        SystemUpdate,
        Navigation,
        ScopeAdd,
        ScopeDelete,
        ListContentTypeAdd,
        ListContentTypeDelete,
        Dirty,
        Activity
    }
}
