using System;
using Common.Extensions;
using Models.Attributes;
using Models.Enums;

namespace Models.Models.Districts
{
    public class DistrictAttributeModel
    {
        public DistrictType Type { get; }
        
        public DistrictDescriptionAttribute DistrictDescriptionAttribute { get; }
        public RootDistrictAttribute RootDistrictAttribute { get; }
        public TechnologyConditionsAttribute TechnologyConditionsAttribute { get; }

        public DistrictAttributeModel(DistrictType districtType)
        {
            Type = districtType;
            DistrictDescriptionAttribute = GetAttribute<DistrictDescriptionAttribute>(districtType);
            RootDistrictAttribute =  GetAttribute<RootDistrictAttribute>(districtType);
            TechnologyConditionsAttribute =  GetAttribute<TechnologyConditionsAttribute>(districtType);
        }

        private static Type _districtType = typeof(DistrictType);

        private TAttribute GetAttribute<TAttribute>(DistrictType districtType)
            where TAttribute : Attribute =>
            _districtType.GetAttribute<TAttribute, DistrictType>(districtType);
    }
}