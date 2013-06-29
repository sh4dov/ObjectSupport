using System.Diagnostics;
using System.Linq.Expressions;

namespace ObjectSupporter.Supporters
{
    internal abstract class MemberSupportBase : SupportBase
    {
        protected override string ExtractName(LambdaExpression expression)
        {
            Debug.Assert(expression.Body is MemberExpression, "expression.Body have to be MemberExpression.");
            var memberExpression = (MemberExpression)expression.Body;
            return memberExpression.Member.Name;
        }

        protected abstract bool CanHandle(MemberExpression expression);

        protected sealed override bool CanHandle(LambdaExpression expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            return memberExpression != null && CanHandle(memberExpression);
        }
    }
}