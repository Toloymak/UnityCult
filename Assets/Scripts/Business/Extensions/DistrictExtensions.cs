using System.Collections.Generic;
using System.Linq;
using Business.Attributes;
using Business.Enums;
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
        
        public static IEnumerable<(ResourceType, int)> GetPrices(this DistrictType districtType)
        {
            var attributes = districtType.GetAttributes<DistrictType, DistrictPriceAttribute>();

            return attributes == null
                ? new (ResourceType, int)[]{}
                : attributes.Select(x => (x.ResourceType, x.Price));
        }
    }
}