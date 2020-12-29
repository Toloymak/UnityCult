using System;
using Business.Enums;
using UnityEngine;

namespace Business.Attributes.District
{
    public class DistrictBuildingTypeAttribute : Attribute
    {
        public DistrictBuildingType BuildingType { get; set; }
        public DistrictType Parent { get; set; }

        public DistrictBuildingTypeAttribute(DistrictBuildingType type, DistrictType parentDistrict = DistrictType.None)
        {
            BuildingType = type;

            if (type == DistrictBuildingType.Upgrade)
            {
                if (parentDistrict == DistrictType.None)
                {
                    Debug.LogError("Upgrade district should have parent district");
                    return;
                }
                
                Parent = parentDistrict;
            }
        }
    }
}