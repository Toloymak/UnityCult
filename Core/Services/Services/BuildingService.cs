using System;
using System.Collections.Generic;
using Models.Enums;
using Models.Models;
using Models.Models.Districts;
using Models.Models.Technologies;
using Models.Models.Villages;

namespace Services.Services
{
    public class BuildingService
    {
        public IList<DistrictModel> GetAvailableDistricts(VillageMapModel villageMapModel,
                                                          TechnologyModel technologies,
                                                          ResourcesStorage resourcesStorage)
        {
            var allDistricts = Enum.GetValues(typeof(DistrictType));

        }
    }
}