using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal static class ExpressionUtility
    {
        public static Expression StripQuotes(Expression exp)
        {
            while (exp != null && exp.NodeType == ExpressionType.Quote)
            {
                exp = ((UnaryExpression)exp).Operand;
            }
            return exp;
        }

        public static Expression StripConverts(Expression exp)
        {
            while (exp != null && exp.NodeType == ExpressionType.Convert)
            {
                exp = ((UnaryExpression)exp).Operand;
            }
            return exp;
        }

        public static bool IsGetFieldValueMethod(MethodInfo method)
        {
            //Edited for .NET Core
            //PseudoRemoteAttribute pseudoRemoteAttribute = (PseudoRemoteAttribute)Attribute.GetCustomAttribute(method, typeof(PseudoRemoteAttribute));
            PseudoRemoteAttribute pseudoRemoteAttribute = method.GetCustomAttribute<PseudoRemoteAttribute>();
            return pseudoRemoteAttribute != null && pseudoRemoteAttribute.Name == "GetFieldValue";
        }

        internal static Type GetElementType(Type seqType)
        {
            Type type = ExpressionUtility.FindIEnumerable(seqType);
            if (type == null)
            {
                return null;
            }
            //Edited for .NET Core
            //return type.GetGenericArguments()[0];
            return type.GenericTypeArguments[0];
        }

        private static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
            {
                return null;
            }
            if (seqType.IsArray)
            {
                return typeof(IEnumerable<>).MakeGenericType(new Type[]
                {
                    seqType.GetElementType()
                });
            }
            //Edited for .NET Core
            //if (seqType.IsGenericType)
            if (seqType.GetTypeInfo().IsGenericType)
            {
                //Edited for .NET Core
                //Type[] genericArguments = seqType.GetGenericArguments();
                Type[] genericArguments = seqType.GenericTypeArguments.ToArray();
                for (int i = 0; i < genericArguments.Length; i++)
                {
                    Type type = genericArguments[i];
                    Type type2 = typeof(IEnumerable<>).MakeGenericType(new Type[]
                    {
                        type
                    });
                    //Edited for .NET Core
                    //if (type2.IsAssignableFrom(seqType))

                    if (type2.GetTypeInfo().IsAssignableFrom(seqType))
                    {
                        Type result = type2;
                        return result;
                    }
                }
            }
                    //Edited for .NET Core
            //Type[] interfaces = seqType.GetInterfaces();
            Type[] interfaces = seqType.GetTypeInfo().GetInterfaces();
            if (interfaces != null && interfaces.Length > 0)
            {
                Type[] array = interfaces;
                for (int j = 0; j < array.Length; j++)
                {
                    Type seqType2 = array[j];
                    Type type3 = ExpressionUtility.FindIEnumerable(seqType2);
                    if (type3 != null)
                    {
                        Type result = type3;
                        return result;
                    }
                }
            }
                    //Edited for .NET Core
            //if (seqType.BaseType != null && seqType.BaseType != typeof(object))
            if (seqType.GetTypeInfo().BaseType != null && seqType.GetTypeInfo().BaseType != typeof(object))
            {
                    //Edited for .NET Core
                //return ExpressionUtility.FindIEnumerable(seqType.BaseType);
                return ExpressionUtility.FindIEnumerable(seqType.GetTypeInfo().BaseType);
            }
            return null;
        }
    }
}
