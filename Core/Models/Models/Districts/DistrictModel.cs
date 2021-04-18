﻿using System;
using Models.Models.Effects;

namespace Models.Models.Districts
{
    public class DistrictModel
    {
        public Guid Id { get; set; }
        
        public long TypeId { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public EffectModel Effects { get; set; }
    }
}