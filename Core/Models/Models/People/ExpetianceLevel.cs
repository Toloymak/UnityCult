namespace Models.Models.People
{
    public class LevelModel
    {
        public int Level { get; set; }
        
        public float CurrentExp { get; set; }
        public float NexLevelExp { get; set; }
        
        public SkillsModel PromisedSkills { get; set; }

        public override string ToString()
        {
            return $"lvl:{Level} ({CurrentExp}/{NexLevelExp})";
        }
    }
}