﻿using Business.Enums;
using Common.Enums;
using Core.Extensions;
using Core.Services.District;
using Core.UnityServiceContracts;
using Models.Models.Village;

namespace Core.Services
{
    public interface IBuildingService
    {
        void Build(VillageCellModel villageCellModel, DistrictType districtType);
    }
    
    public class BuildingService : IBuildingService
    {
        private readonly IUnityBuildingService _unityBuildingService;
        private readonly IResourceService _resourceService;
        private readonly ILogService _logService;
        private readonly IDistrictService _districtService;

        public BuildingService(IUnityBuildingService unityBuildingService,
                               IResourceService resourceService,
                               ILogService logService,
                               IDistrictService districtService)
        {
            _unityBuildingService = unityBuildingService;
            _resourceService = resourceService;
            _logService = logService;
            _districtService = districtService;
        }

        public void Build(VillageCellModel villageCellModel,
                          DistrictType districtType)
        {
            var districtModel = _districtService.GetDistrictTree().GetByType(districtType);
            
            if (!_resourceService.TryTakeResources(districtModel.Resources))
                return;
            
            villageCellModel.DistrictInfoModel = districtModel;
            
            _unityBuildingService.UpdateCellView(villageCellModel);
            
            _logService.Log(LogLevel.Success, $"District {districtModel.Name} has been built");
        }
    }
}