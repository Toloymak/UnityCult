using System;
using Models.Enums;

namespace Models.Attributes
{
    public class RootDistrictAttribute : Attribute
    {
        public DistrictType RootDistrict { get; } 
        
        public RootDistrictAttribute(DistrictType districtType)
        {
            RootDistrict = districtType;
        }
    }
}