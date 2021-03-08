using System.Threading.Tasks;
using Models.Enums;
using Models.Models;

namespace Managers.Managers
{
    public interface IResourceManager
    {
        void Add(ResourceType resourceType, int count);
        Task<bool> TryTake(ResourceType resourceType, int count);
    }

    public class ResourceManager : IResourceManager
    {
        private readonly ResourceModel _resourceModel;
        
        public ResourceManager(ResourceModel resourceModel)
        {
            _resourceModel = resourceModel;
        }
        
        public void Add(ResourceType resourceType, int count)
        {
            _resourceModel.AddOrUpdate(resourceType, count, (type, i) => i + count);
        }

        public Task<bool> TryTake(ResourceType resourceType, int count)
        {
            // todo: add logic of concurently resource protection
        }
    }
}