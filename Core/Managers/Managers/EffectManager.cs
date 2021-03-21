using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;
using Models.Models.Effects;

namespace Managers.Managers
{
    public interface IEffectManager
    {
        IList<ResourceEffectModel> GetResourceEffects(EffectStorage effectStorage);
        void Add(EffectStorage effectStorage, EffectModel effectModel);
        Task RemoveNotActual(EffectStorage effectStorage, TimeSpan currentTime);
    }

    public class EffectManager : IEffectManager
    {
        public EffectManager()
        {
        }

        public IList<ResourceEffectModel> GetResourceEffects(EffectStorage effectStorage)
        {
            var effects = effectStorage
                .ResourceEffects
                .SelectMany(x => x.Value.ResourceEffects)
                .ToList();

            return effects;
        }

        public void Add(EffectStorage effectStorage, EffectModel effectModel)
        {
            effectStorage.Effects
                .AddOrUpdate(effectModel.Id, effectModel, (guid, model) => model);

            if (effectModel.ResourceEffects.Any())
            {
                effectStorage.ResourceEffects
                    .AddOrUpdate(effectModel.Id, effectModel, (guid, model) => model);
            }
        }

        public async Task RemoveNotActual(EffectStorage effectStorage, TimeSpan currentTime)
        {
            var removeExpiredTasks = effectStorage
                .Effects
                .Select(x =>
                    Task.Run(() => RemoveExpiredEffects(effectStorage, x.Value, currentTime)));

            await Task.WhenAll(removeExpiredTasks);
        }

        private void RemoveExpiredEffects(EffectStorage effectStorage, EffectModel effect, TimeSpan currentTime)
        {
            if (!effect.IsExpired(currentTime))
                return;
            
            effectStorage.Effects.TryRemove(effect.Id, out _);
            effectStorage.ResourceEffects.TryRemove(effect.Id, out _);
        }
    }
}