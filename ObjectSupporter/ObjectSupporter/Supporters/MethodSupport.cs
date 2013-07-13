using System;
using System.Linq.Expressions;
using System.Reflection;
using ObjectSupporter.Extensions;

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

            var methodName =
                expression.Convert(e => e.Body as UnaryExpression)
                          .Convert(ue => ue.Operand as MethodCallExpression)
                          .Convert(mc => mc.Object as ConstantExpression)
                          .Convert(ce => ce.Value as MethodInfo)
                          .Convert(mi => mi.Name);
            if (!string.IsNullOrEmpty(methodName))
            {
                return methodName;
            }

            throw new InvalidOperationException();
        }

        protected override bool CanHandle(LambdaExpression expression)
        {
            if (expression.Body is MethodCallExpression)
            {
                return true;
            }

            return expression
                .Convert(e => e.Body as UnaryExpression)
                .Convert(ue => ue.Operand as MethodCallExpression)
                .Convert(mc => mc.Object as ConstantExpression)
                .Convert(ce => ce.Value as MethodInfo)
                .Convert(mi => mi != null);
        }
    }
}