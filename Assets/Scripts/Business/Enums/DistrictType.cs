﻿using Business.Attributes;
using Business.Attributes.District;

namespace Business.Enums
{
    public enum DistrictType
    {
        [Ignore]
        None = 0,
        EliteResidential = 100,
        School = 200,
        Library = 300,
        [DistrictDescription("Arena", "Your warriors can get here a honor and an experience!")]
        [DistrictPrice(ResourceType.OrdinarySoulStone, 100)]
        [RequiredDistricts(Alchemy)]
        Arena = 400,
        [RequiredDistricts(Arena)]
        Arena2 = 410,
        [RequiredDistricts(Arena2)]
        Arena3 = 420,
        [RequiredDistricts(Arena3)]
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
        [DistrictDescription("Administration", "Service can help you with artifacts and issues sharing")]
        Administration = 1000,
        Issuance = 1100,
        Livestock = 1200,
        Storage = 1300,
        Meditation = 1400,
        Residential = 1500,
    }
}