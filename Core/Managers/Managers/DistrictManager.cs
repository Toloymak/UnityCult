using System.Collections.Generic;
using System.Linq;
using Models.Models;
using Models.Models.Districts;

namespace Managers.Managers
{
    public interface IDistrictManager
    {
        ICollection<ResourceEffectModel> GetResourceEffectModels(DistrictStorage districtStorage);
    }

    public class DistrictManager : IDistrictManager
    {
        public ICollection<ResourceEffectModel> GetResourceEffectModels(DistrictStorage districtStorage)
        {
            var effects = districtStorage
               .DistrictWithResourceEffects
               .SelectMany(x => x.Value.Effects.ResourceEffects)
               .ToArray();

            return effects;
        }
    }
}