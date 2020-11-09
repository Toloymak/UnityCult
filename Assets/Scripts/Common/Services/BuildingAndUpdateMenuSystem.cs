using System;
using System.Collections.Generic;
using Common.Consts;
using Common.Extensions;
using Common.Models;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Services
{
    public class BuildingAndUpdateMenuSystem
    {
        private Object _itemPrefab;

        private Object ItemPrefab =>
            _itemPrefab == null
                ? _itemPrefab = Resources.Load(ComponentPrefabNames.ListItem)
                : _itemPrefab;
        
        public void FillBuildingOrUpdateList(IList<BuildingActionItem> buildingActionItems, UiStoreService uiStoreService)
        {
            uiStoreService.BuildActionList.transform.DeleteAllChildren();

            foreach (var buildingActionItem in buildingActionItems)
            {
                var newCell = Object.Instantiate(ItemPrefab, uiStoreService.BuildActionList.transform);
                newCell.name = $"buildingActionItem_{buildingActionItem.DistrictType.ToString()}_{Guid.NewGuid()}";

                var itemGameObject = GameObject.Find(newCell.name);
                itemGameObject.transform.Find("Name").GetComponent<Text>().text =
                    buildingActionItem.DistrictType.GetName();
                itemGameObject.transform.Find("Description").GetComponent<Text>().text = buildingActionItem
                   .DistrictType.GetDescription();
                
                
                itemGameObject.transform.Find("Prices").Find("Text").GetComponent<Text>().text = "-";
            }
            
        }
    }
}