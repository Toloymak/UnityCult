using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Interfaces;
using Common.Storages;

namespace Business.Models.Districts
{
    public class DistrictModel : IListItem
    {
        // todo: Remove
        public DistrictType DistrictType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public IDictionary<ResourceType, int> Resources { get; set; }

        public DistrictBuildingType BuildingType { get; set; }
        public DistrictType? Parent { get; set; }

        public IEnumerable<DistrictType> RequiredDistricts { get; set; }
        public IEnumerable<ResearchType> RequiredResearches { get; set; }

        public bool IsActive => true;
        
        public Action ClickAction { get; set; }

        public override string ToString()
        {
            return DistrictType.ToString();
        }
    }
}