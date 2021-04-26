using System;
using System.Collections.Generic;
using System.Linq;
using Business.Attributes;
using Common.Helpers;
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
            var allDistricts = EnumHelper.GetAllEnumValues<DistrictType>();

            var type = typeof(DistrictType);
            var districts = allDistricts
               .Select(x => new DistrictAttributeModel(x))
               .Select(x => new DistrictModel()
                {
                    Name = x.DistrictDescriptionAttribute.Name,
                    Description = x.DistrictDescriptionAttribute.Description,
                    Type = x.Type,
                })
               .ToList();

            return districts;
        }
    }
}