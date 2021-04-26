using System;
using System.Linq;

namespace Common.Extensions
{
    public static class EnumExtensions
    {
        public static TAttribute GetAttribute<TAttribute>(this Type type, string memberName)
            where TAttribute : Attribute
        {
            var attribute = type
               .GetMember(memberName)
               .FirstOrDefault()
              ?.GetCustomAttributes(typeof(TAttribute), false)
               .FirstOrDefault();

            return (TAttribute) attribute;
        }
        
        public static TAttribute GetAttribute<TAttribute, TEnum>(this Type type, TEnum @enum)
            where TAttribute : Attribute
        {
            return type.GetAttribute<TAttribute>(@enum.ToString());
        }
    }
}