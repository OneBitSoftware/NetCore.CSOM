using Microsoft.SharePoint.Client.NetCoreMime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ClientRequest
    {
        private class ExecuteQueryMimeInfo
        {
            private string m_boundary;

            private string m_mainPartCid;

            public string Boundary
            {
                get
                {
                    return this.m_boundary;
                }
            }

            public string MainPartCid
            {
                get
                {
                    return this.m_mainPartCid;
                }
            }

            public string ContentType
            {
                get
                {
                    return string.Format(CultureInfo.InvariantCulture, "multipart/related;type=\"application/xop+xml\";boundary=\"{0}\";start=\"{1}\";start-info=\"application/xml\"", new object[]
                    {
                        this.Boundary,
                        this.MainPartCid
                    });
                }
            }

            public ExecuteQueryMimeInfo()
            {
                this.m_boundary = MimeUtility.CreateBoundary();
                this.m_mainPartCid = "<http://sharepoint.microsoft.com/client/" + DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture) + ">";
            }
        }

        internal const long InvalidId = -1L;

        private const int StartSequenceId = 1073741824;

        internal const int GenericErrorCode = -1;

        private const string MultiPartContentTypeFormat = "multipart/related;type=\"application/xop+xml\";boundary=\"{0}\";start=\"{1}\";start-info=\"application/xml\"";

        private const string MultiPartMainPartContentType = "application/xop+xml;charset=utf-8;type=\"application/xml\"";

        private static long s_sequenceId;

        private ClientRuntimeContext m_context;

        private WebRequestExecutor m_requestExecutor;

        private string m_soapPageUrl;

        private ClientRequestStatus m_requestStatus;

        private List<ClientAction> m_queries = new List<ClientAction>();

        private ClientAction m_lastAction;

        private List<ClientObject> m_clientObjectCleanupList;

        private List<ObjectPath> m_clientObjectPathCleanupList;

        private Stack<ExecutionScope> m_executionScopes;

        private SerializationContext m_serializationContext;

        private Dictionary<string, object> m_queryIdToObjectMap = new Dictionary<string, object>();

        public static long NextSequenceId
        {
            get
            {
                long num = Interlocked.Increment(ref ClientRequest.s_sequenceId);
                return num + 1073741824L;
            }
        }

        internal ClientRuntimeContext Context
        {
            get
            {
                return this.m_context;
            }
        }

        public WebRequestExecutor RequestExecutor
        {
            get
            {
                if (this.m_requestExecutor == null)
                {
                    WebRequestExecutorFactory webRequestExecutorFactory = this.m_context.WebRequestExecutorFactory;
                    this.m_requestExecutor = webRequestExecutorFactory.CreateWebRequestExecutor(this.m_context, this.SoapPageUrl);
                }
                return this.m_requestExecutor;
            }
        }

        private string SoapPageUrl
        {
            get
            {
                if (string.IsNullOrEmpty(this.m_soapPageUrl))
                {
                    this.m_soapPageUrl = this.m_context.Url;
                    if (!this.m_soapPageUrl.EndsWith("/"))
                    {
                        this.m_soapPageUrl += "/";
                    }
                    this.m_soapPageUrl += this.Context.ServiceRelativeUrl;
                }
                return this.m_soapPageUrl;
            }
        }

        internal ClientRequestStatus RequestStatus
        {
            get
            {
                return this.m_requestStatus;
            }
        }

        internal List<ClientAction> Actions
        {
            get
            {
                return this.m_queries;
            }
        }

        internal ClientAction LastAction
        {
            get
            {
                return this.m_lastAction;
            }
        }

        internal Stack<ExecutionScope> ExecutionScopes
        {
            get
            {
                if (this.m_executionScopes == null)
                {
                    this.m_executionScopes = new Stack<ExecutionScope>();
                }
                return this.m_executionScopes;
            }
        }

        internal SerializationContext SerializationContext
        {
            get
            {
                if (this.m_serializationContext == null)
                {
                    this.m_serializationContext = new SerializationContext(this.Context);
                }
                return this.m_serializationContext;
            }
        }

        internal Dictionary<string, object> QueryIdToObjectMap
        {
            get
            {
                return this.m_queryIdToObjectMap;
            }
        }

        internal ClientRequest(ClientRuntimeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.m_context = context;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void AddQuery(ClientAction query)
        {
            if (this.m_requestStatus != ClientRequestStatus.Active)
            {
                throw new InvalidOperationException(Resources.GetString("RequestHasBeenExecuted"));
            }
            this.m_queries.Add(query);
            this.m_lastAction = query;
        }

        internal void AddObjectToQueryCleanupList(ClientObject obj)
        {
            if (this.m_clientObjectCleanupList == null)
            {
                this.m_clientObjectCleanupList = new List<ClientObject>();
            }
            this.m_clientObjectCleanupList.Add(obj);
        }

        internal void AddToObjectPathCleanupList(ObjectPath path)
        {
            if (this.m_clientObjectPathCleanupList == null)
            {
                this.m_clientObjectPathCleanupList = new List<ObjectPath>();
            }
            this.m_clientObjectPathCleanupList.Add(path);
        }

        private void CleanupQuery()
        {
            if (this.m_clientObjectCleanupList != null)
            {
                foreach (ClientObject current in this.m_clientObjectCleanupList)
                {
                    current.CleanupQuery();
                }
                this.m_clientObjectCleanupList = null;
            }
            if (this.m_clientObjectPathCleanupList != null)
            {
                foreach (ObjectPath current2 in this.m_clientObjectPathCleanupList)
                {
                    current2.Invalidate();
                }
                this.m_clientObjectPathCleanupList = null;
            }
        }

        internal void ExecuteQuery()
        {
            if (this.m_requestStatus != ClientRequestStatus.Active)
            {
                throw new ClientRequestException(Resources.GetString("RequestHasBeenExecuted"));
            }
            this.m_requestStatus = ClientRequestStatus.InProgress;
            ChunkStringBuilder sb = this.BuildQuery();
            this.CleanupQuery();
            this.ExecuteQueryToServer(sb);
        }

        private ChunkStringBuilder BuildQuery()
        {
            SerializationContext serializationContext = this.SerializationContext;
            ChunkStringBuilder chunkStringBuilder = new ChunkStringBuilder();
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.OmitXmlDeclaration = true;
            xmlWriterSettings.NewLineHandling = NewLineHandling.Entitize;
            XmlWriter xmlWriter = XmlWriter.Create(chunkStringBuilder.CreateTextWriter(CultureInfo.InvariantCulture), xmlWriterSettings);
            xmlWriter.WriteStartElement("Request", "http://schemas.microsoft.com/sharepoint/clientquery/2009");
            xmlWriter.WriteAttributeString("AddExpandoFieldTypeSuffix", "true");
            xmlWriter.WriteAttributeString("SchemaVersion", this.Context.RequestSchemaVersion.ToString());
            xmlWriter.WriteAttributeString("LibraryVersion", "16.0.0.0");
            if (!string.IsNullOrEmpty(this.m_context.ApplicationName))
            {
                xmlWriter.WriteAttributeString("ApplicationName", this.m_context.ApplicationName);
            }
            xmlWriter.WriteStartElement("Actions");
            Stack<ExecutionScope> stack = new Stack<ExecutionScope>();
            foreach (ClientAction current in this.m_queries)
            {
                if (current is ClientActionExecutionScopeStart)
                {
                    ClientActionExecutionScopeStart clientActionExecutionScopeStart = (ClientActionExecutionScopeStart)current;
                    clientActionExecutionScopeStart.Scope.WriteStart(xmlWriter, serializationContext);
                    stack.Push(clientActionExecutionScopeStart.Scope);
                }
                else if (current is ClientActionExecutionScopeEnd)
                {
                    ClientActionExecutionScopeEnd clientActionExecutionScopeEnd = (ClientActionExecutionScopeEnd)current;
                    if (stack.Count == 0 || stack.Pop() != clientActionExecutionScopeEnd.Scope)
                    {
                        throw ExceptionHandlingScope.CreateInvalidUsageException();
                    }
                    clientActionExecutionScopeEnd.Scope.WriteEnd(xmlWriter, serializationContext);
                }
                else
                {
                    current.WriteToXml(xmlWriter, serializationContext);
                }
            }
            if (stack.Count > 0)
            {
                throw ExceptionHandlingScope.CreateInvalidUsageException();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("ObjectPaths");
            Dictionary<long, ObjectPath> dictionary = new Dictionary<long, ObjectPath>();
            while (true)
            {
                List<long> list = new List<long>();
                foreach (long current2 in serializationContext.Paths.Keys)
                {
                    if (!dictionary.ContainsKey(current2))
                    {
                        list.Add(current2);
                    }
                }
                if (list.Count == 0)
                {
                    break;
                }
                for (int i = 0; i < list.Count; i++)
                {
                    ObjectPath objectPath = this.m_context.ObjectPaths[list[i]];
                    objectPath.WriteToXml(xmlWriter, serializationContext);
                    dictionary[list[i]] = objectPath;
                }
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.Flush();
            return chunkStringBuilder;
        }

        private bool IsMultiPartMime(string contentType, out string boundary)
        {
            boundary = MimeUtility.GetBoundary(contentType);
            return !string.IsNullOrEmpty(contentType) && contentType.StartsWith("multipart/related") && !string.IsNullOrEmpty(boundary);
        }

        private void ProcessResponse()
        {
            string responseContentType = this.RequestExecutor.ResponseContentType;
            HttpStatusCode statusCode = this.RequestExecutor.StatusCode;
            string boundary;
            bool flag = this.IsMultiPartMime(responseContentType, out boundary);
            if (statusCode != HttpStatusCode.OK || (!responseContentType.StartsWith("application/json") && !flag))
            {
                this.m_requestStatus = ClientRequestStatus.CompletedException;
                throw new ClientRequestException(Resources.GetString("RequestUnexpectedResponseWithContentTypeAndStatus", new object[]
                {
                    responseContentType,
                    statusCode
                }));
            }
            this.m_context.ProcessingResponse = true;
            try
            {
                using (Stream responseStream = this.RequestExecutor.GetResponseStream())
                {
                    MimeReader mimeReader = null;
                    Stream responseStream2 = responseStream;
                    if (flag)
                    {
                        mimeReader = new MimeReader(responseStream, boundary);
                        if (!mimeReader.ReadNextPart())
                        {
                            throw new ClientRequestException(Resources.GetString("RequestUnexpectedResponseWithContentTypeAndStatus", new object[]
                            {
                                responseContentType,
                                statusCode
                            }));
                        }
                        responseStream2 = mimeReader.GetContentStream();
                    }
                    this.ProcessResponseStream(responseStream2);
                    if (flag)
                    {
                        while (mimeReader.ReadNextPart())
                        {
                            int num = 2000;
                            int num2 = num;
                            MimeHeaders mimeHeaders = mimeReader.ReadHeaders(num, ref num2);
                            if (mimeHeaders.ContentID != null && !string.IsNullOrEmpty(mimeHeaders.ContentID.Value))
                            {
                                string text = mimeHeaders.ContentID.Value;
                                if (text.StartsWith("<", StringComparison.Ordinal) && text.EndsWith(">", StringComparison.Ordinal))
                                {
                                    text = text.Substring(1, text.Length - 2);
                                }
                                ChunkStreamBuilder chunkStreamBuilder = new ChunkStreamBuilder();
                                chunkStreamBuilder.CopyFrom(mimeReader.GetContentStream());
                                this.Context.AddStream(text, chunkStreamBuilder);
                            }
                        }
                    }
                    this.m_requestStatus = ClientRequestStatus.CompletedSuccess;
                }
            }
            catch (Exception ex)
            {
                this.m_requestStatus = ClientRequestStatus.CompletedException;
                throw;
            }
            finally
            {
                this.m_context.ProcessingResponse = false;
                this.RequestExecutor.Dispose();
            }
        }

        private void ProcessResponseStream(Stream responseStream)
        {
            StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
            JsonReader jsonReader = new JsonReader(reader, this.m_context);
            jsonReader.ReadArrayStart();
            Dictionary<string, object> dictionary = jsonReader.ReadObject() as Dictionary<string, object>;
            if (dictionary == null)
            {
                throw new ClientRequestException(Resources.GetString("RequestUnknownResponse"));
            }
            object obj;
            if (!dictionary.TryGetValue("SchemaVersion", out obj))
            {
                throw new ClientRequestException(Resources.GetString("RequestUnknownResponse"));
            }
            string text = obj as string;
            if (string.IsNullOrEmpty(text))
            {
                throw new ClientRequestException(Resources.GetString("RequestUnknownResponse"));
            }
            this.m_context.ServerSchemaVersion = new Version(text);
            if (!dictionary.TryGetValue("LibraryVersion", out obj))
            {
                throw new ClientRequestException(Resources.GetString("RequestUnknownResponse"));
            }
            string text2 = obj as string;
            if (string.IsNullOrEmpty(text2))
            {
                throw new ClientRequestException(Resources.GetString("RequestUnknownResponse"));
            }
            this.m_context.ServerLibraryVersion = new Version(text2);
            if (dictionary.TryGetValue("TraceCorrelationId", out obj))
            {
                this.m_context.SetTraceCorrelationId(obj as string);
            }
            if (!dictionary.TryGetValue("ErrorInfo", out obj))
            {
                throw new ClientRequestException(Resources.GetString("RequestUnknownResponse"));
            }
            object obj2 = obj;
            if (obj2 != null)
            {
                Dictionary<string, object> dictionary2 = obj2 as Dictionary<string, object>;
                if (dictionary2 == null)
                {
                    throw new ClientRequestException(Resources.GetString("RequestUnknownResponse"));
                }
                ServerException ex = ServerException.CreateFromErrorInfo(dictionary2);
                throw ex;
            }
            else
            {
                if (!ClientRuntimeContext.CanHandleResponseSchema(this.m_context.ServerSchemaVersion))
                {
                    throw new ClientRequestException(Resources.GetString("CannotHandleServerResponseSchema", new object[]
                    {
                        text
                    }));
                }
                while (jsonReader.PeekTokenType() != JsonTokenType.ArrayEnd)
                {
                    long num = jsonReader.ReadInt64();
                    obj = null;
                    if (this.m_queryIdToObjectMap.TryGetValue(num.ToString(CultureInfo.InvariantCulture), out obj) && obj != null)
                    {
                        ClientObject clientObject = obj as ClientObject;
                        string scriptType = null;
                        if (clientObject != null && jsonReader.PeekTokenType() == JsonTokenType.ObjectStart && jsonReader.PeekObjectType(out scriptType))
                        {
                            Type typeFromScriptType = ScriptTypeMap.GetTypeFromScriptType(scriptType);
                            if (typeFromScriptType != null && typeFromScriptType != clientObject.GetType())
                            {
                                ClientObject clientObject2 = ScriptTypeMap.CreateObjectFromScriptType(scriptType, this.Context) as ClientObject;
                                if (clientObject2 != null)
                                {
                                    clientObject.SetTypedObject(clientObject2);
                                    obj = clientObject2;
                                }
                            }
                        }
                        IFromJson fromJson = obj as IFromJson;
                        if (fromJson != null && !fromJson.CustomFromJson(jsonReader))
                        {
                            fromJson.FromJson(jsonReader);
                        }
                    }
                    else
                    {
                        jsonReader.ReadObject();
                    }
                }
                return;
            }
        }

        private void WriteMimeStream(ClientRequest.ExecuteQueryMimeInfo mimeInfo, ChunkStringBuilder sb, Stream requestStream)
        {
            MimeWriter mimeWriter = new MimeWriter(requestStream, mimeInfo.Boundary);
            mimeWriter.StartPart();
            mimeWriter.WriteHeader(MimeGlobals.ContentIDHeader, mimeInfo.MainPartCid);
            mimeWriter.WriteHeader(MimeGlobals.ContentTransferEncodingHeader, "8bit");
            mimeWriter.WriteHeader(MimeGlobals.ContentTypeHeader, "application/xop+xml;charset=utf-8;type=\"application/xml\"");
            mimeWriter.WriteHeader(MimeGlobals.ContentLengthHeader, sb.Length.ToString(CultureInfo.InvariantCulture));
            sb.WriteContentAsUTF8(mimeWriter.GetContentStream());
            foreach (StreamInfo current in this.SerializationContext.Streams)
            {
                mimeWriter.StartPart();
                mimeWriter.WriteHeader(MimeGlobals.ContentIDHeader, "<" + current.Id + ">");
                mimeWriter.WriteHeader(MimeGlobals.ContentTransferEncodingHeader, "binary");
                mimeWriter.WriteHeader(MimeGlobals.ContentTypeHeader, "application/octet-stream");
                mimeWriter.WriteHeader(MimeGlobals.ContentLengthHeader, current.Stream.Length.ToString(CultureInfo.InvariantCulture));
                Stream contentStream = mimeWriter.GetContentStream();
                ChunkStreamBuilder.CopyStream(current.Stream, contentStream);
                //Edited for .NET Core
                current.Stream.Dispose();//.Close();
            }
            mimeWriter.Close();
        }

        private void ExecuteQueryToServer(ChunkStringBuilder sb)
        {
            this.m_context.FireExecutingWebRequestEvent(new WebRequestEventArgs(this.RequestExecutor));
            this.RequestExecutor.RequestContentType = "text/xml";
            if (this.m_context.AuthenticationMode == ClientAuthenticationMode.Default)
            {
                this.RequestExecutor.RequestHeaders["X-RequestForceAuthentication"] = "true";
            }
            ClientRequest.ExecuteQueryMimeInfo executeQueryMimeInfo = null;
            if (this.SerializationContext.Streams != null && this.SerializationContext.Streams.Count > 0)
            {
                executeQueryMimeInfo = new ClientRequest.ExecuteQueryMimeInfo();
                this.RequestExecutor.RequestContentType = executeQueryMimeInfo.ContentType;
            }
            Stream requestStream = this.RequestExecutor.GetRequestStream();
            if (executeQueryMimeInfo != null)
            {
                this.WriteMimeStream(executeQueryMimeInfo, sb, requestStream);
            }
            else
            {
                sb.WriteContentAsUTF8(requestStream);
            }
            requestStream.Flush();
            //Edited for .NET Core
            //requestStream.Close();
            requestStream.Dispose();
            this.RequestExecutor.Execute();
            this.ProcessResponse();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void AddQueryIdAndResultObject(long id, object obj)
        {
            if (this.m_requestStatus != ClientRequestStatus.Active)
            {
                throw new InvalidOperationException(Resources.GetString("RequestHasBeenExecuted"));
            }
            this.m_queryIdToObjectMap[id.ToString(CultureInfo.InvariantCulture)] = obj;
            ClientObject clientObject = obj as ClientObject;
            if (clientObject != null && clientObject.ObjectData.AssociatedObject != null)
            {
                this.m_queryIdToObjectMap[id.ToString(CultureInfo.InvariantCulture)] = clientObject.ObjectData.AssociatedObject;
            }
        }
    }
}
