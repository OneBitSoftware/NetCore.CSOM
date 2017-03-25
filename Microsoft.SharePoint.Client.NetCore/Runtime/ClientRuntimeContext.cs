using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Linq.Expressions;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public class ClientRuntimeContext : IDisposable
    {
        private string m_url;

        private long m_sequenceId;

        private string m_applicationName = ".NET Library";

        private string m_clientTag;

        private bool m_disableReturnValueCache;

        private bool m_validateOnClient = true;

        private ClientAuthenticationMode m_authenticationMode;

        private FormsAuthenticationLoginInfo m_formsAuthenticationLoginInfo;

        private ICredentials m_credentials;

        private WebRequestExecutorFactory m_webRequestExecutorFactory = new DefaultWebRequestExecutorFactory();

        private ClientRequest m_request;

        private bool m_bProcessingResponse;

        private int m_requestTimeout = 180000;

        private Dictionary<string, object> m_staticObjects;

        private Dictionary<long, ObjectPath> m_objectPaths = new Dictionary<long, ObjectPath>();

        private ClientQueryProvider m_queryProvider;

        internal static Version[] s_supportedSchemaVersions = new Version[]
        {
            ClientSchemaVersions.CurrentVersion,
            ClientSchemaVersions.Version14
        };

        private Version m_serverSchemaVersion;

        private Version m_serverLibraryVersion;

        private Version m_requestSchemaVersion;

        private string m_traceCorrelationId;

        private string m_traceCorrelationIdToServer;

        private Dictionary<string, ChunkStreamBuilder> m_streamsFromServer;

        public event EventHandler<WebRequestEventArgs> ExecutingWebRequest;

        internal long NextSequenceId
        {
            get
            {
                return Interlocked.Increment(ref this.m_sequenceId);
            }
        }

        protected internal virtual string ServiceRelativeUrl
        {
            get
            {
                return "_vti_bin/client.svc/ProcessQuery";
            }
        }

        public string Url
        {
            get
            {
                return this.m_url;
            }
        }

        public string ApplicationName
        {
            get
            {
                return this.m_applicationName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (value.Length > 128)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.m_applicationName = value;
            }
        }

        public string ClientTag
        {
            get
            {
                return this.m_clientTag;
            }
            set
            {
                if (value != null && value.Length > 32)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                this.m_clientTag = value;
            }
        }

        public bool DisableReturnValueCache
        {
            get
            {
                return this.m_disableReturnValueCache;
            }
            set
            {
                this.m_disableReturnValueCache = value;
            }
        }

        public bool ValidateOnClient
        {
            get
            {
                return this.m_validateOnClient;
            }
            set
            {
                this.m_validateOnClient = value;
            }
        }

        public ClientAuthenticationMode AuthenticationMode
        {
            get
            {
                return this.m_authenticationMode;
            }
            set
            {
                this.m_authenticationMode = value;
            }
        }

        public FormsAuthenticationLoginInfo FormsAuthenticationLoginInfo
        {
            get
            {
                return this.m_formsAuthenticationLoginInfo;
            }
            set
            {
                this.m_formsAuthenticationLoginInfo = value;
            }
        }

        public ICredentials Credentials
        {
            get
            {
                return this.m_credentials;
            }
            set
            {
                this.m_credentials = value;
            }
        }

        public WebRequestExecutorFactory WebRequestExecutorFactory
        {
            get
            {
                return this.m_webRequestExecutorFactory;
            }
            set
            {
                this.m_webRequestExecutorFactory = value;
            }
        }

        public ClientRequest PendingRequest
        {
            get
            {
                if (this.m_request == null)
                {
                    this.m_request = new ClientRequest(this);
                }
                return this.m_request;
            }
        }

        public bool HasPendingRequest
        {
            get
            {
                return this.m_request != null && this.m_request.LastAction != null;
            }
        }

        internal bool ProcessingResponse
        {
            get
            {
                return this.m_bProcessingResponse;
            }
            set
            {
                this.m_bProcessingResponse = value;
            }
        }

        public object Tag
        {
            get;
            set;
        }

        public int RequestTimeout
        {
            get
            {
                return this.m_requestTimeout;
            }
            set
            {
                if (value > 0 || value == -1)
                {
                    this.m_requestTimeout = value;
                    return;
                }
                throw new ArgumentOutOfRangeException("value");
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Dictionary<string, object> StaticObjects
        {
            get
            {
                if (this.m_staticObjects == null)
                {
                    this.m_staticObjects = new Dictionary<string, object>();
                }
                return this.m_staticObjects;
            }
        }

        internal Dictionary<long, ObjectPath> ObjectPaths
        {
            get
            {
                return this.m_objectPaths;
            }
        }

        internal ClientQueryProvider QueryProvider
        {
            get
            {
                if (this.m_queryProvider == null)
                {
                    this.m_queryProvider = new ClientQueryProvider();
                }
                return this.m_queryProvider;
            }
        }

        public Version ServerSchemaVersion
        {
            get
            {
                if (this.m_serverSchemaVersion == null)
                {
                    throw new PropertyOrFieldNotInitializedException(Resources.GetString("NamedPropertyHasNotBeenInitialized", new object[]
                    {
                        "ServerSchemaVersion"
                    }));
                }
                return this.m_serverSchemaVersion;
            }
            internal set
            {
                this.m_serverSchemaVersion = value;
            }
        }

        public Version ServerLibraryVersion
        {
            get
            {
                if (this.m_serverLibraryVersion == null)
                {
                    throw new PropertyOrFieldNotInitializedException(Resources.GetString("NamedPropertyHasNotBeenInitialized", new object[]
                    {
                        "ServerLibraryVersion"
                    }));
                }
                return this.m_serverLibraryVersion;
            }
            internal set
            {
                this.m_serverLibraryVersion = value;
            }
        }

        public Version RequestSchemaVersion
        {
            get
            {
                if (this.m_requestSchemaVersion == null)
                {
                    return ClientSchemaVersions.CurrentVersion;
                }
                return this.m_requestSchemaVersion;
            }
            set
            {
                this.m_requestSchemaVersion = value;
            }
        }

        public string TraceCorrelationId
        {
            get
            {
                if (!string.IsNullOrEmpty(this.m_traceCorrelationIdToServer))
                {
                    return this.m_traceCorrelationIdToServer;
                }
                return this.m_traceCorrelationId;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    Guid guid = new Guid(value);
                    this.m_traceCorrelationIdToServer = guid.ToString("D");
                    return;
                }
                this.m_traceCorrelationIdToServer = value;
            }
        }

        protected ClientRuntimeContext(string webFullUrl)
        {
            if (webFullUrl == null)
            {
                throw new ArgumentNullException("webFullUrl");
            }
        //Edited for .NET Core
           // if (!webFullUrl.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) && !webFullUrl.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
            if (!webFullUrl.ToLowerInvariant().StartsWith("http://") && !webFullUrl.ToLowerInvariant().StartsWith("https://"))
            {
                throw new ArgumentException();
            }
            this.m_url = webFullUrl;
        }

        protected virtual void OnExecutingWebRequest(WebRequestEventArgs args)
        {
            if (args != null && args.WebRequestExecutor != null)
            {
                if (args.WebRequestExecutor.WebRequest != null)
                {
                    //Edited for .NET Core
                    //args.WebRequestExecutor.WebRequest.AutomaticDecompression = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                    //args.WebRequestExecutor.WebRequest.E = (DecompressionMethods.GZip | DecompressionMethods.Deflate);
                }
                if (!string.IsNullOrEmpty(this.m_traceCorrelationIdToServer))
                {
                    args.WebRequestExecutor.RequestHeaders["SPResponseGuid"] = this.m_traceCorrelationIdToServer;
                }
                if (!string.IsNullOrEmpty(this.ClientTag))
                {
                    args.WebRequestExecutor.RequestHeaders["X-ClientService-ClientTag"] = this.ClientTag;
                }
            }
            EventHandler<WebRequestEventArgs> executingWebRequest = this.ExecutingWebRequest;
            if (executingWebRequest != null)
            {
                executingWebRequest(this, args);
            }
        }

        internal void FireExecutingWebRequestEvent(WebRequestEventArgs args)
        {
            this.OnExecutingWebRequest(args);
        }

        public virtual void ExecuteQuery()
        {
            ScriptTypeMap.EnsureInited();
            ClientRequest pendingRequest = this.PendingRequest;
            this.m_request = null;
            pendingRequest.ExecuteQuery();
        }

        public T CastTo<T>(ClientObject obj) where T : ClientObject
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            ClientAction.CheckActionParameterInContext(this, obj);
            Type typeFromHandle = typeof(T);
        //Edited for .NET Core
            //if (!typeof(ClientObject).IsAssignableFrom(typeFromHandle))
            if (!typeof(ClientObject).GetTypeInfo().IsAssignableFrom(typeFromHandle))
            {
                throw new ArgumentException();
            }
            if (obj.Context != this)
            {
                throw new InvalidOperationException();
            }
            T t;
        //Edited for .NET Core
            //if (typeFromHandle.IsAssignableFrom(obj.GetType()))
            if (typeFromHandle.GetTypeInfo().IsAssignableFrom(obj.GetType()))
            {
                t = (T)((object)Activator.CreateInstance(typeFromHandle, new object[]
                {
                    this,
                    obj.Path
                }));
                t.SetObjectDataFrom(obj);
                return t;
            }
        //Edited for .NET Core
            //if (obj.ObjectData.AssociatedObject != null && typeFromHandle.IsAssignableFrom(obj.ObjectData.AssociatedObject.GetType()))
            if (obj.ObjectData.AssociatedObject != null && typeFromHandle.GetTypeInfo().IsAssignableFrom(obj.ObjectData.AssociatedObject.GetType()))
            {
                t = (T)((object)Activator.CreateInstance(typeFromHandle, new object[]
                {
                    this,
                    obj.Path
                }));
                t.SetObjectDataFrom(obj);
                return t;
            }
        //Edited for .NET Core
            //if (!obj.GetType().IsAssignableFrom(typeFromHandle))
            if (!obj.GetType().GetTypeInfo().IsAssignableFrom(typeFromHandle))
            {
                throw ClientUtility.CreateArgumentException("type");
            }
        //Edited for .NET Core
            //if (obj.ObjectData.AssociatedObject != null && !obj.ObjectData.AssociatedObject.GetType().IsAssignableFrom(typeFromHandle))
            if (obj.ObjectData.AssociatedObject != null && !obj.ObjectData.AssociatedObject.GetType().GetTypeInfo().IsAssignableFrom(typeFromHandle))
            {
                throw ClientUtility.CreateArgumentException("type");
            }
            t = (T)((object)Activator.CreateInstance(typeFromHandle, new object[]
            {
                this,
                obj.Path
            }));
            t.SetObjectDataFrom(obj);
            object obj2;
            if (obj.ObjectData.AssociatedObject == null)
            {
                obj2 = obj;
            }
            else
            {
                obj2 = obj.ObjectData.AssociatedObject;
            }
            if (obj2 != null)
            {
                List<string> list = new List<string>();
                Dictionary<string, object> queryIdToObjectMap = this.PendingRequest.QueryIdToObjectMap;
                foreach (KeyValuePair<string, object> current in queryIdToObjectMap)
                {
                    if (object.ReferenceEquals(current.Value, obj2))
                    {
                        list.Add(current.Key);
                    }
                }
                foreach (string current2 in list)
                {
                    queryIdToObjectMap[current2] = t;
                }
                obj.ObjectData.AssociatedObject = t;
            }
            return t;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddQuery(ClientAction query)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            this.PendingRequest.AddQuery(query);
        }

        internal void AddObjectToQueryCleanupList(ClientObject obj)
        {
            this.PendingRequest.AddObjectToQueryCleanupList(obj);
        }

        internal void AddObjectPath(ObjectPath path)
        {
            this.m_objectPaths[path.Id] = path;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddQueryIdAndResultObject(long id, object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            this.PendingRequest.AddQueryIdAndResultObject(id, obj);
        }

        public object ParseObjectFromJsonString(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return null;
            }
            StringReader stringReader = new StringReader(json);
            JsonReader jsonReader = new JsonReader(stringReader, this);
            object result = jsonReader.ReadObject();
            jsonReader.Dispose();
            stringReader.Dispose();
            return result;
        }

        internal static ClientRuntimeContext GetContextFromClientObject(ClientObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            return obj.Context;
        }

        internal static ClientRuntimeContext GetContextFromObjectPath(ObjectPath objectPath)
        {
            if (objectPath == null)
            {
                throw new ArgumentNullException("objectPath");
            }
            return objectPath.Context;
        }

        public static void AddClientTypeAssembly(Assembly assembly)
        {
            if (assembly == null)
            {
                throw new ArgumentNullException("assembly");
            }
            ScriptTypeMap.EnsureInited();
            ScriptTypeMap.AddClientProxyAssembly(assembly);
        }

        public static void SetupRequestCredential(ClientRuntimeContext context, HttpWebRequest request)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }
            if (context.AuthenticationMode == ClientAuthenticationMode.Anonymous)
            {
                if (context.Credentials != null)
                {
                    request.Credentials = context.Credentials;
                }
            }
            else if (context.AuthenticationMode == ClientAuthenticationMode.Default)
            {
                if (context.Credentials == null)
                {
                    request.Credentials = CredentialCache.DefaultCredentials;
                }
                else
                {
                    request.Credentials = context.Credentials;
                }
            }
            else if (context.AuthenticationMode == ClientAuthenticationMode.FormsAuthentication)
            {
                ClientRuntimeContext.FormsAuthenticationLogin(context, request);
            }
            SharePointOnlineCredentials sharePointOnlineCredentials = request.Credentials as SharePointOnlineCredentials;
            if (sharePointOnlineCredentials != null)
            {
                request.Headers["X-FORMS_BASED_AUTH_ACCEPTED"] = "f";
                string authenticationCookie = sharePointOnlineCredentials.GetAuthenticationCookie(new Uri(context.Url), false, true);
                if (string.IsNullOrEmpty(authenticationCookie))
                {
                    authenticationCookie = sharePointOnlineCredentials.GetAuthenticationCookie(new Uri(context.Url), true, true);
                }
                if (!string.IsNullOrEmpty(authenticationCookie))
                {
                    request.Headers[HttpRequestHeader.Cookie] = authenticationCookie;
                }
            }
        }

        private static void FormsAuthenticationLogin(ClientRuntimeContext context, HttpWebRequest request)
        {
            if (context.FormsAuthenticationLoginInfo == null)
            {
                throw new ArgumentNullException(Resources.GetString("MissedFormsAuthLoginInfo"));
            }
            Uri contextUri = new Uri(context.Url);
            CookieCollection cookies = context.FormsAuthenticationLoginInfo.EnsureLogin(contextUri);
            if (request.CookieContainer == null)
            {
                request.CookieContainer = new CookieContainer();
            }
        //Edited for .NET Core
            //request.CookieContainer.Add(cookies);
            request.CookieContainer.Add(contextUri,cookies);
        }

        public void Load<T>(T clientObject, params Expression<Func<T, object>>[] retrievals) where T : ClientObject
        {
            if (clientObject == null)
            {
                throw new ArgumentNullException("clientObject");
            }
            ClientAction.CheckActionParameterInContext(this, clientObject);
            DataRetrieval.Load<T>(clientObject, retrievals);
        }

        public IEnumerable<T> LoadQuery<T>(ClientObjectCollection<T> clientObjects) where T : ClientObject
        {
            if (clientObjects == null)
            {
                throw new ArgumentNullException("clientObjects");
            }
            ClientAction.CheckActionParameterInContext(this, clientObjects);
            ClientQueryableResult<T> clientQueryableResult = new ClientQueryableResult<T>();
            ClientQueryInternal clientQueryInternal = new ClientQueryInternal(clientObjects, null, false, null);
            clientQueryInternal.ChildItemQuery.SelectAllProperties();
            clientObjects.Context.AddQueryIdAndResultObject(clientQueryInternal.Id, clientQueryableResult);
            clientObjects.Context.AddQuery(clientQueryInternal);
            return clientQueryableResult;
        }

        public IEnumerable<T> LoadQuery<T>(IQueryable<T> clientObjects) where T : ClientObject
        {
            if (clientObjects == null)
            {
                throw new ArgumentNullException("clientObjects");
            }
            ClientAction.CheckActionParameterInContext(this, clientObjects);
            ClientObjectCollection<T> clientObjectCollection = clientObjects as ClientObjectCollection<T>;
            if (clientObjectCollection != null)
            {
                return this.LoadQuery<T>(clientObjectCollection);
            }
            ClientQueryable<T> clientQueryable = clientObjects as ClientQueryable<T>;
            if (clientQueryable != null)
            {
                return DataRetrieval.Retrieve<T>(clientQueryable);
            }
            throw new NotSupportedException();
        }

        internal static bool CanHandleResponseSchema(Version responseSchemaVersion)
        {
            for (int i = 0; i < ClientRuntimeContext.s_supportedSchemaVersions.Length; i++)
            {
                if (ClientRuntimeContext.s_supportedSchemaVersions[i] == responseSchemaVersion)
                {
                    return true;
                }
            }
            return false;
        }

        internal void AddStream(string streamId, ChunkStreamBuilder stream)
        {
            if (this.m_streamsFromServer == null)
            {
                this.m_streamsFromServer = new Dictionary<string, ChunkStreamBuilder>();
            }
            ChunkStreamBuilder chunkStreamBuilder;
            if (this.m_streamsFromServer.TryGetValue(streamId, out chunkStreamBuilder) && chunkStreamBuilder != null)
            {
                chunkStreamBuilder.Close();
            }
            this.m_streamsFromServer[streamId] = stream;
        }

        internal Stream GetStreamAndRemoveFromContext(string streamId)
        {
            if (this.m_streamsFromServer == null)
            {
                throw new ArgumentOutOfRangeException("streamId");
            }
            ChunkStreamBuilder chunkStreamBuilder = this.m_streamsFromServer[streamId];
            this.m_streamsFromServer.Remove(streamId);
            return chunkStreamBuilder.CreateReadonlyStream();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && this.m_streamsFromServer != null)
            {
                foreach (ChunkStreamBuilder current in this.m_streamsFromServer.Values)
                {
                    current.Close();
                }
                this.m_streamsFromServer = null;
            }
        }

        internal void SetTraceCorrelationId(string value)
        {
            this.m_traceCorrelationId = value;
        }
    }
}
