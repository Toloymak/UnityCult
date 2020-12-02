using System;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.Services;
using Leopotam.Ecs;

namespace Common.Systems.Village
{
    public class FieldControlSystem : BaseSystem, IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private FieldService _fieldService = null;
        private BuildingService _buildingService = null;

        private const int RowCount = 10;
        private const int ColumnCount = 10;
        
        public void Init()
        {
            var villageEntity = _ecsWorld.NewEntity();
            var villageFieldComponent = villageEntity.Set<VillageFieldComponent>();

            _fieldService.CreateVillageField(villageFieldComponent, RowCount, ColumnCount);

            LogService.AddLog(LogLevel.Debug, "Village matrix has been created");

            foreach (var district in BaseStateOfGame.Districts)
            {
                var cell = villageFieldComponent.FieldModel.GetItem(district.row, district.column);
                
                _buildingService.Build(cell, district.districtType);
            }
        }
    }
}