using System;
using System.Linq.Expressions;
using ObjectSupporter.ExpressionNameStrategies;
using ObjectSupporter.Properties;
using ObjectSupporter.Supporters;

namespace ObjectSupporter
{
    public static class ObjectSupport
    {
        private static readonly ExpressionNameStrategy _expressionNameStrategy = new ExpressionNameStrategy();
        private static readonly Lazy<ISupport> _lazyFieldSupport = new Lazy<ISupport>(() => new FieldSupport());
        private static readonly Lazy<ISupport> _lazyMethodSupport = new Lazy<ISupport>(() => new MethodSupport());
        private static readonly Lazy<ISupport> _lazyPropertySupport = new Lazy<ISupport>(() => new PropertySupport());

        public static ISupport Argument
        {
            get { return _lazyFieldSupport.Value; }
        }

        public static ISupport Field
        {
            get { return _lazyFieldSupport.Value; }
        }

        public static ISupport Method
        {
            get { return _lazyMethodSupport.Value; }
        }

        public static ISupport Property
        {
            get { return _lazyPropertySupport.Value; }
        }

        public static ISupport Variable
        {
            get { return _lazyFieldSupport.Value; }
        }

        public static string GetName<T>(Expression<Func<T, object>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName<TClass, TResult>(Expression<Func<TClass, TResult>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName<T>(Expression<Action<T>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public static string GetName<TResult>(Expression<Func<TResult>> expression)
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

        public static string GetName(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(GetNameInternal(() => expression), Resources.ArgumentCannotBeNull);
            }

            return GetName(expression.Body);
        }

        public static string GetName(Expression expression)
        {
            if (_expressionNameStrategy.CanHandle(expression))
            {
                return _expressionNameStrategy.GetName(expression);
            }

            throw new InvalidOperationException(Resources.InvalidParameterType);
        }

        private static string GetNameInternal<T>(Expression<Func<T>> expression)
        {
            return GetName(expression.Body);
        }
    }
}