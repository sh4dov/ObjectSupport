using System;
using ObjectSupporter.Properties;

namespace ObjectSupporter.Extensions
{
    public static class GenericConverterExtension
    {
        public static TTarget Convert<TSource, TTarget>(this TSource value, Func<TSource, TTarget> converter) where TSource : class
        {
            if (converter == null)
            {
                throw new ArgumentNullException(ObjectSupport.Argument.GetName(() => converter), Resources.ArgumentCannotBeNull);
            }

            if (value == null)
            {
                return default(TTarget);
            }
            return converter(value);
        }
    }
}