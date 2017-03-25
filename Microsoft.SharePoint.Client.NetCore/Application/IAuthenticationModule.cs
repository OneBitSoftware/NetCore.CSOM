using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreApplication
{
    /// <summary>Provides the base authentication interface for Web client authentication modules.</summary>
    public interface IAuthenticationModule
    {
        /// <summary>Gets a value indicating whether the authentication module supports preauthentication.</summary>
        /// <returns>true if the authorization module supports preauthentication; otherwise false.</returns>
        bool CanPreAuthenticate
        {
            get;
        }

        /// <summary>Gets the authentication type provided by this authentication module.</summary>
        /// <returns>A string indicating the authentication type provided by this authentication module.</returns>
        string AuthenticationType
        {
            get;
        }

        /// <summary>Returns an instance of the <see cref="T:System.Net.Authorization" /> class in respose to an authentication challenge from a server.</summary>
        /// <returns>An <see cref="T:System.Net.Authorization" /> instance containing the authorization message for the request, or null if the challenge cannot be handled.</returns>
        /// <param name="challenge">The authentication challenge sent by the server. </param>
        /// <param name="request">The <see cref="T:System.Net.WebRequest" /> instance associated with the challenge. </param>
        /// <param name="credentials">The credentials associated with the challenge. </param>
        Authorization Authenticate(string challenge, WebRequest request, ICredentials credentials);

        /// <summary>Returns an instance of the <see cref="T:System.Net.Authorization" /> class for an authentication request to a server.</summary>
        /// <returns>An <see cref="T:System.Net.Authorization" /> instance containing the authorization message for the request.</returns>
        /// <param name="request">The <see cref="T:System.Net.WebRequest" /> instance associated with the authentication request. </param>
        /// <param name="credentials">The credentials associated with the authentication request. </param>
        Authorization PreAuthenticate(WebRequest request, ICredentials credentials);
    }
}
