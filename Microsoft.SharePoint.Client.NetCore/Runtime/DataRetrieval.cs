using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal static class DataRetrieval
    {
        private class QueryProcessInfo
        {
            public Dictionary<long, ClientQueryInternal> BySelect = new Dictionary<long, ClientQueryInternal>();

            public Dictionary<long, ClientQueryInternal> ByInclude = new Dictionary<long, ClientQueryInternal>();

            public Dictionary<ClientQueryInternal, ChunkStringBuilder> Expression = new Dictionary<ClientQueryInternal, ChunkStringBuilder>();

            public void FinalProcess()
            {
                foreach (ClientQueryInternal current in this.BySelect.Values)
                {
                    if (!this.ByInclude.ContainsKey(current.Id))
                    {
                        current.SelectAllProperties();
                    }
                }
                foreach (KeyValuePair<ClientQueryInternal, ChunkStringBuilder> current2 in this.Expression)
                {
                    if (current2.Key.ChildItemFilterSet)
                    {
                        throw new InvalidQueryExpressionException();
                    }
                    current2.Key.ChildItemFilterExpression(current2.Value);
                }
            }
        }

        private class QueryMethodAggregator
        {
            private Expression m_exp;

            public int Where;

            public int Include;

            public int Take;

            public int Select;

            public int Member;

            public int OrderBy;

            public int OrderByDescending;

            public bool IsEmpty
            {
                get
                {
                    return this.Where == 0 && this.Include == 0 && this.Take == 0 && this.Select == 0 && this.Member == 0 && this.OrderBy == 0 && this.OrderByDescending == 0;
                }
            }

            public QueryMethodAggregator(Expression exp)
            {
                this.m_exp = exp;
            }

            public void Check()
            {
                if (this.Where <= 1 && this.Include <= 1 && this.Take <= 1 && this.OrderBy <= 1 && this.OrderByDescending <= 1)
                {
                    return;
                }
                if (this.m_exp == null)
                {
                    throw new InvalidQueryExpressionException();
                }
                throw new InvalidQueryExpressionException(Resources.GetString("NotSupportedQueryExpressionWithExpressionDetail", new object[]
                {
                    this.m_exp.ToString()
                }));
            }
        }

        internal static void Load<T>(T clientObject, params Expression<Func<T, object>>[] retrievals) where T : ClientObject
        {
            ClientObjectCollection clientObjectCollection = clientObject as ClientObjectCollection;
            if (retrievals == null || retrievals.Length == 0)
            {
                clientObject.Query.SelectAllProperties();
                if (clientObjectCollection != null)
                {
                    clientObject.Query.ChildItemQuery.SelectAllProperties();
                    return;
                }
            }
            else
            {
                DataRetrieval.QueryProcessInfo queryProcessInfo = new DataRetrieval.QueryProcessInfo();
                int num = 0;
                int num2 = 0;
                for (int i = 0; i < retrievals.Length; i++)
                {
                    Expression<Func<T, object>> expression = retrievals[i];
                    DataRetrieval.QueryMethodAggregator queryMethodAggregator = new DataRetrieval.QueryMethodAggregator(expression);
                    DataRetrieval.ProcessQueryExpression(clientObject.Query, clientObject, expression.Body, true, queryProcessInfo, queryMethodAggregator);
                    queryMethodAggregator.Check();
                    if (queryMethodAggregator.Where > 0 || queryMethodAggregator.Take > 0)
                    {
                        num++;
                        if (num > 1)
                        {
                            throw new InvalidQueryExpressionException();
                        }
                    }
                    num2 += queryMethodAggregator.Include;
                    if (queryMethodAggregator.IsEmpty)
                    {
                        clientObject.Query.SelectAllProperties();
                        if (clientObjectCollection != null)
                        {
                            clientObject.Query.ChildItemQuery.SelectAllProperties();
                        }
                    }
                }
                if (clientObjectCollection != null && num2 == 0)
                {
                    clientObject.Query.ChildItemQuery.SelectAllProperties();
                }
                queryProcessInfo.FinalProcess();
            }
        }

        internal static ClientQueryableResult<T> Retrieve<T>(ClientQueryable<T> clientQueryable) where T : ClientObject
        {
            Expression expression = clientQueryable.Expression;
            ClientQueryableResult<T> clientQueryableResult = new ClientQueryableResult<T>();
            ClientObject rootClientObjectForClientQueryableExpression = DataRetrieval.GetRootClientObjectForClientQueryableExpression(expression);
            if (rootClientObjectForClientQueryableExpression == null)
            {
                throw new InvalidQueryExpressionException();
            }
            ClientQueryInternal clientQueryInternal = new ClientQueryInternal(rootClientObjectForClientQueryableExpression, null, false, null);
            rootClientObjectForClientQueryableExpression.Context.AddQueryIdAndResultObject(clientQueryInternal.Id, clientQueryableResult);
            rootClientObjectForClientQueryableExpression.Context.AddQuery(clientQueryInternal);
            DataRetrieval.QueryProcessInfo queryProcessInfo = new DataRetrieval.QueryProcessInfo();
            DataRetrieval.QueryMethodAggregator queryMethodAggregator = new DataRetrieval.QueryMethodAggregator(expression);
            DataRetrieval.ProcessQueryExpression(clientQueryInternal, rootClientObjectForClientQueryableExpression, expression, false, queryProcessInfo, queryMethodAggregator);
            queryMethodAggregator.Check();
            if (queryMethodAggregator.Include == 0)
            {
                clientQueryInternal.ChildItemQuery.SelectAllProperties();
            }
            queryProcessInfo.FinalProcess();
            return clientQueryableResult;
        }

        private static ClientObject GetRootClientObjectForClientQueryableExpression(Expression exp)
        {
            ClientObject clientObject = null;
            ExpressionType nodeType = exp.NodeType;
            if (nodeType != ExpressionType.Call)
            {
                if (nodeType == ExpressionType.Constant)
                {
                    ConstantExpression constantExpression = (ConstantExpression)exp;
                    clientObject = (constantExpression.Value as ClientObject);
                    if (clientObject == null)
                    {
                        throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                    }
                }
            }
            else
            {
                MethodCallExpression methodCallExpression = (MethodCallExpression)exp;
                if (methodCallExpression.Object != null)
                {
                    clientObject = DataRetrieval.GetRootClientObjectForClientQueryableExpression(methodCallExpression.Object);
                }
                else
                {
                    if (methodCallExpression.Arguments.Count <= 0)
                    {
                        throw DataRetrieval.CreateInvalidQueryExpressionException(methodCallExpression);
                    }
                    clientObject = DataRetrieval.GetRootClientObjectForClientQueryableExpression(methodCallExpression.Arguments[0]);
                }
            }
            return clientObject;
        }

        private static ClientQueryInternal ProcessQueryExpression(ClientQueryInternal rootQuery, ClientObject rootClientObject, Expression exp, bool leaf, DataRetrieval.QueryProcessInfo queryInfo, DataRetrieval.QueryMethodAggregator aggregator)
        {
            ExpressionType nodeType = exp.NodeType;
            switch (nodeType)
            {
                case ExpressionType.Call:
                    {
                        ClientQueryInternal result = DataRetrieval.ProcessMethodCallQueryExpression(rootQuery, rootClientObject, (MethodCallExpression)exp, leaf, queryInfo, aggregator);
                        return result;
                    }
                case ExpressionType.Coalesce:
                case ExpressionType.Conditional:
                    break;
                case ExpressionType.Constant:
                    {
                        ConstantExpression constantExpression = (ConstantExpression)exp;
                        if (constantExpression.Value == rootClientObject)
                        {
                            ClientQueryInternal result = rootQuery;
                            return result;
                        }
                        throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                    }
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    {
                        UnaryExpression unaryExpression = (UnaryExpression)exp;
                        ClientQueryInternal result = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, unaryExpression.Operand, leaf, queryInfo, aggregator);
                        return result;
                    }
                default:
                    if (nodeType == ExpressionType.MemberAccess)
                    {
                        ClientQueryInternal result = DataRetrieval.ProcessMemberAccessQueryExpression(rootQuery, rootClientObject, (MemberExpression)exp, leaf, queryInfo, aggregator);
                        return result;
                    }
                    if (nodeType == ExpressionType.Parameter)
                    {
                        ClientQueryInternal result = rootQuery;
                        return result;
                    }
                    break;
            }
            throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
        }

        private static ClientQueryInternal ProcessMemberAccessQueryExpression(ClientQueryInternal rootQuery, ClientObject rootClientObject, MemberExpression exp, bool leaf, DataRetrieval.QueryProcessInfo queryInfo, DataRetrieval.QueryMethodAggregator aggregator)
        {
        //Edited for .NET Core
            //if (exp.Member.MemberType != MemberTypes.Property || exp.Member.GetCustomAttributes(typeof(RemoteAttribute), false).Length <= 0)
            if (exp.Member.MemberType != MemberTypes.Property || exp.Member.GetCustomAttributes(typeof(RemoteAttribute), false).Count() <= 0)
            {
                throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
            }
            ClientQueryInternal clientQueryInternal = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, exp.Expression, false, queryInfo, aggregator);
            aggregator.Member++;
            if (clientQueryInternal == null)
            {
                throw new InvalidQueryExpressionException();
            }
            ClientQueryInternal clientQueryInternal2;
            //if (typeof(ClientObject).IsAssignableFrom(exp.Type))
            if (typeof(ClientObject).GetTypeInfo().IsAssignableFrom(exp.Type))
            {
                clientQueryInternal2 = clientQueryInternal.GetSubQuery(exp.Member.Name);
                if (clientQueryInternal2 == null)
                {
                    clientQueryInternal2 = new ClientQueryInternal(null, exp.Member.Name, true, clientQueryInternal);
                    clientQueryInternal.SelectSubQuery(clientQueryInternal2);
                }
                if (leaf)
                {
                    clientQueryInternal.SelectWithAll(exp.Member.Name);
                }
            }
            else
            {
                clientQueryInternal.Select(exp.Member.Name);
                clientQueryInternal2 = null;
            }
            return clientQueryInternal2;
        }

        private static ClientQueryInternal ProcessMethodCallQueryExpression(ClientQueryInternal rootQuery, ClientObject rootClientObject, MethodCallExpression exp, bool leaf, DataRetrieval.QueryProcessInfo queryInfo, DataRetrieval.QueryMethodAggregator aggregator)
        {
            ClientQueryInternal result;
            if (exp.Method.IsGenericMethod && (exp.Method.DeclaringType == typeof(Enumerable) || exp.Method.DeclaringType == typeof(System.Linq.Queryable)))
            {
                result = DataRetrieval.ProcessClientQueryableMethodCallQueryExpression(rootQuery, rootClientObject, exp, leaf, queryInfo, aggregator);
            }
            else if (exp.Method.IsGenericMethod && exp.Method.DeclaringType == typeof(ClientObjectQueryableExtension) && (exp.Method.Name == "Include" || exp.Method.Name == "IncludeWithDefaultProperties"))
            {
                if (exp.Arguments.Count != 2)
                {
                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                }
                IEnumerable<Expression> enumerable = null;
                NewArrayExpression newArrayExpression = exp.Arguments[1] as NewArrayExpression;
                if (newArrayExpression == null)
                {
                    Expression expression = ExpressionEvaluator.PartialEvaluate(exp.Arguments[1], new Func<Expression, bool>(DataRetrieval.ExpectConstantExpression_CanExpressionBeEvaluated));
                    if (expression.NodeType == ExpressionType.Constant)
                    {
                        ConstantExpression constantExpression = (ConstantExpression)expression;
                        enumerable = (constantExpression.Value as IEnumerable<Expression>);
                    }
                    if (enumerable == null)
                    {
                        throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                    }
                }
                else
                {
                    enumerable = newArrayExpression.Expressions;
                }
                ClientQueryInternal clientQueryInternal = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, exp.Arguments[0], false, queryInfo, aggregator);
                aggregator.Include++;
                if (clientQueryInternal == null)
                {
                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                }
                queryInfo.ByInclude[clientQueryInternal.ChildItemQuery.Id] = clientQueryInternal.ChildItemQuery;
                ClientQueryInternal childItemQuery = clientQueryInternal.ChildItemQuery;
                if (exp.Method.Name == "IncludeWithDefaultProperties")
                {
                    childItemQuery.SelectAllProperties();
                }
                foreach (Expression current in enumerable)
                {
                    Expression expression2 = ExpressionUtility.StripQuotes(current);
                    LambdaExpression lambdaExpression = expression2 as LambdaExpression;
                    if (lambdaExpression == null)
                    {
                        expression2 = ExpressionEvaluator.PartialEvaluate(expression2, new Func<Expression, bool>(DataRetrieval.ExpectConstantExpression_CanExpressionBeEvaluated));
                        ConstantExpression constantExpression2 = expression2 as ConstantExpression;
                        if (constantExpression2 != null)
                        {
                            lambdaExpression = (constantExpression2.Value as LambdaExpression);
                        }
                        if (lambdaExpression == null)
                        {
                            throw DataRetrieval.CreateInvalidQueryExpressionException(expression2);
                        }
                    }
                    Expression exp2 = lambdaExpression.Body;
                    exp2 = ExpressionUtility.StripConverts(exp2);
                    DataRetrieval.QueryMethodAggregator queryMethodAggregator = new DataRetrieval.QueryMethodAggregator(current);
                    DataRetrieval.ProcessQueryExpression(childItemQuery, null, exp2, true, queryInfo, queryMethodAggregator);
                    queryMethodAggregator.Check();
                }
                result = clientQueryInternal;
            }
            else
            {
                if (!ExpressionUtility.IsGetFieldValueMethod(exp.Method))
                {
                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                }
                ClientQueryInternal clientQueryInternal2 = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, exp.Object, false, queryInfo, aggregator);
                aggregator.Member++;
                if (clientQueryInternal2 == null)
                {
                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                }
                Expression expression3 = exp.Arguments[0];
                expression3 = ExpressionEvaluator.PartialEvaluate(expression3, new Func<Expression, bool>(DataRetrieval.ExpectConstantExpression_CanExpressionBeEvaluated));
                if (expression3.NodeType != ExpressionType.Constant || expression3.Type != typeof(string))
                {
                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                }
                ConstantExpression constantExpression3 = (ConstantExpression)expression3;
                clientQueryInternal2.Select((string)constantExpression3.Value);
                result = null;
            }
            return result;
        }

        private static ClientQueryInternal ProcessClientQueryableMethodCallQueryExpression(
            ClientQueryInternal rootQuery, ClientObject rootClientObject,
            MethodCallExpression exp, bool leaf,
            DataRetrieval.QueryProcessInfo queryInfo, DataRetrieval.QueryMethodAggregator aggregator)
        {
            //Edited for .NET Core
            string name;
            if ((name = exp.Method.Name) != null)
            {
                //Edited for .NET Core
                // This was bugged when reflecting the source, wo it needs checking
                    var newDictionary = new Dictionary<string, int>(8)
                    {
                        {
                            "Where",
                            0
                        },
                        {
                            "OrderBy",
                            1
                        },
                        {
                            "OrderByDescending",
                            2
                        },
                        {
                            "ThenBy",
                            3
                        },
                        {
                            "ThenByDescending",
                            4
                        },
                        {
                            "Select",
                            5
                        },
                        {
                            "Take",
                            6
                        },
                        {
                            "OfType",
                            7
                        }
                    };
                int num;
                if (newDictionary.TryGetValue(name, out num))
				{
                    ClientQueryInternal result;
                    switch (num)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                            {
                                ClientQueryInternal clientQueryInternal = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, exp.Arguments[0], leaf, queryInfo, aggregator);
                                string name2;
                                if ((name2 = exp.Method.Name) != null)
                                {
                                    if (!(name2 == "Where"))
                                    {
                                        if (!(name2 == "OrderBy"))
                                        {
                                            if (name2 == "OrderByDescending")
                                            {
                                                aggregator.OrderByDescending++;
                                            }
                                        }
                                        else
                                        {
                                            aggregator.OrderBy++;
                                        }
                                    }
                                    else
                                    {
                                        aggregator.Where++;
                                    }
                                }
                                Expression expression = ExpressionUtility.StripQuotes(exp.Arguments[1]);
                                LambdaExpression lambdaExpression = expression as LambdaExpression;
                                if (lambdaExpression == null)
                                {
                                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                                }
                                ChunkStringBuilder chunkStringBuilder = new ChunkStringBuilder();
                                XmlWriter xmlWriter = chunkStringBuilder.CreateXmlWriter();
                                string name3;
                                if ((name3 = exp.Method.Name) != null)
                                {
                                    if (!(name3 == "Where"))
                                    {
                                        if (!(name3 == "OrderBy"))
                                        {
                                            if (!(name3 == "OrderByDescending"))
                                            {
                                                if (!(name3 == "ThenBy"))
                                                {
                                                    if (!(name3 == "ThenByDescending"))
                                                    {
                                                        goto IL_224;
                                                    }
                                                    xmlWriter.WriteStartElement("ThenByDescending");
                                                }
                                                else
                                                {
                                                    xmlWriter.WriteStartElement("ThenBy");
                                                }
                                            }
                                            else
                                            {
                                                xmlWriter.WriteStartElement("OrderByDescending");
                                            }
                                        }
                                        else
                                        {
                                            xmlWriter.WriteStartElement("OrderBy");
                                        }
                                    }
                                    else
                                    {
                                        xmlWriter.WriteStartElement("Where");
                                    }
                                    ClientQueryInternal.WriteFilterExpressionToXml(xmlWriter, clientQueryInternal.ChildItemQuery.ChildItemExpressionSerializationContext, lambdaExpression);
                                    xmlWriter.WriteStartElement("Object");
                                    ChunkStringBuilder chunkStringBuilder2 = null;
                                    if (queryInfo.Expression.TryGetValue(clientQueryInternal.ChildItemQuery, out chunkStringBuilder2))
                                    {
                                        chunkStringBuilder2.WriteContentAsRawXml(xmlWriter);
                                    }
                                    else
                                    {
                                        xmlWriter.WriteStartElement("QueryableObject");
                                        xmlWriter.WriteEndElement();
                                    }
                                    xmlWriter.WriteEndElement();
                                    xmlWriter.WriteEndElement();
                                    xmlWriter.Dispose();
                                    queryInfo.Expression[clientQueryInternal.ChildItemQuery] = chunkStringBuilder;
                                    result = clientQueryInternal;
                                    break;
                                }
                                IL_224:
                                throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                            }
                        case 5:
                            {
                                DataRetrieval.CheckSelectExpression(exp);
                                ClientQueryInternal clientQueryInternal2 = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, exp.Arguments[0], leaf, queryInfo, aggregator);
                                aggregator.Select++;
                                result = clientQueryInternal2;
                                queryInfo.BySelect[clientQueryInternal2.ChildItemQuery.Id] = clientQueryInternal2.ChildItemQuery;
                                break;
                            }
                        case 6:
                            {
                                ClientQueryInternal clientQueryInternal3 = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, exp.Arguments[0], leaf, queryInfo, aggregator);
                                aggregator.Take++;
                                Expression expression2 = exp.Arguments[1];
                                expression2 = ExpressionEvaluator.PartialEvaluate(expression2, new Func<Expression, bool>(DataRetrieval.ExpectConstantExpression_CanExpressionBeEvaluated));
                                if (expression2.NodeType != ExpressionType.Constant || expression2.Type != typeof(int))
                                {
                                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                                }
                                ConstantExpression constantExpression = (ConstantExpression)expression2;
                                int num2 = (int)constantExpression.Value;
                                if (num2 < 0)
                                {
                                    throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
                                }
                                ChunkStringBuilder chunkStringBuilder3 = new ChunkStringBuilder();
                                XmlWriter xmlWriter2 = chunkStringBuilder3.CreateXmlWriter();
                                xmlWriter2.WriteStartElement("Take");
                                xmlWriter2.WriteAttributeString("Count", num2.ToString(CultureInfo.InvariantCulture));
                                ChunkStringBuilder chunkStringBuilder4 = null;
                                if (queryInfo.Expression.TryGetValue(clientQueryInternal3.ChildItemQuery, out chunkStringBuilder4))
                                {
                                    chunkStringBuilder4.WriteContentAsRawXml(xmlWriter2);
                                }
                                else
                                {
                                    xmlWriter2.WriteStartElement("QueryableObject");
                                    xmlWriter2.WriteEndElement();
                                }
                                xmlWriter2.WriteEndElement();
                                xmlWriter2.Dispose();
                                queryInfo.Expression[clientQueryInternal3.ChildItemQuery] = chunkStringBuilder3;
                                result = clientQueryInternal3;
                                break;
                            }
                        case 7:
                            {
                                ClientQueryInternal clientQueryInternal4 = DataRetrieval.ProcessQueryExpression(rootQuery, rootClientObject, exp.Arguments[0], leaf, queryInfo, aggregator);
                                if (!exp.Method.IsGenericMethod || exp.Method.ContainsGenericParameters)
                                {
                                    throw new InvalidQueryExpressionException(Resources.GetString("NotSupportedQueryExpressionWithExpressionValue", new object[]
                                    {
                                exp.ToString()
                                    }));
                                }
                                Type[] genericArguments = exp.Method.GetGenericArguments();
                                if (genericArguments == null || genericArguments.Length != 1)
                                {
                                    throw new InvalidQueryExpressionException(Resources.GetString("NotSupportedQueryExpressionWithExpressionValue", new object[]
                                    {
                                exp.ToString()
                                    }));
                                }
                                string value = null;
                                string value2 = null;
                                DataConvert.GetTypeNameOrTypeId(genericArguments[0], out value, out value2);
                                if (string.IsNullOrEmpty(value) && string.IsNullOrEmpty(value2))
                                {
                                    throw new InvalidQueryExpressionException(Resources.GetString("NotSupportedQueryExpressionWithExpressionValue", new object[]
                                    {
                                exp.ToString()
                                    }));
                                }
                                ChunkStringBuilder chunkStringBuilder5 = new ChunkStringBuilder();
                                XmlWriter xmlWriter3 = chunkStringBuilder5.CreateXmlWriter();
                                xmlWriter3.WriteStartElement("OfType");
                                if (!string.IsNullOrEmpty(value))
                                {
                                    xmlWriter3.WriteAttributeString("Type", value);
                                }
                                else
                                {
                                    xmlWriter3.WriteAttributeString("TypeId", value2);
                                }
                                ChunkStringBuilder chunkStringBuilder6 = null;
                                if (queryInfo.Expression.TryGetValue(clientQueryInternal4.ChildItemQuery, out chunkStringBuilder6))
                                {
                                    chunkStringBuilder6.WriteContentAsRawXml(xmlWriter3);
                                }
                                else
                                {
                                    xmlWriter3.WriteStartElement("QueryableObject");
                                    xmlWriter3.WriteEndElement();
                                }
                                xmlWriter3.WriteEndElement();
                                xmlWriter3.Dispose();
                                queryInfo.Expression[clientQueryInternal4.ChildItemQuery] = chunkStringBuilder5;
                                result = clientQueryInternal4;
                                break;
                            }
                        default:
                            goto IL_5B7;
                    }
                    return result;
                }
            }
            IL_5B7:
            throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
        }

        private static void CheckSelectExpression(MethodCallExpression exp)
        {
            if (exp.Arguments.Count != 2)
            {
                throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
            }
            Expression expression = ExpressionUtility.StripQuotes(exp.Arguments[1]);
            LambdaExpression lambdaExpression = expression as LambdaExpression;
            if (lambdaExpression == null || lambdaExpression.Parameters.Count != 1)
            {
                throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
            }
            Expression expression2 = ExpressionUtility.StripConverts(ExpressionUtility.StripQuotes(lambdaExpression.Body));
            ParameterExpression parameterExpression = expression2 as ParameterExpression;
            if (parameterExpression == null || parameterExpression.Name != lambdaExpression.Parameters[0].Name)
            {
                throw DataRetrieval.CreateInvalidQueryExpressionException(exp);
            }
        }

        private static bool ExpectConstantExpression_CanExpressionBeEvaluated(Expression exp)
        {
            if (exp == null)
            {
                return true;
            }
            if (exp.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)exp;
                //Edited for .NET Core
                //if (!Attribute.IsDefined(memberExpression.Member, typeof(RemoteAttribute)) && !Attribute.IsDefined(memberExpression.Member, typeof(PseudoRemoteAttribute)))
                if (memberExpression.Member.GetCustomAttribute<RemoteAttribute>() == null || memberExpression.Member.GetCustomAttribute<PseudoRemoteAttribute>() == null)
                {
                    return true;
                }
            }
            return exp.NodeType == ExpressionType.Constant || exp.NodeType == ExpressionType.Convert || exp.NodeType == ExpressionType.ConvertChecked;
        }

        private static InvalidQueryExpressionException CreateInvalidQueryExpressionException(Expression exp)
        {
            if (exp == null)
            {
                return new InvalidQueryExpressionException();
            }
            return new InvalidQueryExpressionException(Resources.GetString("NotSupportedQueryExpressionWithExpressionValue", new object[]
            {
                exp.ToString()
            }));
        }
    }
}