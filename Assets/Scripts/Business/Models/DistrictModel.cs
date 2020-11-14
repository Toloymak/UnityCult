using System.Collections.Generic;
using Business.Enums;
using Business.Extensions;

namespace Business.Models
{
    public class DistrictModel
    {
        public DistrictType DistrictType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IEnumerable<(ResourceType type, int value)> Prices { get; set; }
        
        public DistrictBuildingType BuildingType { get; set; }
        public DistrictType? Parent { get; set; }
        
        public IEnumerable<DistrictType> RequiredDistricts { get; set; }
        public IEnumerable<ResearchType> RequiredResearches { get; set; }

        public override string ToString()
        {
            return DistrictType.ToString();
        }
    }
}