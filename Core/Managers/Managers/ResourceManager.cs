using System.Threading.Tasks;
using Models.Enums;

namespace Managers.Managers
{
    public interface IResourceManager
    {
        Task Add(ResourceType resourceType, int count);
    }

    public class ResourceManager : IResourceManager
    {
        public Task Add(ResourceType resourceType, int count)
        {
            throw new System.NotImplementedException();
        }
    }
}