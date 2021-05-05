using System;
using System.Collections.Generic;
using System.Linq;
using Models.Models;
using Models.Models.Districts;
using Models.Models.Villages;

namespace Managers.Managers
{
    public interface IDistrictManager
    {
        IEnumerable<ResourceEffectModel> GetResourceEffectModels(VillageMapModel villageMapModel);
        void AddDistrict(DistrictStorage storage, DistrictModel districtModel);
    }

    public class DistrictManager : IDistrictManager
    {
        public IEnumerable<ResourceEffectModel> GetResourceEffectModels(VillageMapModel villageMapModel)
        {
            var effects = villageMapModel
               .Cells
               .SelectMany(x => x)
               .Where(x => x.District != null)
               .SelectMany(x => x.District.Effects)
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