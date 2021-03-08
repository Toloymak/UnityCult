﻿using Models.Enums;

namespace Models.Models
{
    public class ResourceEffectModel : EffectModel
    {
        public ResourceType ResourceType { get; set; }
        public int Amount { get; set; }
    }
}