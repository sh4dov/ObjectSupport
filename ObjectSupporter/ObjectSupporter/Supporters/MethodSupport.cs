using System;
using System.Linq.Expressions;
using System.Reflection;

namespace ObjectSupporter.Supporters
{
    internal sealed class MethodSupport : SupportBase
    {
        internal MethodSupport()
        {
        }

        protected override string ExtractName(LambdaExpression expression)
        {
            var methodCallExpression = expression.Body as MethodCallExpression;
            if (methodCallExpression != null)
            {
                return methodCallExpression.Method.Name;
            }

            // TODO: This is very dirty hack and needs to be changed!
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var methodCallExpression1 = unaryExpression.Operand as MethodCallExpression;
                if (methodCallExpression1 != null)
                {
                    var constantExpression = methodCallExpression1.Object as ConstantExpression;
                    if (constantExpression != null)
                    {
                        var methodInfo = constantExpression.Value as MethodInfo;
                        if (methodInfo != null)
                        {
                            return methodInfo.Name;
                        }
                    }
                }
            }

            throw new InvalidOperationException();
        }

        protected override bool CanHandle(LambdaExpression expression)
        {
            if (expression.Body is MethodCallExpression)
            {
                return true;
            }

            // TODO: This is very dirty hack and needs to be changed!
            var unaryExpression = expression.Body as UnaryExpression;
            if (unaryExpression != null)
            {
                var methodCallExpression = unaryExpression.Operand as MethodCallExpression;
                if (methodCallExpression != null)
                {
                    var constantExpression = methodCallExpression.Object as ConstantExpression;
                    if (constantExpression != null)
                    {
                        var methodInfo = constantExpression.Value as MethodInfo;
                        if (methodInfo != null)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
}