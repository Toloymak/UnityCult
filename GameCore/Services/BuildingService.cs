using Business.Models.Districts;
using Common.Enums;
using Core.UnityServiceContracts;
using Models.Models.Village;

namespace Core.Services
{
    public interface IBuildingService
    {
        void Build(VillageCellModel villageCellModel, DistrictModel districtModel);
    }
    
    public class BuildingService : IBuildingService
    {
        private readonly IUnityBuildingService _unityBuildingService;
        private readonly IResourceService _resourceService;
        private readonly ILogService _logService;

        public BuildingService(IUnityBuildingService unityBuildingService,
                               IResourceService resourceService,
                               ILogService logService)
        {
            _unityBuildingService = unityBuildingService;
            _resourceService = resourceService;
            _logService = logService;
        }

        public void Build(VillageCellModel villageCellModel,
                          DistrictModel districtModel)
        {
            if (!_resourceService.TryTakeResources(districtModel.Resources))
                return;
            
            villageCellModel.DistrictModel = districtModel;
            
            _unityBuildingService.UpdateCellView(villageCellModel);
            
            _logService.Log(LogLevel.Success, $"District {districtModel.Name} has been built");
        }
    }
}