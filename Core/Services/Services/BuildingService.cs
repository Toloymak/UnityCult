using System;
using System.Collections.Generic;
using System.Linq;
using Business.Attributes;
using Common.Helpers;
using Managers.Managers;
using Models.Consts;
using Models.Enums;
using Models.Extensions;
using Models.Models;
using Models.Models.Districts;
using Models.Models.Technologies;
using Models.Models.Villages;

namespace Services.Services
{
    public interface IBuildingService
    {
        IList<DistrictModel> GetAvailableDistricts(VillageMapModel villageMapModel,
                                                   TechnologyModel technologies,
                                                   ResourcesStorage resourcesStorage,
                                                   VillageCellModel villageCellModel = null);
        
        bool BuildDistrict(VillageCellModel villageCellModel,
                           DistrictModel districtModel,
                           ResourcesStorage resourcesStorage);
    }

    public class BuildingService : IBuildingService
    {
        private readonly IResourceManager _resourceManager;

        public BuildingService(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }

        public IList<DistrictModel> GetAvailableDistricts(VillageMapModel villageMapModel,
                                                          TechnologyModel technologies,
                                                          ResourcesStorage resourcesStorage,
                                                          VillageCellModel villageCellModel = null)
        {
            var districts = DistrictConsts
               .AllDistricts
               .Where(x => 
                          villageCellModel?.District == null 
                              ? x.RootDistrict == DistrictType.None
                              : x.RootDistrict == villageCellModel.District?.Type)
               .ToList();

            return districts;
        }

        public bool BuildDistrict(VillageCellModel villageCellModel,
                                  DistrictModel districtModel,
                                  ResourcesStorage resourcesStorage)
        {
            if (_resourceManager.TryTake(resourcesStorage, districtModel.Price))
            {
                villageCellModel.District = districtModel;
                return true;
            }

            return false;
        }
    }
}