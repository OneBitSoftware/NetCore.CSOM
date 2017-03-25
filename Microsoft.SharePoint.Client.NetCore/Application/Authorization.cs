using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCoreApplication
{


    /// <summary>Contains an authentication message for an Internet server.</summary>
    public class Authorization
    {
        private string m_Message;

        private bool m_Complete;

        private string[] m_ProtectionRealm;

        private string m_ConnectionGroupId;

        private bool m_MutualAuth;

        /// <summary>Gets the message returned to the server in response to an authentication challenge.</summary>
        /// <returns>The message that will be returned to the server in response to an authentication challenge.</returns>
        public string Message
        {
            get
            {
                return this.m_Message;
            }
        }

        /// <summary>Gets a unique identifier for user-specific connections.</summary>
        /// <returns>A unique string that associates a connection with an authenticating entity.</returns>
        public string ConnectionGroupId
        {
            get
            {
                return this.m_ConnectionGroupId;
            }
        }

        /// <summary>Gets the completion status of the authorization.</summary>
        /// <returns>true if the authentication process is complete; otherwise, false.</returns>
        public bool Complete
        {
            get
            {
                return this.m_Complete;
            }
        }

        /// <summary>Gets or sets the prefix for Uniform Resource Identifiers (URIs) that can be authenticated with the <see cref="P:System.Net.Authorization.Message" /> property.</summary>
        /// <returns>An array of strings that contains URI prefixes.</returns>
        public string[] ProtectionRealm
        {
            get
            {
                return this.m_ProtectionRealm;
            }
            set
            {
                string[] protectionRealm = ValidationHelper.MakeEmptyArrayNull(value);
                this.m_ProtectionRealm = protectionRealm;
            }
        }

        /// <summary>Gets or sets a <see cref="T:System.Boolean" /> value that indicates whether mutual authentication occurred.</summary>
        /// <returns>true if both client and server were authenticated; otherwise, false.</returns>
        public bool MutuallyAuthenticated
        {
            get
            {
                return this.Complete && this.m_MutualAuth;
            }
            set
            {
                this.m_MutualAuth = value;
            }
        }

        /// <summary>Creates a new instance of the <see cref="T:System.Net.Authorization" /> class with the specified authorization message.</summary>
        /// <param name="token">The encrypted authorization message expected by the server. </param>
        public Authorization(string token)
        {
            this.m_Message = ValidationHelper.MakeStringNull(token);
            this.m_Complete = true;
        }

        /// <summary>Creates a new instance of the <see cref="T:System.Net.Authorization" /> class with the specified authorization message and completion status.</summary>
        /// <param name="token">The encrypted authorization message expected by the server. </param>
        /// <param name="finished">The completion status of the authorization attempt. true if the authorization attempt is complete; otherwise, false. </param>
        public Authorization(string token, bool finished)
        {
            this.m_Message = ValidationHelper.MakeStringNull(token);
            this.m_Complete = finished;
        }

        /// <summary>Creates a new instance of the <see cref="T:System.Net.Authorization" /> class with the specified authorization message, completion status, and connection group identifier.</summary>
        /// <param name="token">The encrypted authorization message expected by the server. </param>
        /// <param name="finished">The completion status of the authorization attempt. true if the authorization attempt is complete; otherwise, false. </param>
        /// <param name="connectionGroupId">A unique identifier that can be used to create private client-server connections that are bound only to this authentication scheme. </param>
        public Authorization(string token, bool finished, string connectionGroupId) : this(token, finished, connectionGroupId, false)
        {
        }

        internal Authorization(string token, bool finished, string connectionGroupId, bool mutualAuth)
        {
            this.m_Message = ValidationHelper.MakeStringNull(token);
            this.m_ConnectionGroupId = ValidationHelper.MakeStringNull(connectionGroupId);
            this.m_Complete = finished;
            this.m_MutualAuth = mutualAuth;
        }

        internal void SetComplete(bool complete)
        {
            this.m_Complete = complete;
        }
    }
}