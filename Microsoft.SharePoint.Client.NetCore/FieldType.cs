using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    public enum FieldType
    {
        Invalid,
        Integer,
        Text,
        Note,
        DateTime,
        Counter,
        Choice,
        Lookup,
        Boolean,
        Number,
        Currency,
        URL,
        Computed,
        Threading,
        Guid,
        MultiChoice,
        GridChoice,
        Calculated,
        File,
        Attachments,
        User,
        Recurrence,
        CrossProjectLink,
        ModStat,
        Error,
        ContentTypeId,
        PageSeparator,
        ThreadIndex,
        WorkflowStatus,
        AllDayEvent,
        WorkflowEventType,
        Geolocation,
        OutcomeChoice,
        MaxItems
    }
}
