using System.Collections.Generic;
using Models.Enums;
using Models.Models;

namespace Services.Services
{
    public interface IInfoProvider
    {
        IDictionary<ResourceType, int> GetResources();
    }
    
    public class InfoProvider : IInfoProvider
    {
        private readonly ResourcesStorage _resourcesStorage;

        public InfoProvider(ResourcesStorage resourcesStorage)
        {
            _resourcesStorage = resourcesStorage;
        }

        public IDictionary<ResourceType, int> GetResources()
        {
            return _resourcesStorage;
        }
    }
}