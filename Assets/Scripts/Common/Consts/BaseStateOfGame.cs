using System.Collections.Generic;
using Business.Enums;

namespace Common.Consts
{
    public static class BaseStateOfGame
    {
        public static IList<(DistrictType districtType, int row, int column)> Districts = 
            new List<(DistrictType, int, int)>
            {
                (DistrictType.Camp, 3, 5)
            };
    }
}