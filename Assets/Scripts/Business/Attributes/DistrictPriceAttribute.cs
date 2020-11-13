using System;
using Business.Enums;

namespace Business.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class DistrictPriceAttribute : Attribute
    {
        public ResourceType ResourceType { get; set; }
        public int Price { get; set; }

        public DistrictPriceAttribute(ResourceType type, int value)
        {
            ResourceType = type;
            Price = value;
        }
    }
}