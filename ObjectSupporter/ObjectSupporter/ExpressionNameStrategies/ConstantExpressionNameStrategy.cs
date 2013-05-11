using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal sealed class ConstantExpressionNameStrategy : ExpressionNameStrategyBase<ConstantExpression>
    {
        protected override string GetName(ConstantExpression expression)
        {
            return expression.ToString();
        }
    }
}