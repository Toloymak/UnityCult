using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Extensions;
using Common.Components;
using Common.Consts;
using Common.Models;
using Common.TypeExtensions;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Services
{
    public class BuildingAndUpdateMenuService
    {
        private Object _itemPrefab;

        private Object ItemPrefab =>
            _itemPrefab == null
                ? _itemPrefab = Resources.Load(ComponentPrefabNames.ListItem)
                : _itemPrefab;

        private Object _priceItem;

        private Object PriceItem =>
            _priceItem == null
                ? _priceItem = Resources.Load(ComponentPrefabNames.PriceItem)
                : _priceItem;
        
        public void FillBuildingOrUpdateList(IList<BuildingActionItem> buildingActionItems,
                                             UiStoreService uiStoreService,
                                             IDictionary<ResourceType, ResourceComponent> resourceComponents,
                                             DistrictCellModel districtCellModel)
        
        {
            uiStoreService.BuildActionList.transform.DeleteAllChildren();

            foreach (var buildingActionItem in buildingActionItems)
            {
                var itemGameObject = (GameObject) Object.Instantiate(ItemPrefab, uiStoreService.BuildActionList.transform);
                itemGameObject.name = $"buildingActionItem_{buildingActionItem.DistrictType.ToString()}_{Guid.NewGuid()}";
                
                itemGameObject.transform.Find("Name").GetComponent<Text>().text =
                    buildingActionItem.DistrictType.GetName();
                itemGameObject.transform.Find("Description").GetComponent<Text>().text = buildingActionItem
                   .DistrictType.GetDescription();

                var isEnoughMoney = buildingActionItem.IsEnoughResources(resourceComponents);
                var button = itemGameObject.GetComponent<Button>();
                button.interactable = isEnoughMoney;

                var buttonEvent = new Button.ButtonClickedEvent();
                buttonEvent.AddListener(() =>
                {
                    Build(districtCellModel, resourceComponents, buildingActionItem.DistrictType, uiStoreService);
                });
                
                button.onClick = buttonEvent;
                
                var priceListGameObject = itemGameObject.transform.Find(UiObjectNames.PriceItemInListItem);
                priceListGameObject.transform.DeleteAllChildren();

                foreach (var price in buildingActionItem.DistrictType.GetPrices())
                {
                    var newPrice = (GameObject) Object.Instantiate(PriceItem, priceListGameObject.transform);
                    
                    newPrice.transform.Find("Name").GetComponent<Text>().text = price.Item1.GetShortName();
                    newPrice.transform.Find("Value").GetComponent<Text>().text = price.Item2.ToString();
                }
            }
        }

        public void Build(DistrictCellModel districtCellModel,
                          IDictionary<ResourceType, ResourceComponent> resourceComponents,
                          DistrictType districtType,
                          UiStoreService uiStoreService)
        {
            var prices = districtType.GetPrices();
            foreach (var price in prices)
            {
                resourceComponents[price.type].Count -= price.value;
            }
            
            districtCellModel.Type = districtType;

            var texture = districtType.GetTexturePath();

            if (!string.IsNullOrEmpty(texture))
            {
                var img = Resources.Load<Sprite>(texture);
                districtCellModel.GetLogo.sprite = Object.Instantiate(img);
            }
            
            Debug.Log($"District {districtType} on cell {districtCellModel.Name} was built");

            uiStoreService.BuildActionList.transform.DeleteAllChildren();
            districtCellModel.GameObject.GetComponent<Toggle>().isOn = false;
        }
    }
}