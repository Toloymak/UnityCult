using System;
using Common.Components;
using Common.Enums;
using Common.Services;
using Leopotam.Ecs;

namespace Common.Systems.Village
{
    public class FieldControlSystem : BaseSystem, IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private FieldService _fieldService = null;
        
        private const int RowCount = 10;
        private const int ColumnCount = 10;
        
        public void Init()
        {
            var villageEntity = _ecsWorld.NewEntity();
            var villageFieldComponent = villageEntity.Set<VillageFieldComponent>();

            _fieldService.CreateVillageField(villageFieldComponent, RowCount, ColumnCount);

            LogService.AddLog(LogLevel.Debug, "Village matrix has been created");
        }
    }
}