using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Models.Models;


namespace Core.Services
{
    public interface IResourceService
    {
        bool TryTakeResources(IDictionary<ResourceType, int> resources);
        void AddResources(IDictionary<ResourceType, int> resources);
    }
    
    public class ResourceService : IResourceService
    {
        private readonly ResourcesModel _resourcesModel;
        
        public ResourceService(ResourcesModel resourcesModel)
        {
            _resourcesModel = resourcesModel;
        }

        public bool TryTakeResources(IDictionary<ResourceType, int> resources)
        {
            if (resources.Any(x => _resourcesModel[x.Key] < x.Value))
                return false;

            foreach (var resource in resources)
            {
                _resourcesModel[resource.Key] = _resourcesModel[resource.Key] - resource.Value;
            }

            return true;
        }
        
        public void AddResources(IDictionary<ResourceType, int> resources)
        {
            foreach (var resource in resources)
            {
                _resourcesModel[resource.Key] = _resourcesModel[resource.Key] + resource.Value;
            }
        }
    }
}