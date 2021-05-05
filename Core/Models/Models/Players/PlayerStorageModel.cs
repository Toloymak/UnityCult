using System;
using Models.Models.Districts;
using Models.Models.Effects;
using Models.Models.Villages;

namespace Models.Models.Players
{
    public class PlayerStorageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public VillageMapModel VillageMap { get; set; }
        public EffectStorage EffectStorage { get; set; }
        public ResourcesStorage ResourcesStorage { get; set; }

        public PlayerStorageModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            
            EffectStorage = new EffectStorage();
            ResourcesStorage = new ResourcesStorage();
        }
    }
}