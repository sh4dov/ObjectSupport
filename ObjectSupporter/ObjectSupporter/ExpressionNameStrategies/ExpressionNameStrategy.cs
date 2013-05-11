using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ObjectSupporter.ExpressionNameStrategies
{
    internal sealed class ExpressionNameStrategy : IExpressionNameStrategy
    {
        private readonly List<IExpressionNameStrategy> _strategies = new List<IExpressionNameStrategy>
            {
                new MemberExpressionNameStrategy(),
                new ConstantExpressionNameStrategy(),
                new BinaryExpressionNameStrategy(),
                new MethodCallExpressionNameStrategy(),
                new UnaryExpressionNameStrategy()
            };

        public bool CanHandle(Expression expression)
        {
            return _strategies.Any(s => s.CanHandle(expression));
        }

        public string GetName(Expression expression)
        {
            var strategy = _strategies.FirstOrDefault(s => s.CanHandle(expression));
            if (strategy != null)
            {
                return strategy.GetName(expression);
            }
            return null;
        }
    }
}