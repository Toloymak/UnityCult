namespace Models.Models.People
{
    public class SpecificSkillsModel
    {
        public float Farming { get; set; }
        public float Craft { get; set; }
        public float Management { get; set; }

        public override string ToString()
        {
            return $"Farm:{Farming}, Craft:{Craft}, Mng: {Management}";
        }
    }
}