using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreApplication
{
    //[GeneratedCode("wsdl", "2.0.50727.42"), DesignerCategory("code"), DebuggerStepThrough, WebServiceBinding(Name = "AuthenticationSoap", Namespace = "http://schemas.microsoft.com/sharepoint/soap/")]
    //public class Authentication : SoapHttpClientProtocol
    //{
    //    private SendOrPostCallback LoginOperationCompleted;

    //    private SendOrPostCallback ModeOperationCompleted;

    //    public event LoginCompletedEventHandler LoginCompleted;

    //    public event ModeCompletedEventHandler ModeCompleted;

    //    public Authentication(Uri uri)
    //    {
    //        base.Url = uri.ToString();
    //        base.Credentials = CredentialCache.DefaultCredentials;
    //    }

    //    //[SoapDocumentMethod("http://schemas.microsoft.com/sharepoint/soap/Login", RequestNamespace = "http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace = "http://schemas.microsoft.com/sharepoint/soap/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    //    public LoginResult Login(string username, string password)
    //    {
    //        object[] array = base.Invoke("Login", new object[]
    //        {
    //            username,
    //            password
    //        });
    //        return (LoginResult)array[0];
    //    }

    //    public IAsyncResult BeginLogin(string username, string password, AsyncCallback callback, object asyncState)
    //    {
    //        return base.BeginInvoke("Login", new object[]
    //        {
    //            username,
    //            password
    //        }, callback, asyncState);
    //    }

    //    public LoginResult EndLogin(IAsyncResult asyncResult)
    //    {
    //        object[] array = base.EndInvoke(asyncResult);
    //        return (LoginResult)array[0];
    //    }

    //    public void LoginAsync(string username, string password)
    //    {
    //        this.LoginAsync(username, password, null);
    //    }

    //    public void LoginAsync(string username, string password, object userState)
    //    {
    //        if (this.LoginOperationCompleted == null)
    //        {
    //            this.LoginOperationCompleted = new SendOrPostCallback(this.OnLoginOperationCompleted);
    //        }
    //        base.InvokeAsync("Login", new object[]
    //        {
    //            username,
    //            password
    //        }, this.LoginOperationCompleted, userState);
    //    }

    //    private void OnLoginOperationCompleted(object arg)
    //    {
    //        if (this.LoginCompleted != null)
    //        {
    //            InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
    //            this.LoginCompleted(this, new LoginCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
    //        }
    //    }

    //    [SoapDocumentMethod("http://schemas.microsoft.com/sharepoint/soap/Mode", RequestNamespace = "http://schemas.microsoft.com/sharepoint/soap/", ResponseNamespace = "http://schemas.microsoft.com/sharepoint/soap/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
    //    public AuthenticationMode Mode()
    //    {
    //        object[] array = base.Invoke("Mode", new object[0]);
    //        return (AuthenticationMode)array[0];
    //    }

    //    public IAsyncResult BeginMode(AsyncCallback callback, object asyncState)
    //    {
    //        return base.BeginInvoke("Mode", new object[0], callback, asyncState);
    //    }

    //    public AuthenticationMode EndMode(IAsyncResult asyncResult)
    //    {
    //        object[] array = base.EndInvoke(asyncResult);
    //        return (AuthenticationMode)array[0];
    //    }

    //    public void ModeAsync()
    //    {
    //        this.ModeAsync(null);
    //    }

    //    public void ModeAsync(object userState)
    //    {
    //        if (this.ModeOperationCompleted == null)
    //        {
    //            this.ModeOperationCompleted = new SendOrPostCallback(this.OnModeOperationCompleted);
    //        }
    //        base.InvokeAsync("Mode", new object[0], this.ModeOperationCompleted, userState);
    //    }

    //    private void OnModeOperationCompleted(object arg)
    //    {
    //        if (this.ModeCompleted != null)
    //        {
    //            InvokeCompletedEventArgs invokeCompletedEventArgs = (InvokeCompletedEventArgs)arg;
    //            this.ModeCompleted(this, new ModeCompletedEventArgs(invokeCompletedEventArgs.Results, invokeCompletedEventArgs.Error, invokeCompletedEventArgs.Cancelled, invokeCompletedEventArgs.UserState));
    //        }
    //    }

    //    public new void CancelAsync(object userState)
    //    {
    //        base.CancelAsync(userState);
    //    }

    //    protected override WebRequest GetWebRequest(Uri uri)
    //    {
    //        WebRequest webRequest = base.GetWebRequest(uri);
    //        if (webRequest is HttpWebRequest)
    //        {
    //            HttpWebRequest httpWebRequest = (HttpWebRequest)webRequest;
    //            httpWebRequest.KeepAlive = false;
    //        }
    //        return webRequest;
    //    }
    //}
}
