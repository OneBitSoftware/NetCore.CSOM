using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ServerException : Exception
    {
        private string m_serverStackTrace;

        private int m_serverErrorCode;

        private string m_serverErrorValue;

        private string m_serverErrorTypeName;

        private object m_serverErrorDetails;

        private string m_serverErrorTraceCorrelationId;

        public string ServerStackTrace
        {
            get
            {
                return this.m_serverStackTrace;
            }
        }

        public int ServerErrorCode
        {
            get
            {
                return this.m_serverErrorCode;
            }
        }

        public string ServerErrorValue
        {
            get
            {
                return this.m_serverErrorValue;
            }
        }

        public string ServerErrorTypeName
        {
            get
            {
                return this.m_serverErrorTypeName;
            }
        }

        public object ServerErrorDetails
        {
            get
            {
                return this.m_serverErrorDetails;
            }
        }

        public string ServerErrorTraceCorrelationId
        {
            get
            {
                return this.m_serverErrorTraceCorrelationId;
            }
        }

        internal ServerException(string message, string serverStackTrace, int serverErrorCode) : this(message, serverStackTrace, serverErrorCode, null, null, null, null)
        {
        }

        internal ServerException(string message, string serverStackTrace, int serverErrorCode, string serverErrorValue, string serverErrorTypeName, object serverErrorDetails, string serverErrorTraceCorrelationId) : base(message)
        {
            this.m_serverStackTrace = serverStackTrace;
            this.m_serverErrorCode = serverErrorCode;
            this.m_serverErrorValue = serverErrorValue;
            this.m_serverErrorTypeName = serverErrorTypeName;
            this.m_serverErrorDetails = serverErrorDetails;
            this.m_serverErrorTraceCorrelationId = serverErrorTraceCorrelationId;
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.ServerStackTrace))
            {
                return base.ToString();
            }
            return this.Message + Environment.NewLine + this.ServerStackTrace;
        }

        internal static ServerException CreateFromErrorInfo(Dictionary<string, object> errorInfo)
        {
            object obj;
            string message;
            if (errorInfo.TryGetValue("ErrorMessage", out obj))
            {
                message = (string)obj;
            }
            else
            {
                message = string.Empty;
            }
            string serverStackTrace;
            if (errorInfo.TryGetValue("ErrorStackTrace", out obj))
            {
                serverStackTrace = (string)obj;
            }
            else
            {
                serverStackTrace = string.Empty;
            }
            int num = 0;
            if (errorInfo.TryGetValue("ErrorCode", out obj))
            {
                if (obj is int)
                {
                    num = (int)obj;
                }
                else if (obj is long)
                {
                    num = (int)((long)obj);
                }
            }
            string serverErrorValue = null;
            if (errorInfo.TryGetValue("ErrorValue", out obj))
            {
                serverErrorValue = (string)obj;
            }
            string serverErrorTypeName = null;
            if (errorInfo.TryGetValue("ErrorTypeName", out obj))
            {
                serverErrorTypeName = (string)obj;
            }
            object serverErrorDetails = null;
            if (errorInfo.TryGetValue("ErrorDetails", out obj))
            {
                serverErrorDetails = obj;
            }
            string serverErrorTraceCorrelationId = null;
            if (errorInfo.TryGetValue("TraceCorrelationId", out obj))
            {
                serverErrorTraceCorrelationId = (string)obj;
            }
            if (num == -2147024891)
            {
                return new ServerUnauthorizedAccessException(message, serverStackTrace, num, serverErrorValue, serverErrorTypeName, serverErrorDetails, serverErrorTraceCorrelationId);
            }
            return new ServerException(message, serverStackTrace, num, serverErrorValue, serverErrorTypeName, serverErrorDetails, serverErrorTraceCorrelationId);
        }
    }
}
