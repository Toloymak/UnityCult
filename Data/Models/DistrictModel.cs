using System.Collections.Generic;
using Business.Enums;
using Models.Extensions;

namespace Models.Models
{
    public class DistrictModel
    {
        public DistrictType DistrictType { get; set; }
        public IList<DistrictModel> ChildDistricts { get; set; }

        public IEnumerable<long> RequiredDistricts { get; set; }
        public IEnumerable<long> RequiredResearches { get; set; }
        
        public IDictionary<ResourceType, int> Resources { get; set; }

        public string Name => DistrictType.GetName();
        public string Description => DistrictType.GetDescription();
    }
}