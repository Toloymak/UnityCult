using System;
using System.Collections.Generic;

namespace Common.Helpers
{
    public static class LinqExtensions
    {
        public static ICollection<T> ForEach<T>(this ICollection<T> enumerable, Action<T> action)
        {
            foreach (var value in enumerable)
            {
                action.Invoke(value);
            }

            return enumerable;
        }
    }
}