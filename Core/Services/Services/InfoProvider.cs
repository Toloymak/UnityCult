using System;
using System.Collections.Generic;
using System.Linq;
using Models.Enums;
using Models.Models;
using Models.Models.Effects;
using Models.Models.Players;
using Models.Models.Villages;

namespace Services.Services
{
    public interface IInfoProvider
    {
        IDictionary<ResourceType, int> GetResources(PlayerStorageModel playerStorageModel);
        VillageMapModel GetMap(PlayerStorageModel playerStorage);
        ICollection<EffectModel> GetEffects(PlayerStorageModel playerStorage);
        ICollection<EffectModel> GetDistrictEffects(PlayerStorageModel playerStorage);
    }
    
    public class InfoProvider : IInfoProvider
    {
        public IDictionary<ResourceType, int> GetResources(PlayerStorageModel playerStorageModel)
        {
            return playerStorageModel.ResourcesStorage;
        }

        public VillageMapModel GetMap(PlayerStorageModel playerStorage)
        {
            return playerStorage.VillageMap;
        }

        public ICollection<EffectModel> GetEffects(PlayerStorageModel playerStorage)
        {
            return playerStorage.EffectStorage.Effects.Select(x => x.Value).ToList();
        }

        public ICollection<EffectModel> GetDistrictEffects(PlayerStorageModel playerStorage)
        {
            return playerStorage
               .VillageMap
               .Cells
               .SelectMany(x => x)
               .Where(x => x.District != null && x.District.Effects.Any())
               .SelectMany(x => x.District.Effects)
               .ToList();
        }
    }
}