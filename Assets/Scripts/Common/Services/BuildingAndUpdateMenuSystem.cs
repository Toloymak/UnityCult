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
        private GameObject _listPanel;

        private GameObject ListPanel =>
            _listPanel != null
                ? _listPanel
                : _listPanel = GameObject.Find("BuildingScrollList/BuildingActionList");
        
        private Object _itemPrefab;

        private Object ItemPrefab =>
            _itemPrefab == null
                ? _itemPrefab = Resources.Load(ComponentPrefabNames.ListItem)
                : _itemPrefab;


        public void FillBuildingOrUpdateList(IList<BuildingActionItem> buildingActionItems)
        {
            ListPanel.transform.DeleteAllChildren();

            foreach (var buildingActionItem in buildingActionItems)
            {
                var newCell = Object.Instantiate(ItemPrefab, _listPanel.transform);
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