using System.Collections.Generic;
using Business.Enums;
using Common.Attributes;
using Common.TypeExtensions;

namespace Business.Extensions
{
    public static class DistrictExtensions
    {
        public static string GetName(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, DistrictDescriptionAttribute>();

            return attribute == null 
                ? districtType.ToString() 
                : attribute.Name;
        }
        
        public static string GetDescription(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, DistrictDescriptionAttribute>();

            return attribute == null 
                ? string.Empty 
                : attribute.Description;
        }
        
        public static IList<(string, int)> GetPrices(this DistrictType districtType)
        {
            return new List<(string, int)>();
        }
    }
}