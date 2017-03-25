using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreIdcrl
{
    internal static class IdcrlConstants
    {
        public const string HEADER_IDCRL_AUTH_ACCEPTED = "X-IDCRL_ACCEPTED";

        public const string HEADER_FORMS_BASED_AUTH_ACCEPTED = "X-FORMS_BASED_AUTH_ACCEPTED";

        public const string HEADER_IDCRL_AUTH_PARAMS_V1 = "X-IDCRL_AUTH_PARAMS_V1";

        public const string True = "t";

        public const string False = "f";

        public const string REGKEY_MSOIdentityCRL = "SOFTWARE\\Microsoft\\MSOIdentityCRL";

        public const string REGVAL_ServiceEnvironment = "ServiceEnvironment";

        public const string ENV_INT_MSO = "INT-MSO";

        public const string ENV_PPE_MSO = "PPE-MSO";

        public const string ENV_PRODUCTION = "production";

        public const string BPOSIDCRL_AUTHORIZATION_HEADER_PREFIX = "BPOSIDCRL ";

        public const string IDCRLTYPE_BPOSIDRL = "BPOSIDCRL";

        public const string IDCRL_PARAM_IDCRL_TYPE = "IDCRL TYPE";

        public const string IDCRL_PARAM_ENDPOINT = "ENDPOINT";

        public const string IDCRL_PARAM_ROOTDOMAIN = "ROOTDOMAIN";

        public const string IDCRL_PARAM_POLICY = "POLICY";
    }
}
