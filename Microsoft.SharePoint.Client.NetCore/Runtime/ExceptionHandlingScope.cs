using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public sealed class ExceptionHandlingScope : IFromJson
    {
        private ClientRuntimeContext m_context;

        private bool m_processed;

        private bool m_hasError;

        private string m_errorMessage;

        private string m_serverStackTrace;

        private int m_serverErrorCode;

        private string m_serverErrorValue;

        private string m_serverErrorTypeName;

        private object m_serverErrorDetails;

        private ExecutionScope m_executionScope;

        private ExecutionScope m_tryScope;

        private ExecutionScope m_catchScope;

        private ExecutionScope m_finallyScope;

        internal bool IsSimpleForm
        {
            get
            {
                return this.m_tryScope == null;
            }
        }

        public bool Processed
        {
            get
            {
                return this.m_processed;
            }
        }

        public bool HasException
        {
            get
            {
                return this.m_hasError;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this.m_errorMessage;
            }
        }

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

        public ExceptionHandlingScope(ClientRuntimeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.m_context = context;
            this.m_serverErrorCode = -1;
        }

        internal static Exception CreateInvalidUsageException()
        {
            return new ClientRequestException(Resources.GetString("InvalidUsageOfExceptionHandlingScope"));
        }

        public IDisposable StartScope()
        {
            if (this.m_executionScope != null)
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            this.m_executionScope = new ExceptionHandlingExecutionScope(this.m_context, this, new ExecutionScopeDisposingCallback(this.ExceptionHandlingScopeDisposingCallback));
            this.m_context.PendingRequest.AddQueryIdAndResultObject(this.m_executionScope.Id, this);
            return this.m_executionScope;
        }

        private void ExceptionHandlingScopeDisposingCallback()
        {
            if (this.m_tryScope != null)
            {
                if (this.m_catchScope == null && this.m_finallyScope == null)
                {
                    throw ExceptionHandlingScope.CreateInvalidUsageException();
                }
                ClientAction lastAction = this.m_context.PendingRequest.LastAction;
                if (lastAction == null || !(lastAction is ClientActionExecutionScopeEnd))
                {
                    throw ExceptionHandlingScope.CreateInvalidUsageException();
                }
                ClientActionExecutionScopeEnd clientActionExecutionScopeEnd = (ClientActionExecutionScopeEnd)lastAction;
                if (clientActionExecutionScopeEnd.Scope.Name != "CatchScope" && clientActionExecutionScopeEnd.Scope.Name != "FinallyScope")
                {
                    throw ExceptionHandlingScope.CreateInvalidUsageException();
                }
            }
        }

        public IDisposable StartTry()
        {
            if (this.m_executionScope == null || this.m_executionScope.Disposed || this.m_tryScope != null)
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            ClientAction lastAction = this.m_context.PendingRequest.LastAction;
            if (lastAction == null || !(lastAction is ClientActionExecutionScopeStart))
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            if (((ClientActionExecutionScopeStart)lastAction).Scope.Name != "ExceptionHandlingScope")
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            this.m_tryScope = new ExecutionScope(this.m_context, "TryScope", null);
            return this.m_tryScope;
        }

        public IDisposable StartCatch()
        {
            if (this.m_executionScope == null || this.m_executionScope.Disposed || this.m_tryScope == null || !this.m_tryScope.Disposed || this.m_catchScope != null || this.m_finallyScope != null)
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            ClientAction lastAction = this.m_context.PendingRequest.LastAction;
            if (lastAction == null || !(lastAction is ClientActionExecutionScopeEnd))
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            if (((ClientActionExecutionScopeEnd)lastAction).Scope.Name != "TryScope")
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            this.m_catchScope = new ExecutionScope(this.m_context, "CatchScope", null);
            return this.m_catchScope;
        }

        public IDisposable StartFinally()
        {
            if (this.m_executionScope == null || this.m_executionScope.Disposed || this.m_tryScope == null || !this.m_tryScope.Disposed || (this.m_catchScope != null && !this.m_catchScope.Disposed) || this.m_finallyScope != null)
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            ClientAction lastAction = this.m_context.PendingRequest.LastAction;
            if (lastAction == null || !(lastAction is ClientActionExecutionScopeEnd))
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            if (((ClientActionExecutionScopeEnd)lastAction).Scope.Name != "TryScope" && ((ClientActionExecutionScopeEnd)lastAction).Scope.Name != "CatchScope")
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            this.m_finallyScope = new ExecutionScope(this.m_context, "FinallyScope", null);
            return this.m_finallyScope;
        }

        void IFromJson.FromJson(JsonReader reader)
        {
            object obj = reader.ReadObject();
            Dictionary<string, object> dictionary = obj as Dictionary<string, object>;
            if (dictionary == null)
            {
                throw new ClientRequestException(Resources.GetString("UnknownResponseData"));
            }
            if (dictionary.TryGetValue("HasException", out obj))
            {
                this.m_hasError = (bool)obj;
                if (this.m_hasError)
                {
                    if (!dictionary.TryGetValue("ErrorInfo", out obj))
                    {
                        throw new ClientRequestException(Resources.GetString("UnknownResponseData"));
                    }
                    Dictionary<string, object> dictionary2 = obj as Dictionary<string, object>;
                    if (dictionary2 == null)
                    {
                        throw new ClientRequestException(Resources.GetString("UnknownResponseData"));
                    }
                    ServerException ex = ServerException.CreateFromErrorInfo(dictionary2);
                    this.m_errorMessage = ex.Message;
                    this.m_serverStackTrace = ex.ServerStackTrace;
                    this.m_serverErrorCode = ex.ServerErrorCode;
                    this.m_serverErrorValue = ex.ServerErrorValue;
                    this.m_serverErrorTypeName = ex.ServerErrorTypeName;
                    this.m_serverErrorDetails = ex.ServerErrorDetails;
                }
                this.m_processed = true;
                return;
            }
            throw new ClientRequestException(Resources.GetString("UnknownResponseData"));
        }

        bool IFromJson.CustomFromJson(JsonReader reader)
        {
            return false;
        }
    }
}
