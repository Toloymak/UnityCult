using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Models.Models;
using Models.Models.Village;

namespace Core.Extensions
{
    public static class DistrictExtensions
    {
        public static IList<DistrictInfoModel> GetAvailable(this IList<DistrictInfoModel> districtModels)
        {
            return districtModels.Where(x => x.DistrictType != DistrictType.None).ToList();
        }

        public static bool WasChangedBuildingList(this IList<DistrictInfoModel> districtModels,
                                                  IList<DistrictInfoModel> cachedDistrictModels)
        {
            if (cachedDistrictModels.Count == districtModels.Count)
            {
                return districtModels
                   .Where((t, i) => t.DistrictType != cachedDistrictModels[i].DistrictType)
                   .Any();
            }
            
            return true;
        }
        
        public static DistrictInfoModel GetByType(this IList<DistrictInfoModel> districtModels, DistrictType districtType)
        {
            foreach (var districtModel in districtModels)
            {
                var result = Find(districtModel, districtType);
                if (result != null)
                    return result;
            }

            return null;
        }
        
        private static DistrictInfoModel Find(DistrictInfoModel districtInfoModel, DistrictType districtType)
        {
            if (districtInfoModel.DistrictType == districtType)
                return districtInfoModel;

            if (districtInfoModel.ChildDistricts == null)
                return null;
            
            foreach (var model in districtInfoModel.ChildDistricts)
            {
                var result = Find(model, districtType);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}