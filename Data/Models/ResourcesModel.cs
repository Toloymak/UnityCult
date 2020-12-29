using System;
using System.Collections.Generic;
using System.Linq;
using Business.Enums;

namespace Models.Models
{
    public class ResourcesModel : Dictionary<ResourceType, int>
    {
        public ResourcesModel()
            : base(new Dictionary<ResourceType, int>())
        {
            foreach (var resourceType in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
            {
                Add(resourceType, 0);
            }
        }
    }
}