using System.Collections.Generic;
using Models.Enums;
using Models.Models;

namespace Managers.Managers
{
    public interface IResourceManager
    {
        void Add(ResourcesStorage resourcesStorage, ResourceType resourceType, int count);
        bool TryTake(ResourcesStorage resourcesStorage, (ResourceType, int)[] resources);
    }

    public class ResourceManager : IResourceManager
    {
        public void Add(ResourcesStorage resourcesStorage, ResourceType resourceType, int count)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            resourcesStorage.AddOrUpdate(resourceType, count, (type, i) => i + count);
        }

        public bool TryTake(ResourcesStorage resourcesStorage, (ResourceType, int)[] resources)
        {
            lock (resourcesStorage.TakeResourceLocker)
            {
                if (!IsEnoughResources(resourcesStorage, resources))
                    return false;

                TakeResources(resourcesStorage, resources);
                
                return true;
            }
        }

        private bool IsEnoughResources(ResourcesStorage resourcesStorage, IEnumerable<(ResourceType, int)> resources)
        {
            foreach (var (type, amount) in resources)
            {
                if (resourcesStorage[type] < amount)
                    return false;
            }

            return true;
        }
        
        private void TakeResources(ResourcesStorage resourcesStorage, IEnumerable<(ResourceType, int)> resources)
        {
            foreach (var (resourceType, amount) in resources)
            {
                Add(resourcesStorage, resourceType, -amount);
            }
        }
    }
}