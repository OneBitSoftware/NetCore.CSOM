using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal sealed class ClientQueryProvider : IQueryProvider
    {
        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            //Edited for .NET Core
            //if (!typeof(IQueryable<TElement>).IsAssignableFrom(expression.Type))
            if (!typeof(IQueryable<TElement>).GetTypeInfo().IsAssignableFrom(expression.Type))
            {
                throw new ArgumentOutOfRangeException("expression");
            }
            return new ClientQueryable<TElement>(this, expression);
        }

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            Type elementType = ExpressionUtility.GetElementType(expression.Type);
            if (elementType == null)
            {
                return null;
            }
            IQueryable result;
            try
            {
                object obj = Activator.CreateInstance(typeof(ClientQueryable<>).MakeGenericType(new Type[]
                {
                    elementType
                }), new object[]
                {
                    this,
                    expression
                });
                result = (IQueryable)obj;
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
            return result;
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            return ClientQueryProvider.ExecuteExpression<TResult>(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
        //Edited for .NET Core
            //MethodInfo methodInfo = base.GetType().GetMethod("ExecuteExpression", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(new Type[]
            MethodInfo methodInfo = base.GetType().GetTypeInfo().GetMethod("ExecuteExpression", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(new Type[]
            {
                expression.Type
            });
            return methodInfo.Invoke(null, new object[]
            {
                expression
            });
        }

        private static TResult ExecuteExpression<TResult>(Expression expression)
        {
            ReplaceQueryableCollectionWithEnumerableCollectionExpressionVisitor replaceQueryableCollectionWithEnumerableCollectionExpressionVisitor = new ReplaceQueryableCollectionWithEnumerableCollectionExpressionVisitor();
            Expression body = replaceQueryableCollectionWithEnumerableCollectionExpressionVisitor.Visit(expression);
            Expression<Func<TResult>> expression2 = Expression.Lambda<Func<TResult>>(body, null);
            return expression2.Compile()();
        }
    }
}
