using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal sealed class BinaryExpressionNameStrategy : ExpressionNameStrategyBase<BinaryExpression>
    {
        protected override string GetName(BinaryExpression expression)
        {
            return expression.ToString();
        }
    }
}