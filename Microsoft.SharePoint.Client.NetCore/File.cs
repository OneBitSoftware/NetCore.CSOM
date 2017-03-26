using Microsoft.SharePoint.Client.NetCore.Runtime;
using Microsoft.SharePoint.Client.NetCore.Utilities;
using Microsoft.SharePoint.Client.NetCore.WebParts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.File", ServerTypeId = "{df28be1e-74b5-4b21-b73a-2bbac0a23d8a}")]
    public class File : ClientObject
    {
        private enum SaveBinaryCheckMode
        {
            ETag,
            Overwrite
        }

        private const int UploadBufferSize = 1024;

        [Remote]
        public User Author
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Author", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "Author"));
                    base.ObjectData.ClientObjectProperties["Author"] = user;
                }
                return user;
            }
        }

        [Remote]
        public User CheckedOutByUser
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("CheckedOutByUser", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "CheckedOutByUser"));
                    base.ObjectData.ClientObjectProperties["CheckedOutByUser"] = user;
                }
                return user;
            }
        }

        [Remote]
        public string CheckInComment
        {
            get
            {
                base.CheckUninitializedProperty("CheckInComment");
                return (string)base.ObjectData.Properties["CheckInComment"];
            }
        }

        [Remote]
        public CheckOutType CheckOutType
        {
            get
            {
                base.CheckUninitializedProperty("CheckOutType");
                return (CheckOutType)base.ObjectData.Properties["CheckOutType"];
            }
        }

        [Remote]
        public string ContentTag
        {
            get
            {
                base.CheckUninitializedProperty("ContentTag");
                return (string)base.ObjectData.Properties["ContentTag"];
            }
        }

        [Remote]
        public CustomizedPageStatus CustomizedPageStatus
        {
            get
            {
                base.CheckUninitializedProperty("CustomizedPageStatus");
                return (CustomizedPageStatus)base.ObjectData.Properties["CustomizedPageStatus"];
            }
        }

        [Remote]
        public Guid ListId
        {
            get
            {
                base.CheckUninitializedProperty("ListId");
                return (Guid)base.ObjectData.Properties["ListId"];
            }
        }

        [Remote]
        public EffectiveInformationRightsManagementSettings EffectiveInformationRightsManagementSettings
        {
            get
            {
                object obj;
                EffectiveInformationRightsManagementSettings effectiveInformationRightsManagementSettings;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("EffectiveInformationRightsManagementSettings", out obj))
                {
                    effectiveInformationRightsManagementSettings = (EffectiveInformationRightsManagementSettings)obj;
                }
                else
                {
                    effectiveInformationRightsManagementSettings = new EffectiveInformationRightsManagementSettings(base.Context, new ObjectPathProperty(base.Context, base.Path, "EffectiveInformationRightsManagementSettings"));
                    base.ObjectData.ClientObjectProperties["EffectiveInformationRightsManagementSettings"] = effectiveInformationRightsManagementSettings;
                }
                return effectiveInformationRightsManagementSettings;
            }
        }

        [Remote]
        public string ETag
        {
            get
            {
                base.CheckUninitializedProperty("ETag");
                return (string)base.ObjectData.Properties["ETag"];
            }
        }

        [Remote]
        public bool Exists
        {
            get
            {
                base.CheckUninitializedProperty("Exists");
                return (bool)base.ObjectData.Properties["Exists"];
            }
        }

        [Remote]
        public InformationRightsManagementFileSettings InformationRightsManagementSettings
        {
            get
            {
                object obj;
                InformationRightsManagementFileSettings informationRightsManagementFileSettings;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("InformationRightsManagementSettings", out obj))
                {
                    informationRightsManagementFileSettings = (InformationRightsManagementFileSettings)obj;
                }
                else
                {
                    informationRightsManagementFileSettings = new InformationRightsManagementFileSettings(base.Context, new ObjectPathProperty(base.Context, base.Path, "InformationRightsManagementSettings"));
                    base.ObjectData.ClientObjectProperties["InformationRightsManagementSettings"] = informationRightsManagementFileSettings;
                }
                return informationRightsManagementFileSettings;
            }
        }

        [Remote]
        public bool IrmEnabled
        {
            get
            {
                base.CheckUninitializedProperty("IrmEnabled");
                return (bool)base.ObjectData.Properties["IrmEnabled"];
            }
            set
            {
                base.ObjectData.Properties["IrmEnabled"] = value;
                if (base.Context != null)
                {
                    base.Context.AddQuery(new ClientActionSetProperty(this, "IrmEnabled", value));
                }
            }
        }

        [Remote]
        public long Length
        {
            get
            {
                base.CheckUninitializedProperty("Length");
                return (long)base.ObjectData.Properties["Length"];
            }
        }

        [Remote]
        public FileLevel Level
        {
            get
            {
                base.CheckUninitializedProperty("Level");
                return (FileLevel)base.ObjectData.Properties["Level"];
            }
        }

        [Remote]
        public string LinkingUri
        {
            get
            {
                base.CheckUninitializedProperty("LinkingUri");
                return (string)base.ObjectData.Properties["LinkingUri"];
            }
        }

        [Remote]
        public string LinkingUrl
        {
            get
            {
                base.CheckUninitializedProperty("LinkingUrl");
                return (string)base.ObjectData.Properties["LinkingUrl"];
            }
        }

        [Remote]
        public ListItem ListItemAllFields
        {
            get
            {
                object obj;
                ListItem listItem;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ListItemAllFields", out obj))
                {
                    listItem = (ListItem)obj;
                }
                else
                {
                    listItem = new ListItem(base.Context, new ObjectPathProperty(base.Context, base.Path, "ListItemAllFields"));
                    base.ObjectData.ClientObjectProperties["ListItemAllFields"] = listItem;
                }
                return listItem;
            }
        }

        [Remote]
        public User LockedByUser
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("LockedByUser", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "LockedByUser"));
                    base.ObjectData.ClientObjectProperties["LockedByUser"] = user;
                }
                return user;
            }
        }

        [Remote]
        public int MajorVersion
        {
            get
            {
                base.CheckUninitializedProperty("MajorVersion");
                return (int)base.ObjectData.Properties["MajorVersion"];
            }
        }

        [Remote]
        public int MinorVersion
        {
            get
            {
                base.CheckUninitializedProperty("MinorVersion");
                return (int)base.ObjectData.Properties["MinorVersion"];
            }
        }

        [Remote]
        public User ModifiedBy
        {
            get
            {
                object obj;
                User user;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("ModifiedBy", out obj))
                {
                    user = (User)obj;
                }
                else
                {
                    user = new User(base.Context, new ObjectPathProperty(base.Context, base.Path, "ModifiedBy"));
                    base.ObjectData.ClientObjectProperties["ModifiedBy"] = user;
                }
                return user;
            }
        }

        [Remote]
        public string Name
        {
            get
            {
                base.CheckUninitializedProperty("Name");
                return (string)base.ObjectData.Properties["Name"];
            }
        }

        [Remote]
        public ListPageRenderType PageRenderType
        {
            get
            {
                base.CheckUninitializedProperty("PageRenderType");
                return (ListPageRenderType)base.ObjectData.Properties["PageRenderType"];
            }
        }

        [Remote]
        public PropertyValues Properties
        {
            get
            {
                object obj;
                PropertyValues propertyValues;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Properties", out obj))
                {
                    propertyValues = (PropertyValues)obj;
                }
                else
                {
                    propertyValues = new PropertyValues(base.Context, new ObjectPathProperty(base.Context, base.Path, "Properties"));
                    base.ObjectData.ClientObjectProperties["Properties"] = propertyValues;
                }
                return propertyValues;
            }
        }

        [Remote]
        public ResourcePath ServerRelativePath
        {
            get
            {
                base.CheckUninitializedProperty("ServerRelativePath");
                return (ResourcePath)base.ObjectData.Properties["ServerRelativePath"];
            }
        }

        [Remote]
        public string ServerRelativeUrl
        {
            get
            {
                base.CheckUninitializedProperty("ServerRelativeUrl");
                return (string)base.ObjectData.Properties["ServerRelativeUrl"];
            }
        }

        [Remote]
        public Guid SiteId
        {
            get
            {
                base.CheckUninitializedProperty("SiteId");
                return (Guid)base.ObjectData.Properties["SiteId"];
            }
        }

        [Remote]
        public DateTime TimeCreated
        {
            get
            {
                base.CheckUninitializedProperty("TimeCreated");
                return (DateTime)base.ObjectData.Properties["TimeCreated"];
            }
        }

        [Remote]
        public DateTime TimeLastModified
        {
            get
            {
                base.CheckUninitializedProperty("TimeLastModified");
                return (DateTime)base.ObjectData.Properties["TimeLastModified"];
            }
        }

        [Remote]
        public string Title
        {
            get
            {
                base.CheckUninitializedProperty("Title");
                return (string)base.ObjectData.Properties["Title"];
            }
        }

        [Remote]
        public int UIVersion
        {
            get
            {
                base.CheckUninitializedProperty("UIVersion");
                return (int)base.ObjectData.Properties["UIVersion"];
            }
        }

        [Remote]
        public string UIVersionLabel
        {
            get
            {
                base.CheckUninitializedProperty("UIVersionLabel");
                return (string)base.ObjectData.Properties["UIVersionLabel"];
            }
        }

        [Remote]
        public Guid UniqueId
        {
            get
            {
                base.CheckUninitializedProperty("UniqueId");
                return (Guid)base.ObjectData.Properties["UniqueId"];
            }
        }

        [Remote]
        public FileVersionEventCollection VersionEvents
        {
            get
            {
                object obj;
                FileVersionEventCollection fileVersionEventCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("VersionEvents", out obj))
                {
                    fileVersionEventCollection = (FileVersionEventCollection)obj;
                }
                else
                {
                    fileVersionEventCollection = new FileVersionEventCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "VersionEvents"));
                    base.ObjectData.ClientObjectProperties["VersionEvents"] = fileVersionEventCollection;
                }
                return fileVersionEventCollection;
            }
        }

        [Remote]
        public FileVersionCollection Versions
        {
            get
            {
                object obj;
                FileVersionCollection fileVersionCollection;
                if (base.ObjectData.ClientObjectProperties.TryGetValue("Versions", out obj))
                {
                    fileVersionCollection = (FileVersionCollection)obj;
                }
                else
                {
                    fileVersionCollection = new FileVersionCollection(base.Context, new ObjectPathProperty(base.Context, base.Path, "Versions"));
                    base.ObjectData.ClientObjectProperties["Versions"] = fileVersionCollection;
                }
                return fileVersionCollection;
            }
        }

        [Remote]
        public Guid WebId
        {
            get
            {
                base.CheckUninitializedProperty("WebId");
                return (Guid)base.ObjectData.Properties["WebId"];
            }
        }

        internal void InitFromCreationInformation(FileCreationInformation creation)
        {
            if (creation != null)
            {
                base.ObjectData.Properties["Name"] = creation.Url;
                if (!string.IsNullOrEmpty(creation.Url))
                {
                    if (creation.Url.EndsWith("/", StringComparison.Ordinal))
                    {
                        throw new ArgumentException();
                    }
                    int num = creation.Url.LastIndexOf('/');
                    if (num >= 0 && num < creation.Url.Length)
                    {
                        string value = creation.Url.Substring(num + 1);
                        base.ObjectData.Properties["Name"] = value;
                    }
                }
            }
        }

        private void CheckScope(PersonalizationScope scope)
        {
        }

        private static string MakeFullUrl(ClientContext context, string serverRelativeUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (serverRelativeUrl == null)
            {
                throw new ArgumentNullException("serverRelativeUrl");
            }
            if (!serverRelativeUrl.StartsWith("/"))
            {
                throw new ArgumentOutOfRangeException("serverRelativeUrl");
            }
            Uri uri = new Uri(context.Url);
            uri = new Uri(uri, serverRelativeUrl);
            return uri.AbsoluteUri;
        }

        public static FileInformation OpenBinaryDirect(ClientContext context, string serverRelativeUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.HasPendingRequest)
            {
                throw new ClientRequestException(Resources.GetString("NoDirectHttpRequest"));
            }
            string requestUrl = File.MakeFullUrl(context, serverRelativeUrl);
            WebRequestExecutor webRequestExecutor = context.WebRequestExecutorFactory.CreateWebRequestExecutor(context, requestUrl);
            webRequestExecutor.RequestHeaders[HttpRequestHeader.Translate] = "f";
            context.FireExecutingWebRequestEventInternal(new WebRequestEventArgs(webRequestExecutor));
            webRequestExecutor.GetRequestStream().Write(new byte[0], 0, 0);
            webRequestExecutor.RequestMethod = "GET";
            webRequestExecutor.Execute();
            if (webRequestExecutor.StatusCode != HttpStatusCode.OK)
            {
                throw new ClientRequestException(Resources.GetString("RequestUnexpectedResponseWithContentTypeAndStatus", new object[]
                {
                    webRequestExecutor.ResponseContentType,
                    webRequestExecutor.StatusCode
                }));
            }
            string etag = webRequestExecutor.ResponseHeaders["ETag"];
            Stream responseStream = webRequestExecutor.GetResponseStream();
            return new FileInformation(responseStream, etag);
        }

        public static void SaveBinaryDirect(ClientContext context, string serverRelativeUrl, Stream stream, bool overwriteIfExists)
        {
            File.SaveBinary(context, serverRelativeUrl, stream, null, overwriteIfExists, File.SaveBinaryCheckMode.Overwrite);
        }

        public static void SaveBinaryDirect(ClientContext context, string serverRelativeUrl, Stream stream, string etag)
        {
            File.SaveBinary(context, serverRelativeUrl, stream, etag, false, File.SaveBinaryCheckMode.ETag);
        }

        private static void SaveBinary(ClientContext context, string serverRelativeUrl, Stream stream, string etag, bool overwriteIfExists, File.SaveBinaryCheckMode checkMode)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if (context.HasPendingRequest)
            {
                throw new ClientRequestException(Resources.GetString("NoDirectHttpRequest"));
            }
            string requestUrl = File.MakeFullUrl(context, serverRelativeUrl);
            WebRequestExecutor webRequestExecutor = context.WebRequestExecutorFactory.CreateWebRequestExecutor(context, requestUrl);
            webRequestExecutor.RequestMethod = "PUT";
            if (checkMode == File.SaveBinaryCheckMode.ETag)
            {
                if (!string.IsNullOrEmpty(etag))
                {
                    webRequestExecutor.RequestHeaders[HttpRequestHeader.IfMatch] = etag;
                }
            }
            else if (!overwriteIfExists)
            {
                webRequestExecutor.RequestHeaders[HttpRequestHeader.IfNoneMatch] = "*";
            }
            context.FireExecutingWebRequestEventInternal(new WebRequestEventArgs(webRequestExecutor));
            Stream requestStream = webRequestExecutor.GetRequestStream();
            byte[] buffer = new byte[1024];
            int count;
            while ((count = stream.Read(buffer, 0, 1024)) > 0)
            {
                requestStream.Write(buffer, 0, count);
            }
            requestStream.Flush();
            //Edited for .NET Core
            requestStream.Dispose();// Close();
            try
            {
                webRequestExecutor.Execute();
                if (webRequestExecutor.StatusCode != HttpStatusCode.Created && webRequestExecutor.StatusCode != HttpStatusCode.OK)
                {
                    throw new ClientRequestException(Resources.GetString("RequestUnexpectedResponseWithContentTypeAndStatus", new object[]
                    {
                        webRequestExecutor.ResponseContentType,
                        webRequestExecutor.StatusCode
                    }));
                }
            }
            catch (WebException ex)
            {
                HttpWebResponse httpWebResponse = ex.Response as HttpWebResponse;
                if (httpWebResponse == null || httpWebResponse.StatusCode != HttpStatusCode.PreconditionFailed)
                {
                    throw;
                }
                if (checkMode == File.SaveBinaryCheckMode.ETag)
                {
                    throw new ClientRequestException(Resources.GetString("ETagNotMatch"));
                }
                throw new ClientRequestException(Resources.GetString("FileAlreadyExists"));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public File(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
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
                case "Author":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Author", this.Author, reader);
                    this.Author.FromJson(reader);
                    break;
                case "CheckedOutByUser":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("CheckedOutByUser", this.CheckedOutByUser, reader);
                    this.CheckedOutByUser.FromJson(reader);
                    break;
                case "CheckInComment":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CheckInComment"] = reader.ReadString();
                    break;
                case "CheckOutType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CheckOutType"] = reader.ReadEnum<CheckOutType>();
                    break;
                case "ContentTag":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ContentTag"] = reader.ReadString();
                    break;
                case "CustomizedPageStatus":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["CustomizedPageStatus"] = reader.ReadEnum<CustomizedPageStatus>();
                    break;
                case "ListId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ListId"] = reader.ReadGuid();
                    break;
                case "EffectiveInformationRightsManagementSettings":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("EffectiveInformationRightsManagementSettings", this.EffectiveInformationRightsManagementSettings, reader);
                    this.EffectiveInformationRightsManagementSettings.FromJson(reader);
                    break;
                case "ETag":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ETag"] = reader.ReadString();
                    break;
                case "Exists":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Exists"] = reader.ReadBoolean();
                    break;
                case "InformationRightsManagementSettings":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("InformationRightsManagementSettings", this.InformationRightsManagementSettings, reader);
                    this.InformationRightsManagementSettings.FromJson(reader);
                    break;
                case "IrmEnabled":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["IrmEnabled"] = reader.ReadBoolean();
                    break;
                case "Length":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Length"] = reader.ReadInt64();
                    break;
                case "Level":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Level"] = reader.ReadEnum<FileLevel>();
                    break;
                case "LinkingUri":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LinkingUri"] = reader.ReadString();
                    break;
                case "LinkingUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["LinkingUrl"] = reader.ReadString();
                    break;
                case "ListItemAllFields":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ListItemAllFields", this.ListItemAllFields, reader);
                    this.ListItemAllFields.FromJson(reader);
                    break;
                case "LockedByUser":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("LockedByUser", this.LockedByUser, reader);
                    this.LockedByUser.FromJson(reader);
                    break;
                case "MajorVersion":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MajorVersion"] = reader.ReadInt32();
                    break;
                case "MinorVersion":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["MinorVersion"] = reader.ReadInt32();
                    break;
                case "ModifiedBy":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("ModifiedBy", this.ModifiedBy, reader);
                    this.ModifiedBy.FromJson(reader);
                    break;
                case "Name":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Name"] = reader.ReadString();
                    break;
                case "PageRenderType":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["PageRenderType"] = reader.ReadEnum<ListPageRenderType>();
                    break;
                case "Properties":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Properties", this.Properties, reader);
                    this.Properties.FromJson(reader);
                    break;
                case "ServerRelativePath":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerRelativePath"] = reader.Read<ResourcePath>();
                    break;
                case "ServerRelativeUrl":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["ServerRelativeUrl"] = reader.ReadString();
                    break;
                case "SiteId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["SiteId"] = reader.ReadGuid();
                    break;
                case "TimeCreated":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TimeCreated"] = reader.ReadDateTime();
                    break;
                case "TimeLastModified":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["TimeLastModified"] = reader.ReadDateTime();
                    break;
                case "Title":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["Title"] = reader.ReadString();
                    break;
                case "UIVersion":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UIVersion"] = reader.ReadInt32();
                    break;
                case "UIVersionLabel":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UIVersionLabel"] = reader.ReadString();
                    break;
                case "UniqueId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["UniqueId"] = reader.ReadGuid();
                    break;
                case "VersionEvents":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("VersionEvents", this.VersionEvents, reader);
                    this.VersionEvents.FromJson(reader);
                    break;
                case "Versions":
                    flag = true;
                    reader.ReadName();
                    base.UpdateClientObjectPropertyType("Versions", this.Versions, reader);
                    this.Versions.FromJson(reader);
                    break;
                case "WebId":
                    flag = true;
                    reader.ReadName();
                    base.ObjectData.Properties["WebId"] = reader.ReadGuid();
                    break;
            }
            return flag;
        }

        [Remote]
        public ClientResult<string> GetPreAuthorizedAccessUrl(int expirationHours)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetPreAuthorizedAccessUrl", new object[]
            {
                expirationHours
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<string> GetImagePreviewUrl(int width, int height, string clientType)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetImagePreviewUrl", new object[]
            {
                width,
                height,
                clientType
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<string> GetImagePreviewUri(int width, int height, string clientType)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetImagePreviewUri", new object[]
            {
                width,
                height,
                clientType
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<long> StartUpload(Guid uploadId, Stream stream)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "StartUpload", new object[]
            {
                uploadId,
                stream
            });
            context.AddQuery(clientAction);
            ClientResult<long> clientResult = new ClientResult<long>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public ClientResult<long> ContinueUpload(Guid uploadId, long fileOffset, Stream stream)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "ContinueUpload", new object[]
            {
                uploadId,
                fileOffset,
                stream
            });
            context.AddQuery(clientAction);
            ClientResult<long> clientResult = new ClientResult<long>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public File FinishUpload(Guid uploadId, long fileOffset, Stream stream)
        {
            ClientRuntimeContext context = base.Context;
            return new File(context, new ObjectPathMethod(context, base.Path, "FinishUpload", new object[]
            {
                uploadId,
                fileOffset,
                stream
            }));
        }

        [Remote]
        public void CancelUpload(Guid uploadId)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "CancelUpload", new object[]
            {
                uploadId
            });
            context.AddQuery(query);
        }

        [Remote]
        public UploadStatus GetUploadStatus(Guid uploadId)
        {
            ClientRuntimeContext context = base.Context;
            return new UploadStatus(context, new ObjectPathMethod(context, base.Path, "GetUploadStatus", new object[]
            {
                uploadId
            }));
        }

        [Remote]
        public void SaveBinary(FileSaveBinaryInformation parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && parameters == null)
            {
                throw ClientUtility.CreateArgumentNullException("parameters");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "SaveBinary", new object[]
            {
                parameters
            });
            context.AddQuery(query);
        }

        [Remote]
        public void DeleteObject()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "DeleteObject", null);
            context.AddQuery(query);
            base.RemoveFromParentCollection();
        }

        [Remote]
        public ClientResult<Guid> Recycle()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "Recycle", null);
            context.AddQuery(clientAction);
            ClientResult<Guid> clientResult = new ClientResult<Guid>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            base.RemoveFromParentCollection();
            return clientResult;
        }

        [Remote]
        public ClientResult<Stream> ExecuteCobaltRequest(Stream inputStream)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "ExecuteCobaltRequest", new object[]
            {
                inputStream
            });
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public void CheckOut()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "CheckOut", null);
            context.AddQuery(query);
        }

        [Remote]
        public void UndoCheckOut()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "UndoCheckOut", null);
            context.AddQuery(query);
        }

        [Remote]
        public void CheckIn(string comment, CheckinType checkInType)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && comment != null && comment.Length > 1023)
            {
                throw ClientUtility.CreateArgumentException("comment");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "CheckIn", new object[]
            {
                comment,
                checkInType
            });
            context.AddQuery(query);
        }

        [Remote]
        public void Publish(string comment)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && comment != null && comment.Length > 1023)
            {
                throw ClientUtility.CreateArgumentException("comment");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "Publish", new object[]
            {
                comment
            });
            context.AddQuery(query);
        }

        [Remote]
        public void UnPublish(string comment)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && comment != null && comment.Length > 1023)
            {
                throw ClientUtility.CreateArgumentException("comment");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "UnPublish", new object[]
            {
                comment
            });
            context.AddQuery(query);
        }

        [Remote]
        public void Approve(string comment)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Approve", new object[]
            {
                comment
            });
            context.AddQuery(query);
        }

        [Remote]
        public void Deny(string comment)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Deny", new object[]
            {
                comment
            });
            context.AddQuery(query);
        }

        [Remote]
        public static ClientResult<int> GetContentVerFromTag(ClientRuntimeContext context, string contentTag)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            ClientAction clientAction = new ClientActionInvokeStaticMethod(context, "{df28be1e-74b5-4b21-b73a-2bbac0a23d8a}", "GetContentVerFromTag", new object[]
            {
                contentTag
            });
            context.AddQuery(clientAction);
            ClientResult<int> clientResult = new ClientResult<int>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public LimitedWebPartManager GetLimitedWebPartManager(PersonalizationScope scope)
        {
            ClientRuntimeContext context = base.Context;
            object obj;
            Dictionary<PersonalizationScope, LimitedWebPartManager> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetLimitedWebPartManager", out obj))
            {
                dictionary = (Dictionary<PersonalizationScope, LimitedWebPartManager>)obj;
            }
            else
            {
                dictionary = new Dictionary<PersonalizationScope, LimitedWebPartManager>();
                base.ObjectData.MethodReturnObjects["GetLimitedWebPartManager"] = dictionary;
            }
            LimitedWebPartManager limitedWebPartManager = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(scope, out limitedWebPartManager))
            {
                return limitedWebPartManager;
            }
            limitedWebPartManager = new LimitedWebPartManager(context, new ObjectPathMethod(context, base.Path, "GetLimitedWebPartManager", new object[]
            {
                scope
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[scope] = limitedWebPartManager;
            }
            this.CheckScope(scope);
            return limitedWebPartManager;
        }

        [Remote]
        public ClientResult<string> GetWOPIFrameUrl(SPWOPIFrameAction action)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "GetWOPIFrameUrl", new object[]
            {
                action
            });
            context.AddQuery(clientAction);
            ClientResult<string> clientResult = new ClientResult<string>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }

        [Remote]
        public void Update()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "Update", null);
            context.AddQuery(query);
        }

        [Remote]
        public void MoveTo(string newUrl, MoveOperations flags)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (newUrl == null)
                {
                    throw ClientUtility.CreateArgumentNullException("newUrl");
                }
                Uri uri;
                if (newUrl != null && !Uri.TryCreate(newUrl, UriKind.RelativeOrAbsolute, out uri))
                {
                    throw ClientUtility.CreateArgumentException("newUrl");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "MoveTo", new object[]
            {
                newUrl,
                flags
            });
            context.AddQuery(query);
        }

        [Remote]
        public void MoveToUsingPath(ResourcePath newPath, MoveOperations moveOperations)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && newPath == null)
            {
                throw ClientUtility.CreateArgumentNullException("newPath");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "MoveToUsingPath", new object[]
            {
                newPath,
                moveOperations
            });
            context.AddQuery(query);
        }

        [Remote]
        public void CopyTo(string strNewUrl, bool bOverWrite)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (strNewUrl == null)
                {
                    throw ClientUtility.CreateArgumentNullException("strNewUrl");
                }
                Uri uri;
                if (strNewUrl != null && !Uri.TryCreate(strNewUrl, UriKind.RelativeOrAbsolute, out uri))
                {
                    throw ClientUtility.CreateArgumentException("strNewUrl");
                }
            }
            ClientAction query = new ClientActionInvokeMethod(this, "CopyTo", new object[]
            {
                strNewUrl,
                bOverWrite
            });
            context.AddQuery(query);
        }

        [Remote]
        public ClientResult<Stream> OpenBinaryStream()
        {
            ClientRuntimeContext context = base.Context;
            ClientAction clientAction = new ClientActionInvokeMethod(this, "OpenBinaryStream", null);
            context.AddQuery(clientAction);
            ClientResult<Stream> clientResult = new ClientResult<Stream>();
            context.AddQueryIdAndResultObject(clientAction.Id, clientResult);
            return clientResult;
        }
    }
}