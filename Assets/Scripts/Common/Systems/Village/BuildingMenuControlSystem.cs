using System;
using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Business.Extensions;
using Business.Helpers;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.Models;
using Common.Services;
using Common.Storages;
using Common.TypeExtensions;
using Leopotam.Ecs;

namespace Common.Systems.Village
{
    public class BuildingMenuControlSystem : BaseSystem, IEcsRunSystem
    {
        private BuildingAndUpdateMenuService _buildingAndUpdateMenuService = null;
        private EcsFilter<ResourceComponent> _resourceComponentFilter = null;
        private EcsFilter<VillageFieldComponent> _villageFiledComponentFilter = null;

        private UiStoreService _uiStoreService = null;

        private HashSet<UIActionModel> _fieldUiActionGroup;
        private IDictionary<ResourceType, ResourceComponent> _resourceComponents;
        private VillageFieldComponent _villageFieldComponent;

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

                if (_villageFieldComponent == null)
                    _villageFieldComponent = _villageFiledComponentFilter.Get1[0];

                switch (action.Type)
                {
                    case UiActionType.Click:
                        break;
                    case UiActionType.Selected:
                        var addresses = action.ObjectName.Split('_').Select(int.Parse).ToArray();
                        var cell = _villageFieldComponent.FieldModel.GetItem(addresses[0], addresses[1]);
                        _buildingAndUpdateMenuService
                           .FillBuildingOrUpdateList(new DistrictHelper().GetAvailableBuildings(cell.Type, new[] { DistrictType.None }),
                                                     _uiStoreService,
                                                     _resourceComponents,
                                                     cell);
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