using System;
using System.Linq.Expressions;
using ObjectSupporter.Properties;

namespace ObjectSupporter.Supporters
{
    internal abstract class SupportBase : ISupport
    {
        public string GetName<TClass, TResult>(Expression<Func<TClass, TResult>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        public string GetName<T>(Expression<Func<T>> expression)
        {
            return GetName((LambdaExpression)expression);
        }

        private string GetName(LambdaExpression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(ObjectSupport.GetName(expression), Resources.ArgumentCannotBeNull);
            }

            if (!CanHandle(expression))
            {
                throw new ArgumentException(Resources.InvalidParameterType, ObjectSupport.GetName(() => expression));
            }

            return ExtractName(expression);
        }

        protected abstract string ExtractName(LambdaExpression expression);

        protected abstract bool CanHandle(LambdaExpression expression);
    }
}