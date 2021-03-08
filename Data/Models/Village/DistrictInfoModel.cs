﻿using System.Collections.Generic;
using Business.Enums;
using Models.Extensions;

namespace Models.Models.Village
{
    public class DistrictInfoModel
    {
        public DistrictType DistrictType { get; set; }
        public IList<DistrictInfoModel> ChildDistricts { get; set; }

        public IEnumerable<long> RequiredDistricts { get; set; }
        public IEnumerable<long> RequiredResearches { get; set; }
        
        public IDictionary<ResourceType, int> Resources { get; set; }
        
        public int XSize { get; set; }
        public int ZSize { get; set; }

        public string Name => DistrictType.GetName();
        public string Description => DistrictType.GetDescription();

        public override string ToString()
        {
            return $"{Name} ({XSize}, {ZSize})";
        }
    }
}