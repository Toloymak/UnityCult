using System;
using Models.Models.Districts;
using Models.Models.Effects;

namespace Models.Models.Player
{
    public class PlayerStorageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DistrictStorage DistrictStorage { get; set; }
        public EffectStorage EffectStorage { get; set; }
        public ResourcesStorage ResourcesStorage { get; set; }

        public PlayerStorageModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            
            DistrictStorage = new DistrictStorage();
            EffectStorage = new EffectStorage();
            ResourcesStorage = new ResourcesStorage();
        }
    }
}