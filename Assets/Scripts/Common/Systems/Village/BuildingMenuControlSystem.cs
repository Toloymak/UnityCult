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
using Leopotam.Ecs;

namespace Common.Systems.Village
{
    public class BuildingMenuControlSystem : BaseSystem, IEcsRunSystem
    {
        private BuildingService _buildingService = null;
        private EcsFilter<ResourceComponent> _resourceComponentFilter = null;
        private EcsFilter<VillageFieldComponent> _villageFiledComponentFilter = null;
        private ItemListUiService _itemListUiService = null;

        private UiObjectStorage _uiObjectStorage = null;

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
                        CreateBuildMenu(action);
                        break;
                    case UiActionType.Unselected:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                UiEventStorage.RemoveClick(ObjectGroups.FieldGroup, action.ObjectName, action.Type);
            }
        }

        private void CreateBuildMenu(UIActionModel action)
        {
            var cell = _villageFieldComponent.FieldModel.GetItemByName(action.ObjectName);

            var availableDistricts = new DistrictHelper()
               .GetAvailableBuildings(cell.Type, _villageFieldComponent.GetExistingTypes())
               .Select(x => x.GetModel(() => _buildingService.GetClickAction(cell, x, _resourceComponents)));

            var buildActionList = _uiObjectStorage.GetGameObject(UiObjectNames.BuildingActionList);
            
            _itemListUiService.AddItems(buildActionList.transform, availableDistricts);
        }
    }
}