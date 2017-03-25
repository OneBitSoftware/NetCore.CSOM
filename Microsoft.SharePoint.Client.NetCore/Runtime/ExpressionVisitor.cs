using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal class ExpressionVisitor
    {
        public virtual Expression Visit(Expression exp)
        {
            if (exp == null)
            {
                return exp;
            }
            switch (exp.NodeType)
            {
                case ExpressionType.Add:
                case ExpressionType.AddChecked:
                case ExpressionType.And:
                case ExpressionType.AndAlso:
                case ExpressionType.ArrayIndex:
                case ExpressionType.Coalesce:
                case ExpressionType.Divide:
                case ExpressionType.Equal:
                case ExpressionType.ExclusiveOr:
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                case ExpressionType.LeftShift:
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                case ExpressionType.Modulo:
                case ExpressionType.Multiply:
                case ExpressionType.MultiplyChecked:
                case ExpressionType.NotEqual:
                case ExpressionType.Or:
                case ExpressionType.OrElse:
                case ExpressionType.Power:
                case ExpressionType.RightShift:
                case ExpressionType.Subtract:
                case ExpressionType.SubtractChecked:
                    return this.VisitBinary((BinaryExpression)exp);
                case ExpressionType.ArrayLength:
                case ExpressionType.Convert:
                case ExpressionType.ConvertChecked:
                case ExpressionType.Negate:
                case ExpressionType.NegateChecked:
                case ExpressionType.Not:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                    return this.VisitUnary((UnaryExpression)exp);
                case ExpressionType.Call:
                    return this.VisitMethodCall((MethodCallExpression)exp);
                case ExpressionType.Conditional:
                    return this.VisitConditional((ConditionalExpression)exp);
                case ExpressionType.Constant:
                    return this.VisitConstant((ConstantExpression)exp);
                case ExpressionType.Invoke:
                    return this.VisitInvocation((InvocationExpression)exp);
                case ExpressionType.Lambda:
                    return this.VisitLambda((LambdaExpression)exp);
                case ExpressionType.ListInit:
                    return this.VisitListInit((ListInitExpression)exp);
                case ExpressionType.MemberAccess:
                    return this.VisitMemberAccess((MemberExpression)exp);
                case ExpressionType.MemberInit:
                    return this.VisitMemberInit((MemberInitExpression)exp);
                case ExpressionType.New:
                    return this.VisitNew((NewExpression)exp);
                case ExpressionType.NewArrayInit:
                case ExpressionType.NewArrayBounds:
                    return this.VisitNewArray((NewArrayExpression)exp);
                case ExpressionType.Parameter:
                    return this.VisitParameter((ParameterExpression)exp);
                case ExpressionType.TypeIs:
                    return this.VisitTypeIs((TypeBinaryExpression)exp);
            }
            throw new ArgumentException();
        }

        public virtual Expression VisitBinary(BinaryExpression exp)
        {
            Expression expression = this.Visit(exp.Left);
            Expression expression2 = this.Visit(exp.Right);
            if (expression == exp.Left && expression2 == exp.Right)
            {
                return exp;
            }
            return Expression.MakeBinary(exp.NodeType, expression, expression2, exp.IsLiftedToNull, exp.Method);
        }

        public virtual MemberBinding VisitBinding(MemberBinding binding)
        {
            switch (binding.BindingType)
            {
                case MemberBindingType.Assignment:
                    return this.VisitMemberAssignment((MemberAssignment)binding);
                case MemberBindingType.MemberBinding:
                    return this.VisitMemberMemberBinding((MemberMemberBinding)binding);
                case MemberBindingType.ListBinding:
                    return this.VisitMemberListBinding((MemberListBinding)binding);
                default:
                    throw new ArgumentException();
            }
        }

        public virtual IEnumerable<MemberBinding> VisitBindingList(ReadOnlyCollection<MemberBinding> original)
        {
            List<MemberBinding> list = null;
            for (int i = 0; i < original.Count; i++)
            {
                MemberBinding memberBinding = this.VisitBinding(original[i]);
                if (list != null)
                {
                    list.Add(memberBinding);
                }
                else if (memberBinding != original[i])
                {
                    list = new List<MemberBinding>();
                    for (int j = 0; j < i; j++)
                    {
                        list.Add(original[j]);
                    }
                    list.Add(memberBinding);
                }
            }
            if (list != null)
            {
                return list;
            }
            return original;
        }

        public virtual Expression VisitConditional(ConditionalExpression exp)
        {
            Expression expression = this.Visit(exp.Test);
            Expression expression2 = this.Visit(exp.IfTrue);
            Expression expression3 = this.Visit(exp.IfFalse);
            if (expression == exp.Test && expression2 == exp.IfTrue && expression3 == exp.IfFalse)
            {
                return exp;
            }
            return Expression.Condition(expression, expression2, expression3);
        }

        public virtual Expression VisitConstant(ConstantExpression exp)
        {
            return exp;
        }

        public virtual ElementInit VisitElementInitializer(ElementInit initializer)
        {
            ReadOnlyCollection<Expression> readOnlyCollection = this.VisitExpressionList(initializer.Arguments);
            if (readOnlyCollection != initializer.Arguments)
            {
                return Expression.ElementInit(initializer.AddMethod, readOnlyCollection);
            }
            return initializer;
        }

        public virtual IEnumerable<ElementInit> VisitElementInitializerList(ReadOnlyCollection<ElementInit> original)
        {
            List<ElementInit> list = null;
            for (int i = 0; i < original.Count; i++)
            {
                ElementInit elementInit = this.VisitElementInitializer(original[i]);
                if (list != null)
                {
                    list.Add(elementInit);
                }
                else if (elementInit != original[i])
                {
                    list = new List<ElementInit>();
                    for (int j = 0; j < i; j++)
                    {
                        list.Add(original[j]);
                    }
                    list.Add(elementInit);
                }
            }
            if (list != null)
            {
                return list;
            }
            return original;
        }

        public virtual ReadOnlyCollection<Expression> VisitExpressionList(ReadOnlyCollection<Expression> original)
        {
            List<Expression> list = null;
            int i = 0;
            int count = original.Count;
            while (i < count)
            {
                Expression expression = this.Visit(original[i]);
                if (list != null)
                {
                    list.Add(expression);
                }
                else if (expression != original[i])
                {
                    list = new List<Expression>(count);
                    for (int j = 0; j < i; j++)
                    {
                        list.Add(original[j]);
                    }
                    list.Add(expression);
                }
                i++;
            }
            if (list != null)
            {
                return new ReadOnlyCollection<Expression>(list);
            }
            return original;
        }

        public virtual Expression VisitInvocation(InvocationExpression iv)
        {
            IEnumerable<Expression> enumerable = this.VisitExpressionList(iv.Arguments);
            Expression expression = this.Visit(iv.Expression);
            if (enumerable == iv.Arguments && expression == iv.Expression)
            {
                return iv;
            }
            return Expression.Invoke(expression, enumerable);
        }

        public virtual Expression VisitLambda(LambdaExpression exp)
        {
            Expression expression = this.Visit(exp.Body);
            if (expression != exp.Body)
            {
                return Expression.Lambda(exp.Type, expression, exp.Parameters);
            }
            return exp;
        }

        public virtual Expression VisitListInit(ListInitExpression init)
        {
            NewExpression newExpression = this.VisitNew(init.NewExpression);
            IEnumerable<ElementInit> enumerable = this.VisitElementInitializerList(init.Initializers);
            if (newExpression == init.NewExpression && enumerable == init.Initializers)
            {
                return init;
            }
            return Expression.ListInit(newExpression, enumerable);
        }

        public virtual Expression VisitMemberAccess(MemberExpression m)
        {
            Expression expression = this.Visit(m.Expression);
            if (expression != m.Expression)
            {
                return Expression.MakeMemberAccess(expression, m.Member);
            }
            return m;
        }

        public virtual MemberAssignment VisitMemberAssignment(MemberAssignment assignment)
        {
            Expression expression = this.Visit(assignment.Expression);
            if (expression != assignment.Expression)
            {
                return Expression.Bind(assignment.Member, expression);
            }
            return assignment;
        }

        public virtual Expression VisitMemberInit(MemberInitExpression init)
        {
            NewExpression newExpression = this.VisitNew(init.NewExpression);
            IEnumerable<MemberBinding> enumerable = this.VisitBindingList(init.Bindings);
            if (newExpression == init.NewExpression && enumerable == init.Bindings)
            {
                return init;
            }
            return Expression.MemberInit(newExpression, enumerable);
        }

        public virtual MemberListBinding VisitMemberListBinding(MemberListBinding binding)
        {
            IEnumerable<ElementInit> enumerable = this.VisitElementInitializerList(binding.Initializers);
            if (enumerable != binding.Initializers)
            {
                return Expression.ListBind(binding.Member, enumerable);
            }
            return binding;
        }

        public virtual MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding binding)
        {
            IEnumerable<MemberBinding> enumerable = this.VisitBindingList(binding.Bindings);
            if (enumerable != binding.Bindings)
            {
                return Expression.MemberBind(binding.Member, enumerable);
            }
            return binding;
        }

        public virtual Expression VisitMethodCall(MethodCallExpression m)
        {
            Expression expression = this.Visit(m.Object);
            IEnumerable<Expression> enumerable = this.VisitExpressionList(m.Arguments);
            if (expression == m.Object && enumerable == m.Arguments)
            {
                return m;
            }
            return Expression.Call(expression, m.Method, enumerable);
        }

        public virtual NewExpression VisitNew(NewExpression nex)
        {
            IEnumerable<Expression> enumerable = this.VisitExpressionList(nex.Arguments);
            if (enumerable == nex.Arguments)
            {
                return nex;
            }
            if (nex.Members != null)
            {
                return Expression.New(nex.Constructor, enumerable, nex.Members);
            }
            return Expression.New(nex.Constructor, enumerable);
        }

        public virtual Expression VisitNewArray(NewArrayExpression na)
        {
            IEnumerable<Expression> enumerable = this.VisitExpressionList(na.Expressions);
            if (enumerable == na.Expressions)
            {
                return na;
            }
            if (na.NodeType == ExpressionType.NewArrayInit)
            {
                return Expression.NewArrayInit(na.Type.GetElementType(), enumerable);
            }
            return Expression.NewArrayBounds(na.Type.GetElementType(), enumerable);
        }

        public virtual Expression VisitParameter(ParameterExpression p)
        {
            return p;
        }

        public virtual Expression VisitTypeIs(TypeBinaryExpression b)
        {
            Expression expression = this.Visit(b.Expression);
            if (expression != b.Expression)
            {
                return Expression.TypeIs(expression, b.TypeOperand);
            }
            return b;
        }

        public virtual Expression VisitUnary(UnaryExpression u)
        {
            Expression expression = this.Visit(u.Operand);
            if (expression != u.Operand)
            {
                return Expression.MakeUnary(u.NodeType, expression, u.Type, u.Method);
            }
            return u;
        }
    }
}
