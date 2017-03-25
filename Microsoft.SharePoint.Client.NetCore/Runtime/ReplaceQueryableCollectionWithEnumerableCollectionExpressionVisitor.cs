using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal sealed class ReplaceQueryableCollectionWithEnumerableCollectionExpressionVisitor : ExpressionVisitor
    {
        public override Expression VisitConstant(ConstantExpression exp)
        {
            if (exp.Value is ClientObjectCollection && exp.Value is IQueryable)
            {
                Type elementType = ExpressionUtility.GetElementType(exp.Value.GetType());
                Type type = typeof(EnumerableClientObjectCollection<>).MakeGenericType(new Type[]
                {
                    elementType
                });
                object obj = Activator.CreateInstance(type, new object[]
                {
                    exp.Value
                });
                Type type2 = typeof(EnumerableQuery<>).MakeGenericType(new Type[]
                {
                    elementType
                });
                object value = Activator.CreateInstance(type2, new object[]
                {
                    obj
                });
                return Expression.Constant(value);
            }
            return base.VisitConstant(exp);
        }
    }
}
