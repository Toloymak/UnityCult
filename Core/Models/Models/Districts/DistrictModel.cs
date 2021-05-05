using System.Collections.Generic;
using Models.Enums;
using Models.Models.Effects;

namespace Models.Models.Districts
{
    public class DistrictModel
    {
        public DistrictType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DistrictType RootDistrict { get; set; }
        
        public HashSet<TechnologyType> RequiredTechnologies { get; set; }
        public IDictionary<ResourceType, int> Price { get; set; }
        public ICollection<EffectModel> Effects { get; set; }
        
        public bool IsEnoughMoney { get; set; }

        public DistrictModel()
        {
            RootDistrict = DistrictType.None;
            RequiredTechnologies = new HashSet<TechnologyType>();
            Price = new Dictionary<ResourceType, int>();
            Effects = new List<EffectModel>();
        }
    }
}