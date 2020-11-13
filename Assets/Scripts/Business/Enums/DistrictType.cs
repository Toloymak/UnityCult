using Business.Attributes;

namespace Business.Enums
{
    public enum DistrictType
    {
        None = 0,
        EliteResidential = 1,
        School = 2,
        Library = 3,
        [DistrictDescription("Arena", "Your warriors can get here a honor and an experience!")]
        [DistrictPrice(ResourceType.OrdinarySoulStone, 100)]
        Arena = 4,
        [DistrictPrice(ResourceType.OrdinarySoulStone, 1000)]
        [DistrictPrice(ResourceType.MysticMetal, 500)]
        [DistrictDescription("Factory", "You can create here an equipment")]
        Factory = 5,
        [DistrictPrice(ResourceType.OrdinarySoulStone, 1000)]
        [DistrictPrice(ResourceType.MysticMetal, 500)]
        [DistrictPrice(ResourceType.Energy, 1000)]
        [DistrictPrice(ResourceType.Food, 500)]
        [DistrictPrice(ResourceType.PerfectSoulStone, 1000)]
        Alchemy = 6,
        Farm = 7,
        Research = 8,
        Challenge = 9,
        [DistrictDescription("Administration", "Service can help you with artifacts and issues sharing")]
        Administration = 10,
        Issuance = 11,
        Livestock = 12,
        Storage = 13,
        Meditation = 14,
        Residential = 15,
    }
}