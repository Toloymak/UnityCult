using System;
using System.Collections.Generic;

namespace Models.Models.People
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        // public PersonAssignmentModel Assignment { get; set; }
        
        public SkillsModel Skills { get; }
        public LevelModel Level { get; }
        public HealthModel Health { get; }
        public ChakraModel Chakra { get; }
        public SpecificSkillsModel SpecificSkills { get; }
        public HashSet<AbilityModel> Abilities { get; }

        public PersonModel()
        {
            Skills = new SkillsModel();
            Level = new LevelModel();
            Health = new HealthModel();
            Chakra = new ChakraModel();
            SpecificSkills = new SpecificSkillsModel();
            Abilities = new HashSet<AbilityModel>();
            // Assignment = new PersonAssignmentModel();
        }
    }
}