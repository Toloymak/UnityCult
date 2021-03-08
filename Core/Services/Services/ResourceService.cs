using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Managers.Managers;
using Models.Enums;
using Models.Models;

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
            var effects = await _effectManager.GetResourceEffects();
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

            var tasks = resourceGroups
                .Select(x => _resourceManager.Add(x.Type, x.Sum))
                .ToArray();

            await Task.WhenAll(tasks);
        }
    }
}