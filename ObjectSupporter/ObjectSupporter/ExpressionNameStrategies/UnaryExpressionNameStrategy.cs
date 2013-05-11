using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal sealed class UnaryExpressionNameStrategy : ExpressionNameStrategyBase<UnaryExpression>
    {
        protected override string GetName(UnaryExpression expression)
        {
            return expression.Operand.ToString();
        }
    }
}