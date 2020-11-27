using System;
using System.Collections.Generic;
using Business.Enums;

namespace Business.Models.Unit
{
    public class UnitComponent
    {
        public Guid Id { get; }
        // todo: Implementation for few cults
        public Guid CultId { get; set; }
        
        public string Name { get; set; }
        
        // Classic parameters
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        
        public int MaxEnergy { get; set; }
        public int CurrentEnergy { get; set; }

        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agile { get; set; }
        public int Endurance { get; set; }
        
        // Element parameters
        public int FireChi { get; set; }
        public int ColdChi { get; set; }
        public int WaterChi { get; set; }
        public int AirChi { get; set; }
        public int EarthChi { get; set; }
        public int DeathChi { get; set; }
        
        public int BodyChi { get; set; }
        
        public IDictionary<SkillType, SkillModel> Skills { get; }

        public UnitComponent()
        {
            Id = Guid.NewGuid();
            CultId = Guid.Empty;
            Skills = new Dictionary<SkillType, SkillModel>();
        }
    }
}