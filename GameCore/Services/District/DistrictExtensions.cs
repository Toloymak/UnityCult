using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Business.Models.Districts;

namespace Core.Services.District
{
    public static class DistrictExtensions
    {
        public static IList<DistrictModel> GetAvailable(this IList<DistrictModel> districtModels)
        {
            return districtModels.Where(x => x.DistrictType != DistrictType.None).ToList();
        }

        public static bool WasChangedBuildingList(this IList<DistrictModel> districtModels,
                                                  IList<DistrictModel> cachedDistrictModels)
        {
            if (cachedDistrictModels.Count == districtModels.Count)
            {
                return districtModels
                   .Where((t, i) => t.DistrictType != cachedDistrictModels[i].DistrictType)
                   .Any();
            }
            
            return true;
        }
    }
}