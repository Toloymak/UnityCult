using System;
using System.Collections.Concurrent;
using System.Linq;
using Models.Enums;

namespace Models.Models
{
    public class ResourceModel : ConcurrentDictionary<ResourceType, int>
    {
        public ResourceModel()
            : base(new ConcurrentDictionary<ResourceType, int>())
        {
            foreach (var resourceType in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
            {
                AddOrUpdate(resourceType, 0, (type, i) => i);
            }
        }
    }
}