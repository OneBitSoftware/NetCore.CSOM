using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Runtime;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    public static class ClientObjectQueryableExtension
    {
        internal const string IncludeMethodName = "Include";

        internal const string IncludeWithDefaultPropertiesName = "IncludeWithDefaultProperties";

        public static IQueryable<TSource> Include<TSource>(this IQueryable<TSource> clientObjects, params Expression<Func<TSource, object>>[] retrievals) where TSource : ClientObject
        {
            if (clientObjects == null)
            {
                throw new ArgumentNullException("clientObjects");
            }
            if (retrievals == null)
            {
                throw new ArgumentNullException("retrievals");
            }
            NewArrayExpression newArrayExpression = Expression.NewArrayInit(typeof(Expression<Func<TSource, object>>), (Expression[])retrievals);
            //Edited for .NET Core
            //return clientObjects.Provider.CreateQuery<TSource>(Expression.Call(null, ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(new Type[]
            //return clientObjects.Provider.CreateQuery<TSource>(Expression.Call(null, ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(new Type[]
            //{
            //    typeof(TSource)
            //}), new Expression[]
            //{
            //    clientObjects.Expression,
            //    newArrayExpression
            //}));
            throw new NotImplementedException("This is still not ported to .NET Core");
        }

        public static IQueryable<TSource> IncludeWithDefaultProperties<TSource>(this IQueryable<TSource> clientObjects, params Expression<Func<TSource, object>>[] retrievals) where TSource : ClientObject
        {
            if (clientObjects == null)
            {
                throw new ArgumentNullException("clientObjects");
            }
            if (retrievals == null)
            {
                throw new ArgumentNullException("retrievals");
            }
            NewArrayExpression newArrayExpression = Expression.NewArrayInit(typeof(Expression<Func<TSource, object>>), (Expression[])retrievals);
            //Edited for .NET Core
            //return clientObjects.Provider.CreateQuery<TSource>(Expression.Call(null, ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(new Type[]
            //return clientObjects.Provider.CreateQuery<TSource>(Expression.Call(null, ((MethodInfo)MethodBase.GetCurrentMethod()).MakeGenericMethod(new Type[]
            //{
            //    typeof(TSource)
            //}), new Expression[]
            //{
            //    clientObjects.Expression,
            //    newArrayExpression
            //}));

            throw new NotImplementedException("This is still not ported to .NET Core");
        }
    }
}
