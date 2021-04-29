using System;
using Models.Enums;

namespace Models.Attributes
{
    public class DistrictResourceEffectAttribute : Attribute
    {
        public ResourceType ResourceType { get; set; }
        public int Value { get; set; }
        
        public DistrictResourceEffectAttribute(ResourceType resourceType, int value)
        {
            ResourceType = resourceType;
            Value = value;
        }
    }
}