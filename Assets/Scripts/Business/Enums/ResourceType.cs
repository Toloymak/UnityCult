using Business.Attributes;

namespace Business.Enums
{
    public enum ResourceType
    {
        [ResourceDescription("S", "Ordinary Stone")]
        [ResourceProperty(1300)]
        OrdinarySoulStone,
        [ResourceDescription("GS", "Good Stone")]
        [ResourceProperty(0)]
        GoodSoulStone,
        [ResourceDescription("PS", "Perfect Stone")]
        [ResourceProperty(0)]
        PerfectSoulStone,
        [ResourceDescription("E", "Energy")]
        [ResourceProperty(0)]
        Energy,
        [ResourceDescription("M", "Metal")]
        [ResourceProperty(0)]
        MysticMetal,
        [ResourceDescription("F", "Food")]
        [ResourceProperty(0)]
        Food,
    }
}