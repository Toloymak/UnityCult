using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;

namespace Managers.Managers
{
    public interface IEffectManager
    {
        Task<ICollection<ResourceEffectModel>> GetResourceEffects();
    }

    public class EffectManager : IEffectManager
    {
        public Task<ICollection<ResourceEffectModel>> GetResourceEffects()
        {
            throw new System.NotImplementedException();
        }
    }
}