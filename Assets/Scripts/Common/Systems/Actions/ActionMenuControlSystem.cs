using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Extensions;
using Business.Models.Actions;
using Common.Components;
using Common.Consts;
using Common.Models;
using Common.Services;
using Common.TypeExtensions;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Systems.Actions
{
    public class ActionMenuControlSystem : BaseSystem, IEcsInitSystem
    {
        private UiPrefabStoreService _uiPrefabStoreService = null;
        private UiStoreService _uiStoreService = null;

        public void Init()
        { 
            _uiStoreService.ActionList.transform.DeleteAllChildren();
            FillActionPanel();
        }

        private void FillActionPanel()
        {
            foreach (var actionModel in _testActionModels)
            {
                var newObject = (GameObject) Object.Instantiate(_uiPrefabStoreService.ListItem, _uiStoreService.ActionList
                .transform);
                newObject.name = $"action_{actionModel.Id}";
                newObject.transform.Find("Name").GetComponent<Text>().text = actionModel.Name;
                newObject.transform.Find("Description").GetComponent<Text>().text = actionModel.Description;
                
                var priceListGameObject = newObject.transform.Find(UiObjectNames.PriceItemInListItem);
                priceListGameObject.transform.DeleteAllChildren();
                
                foreach (var reword in actionModel.Resources)
                {
                    var newPrice = (GameObject) Object.Instantiate(PriceItem, priceListGameObject.transform);
                    
                    newPrice.transform.Find("Name").GetComponent<Text>().text = reword.Key.GetShortName();
                    newPrice.transform.Find("Value").GetComponent<Text>().text = reword.Value.ToString();
                }
            }
        }
        
        private Object _priceItem;

        private Object PriceItem =>
            _priceItem == null
                ? _priceItem = UnityEngine.Resources.Load(ComponentPrefabNames.ResourceItem)
                : _priceItem;

        private static IList<ActionModel> _testActionModels = new List<ActionModel>()
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