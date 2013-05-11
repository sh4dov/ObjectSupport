using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal abstract class ExpressionNameStrategyBase<T> : IExpressionNameStrategy where T : Expression
    {
        public bool CanHandle(Expression expression)
        {
            return expression is T;
        }

        public string GetName(Expression expression)
        {
            var specifiedExpression = expression as T;
            if (specifiedExpression != null)
            {
                return GetName(specifiedExpression);
            }

            return null;
        }

        protected abstract string GetName(T expression);
    }
}