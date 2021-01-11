using Core.Services;
using Extensions;
using Interfaces;
using Models;
using Models.Models.Village;
using UnityEngine;

namespace Services
{
    public class MouseControlService : IUpdateService
    {
        private readonly BuildingProcessModel _buildingProcessModel;
        private readonly IBuildingService _buildingService;
        private readonly IStorageService _storageService;

        public MouseControlService(IStorageService storageService, IBuildingService buildingService)
        {
            _storageService = storageService;
            _buildingService = buildingService;
            _buildingProcessModel = storageService.GetOrCreate<BuildingProcessModel>();
        }

        public void Update()
        {
            ProcessBuilding();
        }

        private void ProcessBuilding()
        {
            if (_buildingProcessModel.DistrictInProcess != null && Input.GetMouseButton(0))
            {
                if (TryGetCell(out var cell))
                {
                    _buildingService.Build(cell, _buildingProcessModel.DistrictType);

                    _storageService.Get<BuildingProcessModel>().DistrictInProcess = null;
                }
                else
                {
                    Debug.LogWarning("Trying to build not in the village");
                }
            }
        }

        private bool TryGetCell(out VillageCellModel cell)
        {
            return _storageService.Get<VillageMapModel>()
               .CoordinateDictionary
               .TryGetValue(_buildingProcessModel.DistrictInProcess.transform.GetXZCellPosition(), out cell);
        }
    }
}