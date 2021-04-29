using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.Effects
{
    public class EffectModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public TimeSpan? Period { get; set; }
        public TimeSpan StartTime { get; set; }
        
        public ICollection<ResourceEffectModel> ResourceEffects { get; set; }

        public bool IsExpired(TimeSpan currentTime)
        {
            if (!Period.HasValue)
                return false;

            return currentTime - StartTime > Period;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(Name);
            builder.Append(": ");
            var isFirst = true;
            foreach (var resourceEffect in ResourceEffects)
            {
                if (!isFirst)
                    builder.Append(" ; ");
                else
                    isFirst = false;
                
                builder.Append(resourceEffect.ResourceType.ToString());
                builder.Append(':');
                builder.Append(resourceEffect.Amount.ToString());
            }

            return builder.ToString();
        }
    }
}