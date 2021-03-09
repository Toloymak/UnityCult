using System.Collections.Generic;
using Models.Enums;
using Models.Models;

namespace Managers.Managers
{
    public interface IResourceManager
    {
        void Add(ResourceType resourceType, int count);
        bool TryTake((ResourceType, int)[] resources);
    }

    public class ResourceManager : IResourceManager
    {
        private readonly ResourcesModel _resourcesModel;
        
        public ResourceManager(ResourcesModel resourcesModel)
        {
            _resourcesModel = resourcesModel;
        }
        
        public void Add(ResourceType resourceType, int count)
        {
            // ReSharper disable once InconsistentlySynchronizedField
            _resourcesModel.AddOrUpdate(resourceType, count, (type, i) => i + count);
        }

        public bool TryTake((ResourceType, int)[] resources)
        {
            lock (_resourcesModel.TakeResourceLocker)
            {
                if (!IsEnoughResources(resources))
                    return false;

                TakeResources(resources);
                
                return true;
            }
        }

        private bool IsEnoughResources(IEnumerable<(ResourceType, int)> resources)
        {
            foreach (var (type, amount) in resources)
            {
                if (_resourcesModel[type] < amount)
                    return false;
            }

            return true;
        }
        
        private void TakeResources(IEnumerable<(ResourceType, int)> resources)
        {
            foreach (var (resourceType, amount) in resources)
            {
                Add(resourceType, -amount);
            }
        }
    }
}