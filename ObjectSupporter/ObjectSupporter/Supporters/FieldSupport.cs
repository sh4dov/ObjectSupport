using System.Linq.Expressions;
using System.Reflection;

namespace ObjectSupporter.Supporters
{
    internal sealed class FieldSupport : MemberSupportBase
    {
        internal FieldSupport()
        {
        }

        protected override bool CanHandle(MemberExpression expression)
        {
            return expression.Member is FieldInfo;
        }
    }
}