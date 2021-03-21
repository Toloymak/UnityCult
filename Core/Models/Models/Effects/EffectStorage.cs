using System;
using System.Collections.Concurrent;

namespace Models.Models.Effects
{
    public class EffectStorage
    {
        public ConcurrentDictionary<Guid, EffectModel> Effects { get; }
        public ConcurrentDictionary<Guid, EffectModel> ResourceEffects { get; }

        public EffectStorage()
        {
            Effects = new ConcurrentDictionary<Guid, EffectModel>();
            ResourceEffects = new ConcurrentDictionary<Guid, EffectModel>();
        }
    }
}