using System.Collections.Generic;
using System.Linq;
using Models.Consts;
using Models.Enums;
using Models.Models.Districts;

namespace Models.Extensions
{
    public static class DistrictExtensions
    {
        private static readonly IDictionary<DistrictType, DistrictModel> AllDistrictsDictionary =
            DistrictConsts.AllDistricts.ToDictionary(m => m.Type);

        public static DistrictModel GetModel(this DistrictType type) =>
            AllDistrictsDictionary[type];
    }
}