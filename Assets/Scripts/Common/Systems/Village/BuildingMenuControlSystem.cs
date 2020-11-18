using System;
using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Business.Extensions;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.Models;
using Common.Services;
using Common.Storages;
using Leopotam.Ecs;

namespace Common.Systems.Village
{
    public class BuildingMenuControlSystem : BaseSystem, IEcsRunSystem, IEcsInitSystem
    {
        private BuildingAndUpdateMenuService _buildingAndUpdateMenuService = null;
        private EcsFilter<LogComponent> _logComponentFilter = null;
        private EcsFilter<ResourceComponent> _resourceComponentFilter = null;

        private UiStoreService _uiStoreService = null;

        private HashSet<UIActionModel> _fieldUiActionGroup;
        private IDictionary<ResourceType, ResourceComponent> _resourceComponents;

        public void Init()
        {
            SetLogComponent(_logComponentFilter);
        }

        public void Run()
        {
            if (_fieldUiActionGroup == null)
                _fieldUiActionGroup = UiEventStorage.GetGroup(ObjectGroups.FieldGroup);

            if (_resourceComponents == null && _resourceComponentFilter != null)
                _resourceComponents = _resourceComponentFilter.ToDictionary();
            
            ProcessFieldClicks();
        }

        private void ProcessFieldClicks()
        {
            while (_fieldUiActionGroup.Any())
            {
                var action = _fieldUiActionGroup.First();

                switch (action.Type)
                {
                    case UiActionType.Click:
                        break;
                    case UiActionType.Selected:
                        _buildingAndUpdateMenuService
                           .FillBuildingOrUpdateList(GetTestBuildingActionItems,
                                                     _uiStoreService, 
                                                     _resourceComponents);
                        break;
                    case UiActionType.Unselected:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                UiEventStorage.RemoveClick(ObjectGroups.FieldGroup, action.ObjectName, action.Type);
            }
        }

        private List<BuildingActionItem> GetTestBuildingActionItems =>
            new List<BuildingActionItem>()
            {
                new BuildingActionItem() {DistrictType = DistrictType.Administration},
                new BuildingActionItem() {DistrictType = DistrictType.Arena},
                new BuildingActionItem() {DistrictType = DistrictType.Factory},
                new BuildingActionItem() {DistrictType = DistrictType.Alchemy},
            };
    }
}