using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal sealed class MethodCallExpressionNameStrategy : ExpressionNameStrategyBase<MethodCallExpression>
    {
        protected override string GetName(MethodCallExpression expression)
        {
            return expression.Method.Name;
        }
    }
}