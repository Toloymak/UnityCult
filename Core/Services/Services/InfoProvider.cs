using System.Collections.Generic;
using Models.Enums;
using Models.Models;
using Models.Models.Player;

namespace Services.Services
{
    public interface IInfoProvider
    {
        IDictionary<ResourceType, int> GetResources(PlayerStorageModel playerStorageModel);
    }
    
    public class InfoProvider : IInfoProvider
    {
        public IDictionary<ResourceType, int> GetResources(PlayerStorageModel playerStorageModel)
        {
            return playerStorageModel.ResourcesStorage;
        }
    }
}