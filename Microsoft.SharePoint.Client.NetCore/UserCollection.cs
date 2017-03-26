using Microsoft.SharePoint.Client.NetCore.Runtime;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore
{
    [ScriptType("SP.UserCollection", ServerTypeId = "{e090781e-8899-4672-9b3d-a78f49fad19d}")]
    public class UserCollection : ClientObjectCollection<User>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public UserCollection(ClientRuntimeContext context, ObjectPath objectPath) : base(context, objectPath)
        {
        }

        [Remote]
        public User GetByLoginName(string loginName)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (loginName == null)
                {
                    throw ClientUtility.CreateArgumentNullException("loginName");
                }
                if (loginName != null && loginName.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("loginName");
                }
                if (loginName != null && loginName.Length > 251)
                {
                    throw ClientUtility.CreateArgumentException("loginName");
                }
            }
            object obj;
            Dictionary<string, User> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByLoginName", out obj))
            {
                dictionary = (Dictionary<string, User>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);
                base.ObjectData.MethodReturnObjects["GetByLoginName"] = dictionary;
            }
            User user = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(loginName, out user))
            {
                return user;
            }
            user = new User(context, new ObjectPathMethod(context, base.Path, "GetByLoginName", new object[]
            {
                loginName
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[loginName] = user;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(user.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, user);
            context.AddQuery(objectIdentityQuery);
            return user;
        }

        [Remote]
        public User GetById(int id)
        {
            ClientRuntimeContext context = base.Context;
            return new User(context, new ObjectPathMethod(context, base.Path, "GetById", new object[]
            {
                id
            }));
        }

        [Remote]
        public User GetByEmail(string emailAddress)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (emailAddress == null)
                {
                    throw ClientUtility.CreateArgumentNullException("emailAddress");
                }
                if (emailAddress != null && emailAddress.Length == 0)
                {
                    throw ClientUtility.CreateArgumentException("emailAddress");
                }
                if (emailAddress != null && emailAddress.Length > 255)
                {
                    throw ClientUtility.CreateArgumentException("emailAddress");
                }
            }
            object obj;
            Dictionary<string, User> dictionary;
            if (base.ObjectData.MethodReturnObjects.TryGetValue("GetByEmail", out obj))
            {
                dictionary = (Dictionary<string, User>)obj;
            }
            else
            {
                dictionary = new Dictionary<string, User>();
                base.ObjectData.MethodReturnObjects["GetByEmail"] = dictionary;
            }
            User user = null;
            if (!context.DisableReturnValueCache && dictionary.TryGetValue(emailAddress, out user))
            {
                return user;
            }
            user = new User(context, new ObjectPathMethod(context, base.Path, "GetByEmail", new object[]
            {
                emailAddress
            }));
            if (!context.DisableReturnValueCache)
            {
                dictionary[emailAddress] = user;
            }
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(user.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, user);
            context.AddQuery(objectIdentityQuery);
            return user;
        }

        [Remote]
        public void RemoveByLoginName(string loginName)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RemoveByLoginName", new object[]
            {
                loginName
            });
            context.AddQuery(query);
        }

        [Remote]
        public void RemoveById(int id)
        {
            ClientRuntimeContext context = base.Context;
            ClientAction query = new ClientActionInvokeMethod(this, "RemoveById", new object[]
            {
                id
            });
            context.AddQuery(query);
        }

        [Remote]
        public void Remove(User user)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient && user == null)
            {
                throw ClientUtility.CreateArgumentNullException("user");
            }
            ClientAction query = new ClientActionInvokeMethod(this, "Remove", new object[]
            {
                user
            });
            context.AddQuery(query);
            base.RemoveChild(user);
        }

        [Remote]
        public User Add(UserCreationInformation parameters)
        {
            ClientRuntimeContext context = base.Context;
            if (base.Context.ValidateOnClient)
            {
                if (parameters == null)
                {
                    throw ClientUtility.CreateArgumentNullException("parameters");
                }
                if (parameters != null)
                {
                    if (parameters.LoginName == null)
                    {
                        throw ClientUtility.CreateArgumentNullException("parameters.LoginName");
                    }
                    if (parameters.LoginName != null && parameters.LoginName.Length == 0)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.LoginName");
                    }
                    if (parameters.LoginName != null && parameters.LoginName.Length > 251)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.LoginName");
                    }
                    if (parameters.Title != null && parameters.Title.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Title");
                    }
                    if (parameters.Email != null && parameters.Email.Length > 255)
                    {
                        throw ClientUtility.CreateArgumentException("parameters.Email");
                    }
                }
            }
            User user = new User(context, new ObjectPathMethod(context, base.Path, "Add", new object[]
            {
                parameters
            }));
            user.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(user.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, user);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(user);
            user.InitFromCreationInformation(parameters);
            return user;
        }

        [Remote]
        public User AddUser(User user)
        {
            ClientRuntimeContext context = base.Context;
            User user2 = new User(context, new ObjectPathMethod(context, base.Path, "AddUser", new object[]
            {
                user
            }));
            user2.Path.SetPendingReplace();
            ObjectIdentityQuery objectIdentityQuery = new ObjectIdentityQuery(user2.Path);
            context.AddQueryIdAndResultObject(objectIdentityQuery.Id, user2);
            context.AddQuery(objectIdentityQuery);
            base.AddChild(user2);
            return user2;
        }
    }
}
