using System.Collections.Generic;
using Models.Enums;

namespace Models.Models.Districts
{
    public class DistrictModel
    {
        public DistrictType Type { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public IDictionary<ResourceType, int> Price { get; set; }
        
        public ICollection<ResourceEffectModel> ResourceEffects { get; set; }
    }
}