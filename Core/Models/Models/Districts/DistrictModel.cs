using System.Collections.Generic;

namespace Models.Models.Districts
{
    public class DistrictModel
    {
        public long TypeId { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public ICollection<ResourceEffectModel> ResourceEffects { get; set; }
    }
}