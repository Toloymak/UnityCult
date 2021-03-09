using System;
using System.Collections.Concurrent;

namespace Models.Models.Effects
{
    public class EffectStorageModel
    {
        public ConcurrentDictionary<Guid, EffectModel> Effects { get; }
        public ConcurrentDictionary<Guid, EffectModel> ResourceEffects { get; }

        public EffectStorageModel()
        {
            Effects = new ConcurrentDictionary<Guid, EffectModel>();
            ResourceEffects = new ConcurrentDictionary<Guid, EffectModel>();
        }
    }
}