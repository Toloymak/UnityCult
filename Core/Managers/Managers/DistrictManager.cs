using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Models.Models.Districts;

namespace Managers.Managers
{
    public interface IDistrictManager
    {
        ICollection<ResourceEffectModel> GetResourceEffectModels();
    }

    public class DistrictManager : IDistrictManager
    {
        private readonly DistrictStorageModel _districtStorage;

        public DistrictManager(DistrictStorageModel districtStorage)
        {
            _districtStorage = districtStorage;
        }

        public ICollection<ResourceEffectModel> GetResourceEffectModels()
        {
            var effects = _districtStorage
               .DistrictWithResourceEffects
               .SelectMany(x => x.Value.Effects.ResourceEffects)
               .ToArray();

            return effects;
        }
    }
}