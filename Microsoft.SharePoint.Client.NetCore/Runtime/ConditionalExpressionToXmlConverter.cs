using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ConditionalExpressionToXmlConverter
    {
        private class NotSupportedExpressionChecker : ExpressionVisitor
        {
            private Dictionary<string, Type> m_allowedParameters;

            public NotSupportedExpressionChecker(Dictionary<string, Type> allowedParameters)
            {
                this.m_allowedParameters = allowedParameters;
            }

            public override Expression VisitMemberAccess(MemberExpression m)
            {
                //Edited for .NET Core
                //if (!Attribute.IsDefined(m.Member, typeof(RemoteAttribute)) && !Attribute.IsDefined(m.Member, typeof(PseudoRemoteAttribute)) && m.Expression != null)
                //{
                //    bool flag = false;
                //    if (m.Member.MemberType == MemberTypes.Property && typeof(ClientRuntimeContext).IsAssignableFrom(m.Expression.Type) && typeof(ClientObject).IsAssignableFrom(m.Type))
                //    {
                //        flag = true;
                //    }
                //    else if (ConditionalExpressionToXmlConverter.IsClientResultValueExpression(m))
                //    {
                //        flag = true;
                //    }
                //    else if (ConditionalExpressionToXmlConverter.IsServerObjectIsNullValue(m))
                //    {
                //        flag = true;
                //    }
                //    else if (m.Member.MemberType == MemberTypes.Field)
                //    {
                //        flag = true;
                //    }
                //    if (!flag)
                //    {
                //        throw new ClientRequestException(Resources.GetString("NotSupportedMemberInExpression", new object[]
                //        {
                //            m.Member.Name
                //        }));
                //    }
                //}
                return base.VisitMemberAccess(m);
            }

            public override Expression VisitMethodCall(MethodCallExpression m)
            {
                //Edited for .NET Core
                //if (!Attribute.IsDefined(m.Method, typeof(RemoteAttribute)) && !Attribute.IsDefined(m.Method, typeof(PseudoRemoteAttribute)))
                //{
                //    throw new ClientRequestException(Resources.GetString("NotSupportedMemberInExpression", new object[]
                //    {
                //        m.Method.Name
                //    }));
                //}
                return base.VisitMethodCall(m);
            }

            public override Expression VisitParameter(ParameterExpression p)
            {
                if (this.m_allowedParameters == null || !this.m_allowedParameters.ContainsKey(p.Name) || this.m_allowedParameters[p.Name] != p.Type)
                {
                    throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
                    {
                        p.ToString()
                    }));
                }
                return base.VisitParameter(p);
            }
        }

        private static Dictionary<ExpressionType, string> s_opNames;

        private Expression m_condition;

        private XmlWriter m_writer;

        private SerializationContext m_serializationContext;

        private Dictionary<string, Type> m_allowedParameters;

        static ConditionalExpressionToXmlConverter()
        {
            ConditionalExpressionToXmlConverter.s_opNames = new Dictionary<ExpressionType, string>();
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.GreaterThan] = "GT";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.LessThan] = "LT";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.Equal] = "EQ";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.NotEqual] = "NE";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.GreaterThanOrEqual] = "GE";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.LessThanOrEqual] = "LE";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.AndAlso] = "AND";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.OrElse] = "OR";
            ConditionalExpressionToXmlConverter.s_opNames[ExpressionType.Not] = "NOT";
        }

        public ConditionalExpressionToXmlConverter(Expression condition, XmlWriter writer, Dictionary<string, Type> allowedParameters, SerializationContext serializationContext)
        {
            this.m_condition = condition;
            this.m_writer = writer;
            this.m_allowedParameters = allowedParameters;
            this.m_serializationContext = serializationContext;
        }

        public void Convert()
        {
            Expression exp = this.m_condition;
            ConditionalExpressionToXmlConverter.NotSupportedExpressionChecker notSupportedExpressionChecker = new ConditionalExpressionToXmlConverter.NotSupportedExpressionChecker(this.m_allowedParameters);
            exp = notSupportedExpressionChecker.Visit(exp);
            exp = ExpressionEvaluator.PartialEvaluate(exp, new Func<Expression, bool>(ConditionalExpressionToXmlConverter.CanBeEvaluated));
            this.Write(exp);
        }

        private static bool CanBeEvaluated(Expression exp)
        {
            if (exp == null)
            {
                return true;
            }
            bool result = true;
            if (exp.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)exp;
                //Edited for .NET Core
                //bool flag = Attribute.IsDefined(memberExpression.Member, typeof(RemoteAttribute)) || Attribute.IsDefined(memberExpression.Member, typeof(PseudoRemoteAttribute));
                bool flag = false;
                if (flag)
                {
                    result = false;
                }
                else if (ConditionalExpressionToXmlConverter.IsClientResultValueExpression(memberExpression) || ConditionalExpressionToXmlConverter.IsServerObjectIsNullValue(memberExpression))
                {
                    result = false;
                }
            }
            else if (exp.NodeType == ExpressionType.Call)
            {
                MethodCallExpression methodCallExpression = (MethodCallExpression)exp;
                //Edited for .NET Core
                //bool flag2 = Attribute.IsDefined(methodCallExpression.Method, typeof(RemoteAttribute)) || Attribute.IsDefined(methodCallExpression.Method, typeof(PseudoRemoteAttribute));
                bool flag2 = false;
                if (flag2)
                {
                    result = false;
                }
            }
            else if (exp.NodeType == ExpressionType.Parameter)
            {
                result = false;
            }
            return result;
        }

        //Edited for .NET Core
        private void Write(Expression exp)
        {
            ExpressionType nodeType = exp.NodeType;
            switch (nodeType)
            {
                case ExpressionType.AndAlso:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                    break;
                case ExpressionType.ArrayLength:
                case ExpressionType.ArrayIndex:
                case ExpressionType.Coalesce:
                case ExpressionType.Conditional:
                case ExpressionType.Divide:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.Invoke:
                case ExpressionType.Lambda:
                case ExpressionType.LeftShift:
                case ExpressionType.ListInit:
                    goto IL_71A;
                case ExpressionType.Call:
                    {
                        MethodCallExpression methodCallExpression = (MethodCallExpression)exp;
                        bool flag = false;
                        if (methodCallExpression.Object == null)
                        {
                            flag = true;
                            this.m_writer.WriteStartElement("ExpressionStaticMethod");
                            string serverTypeId = ConditionalExpressionToXmlConverter.GetServerTypeId(methodCallExpression.Method.DeclaringType);
                            if (string.IsNullOrEmpty(serverTypeId))
                            {
                                throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
                                {
                            this.m_condition.ToString()
                                }));
                            }
                            this.m_writer.WriteAttributeString("TypeId", serverTypeId);
                            this.m_writer.WriteAttributeString("Name", ConditionalExpressionToXmlConverter.GetMemberName(methodCallExpression.Method));
                        }
                        else
                        {
                            this.m_writer.WriteStartElement("ExpressionMethod");
                            this.m_writer.WriteAttributeString("Name", ConditionalExpressionToXmlConverter.GetMemberName(methodCallExpression.Method));
                            this.Write(methodCallExpression.Object);
                        }
                        this.m_writer.WriteStartElement("Parameters");
                        foreach (Expression current in methodCallExpression.Arguments)
                        {
                            if (flag)
                            {
                                flag = false;
                            }
                            else
                            {
                                this.Write(current);
                            }
                        }
                        this.m_writer.WriteEndElement();
                        this.m_writer.WriteEndElement();
                        return;
                    }
                case ExpressionType.Constant:
                    {
                        ConstantExpression constantExpression = (ConstantExpression)exp;
                        object value = constantExpression.Value;

                        //Edited for .NET Core
                        //if (value == null || value is ClientObject || value is ClientValueObject || value.GetType().IsPrimitive || value.GetType().IsEnum || value.GetType() == typeof(Guid) || value.GetType() == typeof(DateTime) || value.GetType() == typeof(string))
                        if (value == null || value is ClientObject || value is ClientValueObject || value.GetType().GetTypeInfo().IsPrimitive || value.GetType().GetTypeInfo().IsEnum || value.GetType() == typeof(Guid) || value.GetType() == typeof(DateTime) || value.GetType() == typeof(string))
                        {
                            this.m_writer.WriteStartElement("ExpressionConstant");
                            DataConvert.WriteValueToXmlElement(this.m_writer, value, this.m_serializationContext);
                            this.m_writer.WriteEndElement();
                            return;
                        }
                        throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
                        {
                    this.m_condition.ToString()
                        }));
                    }
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                    {
                        UnaryExpression unaryExpression = (UnaryExpression)exp;
                        string value2 = null;
                        string value3 = null;
                        DataConvert.GetTypeNameOrTypeId(unaryExpression.Type, out value2, out value3);
                        if (!string.IsNullOrEmpty(value2))
                        {
                            this.m_writer.WriteStartElement("ExpressionConvert");
                            this.m_writer.WriteAttributeString("Type", value2);
                            this.Write(unaryExpression.Operand);
                            this.m_writer.WriteEndElement();
                            return;
                        }
                        if (string.IsNullOrEmpty(value3))
                        {
                            throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
                            {
                        this.m_condition.ToString()
                            }));
                        }
                        if (this.m_serializationContext.Context.RequestSchemaVersion >= ClientSchemaVersions.Version15)
                        {
                            this.m_writer.WriteStartElement("ExpressionConvert");
                            this.m_writer.WriteAttributeString("TypeId", value3);
                            this.Write(unaryExpression.Operand);
                            this.m_writer.WriteEndElement();
                            return;
                        }
                        this.Write(unaryExpression.Operand);
                        return;
                    }
                case ExpressionType.Equal:
                    goto IL_D7;
                case ExpressionType.MemberAccess:
                    {
                        MemberExpression memberExpression = (MemberExpression)exp;
                        if (!(memberExpression.Member is PropertyInfo))
                        {
                            throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
                            {
                        this.m_condition.ToString()
                            }));
                        }
                        if (ConditionalExpressionToXmlConverter.IsClientResultValueExpression(memberExpression))
                        {
                            this.Write(memberExpression.Expression);
                            return;
                        }
                        if (ConditionalExpressionToXmlConverter.IsServerObjectIsNullValue(memberExpression))
                        {
                            this.Write(memberExpression.Expression);
                            return;
                        }
                        if (memberExpression.Expression != null)
                        {
                            this.m_writer.WriteStartElement("ExpressionProperty");
                            this.m_writer.WriteAttributeString("Name", ConditionalExpressionToXmlConverter.GetMemberName(memberExpression.Member));
                            this.Write(memberExpression.Expression);
                            this.m_writer.WriteEndElement();
                            return;
                        }
                        this.m_writer.WriteStartElement("ExpressionStaticProperty");
                        string serverTypeId2 = ConditionalExpressionToXmlConverter.GetServerTypeId(memberExpression.Member.DeclaringType);
                        if (string.IsNullOrEmpty(serverTypeId2))
                        {
                            throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
                            {
                        this.m_condition.ToString()
                            }));
                        }
                        this.m_writer.WriteAttributeString("TypeId", serverTypeId2);
                        this.m_writer.WriteAttributeString("Name", ConditionalExpressionToXmlConverter.GetMemberName(memberExpression.Member));
                        this.m_writer.WriteEndElement();
                        return;
                    }
                default:
                    switch (nodeType)
                    {
                        case ExpressionType.Not:
                            {
                                this.m_writer.WriteStartElement(ConditionalExpressionToXmlConverter.s_opNames[exp.NodeType]);
                                UnaryExpression unaryExpression2 = (UnaryExpression)exp;
                                this.Write(unaryExpression2.Operand);
                                this.m_writer.WriteEndElement();
                                return;
                            }
                        case ExpressionType.NotEqual:
                            goto IL_D7;
                        case ExpressionType.Or:
                            goto IL_71A;
                        case ExpressionType.OrElse:
                            break;
                        case ExpressionType.Parameter:
                            {
                                ParameterExpression parameterExpression = (ParameterExpression)exp;
                                this.m_writer.WriteStartElement("ExpressionParameter");
                                this.m_writer.WriteAttributeString("Name", parameterExpression.Name);
                                this.m_writer.WriteEndElement();
                                return;
                            }
                        default:
                            {
                                if (nodeType != ExpressionType.TypeIs)
                                {
                                    goto IL_71A;
                                }
                                TypeBinaryExpression typeBinaryExpression = (TypeBinaryExpression)exp;
                                string value4 = null;
                                string value5 = null;
                                DataConvert.GetTypeNameOrTypeId(typeBinaryExpression.TypeOperand, out value4, out value5);
                                if (string.IsNullOrEmpty(value4) && string.IsNullOrEmpty(value5))
                                {
                                    throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
                                    {
                            this.m_condition.ToString()
                                    }));
                                }
                                this.m_writer.WriteStartElement("ExpressionTypeIs");
                                if (!string.IsNullOrEmpty(value4))
                                {
                                    this.m_writer.WriteAttributeString("Type", value4);
                                }
                                if (!string.IsNullOrEmpty(value5))
                                {
                                    this.m_writer.WriteAttributeString("TypeId", value5);
                                }
                                this.Write(typeBinaryExpression.Expression);
                                this.m_writer.WriteEndElement();
                                return;
                            }
                    }
                    break;
            }
            BinaryExpression binaryExpression = (BinaryExpression)exp;
            this.m_writer.WriteStartElement(ConditionalExpressionToXmlConverter.s_opNames[exp.NodeType]);
            this.Write(binaryExpression.Left);
            this.Write(binaryExpression.Right);
            this.m_writer.WriteEndElement();
            return;
            IL_D7:
            BinaryExpression binaryExpression2 = (BinaryExpression)exp;
            if (ConditionalExpressionToXmlConverter.IsNullExpression(binaryExpression2.Left) || ConditionalExpressionToXmlConverter.IsNullExpression(binaryExpression2.Right) || (ConditionalExpressionToXmlConverter.IsSupportedEqualType(binaryExpression2.Right.Type) && ConditionalExpressionToXmlConverter.IsSupportedEqualType(binaryExpression2.Left.Type)))
            {
                this.m_writer.WriteStartElement(ConditionalExpressionToXmlConverter.s_opNames[exp.NodeType]);
                this.Write(binaryExpression2.Left);
                this.Write(binaryExpression2.Right);
                this.m_writer.WriteEndElement();
                return;
            }
            throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
            {
                this.m_condition.ToString()
            }));
            IL_71A:
            throw new ClientRequestException(Resources.GetString("NotSupportedExpression", new object[]
            {
                this.m_condition.ToString()
            }));
        }

        private static bool IsSupportedEqualType(Type type)
        {
            //Edited for .NET Core
            //return type.IsPrimitive || type.IsEnum || type == typeof(Guid) || type == typeof(DateTime) || type == typeof(string);
            return type.GetTypeInfo().IsPrimitive || type.GetTypeInfo().IsEnum || type == typeof(Guid) || type == typeof(DateTime) || type == typeof(string);
        }

        private static bool IsNullExpression(Expression exp)
        {
            if (exp.NodeType == ExpressionType.Constant)
            {
                ConstantExpression constantExpression = (ConstantExpression)exp;
                return constantExpression.Value == null;
            }
            if (exp.NodeType == ExpressionType.Convert || exp.NodeType == ExpressionType.ConvertChecked)
            {
                UnaryExpression unaryExpression = (UnaryExpression)exp;
                return ConditionalExpressionToXmlConverter.IsNullExpression(unaryExpression.Operand);
            }
            return false;
        }

        private static string GetMemberName(MemberInfo m)
        {
            //Edited for .NET Core
            //RemoteAttribute remoteAttribute = (RemoteAttribute)Attribute.GetCustomAttribute(m, typeof(RemoteAttribute));
            RemoteAttribute remoteAttribute = m.GetCustomAttribute<RemoteAttribute>();

            if (remoteAttribute != null && !string.IsNullOrEmpty(remoteAttribute.Name))
            {
                return remoteAttribute.Name;
            }
            //Edited for .NET Core
            //PseudoRemoteAttribute pseudoRemoteAttribute = (PseudoRemoteAttribute)Attribute.GetCustomAttribute(m, typeof(PseudoRemoteAttribute));

            PseudoRemoteAttribute pseudoRemoteAttribute = m.GetCustomAttribute<PseudoRemoteAttribute>();
            if (pseudoRemoteAttribute != null && !string.IsNullOrEmpty(pseudoRemoteAttribute.Name))
            {
                return pseudoRemoteAttribute.Name;
            }
            return m.Name;
        }

        private static string GetServerTypeId(Type type)
        {
            //Edited for .NET Core
            //ScriptTypeAttribute scriptTypeAttribute = (ScriptTypeAttribute)Attribute.GetCustomAttribute(type, typeof(ScriptTypeAttribute));

            ScriptTypeAttribute scriptTypeAttribute = type.GetTypeInfo().GetCustomAttribute<ScriptTypeAttribute>();
            if (scriptTypeAttribute == null)
            {
                return null;
            }
            return scriptTypeAttribute.ServerTypeId;
        }

        private static bool IsClientResultValueExpression(MemberExpression memExp)
        {
            //Edited for .NET Core
            //return memExp.Expression != null && memExp.Expression.Type.IsGenericType && (memExp.Expression.Type.GetGenericTypeDefinition() == typeof(ClientResult<bool>).GetGenericTypeDefinition() || memExp.Expression.Type.GetGenericTypeDefinition() == typeof(ClientArrayResult<bool>).GetGenericTypeDefinition()) && memExp.Member != null && memExp.Member.Name == "Value";
            return memExp.Expression != null && memExp.Expression.Type.GetTypeInfo().IsGenericType && (memExp.Expression.Type.GetGenericTypeDefinition() == typeof(ClientResult<bool>).GetGenericTypeDefinition() || memExp.Expression.Type.GetGenericTypeDefinition() == typeof(ClientArrayResult<bool>).GetGenericTypeDefinition()) && memExp.Member != null && memExp.Member.Name == "Value";
        }

        private static bool IsServerObjectIsNullValue(MemberExpression memExp)
        {
            if (memExp.Expression != null && memExp.Expression.Type == typeof(bool?) && memExp.Member != null && memExp.Member.Name == "Value" && memExp.Expression.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExpression = (MemberExpression)memExp.Expression;
                //Edited for .NET Core
                //if (memberExpression.Expression != null && typeof(ClientObject).IsAssignableFrom(memberExpression.Expression.Type) && memberExpression.Member != null && memberExpression.Member.Name == "ServerObjectIsNull")
                if (memberExpression.Expression != null && typeof(ClientObject).GetTypeInfo().IsAssignableFrom(memberExpression.Expression.Type) && memberExpression.Member != null && memberExpression.Member.Name == "ServerObjectIsNull")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
