using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal interface IExpressionNameStrategy
    {
        bool CanHandle(Expression expression);

        string GetName(Expression expression);
    }
}