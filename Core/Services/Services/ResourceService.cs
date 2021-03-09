using System.Linq;
using System.Threading.Tasks;
using Managers.Managers;

namespace Services.Services
{
    public interface IResourceService
    {
        Task Calculate();
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

        public async Task Calculate()
        {
            var effects = _effectManager.GetResourceEffects();
            var districtEffects = await _districtManager.GetResourceEffectModels();

            var resourceGroups = effects
                .Concat(districtEffects)
                .GroupBy(x => x.ResourceType)
                .Select(x =>
                    new
                    {
                        Type = x.Key,
                        Sum = x.Sum(r => r.Amount)
                    });

            foreach (var resourceGroup in resourceGroups)
            {
                _resourceManager.Add(resourceGroup.Type, resourceGroup.Sum);
            }
        }
    }
}