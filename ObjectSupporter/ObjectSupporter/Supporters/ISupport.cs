using System;
using System.Linq.Expressions;

namespace ObjectSupporter.Supporters
{
    public interface ISupport
    {
        string GetName<TClass, TResult>(Expression<Func<TClass, TResult>> expression);

        string GetName<T>(Expression<Func<T>> expression);
    }
}