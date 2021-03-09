using System;
using System.Collections.Generic;

namespace Models.Models.Effects
{
    public class EffectModel
    {
        public Guid Id { get; set; }
        
        public long EffectTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public TimeSpan? Period { get; set; }
        public TimeSpan StartTime { get; set; }
        
        public ICollection<ResourceEffectModel> ResourceEffects { get; set; }

        public bool IsExpired(TimeSpan currentTime)
        {
            if (!Period.HasValue)
                return false;

            return currentTime - StartTime > Period;
        }
    }
}