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

        public Task Calculate()
        {
            var effects = _effectManager.GetResourceEffects();
            var districtEffects = _districtManager.GetResourceEffectModels();

            var updateResourceTasks = effects
                .Concat(districtEffects)
                .GroupBy(x => x.ResourceType)
                .Select(x =>
                    new
                    {
                        Type = x.Key,
                        Sum = x.Sum(r => r.Amount)
                    })
               .Select(x => Task.Run(() => _resourceManager.Add(x.Type, x.Sum)));

            return Task.WhenAll(updateResourceTasks);
        }
    }
}