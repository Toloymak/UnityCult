using System.Collections.Generic;
using Business.Enums;
using Models.Models;

namespace Business.Models.Districts
{
    public class DistrictModel : BaseItem
    {
        public long ParentTypeId { get; set; }

        public IEnumerable<long> RequiredDistricts { get; set; }
        public IEnumerable<long> RequiredResearches { get; set; }
        
        public IDictionary<ResourceType, int> Resources { get; set; }

        public DistrictBuildingType BuildingType { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}