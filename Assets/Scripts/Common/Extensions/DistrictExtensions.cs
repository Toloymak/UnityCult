using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Common.Attributes;
using Common.GameTypes;
using JetBrains.Annotations;

namespace Common.Extensions
{
    public static class DistrictExtensions
    {
        public static string GetName(this DistrictType districtType)
        {
            var attribute = districtType.GetDescriptionAttribute();

            return attribute == null 
                ? districtType.ToString() 
                : attribute.Name;
        }
        
        public static string GetDescription(this DistrictType districtType)
        {
            var attribute = districtType.GetDescriptionAttribute();

            return attribute == null 
                ? string.Empty 
                : attribute.Description;
        }
        
        public static IList<(string, int)> GetPrices(this DistrictType districtType)
        {
            return new List<(string, int)>();
        }

        private static DistrictDescriptionAttribute GetDescriptionAttribute(this DistrictType districtType)
        {
            var attribute = typeof(DistrictType)
               .GetMember(districtType.ToString())
               .FirstOrDefault()
              ?.GetCustomAttribute(typeof(DistrictDescriptionAttribute));

            return (DistrictDescriptionAttribute) attribute;
        }
    }
}