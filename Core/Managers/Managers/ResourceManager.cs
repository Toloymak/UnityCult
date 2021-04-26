using System.Collections.Generic;
using Models.Enums;
using Models.Models;

namespace Managers.Managers
{
    public interface IResourceManager
    {
        void Add(ResourcesStorage resourcesStorage, ResourceType resourceType, int count);
        bool TryTake(ResourcesStorage resourcesStorage, IDictionary<ResourceType, int> resources);
    }

    public class ResourceManager : IResourceManager
    {
        public void Add(ResourcesStorage resourcesStorage, ResourceType resourceType, int count)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            resourcesStorage.AddOrUpdate(resourceType, count, (type, i) => i + count);
        }

        public bool TryTake(ResourcesStorage resourcesStorage, IDictionary<ResourceType, int> resources)
        {
            lock (resourcesStorage.TakeResourceLocker)
            {
                if (!IsEnoughResources(resourcesStorage, resources))
                    return false;

                TakeResources(resourcesStorage, resources);
                
                return true;
            }
        }

        private bool IsEnoughResources(ResourcesStorage resourcesStorage, IDictionary<ResourceType, int> resources)
        {
            foreach (var resource in resources)
            {
                if (resourcesStorage[resource.Key] < resource.Value)
                    return false;
            }

            return true;
        }
        
        private void TakeResources(ResourcesStorage resourcesStorage, IDictionary<ResourceType, int> resources)
        {
            foreach (var resource in resources)
            {
                Add(resourcesStorage, resource.Key, -resource.Value);
            }
        }
    }
}