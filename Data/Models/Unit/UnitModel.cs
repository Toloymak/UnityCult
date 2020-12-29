using System;

namespace Models.Models
{
    public class UnitModel : BaseItem
    {
        public Guid CultId { get; set; }
        
        public HealthModel Health { get; set; }
        public UnitParameterModel Parameters { get; set; }
        public ChiModel Chi { get; set; }
    }
}