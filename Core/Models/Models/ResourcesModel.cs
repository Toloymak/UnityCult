using System;
using System.Collections.Concurrent;
using System.Linq;
using Models.Enums;

namespace Models.Models
{
    public class ResourcesModel : ConcurrentDictionary<ResourceType, int>
    {
        public ResourcesModel()
            : base(new ConcurrentDictionary<ResourceType, int>())
        {
            foreach (var resourceType in Enum.GetValues(typeof(ResourceType)).Cast<ResourceType>())
            {
                AddOrUpdate(resourceType, 0, (type, i) => i);
            }

            TakeResourceLocker = new object();
        }
        
        public object TakeResourceLocker { get; set; }
    }
}