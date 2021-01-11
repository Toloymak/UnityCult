using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Models.Models;

namespace Core.Extensions
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
        
        public static DistrictModel GetByType(this IList<DistrictModel> districtModels, DistrictType districtType)
        {
            foreach (var districtModel in districtModels)
            {
                var result = Find(districtModel, districtType);
                if (result != null)
                    return result;
            }

            return null;
        }
        
        private static DistrictModel Find(DistrictModel districtModel, DistrictType districtType)
        {
            if (districtModel.DistrictType == districtType)
                return districtModel;

            if (districtModel.ChildDistricts == null)
                return null;
            
            foreach (var model in districtModel.ChildDistricts)
            {
                var result = Find(model, districtType);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}