using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;

namespace Managers.Managers
{
    public interface IDistrictManager
    {
        Task<ICollection<ResourceEffectModel>> GetResourceEffectModels();
    }

    public class DistrictManager : IDistrictManager
    {
        public Task<ICollection<ResourceEffectModel>> GetResourceEffectModels()
        {
            throw new System.NotImplementedException();
        }
    }
}