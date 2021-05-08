namespace Models.Models.People
{
    public class LevelModel
    {
        public int Level { get; set; }
        
        public float CurrentExp { get; set; }
        public float NexLeveExp { get; set; }
        
        public SkillsModel PromisedSkills { get; set; }
    }
}