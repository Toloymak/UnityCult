using System.Collections.Generic;
using System.Linq;
using Business.Attributes;
using Business.Enums;
using Common.Components;
using Common.Models;
using Common.TypeExtensions;
using Leopotam.Ecs;

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
        
        public static bool IsEnoughResources(this BuildingActionItem buildingActionItem,
                                               IDictionary<ResourceType, ResourceComponent> resourceComponents)
        {
            return buildingActionItem
               .DistrictType
               .GetPrices()
               .All(price => price.value <= resourceComponents[price.type].Count);
        }

        public static IDictionary<ResourceType, ResourceComponent> ToDictionary(this EcsFilter<ResourceComponent> resourceComponents)
        {
            return resourceComponents
               .GetComponents()
               .ToDictionary(component => component.ResourceType);
        }
    }
}