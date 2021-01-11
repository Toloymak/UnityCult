using Business.Enums;
using Consts;
using Core.Services;
using Core.UnityServiceContracts;
using Helpers;
using Models;
using Models.Models.Village;

namespace Services
{
    public class UnityBuildingService : IUnityBuildingService
    {
        private readonly IObjectInstantiateHelper _objectInstantiateHelper;
        private readonly IStorageService _storageService;

        public UnityBuildingService(IObjectInstantiateHelper objectInstantiateHelper,
                                    IStorageService storageService)
        {
            _objectInstantiateHelper = objectInstantiateHelper;
            _storageService = storageService;
        }

        public void UpdateCellView(VillageCellModel villageCellModel)
        {
            throw new System.NotImplementedException();
        }

        public void ShowDistrictForBuilding(DistrictType districtType)
        {
            var obj = _objectInstantiateHelper.Instanate(DistrictPrefabNames.DefaultPrefab, null);
            _storageService.GetOrCreate<BuildingProcessModel>().DistrictInProcess = obj;
            _storageService.GetOrCreate<BuildingProcessModel>().DistrictType = districtType;
        }
    }
}