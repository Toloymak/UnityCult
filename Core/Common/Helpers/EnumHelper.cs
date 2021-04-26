using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public static class EnumHelper
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable> EnumLists = 
            new ConcurrentDictionary<Type, IEnumerable>();

        public static ICollection<TEnum> GetAllEnumValues<TEnum>()
            where TEnum : Enum
        {
            if (EnumLists.TryGetValue(typeof(TEnum), out var enums))
                return enums.Cast<TEnum>().ToList();
            
            var result = EnumLists
               .GetOrAdd(typeof(TEnum), Enum.GetValues(typeof(TEnum)));

            return result.Cast<TEnum>().ToList();
        }
    }
}