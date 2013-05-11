using System;
using System.Linq.Expressions;
using ObjectSupporter.ExpressionNameStrategies;
using ObjectSupporter.Properties;

namespace ObjectSupporter
{
    public static class ObjectSupport
    {
        private static readonly ExpressionNameStrategy _expressionNameStrategy = new ExpressionNameStrategy();

        public static string GetName<T>(Expression<Func<T, object>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName<T>(Expression<Action<T>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName(Expression<Func<object>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName(Expression<Action> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        private static string GetName(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(GetName(() => expression), Resources.ArgumentCannotBeNull);
            }

            return GetName(expression.Body);
        }

        private static string GetName<T>(Expression<Func<T>> expression)
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