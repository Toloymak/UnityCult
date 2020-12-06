using System;
using System.Collections.Generic;
using System.Linq;
using Business.Enums;
using Business.Extensions;
using Business.Interfaces;
using Business.Models.Actions;
using Common.Consts;
using Common.Helpers;
using Common.Services;
using Common.TypeExtensions;
using Leopotam.Ecs;
using SimpleInjector;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Systems.Actions
{
    public class ActionMenuControlSystem : BaseSystem, IEcsInitSystem
    {
        private UiStoreService _uiStoreService = null;
        private ItemListService _itemListService = null;


        public void Init()
        {
            _uiStoreService.ActionList.transform.DeleteAllChildren();
            FillActionPanel();
        }

        private void FillActionPanel()
        {
            _itemListService.AddItems(_uiStoreService.ActionList.transform,
                                      _testActionModels);
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