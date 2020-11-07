using System;
using System.Collections.Generic;
using System.Linq;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.GameTypes;
using Common.Models;
using Common.Services;
using Common.Storages;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Systems.Village
{
    public class FieldControlSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<LogComponent> _logComponentFilter = null;

        private FieldService _fieldService = null;
        private BuildingAndUpdateMenuSystem _buildingAndUpdateMenuSystem = null;
        
        private const int RowCount = 10;
        private const int ColumnCount = 10;
        
        public void Init()
        {
            if (_fieldGroup == null)
                _fieldGroup = UiEventStorage.GetGroup(ObjectGroups.FieldGroup);
            
            SetLogComponent(_logComponentFilter);
            
            var villageEntity = _ecsWorld.NewEntity();
            var villageFieldComponent = villageEntity.Set<VillageFieldComponent>();

            _fieldService.CreateVillageField(villageFieldComponent, RowCount, ColumnCount);

            LogComponent.AddLog(LogLevel.Debug, "Village matrix has been created");
        }

        private HashSet<UIActionModel> _fieldGroup;
        
        public void Run()
        {
            PrepareFieldClicks();
        }

        private void PrepareFieldClicks()
        {
            while (_fieldGroup.Any())
            {
                var action = _fieldGroup.First();

                switch (action.Type)
                {
                    case UiActionType.Click:
                        break;
                    case UiActionType.Selected:
                        _buildingAndUpdateMenuSystem.FillBuildingOrUpdateList(new List<BuildingActionItem>()
                        {
                            new BuildingActionItem(){DistrictType = DistrictType.Administration},
                            new BuildingActionItem(){DistrictType = DistrictType.Arena},
                            new BuildingActionItem(){DistrictType = DistrictType.Factory},
                        });
                        break;
                    case UiActionType.Unselected:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                UiEventStorage.RemoveClick(ObjectGroups.FieldGroup, action.ObjectName, action.Type);
            }
        }
    }
}