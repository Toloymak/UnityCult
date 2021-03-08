using Business.Attributes;

namespace Models.Enums
{
    public enum ResourceType
    {
        [ResourceDescription("S", "Ordinary Stone")]
        [ResourceProperty(1300)]
        OrdinarySoulStone = 0,
        
        [ResourceDescription("GS", "Good Stone")]
        [ResourceProperty(0)]
        GoodSoulStone = 100,
        
        [ResourceDescription("PS", "Perfect Stone")]
        [ResourceProperty(0)]
        PerfectSoulStone = 200,
        
        [ResourceDescription("E", "Energy")]
        [ResourceProperty(0)]
        Energy = 300,
        
        [ResourceDescription("M", "Metal")]
        [ResourceProperty(0)]
        MysticMetal = 400,
        
        [ResourceDescription("F", "Food")]
        [ResourceProperty(0)]
        Food = 500,
    }
}