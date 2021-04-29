using System;
using System.Collections.Generic;
using System.Linq;
using Models.Models;
using Models.Models.Districts;

namespace Managers.Managers
{
    public interface IDistrictManager
    {
        IEnumerable<ResourceEffectModel> GetResourceEffectModels(DistrictStorage districtStorage);
        void AddDistrict(DistrictStorage storage, DistrictModel districtModel);
    }

    public class DistrictManager : IDistrictManager
    {
        public IEnumerable<ResourceEffectModel> GetResourceEffectModels(DistrictStorage districtStorage)
        {
            var effects = districtStorage
               .Districts
               .SelectMany(x => x.Value.Effects)
               .SelectMany(x => x.ResourceEffects)
               .ToArray();

            return effects;
        }

        public void AddDistrict(DistrictStorage storage, DistrictModel districtModel)
        {
            // storage.Districts.AddOrUpdate(districtModel.Id,
            //                               districtModel,
            //                               (guid, model) => districtModel);
        }
    }
}