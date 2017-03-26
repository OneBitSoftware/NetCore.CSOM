using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.DlpPolicyTip", ServerTypeId = "{4fc085d6-53cb-4668-bc9b-ae1e54209812}")]
    public class DlpPolicyTip : ClientObject
    {
        [Remote]
        public string AppliedActionsText
        {
            get
            {
                base.CheckUninitializedProperty("AppliedActionsText");
                return (string)base.ObjectData.Properties["AppliedActionsText"];
            }
        }

        [Remote]
        public string ComplianceUrl
        {
            get
            {
                base.CheckUninitializedProperty("ComplianceUrl");
                return (string)base.ObjectData.Properties["ComplianceUrl"];
            }
        }

        [Remote]
        public string GeneralText
        {
            get
            {
                base.CheckUninitializedProperty("GeneralText");
                return (string)base.ObjectData.Properties["GeneralText"];
            }
        }

        [Remote]
        public DateTime LastProcessedTime
        {
            get
            {
                base.CheckUninitializedProperty("LastProcessedTime");
                return (DateTime)base.ObjectData.Properties["LastProcessedTime"];
            }
        }

        [Remote]
        public IEnumerable<string> MatchedConditionDescriptions
        {
            get
            {
                base.CheckUninitializedProperty("MatchedConditionDescriptions");
                return (IEnumerable<string>)base.ObjectData.Properties["MatchedConditionDescriptions"];
            }
        }

        [Remote]
        public RuleOverrideOptions OverrideOptions
        {
            get
            {
                base.CheckUninitializedProperty("OverrideOptions");
                return (RuleOverrideOptions)base.ObjectData.Properties["OverrideOptions"];
            }
        }

        [Remote]
        public string TwoLetterISOLanguageName
        {
            get
            {
                base.CheckUninitializedProperty("TwoLetterISOLanguageName");
                return (string)base.ObjectData.Properties["TwoLetterISOLanguageName"];
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DlpPolicyTip(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        protected override bool InitOnePropertyFromJson(string peekedName, JsonReader reader)
        {
            bool flag = base.InitOnePropertyFromJson(peekedName, reader);
            if (flag)
            {
                return flag;
            }
            switch (peekedName)
            {
                case "AppliedActionsText":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["AppliedActionsText"] = reader.ReadString();
                    break;
                case "ComplianceUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ComplianceUrl"] = reader.ReadString();
                    break;
                case "GeneralText":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["GeneralText"] = reader.ReadString();
                    break;
                case "LastProcessedTime":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LastProcessedTime"] = reader.ReadDateTime();
                    break;
                case "MatchedConditionDescriptions":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MatchedConditionDescriptions"] = reader.ReadList<string>();
                    break;
                case "OverrideOptions":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["OverrideOptions"] = reader.ReadEnum<RuleOverrideOptions>();
                    break;
                case "TwoLetterISOLanguageName":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TwoLetterISOLanguageName"] = reader.ReadString();
                    break;
            }
            return flag;
        }
    }
}
