using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal sealed class MemberExpressionNameStrategy : ExpressionNameStrategyBase<MemberExpression>
    {
        protected override string GetName(MemberExpression expression)
        {
            return expression.Member.Name;
        }
    }
}