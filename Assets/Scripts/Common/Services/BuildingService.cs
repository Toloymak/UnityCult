using System.Collections.Generic;
using Business.Enums;
using Business.Extensions;
using Common.Components;
using Common.Consts;
using Common.Models;
using Common.Storages;
using Common.TypeExtensions;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Services
{
    public class BuildingService
    {
        private UiObjectStorage _uiObjectStorage;

        public BuildingService(UiObjectStorage uiObjectStorage)
        {
            _uiObjectStorage = uiObjectStorage;
        }

        public void GetClickAction(DistrictCellModel districtCellModel,
                                   DistrictType districtType,
                                   IDictionary<ResourceType, ResourceComponent> resourceComponents)
        {
            Build(districtCellModel, resourceComponents, districtType);
            _uiObjectStorage.GetGameObject(UiObjectNames.BuildingActionList).transform.DeleteAllChildren();
        }
        
        public void Build(DistrictCellModel districtCellModel,
                          IDictionary<ResourceType, ResourceComponent> resourceComponents,
                          DistrictType districtType)
        {
            var prices = districtType.GetPrices();
            foreach (var price in prices)
            {
                resourceComponents[price.Key].Count -= price.Value;
            }
            
            Build(districtCellModel, districtType);

            districtCellModel.GameObject.GetComponent<Toggle>().isOn = false;
        }

        public void Build(DistrictCellModel districtCellModel, DistrictType districtType)
        {
            districtCellModel.Type = districtType;
            districtCellModel.GetName.text = districtType.GetName();

            var texture = districtType.GetTexturePath();

            if (!string.IsNullOrEmpty(texture))
            {
                var img = Resources.Load<Sprite>(texture);
                districtCellModel.GetLogo.sprite = Object.Instantiate(img);
            }
            
            Debug.Log($"District {districtType} on cell {districtCellModel.Name} was built");
        }
    }
}