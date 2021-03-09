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
        IList<ResourceEffectModel> GetResourceEffects();
        void Add(EffectModel effectModel);
        Task RemoveNotActual(TimeSpan currentTime);
    }

    public class EffectManager : IEffectManager
    {
        private readonly EffectStorageModel _effectStorage;

        public EffectManager(EffectStorageModel effectStorage)
        {
            _effectStorage = effectStorage;
        }

        public IList<ResourceEffectModel> GetResourceEffects()
        {
            var effects = _effectStorage
                .ResourceEffects
                .SelectMany(x => x.Value.ResourceEffects)
                .ToList();

            return effects;
        }

        public void Add(EffectModel effectModel)
        {
            _effectStorage.Effects
                .AddOrUpdate(effectModel.Id, effectModel, (guid, model) => model);

            if (effectModel.ResourceEffects.Any())
            {
                _effectStorage.ResourceEffects
                    .AddOrUpdate(effectModel.Id, effectModel, (guid, model) => model);
            }
        }

        public async Task RemoveNotActual(TimeSpan currentTime)
        {
            var removeExpiredTasks = _effectStorage
                .Effects
                .Select(x =>
                    Task.Run(() => RemoveExpiredEffects(x.Value, currentTime)));

            await Task.WhenAll(removeExpiredTasks);
        }

        private void RemoveExpiredEffects(EffectModel effect, TimeSpan currentTime)
        {
            if (!effect.IsExpired(currentTime))
                return;
            
            _effectStorage.Effects.TryRemove(effect.Id, out _);
            _effectStorage.ResourceEffects.TryRemove(effect.Id, out _);
        }
    }
}