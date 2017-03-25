using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Microsoft.SharePoint.Client.NetCore.Runtime
{
    internal static class ExpressionEvaluator
    {
        private class SubtreeEvaluator : ExpressionVisitor
        {
            private Dictionary<Expression, object> m_candidates;

            internal SubtreeEvaluator(Dictionary<Expression, object> candidates)
            {
                this.m_candidates = candidates;
            }

            public Expression Evaluate(Expression exp)
            {
                return this.Visit(exp);
            }

            public override Expression Visit(Expression expr)
            {
                if (expr == null)
                {
                    return null;
                }
                if (this.m_candidates.ContainsKey(expr))
                {
                    return ExpressionEvaluator.SubtreeEvaluator.EvaluateToConstant(expr);
                }
                return base.Visit(expr);
            }

            private static Expression EvaluateToConstant(Expression exp)
            {
                if (exp.NodeType == ExpressionType.Constant)
                {
                    return exp;
                }
                Delegate @delegate = Expression.Lambda(exp, new ParameterExpression[0]).Compile();
                object value = @delegate.DynamicInvoke(new object[0]);
                return Expression.Constant(value, exp.Type);
            }
        }

        private class Nominator : ExpressionVisitor
        {
            private Func<Expression, bool> m_fnCanBeEvaluated;

            private bool m_canBeEvaluated;

            private Dictionary<Expression, object> m_candidates;

            internal Nominator(Func<Expression, bool> fnCanBeEvaluated)
            {
                this.m_fnCanBeEvaluated = fnCanBeEvaluated;
            }

            internal Dictionary<Expression, object> Nominate(Expression exp)
            {
                this.m_candidates = new Dictionary<Expression, object>();
                this.m_canBeEvaluated = true;
                this.Visit(exp);
                return this.m_candidates;
            }

            public override Expression Visit(Expression expr)
            {
                if (expr != null)
                {
                    bool canBeEvaluated = this.m_canBeEvaluated;
                    this.m_canBeEvaluated = true;
                    base.Visit(expr);
                    if (this.m_canBeEvaluated)
                    {
                        if (this.m_fnCanBeEvaluated(expr))
                        {
                            this.m_candidates[expr] = null;
                        }
                        else
                        {
                            this.m_canBeEvaluated = false;
                        }
                    }
                    this.m_canBeEvaluated &= canBeEvaluated;
                }
                return expr;
            }
        }

        public static Expression PartialEvaluate(Expression exp, Func<Expression, bool> fnCanBeEvaluated)
        {
            ExpressionEvaluator.Nominator nominator = new ExpressionEvaluator.Nominator(fnCanBeEvaluated);
            Dictionary<Expression, object> candidates = nominator.Nominate(exp);
            ExpressionEvaluator.SubtreeEvaluator subtreeEvaluator = new ExpressionEvaluator.SubtreeEvaluator(candidates);
            return subtreeEvaluator.Evaluate(exp);
        }
    }
}
