using System;
using Business.Enums;

namespace Business.Attributes.District
{
    public class RequiredDistrictsAttribute : Attribute
    {
        public DistrictType[] DistrictTypes { get; set; }

        public RequiredDistrictsAttribute(params DistrictType[] districtType)
        {
            DistrictTypes = districtType;
        }
    }
}