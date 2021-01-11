using Consts;
using Core.Services;
using Extensions;
using Helpers;
using Interfaces;
using Models;
using Models.Models.Village;
using UnityEngine;

namespace Services.Building
{
    public class DistrictBuildingProcessService : IUpdateService
    {
        private readonly IStorageService _storageService;
        private readonly IMouseHelper _mouseHelper;
        private readonly PrefabCacheService _prefabCacheService;
        private readonly BuildingProcessModel _buildingProcessModel;
        private readonly IBuildingService _buildingService;

        public DistrictBuildingProcessService(IStorageService storageService,
                                              IMouseHelper mouseHelper,
                                              PrefabCacheService prefabCacheService,
                                              IBuildingService buildingService)
        {
            _storageService = storageService;
            _mouseHelper = mouseHelper;
            _prefabCacheService = prefabCacheService;
            _buildingService = buildingService;
            _buildingProcessModel = storageService.GetOrCreate<BuildingProcessModel>();
        }

        public void Update()
        {
            var districtInProcess = _storageService.GetOrCreate<BuildingProcessModel>();
            
            if (districtInProcess.DistrictInProcess == null)
                return;


            if (_buildingProcessModel.DistrictInProcess != null && Input.GetMouseButton(0))
            {
                ProcessBuilding(districtInProcess);
            }
            else if (_mouseHelper.TryGetMousePosition(out var position))
            {
                UpdateDistrictPosition(districtInProcess, position);
            }
        }

        private void UpdateDistrictPosition(BuildingProcessModel districtInProcess, Vector3 position)
        {
            districtInProcess.DistrictInProcess.transform.position = position.GetRoundVector().SetY(1.5f);

            if (TryGetCell(out _))
            {
                ChangeColor(districtInProcess, DistrictPrefabNames.BuildingGreenColorMaterial);
            }
            else
            {
                ChangeColor(districtInProcess, DistrictPrefabNames.BuildingRedColorMaterial);
            }
        }

        private void ChangeColor(BuildingProcessModel districtInProcess, string material)
        {
            districtInProcess.DistrictInProcess.GetComponent<Renderer>().material =
                (Material) _prefabCacheService.GetPrefab(material);
        }

        private void ProcessBuilding(BuildingProcessModel buildingProcessModel)
        {
            if (TryGetCell(out var cell))
            {
                _buildingService.Build(cell, _buildingProcessModel.DistrictType);
                
                ChangeColor(buildingProcessModel, DistrictPrefabNames.BuildingGreyColorMaterial);
                buildingProcessModel.DistrictInProcess = null;
            }
            else
            {
                Debug.LogWarning("Trying to build not in the village");
            }
        }

        private bool TryGetCell(out VillageCellModel cell)
        {
            return _storageService.Get<VillageMapModel>()
               .MapCoordinateDictionary
               .TryGetValue(_buildingProcessModel.DistrictInProcess.transform.GetXZCellPosition(), out cell);
        }
    }
}