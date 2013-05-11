using System;
using System.Linq.Expressions;
using ObjectSupporter.ExpressionNameStrategies;
using ObjectSupporter.Properties;

namespace ObjectSupporter
{
    public static class ObjectSupport
    {
        private static readonly ExpressionNameStrategy _expressionNameStrategy = new ExpressionNameStrategy();

        public static string GetName<T>(Expression<Action<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(Resources.ArgumentCannotBeNull, GetName(() => expression));
            }

            return GetName(expression.Body);
        }

        internal static string GetName<T>(Expression<Func<T>> expression)
        {
            return GetName(expression.Body);
        }

        private static string GetName(Expression expression)
        {
            if (_expressionNameStrategy.CanHandle(expression))
            {
                return _expressionNameStrategy.GetName(expression);
            }

            throw new InvalidOperationException(Resources.InvalidParameterType);
        }
    }
}