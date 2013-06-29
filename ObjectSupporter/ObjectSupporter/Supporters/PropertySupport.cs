using System.Linq.Expressions;
using System.Reflection;

namespace ObjectSupporter.Supporters
{
    internal sealed class PropertySupport : MemberSupportBase
    {
        internal PropertySupport()
        {
        }

        protected override bool CanHandle(MemberExpression expression)
        {
            return expression.Member is PropertyInfo;
        }
    }
}