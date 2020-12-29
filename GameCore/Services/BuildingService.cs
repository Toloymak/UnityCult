using Business.Models.Districts;
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

        public BuildingService(IUnityBuildingService unityBuildingService)
        {
            _unityBuildingService = unityBuildingService;
        }

        public void Build(VillageCellModel villageCellModel,
                          DistrictModel districtModel)
        {
            villageCellModel.DistrictModel = districtModel;
            
            _unityBuildingService.UpdateCellView(villageCellModel);
        }
    }
}