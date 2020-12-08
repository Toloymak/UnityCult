using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Interfaces;
using Business.Models.Actions;
using Common.Consts;
using Common.Services;
using Common.Storages;
using Common.TypeExtensions;
using Leopotam.Ecs;

namespace Common.Systems.Actions
{
    public class ActionMenuControlSystem : BaseSystem, IEcsInitSystem
    {
        private UiObjectStorage _uiObjectStorage = null;
        private ItemListUiService _itemListUiService = null;


        public void Init()
        {
            _uiObjectStorage.GetGameObject(UiObjectNames.ActionList).transform.DeleteAllChildren();
            FillActionPanel();
        }

        private void FillActionPanel()
        {
            var actionList = _uiObjectStorage.GetGameObject(UiObjectNames.ActionList).transform;
            
            _itemListUiService.AddItems(actionList, _testActionModels);
        }

        private static readonly IList<IListItem> _testActionModels = new List<IListItem>()
        {
            new ActionModel()
            {
                Name = "Exploring something",
                Description = "Go to exploring something",
                BaseDuring = new TimeSpan(0, 5, 0),
                Resources = new Dictionary<ResourceType, int>()
                {
                    {ResourceType.Energy, 100},
                    {ResourceType.Food, 500}
                }
            },
            new ActionModel()
            {
                Name = "Attack something",
                Description = "Go to attack somebody",
                BaseDuring = new TimeSpan(0, 5, 0),
                Resources = new Dictionary<ResourceType, int>()
                {
                    {ResourceType.OrdinarySoulStone, 1000},
                }
            },
            new ActionModel()
            {
                Name = "Trading",
                Description = "Go to buy or sell something",
                BaseDuring = new TimeSpan(0, 5, 0),
                Resources = new Dictionary<ResourceType, int>()
                {
                    {ResourceType.OrdinarySoulStone, 1000},
                    {ResourceType.Food, 500}
                }
            },
        };
    }
}