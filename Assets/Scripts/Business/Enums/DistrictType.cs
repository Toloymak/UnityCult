﻿using Business.Attributes;
using Business.Attributes.District;
using Common.Consts;

namespace Business.Enums
{
    public enum DistrictType
    {
        [Ignore]
        None = 0,
        [DistrictPrice(ResourceType.OrdinarySoulStone, 1000)]
        Residential = 100,
        EliteResidential = 110,
        School = 200,
        Library = 300,
        [DistrictDescription("Arena", "Your warriors can get here a honor and an experience!", TextureNames.Arena)]
        [DistrictPrice(ResourceType.OrdinarySoulStone, 100)]
        Arena = 400,
        [DistrictBuildingType(DistrictBuildingType.Upgrade, Arena)]
        [DistrictPrice(ResourceType.OrdinarySoulStone, 1000)]
        Arena2 = 410,
        [DistrictBuildingType(DistrictBuildingType.Upgrade, Arena2)]
        [DistrictPrice(ResourceType.OrdinarySoulStone, 10000)]
        Arena3 = 420,
        [DistrictBuildingType(DistrictBuildingType.Upgrade, Arena3)]
        [DistrictPrice(ResourceType.GoodSoulStone, 1000)]
        Arena4 = 430,
        [DistrictPrice(ResourceType.OrdinarySoulStone, 1000)]
        [DistrictPrice(ResourceType.MysticMetal, 500)]
        [DistrictDescription("Factory", "You can create here an equipment")]
        Factory = 500,
        [DistrictPrice(ResourceType.OrdinarySoulStone, 1000)]
        [DistrictPrice(ResourceType.MysticMetal, 500)]
        [DistrictPrice(ResourceType.Energy, 1000)]
        [DistrictPrice(ResourceType.Food, 500)]
        [DistrictPrice(ResourceType.PerfectSoulStone, 1000)]
        Alchemy = 600,
        [RequiredDistricts(Alchemy)]
        Farm = 700,
        [RequiredDistricts(Farm)]
        Research = 800,
        [RequiredDistricts(Research, Alchemy)]
        Challenge = 900,
        
        [DistrictDescription("Base camp", "Here is living members of cult", maxCount: 1)]
        Camp = 1000,
        
        [DistrictDescription("Administration", "Service can help you with artifacts and issues sharing")]
        [DistrictBuildingType(DistrictBuildingType.Upgrade, Camp)]
        [RequiredDistricts(Residential)]
        [DistrictPrice(ResourceType.OrdinarySoulStone, 10000)]
        Administration = 1010,
        
        Issuance = 1100,
        Livestock = 1200,
        Storage = 1300,
        Meditation = 1400,
    }
}