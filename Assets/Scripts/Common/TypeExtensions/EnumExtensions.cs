using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Common.TypeExtensions
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TEnum, TAttribute>(this TEnum enumValue)
            where TAttribute : Attribute
            where TEnum : Enum
        {
            var attribute = typeof(TEnum)
               .GetMember(enumValue.ToString())
               .FirstOrDefault()
              ?.GetCustomAttribute(typeof(TAttribute));
            
            return (TAttribute) attribute;
        }
        
        public static IEnumerable<TAttribute> GetAttributes<TEnum, TAttribute>(this TEnum enumValue)
            where TAttribute : Attribute
            where TEnum : Enum
        {
            var attribute = typeof(TEnum)
               .GetMember(enumValue.ToString())
               .FirstOrDefault()
              ?.GetCustomAttributes(typeof(TAttribute))
               .Select(x => (TAttribute) x);
            
            return attribute;
        }
    }
}