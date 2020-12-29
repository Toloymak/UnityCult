using Business.Enums;
using Common.Extensions;
using Models.Attributes;

namespace Models.Extensions
{
    public static class DistrictTypeExtensions
    {
        public static string GetName(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, ItemDescriptionAttribute>();

            return attribute == null 
                ? districtType.ToString() 
                : attribute.Name;
        }
        
        public static string GetDescription(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, ItemDescriptionAttribute>();

            return attribute == null 
                ? "(empty)"
                : attribute.Description;
        }

        public static string GetTexturePath(this DistrictType districtType)
        {
            var attribute = districtType.GetAttribute<DistrictType, ItemDescriptionAttribute>();

            return attribute == null 
                ? ""
                : attribute.TexturePath;
        }
    }
}