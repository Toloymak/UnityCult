using System.Collections.Generic;
using Models.Enums;
using Models.Models.Players;
using Models.Models.Villages;

namespace Services.Services
{
    public interface IInfoProvider
    {
        IDictionary<ResourceType, int> GetResources(PlayerStorageModel playerStorageModel);
        VillageMapModel GetMap(PlayerStorageModel playerStorage);
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
    }
}