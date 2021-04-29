using Models.Attributes;

namespace Models.Enums
{
    public enum DistrictType
    {
        [DistrictDescription("Academy1", "todo")]
        WarriorAcademy1 = 0,
        [RootDistrict(WarriorAcademy1)]
        [TechnologyConditions]
        [DistrictDescription("Academy2", "todo")]
        WarriorAcademy2 = 1,
        [RootDistrict(WarriorAcademy2)]
        [DistrictDescription("Academy3", "todo")]
        WarriorAcademy3 = 2,
        [RootDistrict(WarriorAcademy3)]
        [DistrictDescription("Academy4", "todo")]
        WarriorAcademy4 = 3,
        [RootDistrict(WarriorAcademy4)]
        [DistrictDescription("Academy5", "todo")]
        WarriorAcademy5 = 4,
        
        [DistrictDescription("Residential1", "todo")]
        [DistrictResourceEffect(ResourceType.Energy, 5)]
        ResidentialArea1 = 5,
        [RootDistrict(ResidentialArea1)]
        [DistrictDescription("Residential2", "todo")]
        ResidentialArea2 = 6,
        [RootDistrict(ResidentialArea3)]
        [DistrictDescription("Residential3", "todo")]
        ResidentialArea3 = 7,
        [RootDistrict(ResidentialArea3)]
        [DistrictDescription("Residential4", "todo")]
        ResidentialArea4 = 8,
        [RootDistrict(ResidentialArea4)]
        [DistrictDescription("Residential5", "todo")]
        ResidentialArea5 = 9,
        
        [DistrictDescription("Headquarters1", "todo")]
        Headquarters1 = 10,
        [RootDistrict(Headquarters1)]
        [DistrictDescription("Headquarters2", "todo")]
        Headquarters2 = 11,
        [RootDistrict(Headquarters2)]
        [DistrictDescription("Headquarters3", "todo")]
        Headquarters3 = 12,
        [RootDistrict(Headquarters3)]
        [DistrictDescription("Headquarters4", "todo")]
        Headquarters4 = 13,
        [RootDistrict(Headquarters4)]
        [DistrictDescription("Headquarters5", "todo")]
        Headquarters5 = 14,
    }
}