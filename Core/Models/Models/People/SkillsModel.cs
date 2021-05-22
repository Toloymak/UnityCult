namespace Models.Models.People
{
    public class SkillsModel
    {
        public float Strength { get; set; }
        public float Agility { get; set; }
        public float Intelligence { get; set; }
        public float Endurance { get; set; }

        public override string ToString()
        {
            return $"S:{Strength}, A:{Agility}, I:{Intelligence}, E:{Endurance}";
        }
    }
}