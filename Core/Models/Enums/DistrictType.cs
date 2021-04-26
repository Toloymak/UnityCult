using Models.Attributes;

namespace Models.Enums
{
    public enum DistrictType
    {
        [DistrictDescription("todo", "todo")]
        WarriorAcademy1 = 0,
        [RootDistrict(WarriorAcademy1)]
        [TechnologyConditions]
        [DistrictDescription("todo", "todo")]
        WarriorAcademy2 = 1,
        [RootDistrict(WarriorAcademy2)]
        [DistrictDescription("todo", "todo")]
        WarriorAcademy3 = 2,
        [RootDistrict(WarriorAcademy3)]
        [DistrictDescription("todo", "todo")]
        WarriorAcademy4 = 3,
        [RootDistrict(WarriorAcademy4)]
        [DistrictDescription("todo", "todo")]
        WarriorAcademy5 = 4,
        
        [DistrictDescription("todo", "todo")]
        ResidentialArea1 = 5,
        [RootDistrict(ResidentialArea2)]
        [DistrictDescription("todo", "todo")]
        ResidentialArea2 = 6,
        [RootDistrict(ResidentialArea3)]
        [DistrictDescription("todo", "todo")]
        ResidentialArea3 = 7,
        [RootDistrict(ResidentialArea3)]
        [DistrictDescription("todo", "todo")]
        ResidentialArea4 = 8,
        [RootDistrict(ResidentialArea4)]
        [DistrictDescription("todo", "todo")]
        ResidentialArea5 = 9,
        
        [DistrictDescription("todo", "todo")]
        Headquarters1 = 10,
        [RootDistrict(Headquarters1)]
        [DistrictDescription("todo", "todo")]
        Headquarters2 = 11,
        [RootDistrict(Headquarters2)]
        [DistrictDescription("todo", "todo")]
        Headquarters3 = 12,
        [RootDistrict(Headquarters3)]
        [DistrictDescription("todo", "todo")]
        Headquarters4 = 13,
        [RootDistrict(Headquarters4)]
        [DistrictDescription("todo", "todo")]
        Headquarters5 = 14,
    }
}