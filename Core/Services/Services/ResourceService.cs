using System.Linq;
using System.Threading.Tasks;
using Managers.Managers;
using Models.Models;
using Models.Models.Districts;
using Models.Models.Effects;

namespace Services.Services
{
    public interface IResourceService
    {
        Task AddEffectResources(DistrictStorage districtStorage,
                       EffectStorage effectStorage,
                       ResourcesStorage resourcesStorage);
    }

    public class ResourceService : IResourceService
    {
        private readonly IResourceManager _resourceManager;
        private readonly IEffectManager _effectManager;
        private readonly IDistrictManager _districtManager;

        public ResourceService(IResourceManager resourceManager,
            IEffectManager effectManager,
            IDistrictManager districtManager)
        {
            _resourceManager = resourceManager;
            _effectManager = effectManager;
            _districtManager = districtManager;
        }

        public Task AddEffectResources(DistrictStorage districtStorage,
                              EffectStorage effectStorage,
                              ResourcesStorage resourcesStorage)
        {
            var effects = _effectManager.GetResourceEffects(effectStorage);
            var districtEffects = _districtManager.GetResourceEffectModels(districtStorage);

            var updateResourceTasks = effects
                .Concat(districtEffects)
                .GroupBy(x => x.ResourceType)
                .Select(x =>
                    new
                    {
                        Type = x.Key,
                        Sum = x.Sum(r => r.Amount)
                    })
               .Select(x => Task.Run(() => _resourceManager.Add(resourcesStorage, x.Type, x.Sum)));

            return Task.WhenAll(updateResourceTasks);
        }
    }
}