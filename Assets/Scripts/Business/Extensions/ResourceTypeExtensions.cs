using Business.Attributes;
using Business.Enums;
using Common.TypeExtensions;

namespace Business.Extensions
{
    public static class ResourceTypeExtensions
    {
        public static int GetDefaultValue(this ResourceType resourceType)
        {
            return resourceType
                   .GetAttribute<ResourceType, ResourcePropertyAttribute>()
                  ?.DefaultValue
             ?? 0;
        }
        
        public static string GetShortName(this ResourceType resourceType)
        {
            return resourceType
                   .GetAttribute<ResourceType, ResourceDescriptionAttribute>()
                  ?.ShortName
             ?? resourceType.ToString().Substring(0, 2);
        }
        
        public static string GetFullName(this ResourceType resourceType)
        {
            return resourceType
                   .GetAttribute<ResourceType, ResourceDescriptionAttribute>()
                  ?.Name
             ?? resourceType.ToString();;
        }
    }
}