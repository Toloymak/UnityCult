using System;
using System.Collections.Generic;
using System.Linq;
using Business.Attributes;
using Common.Helpers;
using Managers.Managers;
using Models.Enums;
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
            var allDistricts = EnumHelper.GetAllEnumValues<DistrictType>();

            var districts = allDistricts
               .Select(x => new DistrictAttributeModel(x))
               .Where(x => 
                          villageCellModel?.District == null 
                              ? x.RootDistrictAttribute?.RootDistrict == null
                              : x.RootDistrictAttribute?.RootDistrict == villageCellModel.District?.Type)
               .Select(x => new DistrictModel()
                {
                    Name = x.DistrictDescriptionAttribute.Name,
                    Description = x.DistrictDescriptionAttribute.Description,
                    Type = x.Type,
                    Price = new Dictionary<ResourceType, int>() 
                })
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