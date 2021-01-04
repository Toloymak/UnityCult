using System;
using System.Collections.Generic;
using Business.Models.Districts;
using Common.TypeExtensions;
using Consts;
using Core.Services.District;
using Helpers;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Building
{
    public class BuildingPanelService : UpdatableMenuBaseService, IInitService
    {
        private readonly IDistrictService _districtService;
        private readonly ObjectInstantiateHelper _objectInstantiateHelper;
        private GameObject _buildingPanel;
        private Toggle _buildingButton;
        private GameObject _buildingPanelContent;

        private IList<DistrictModel> _cachedDistrictModels;
            
        public BuildingPanelService(UnityObjectCacheService unityObjectCacheService,
                                    IDistrictService districtService,
                                    ObjectInstantiateHelper objectInstantiateHelper)
            : base(Parameters.DefaultUpdatePeriod)
        {
            _districtService = districtService;
            _objectInstantiateHelper = objectInstantiateHelper;
            _buildingPanel = unityObjectCacheService.GetGameObject(UiObjectNames.BuildingPanel);
            _buildingButton = unityObjectCacheService
               .GetGameObject(UiObjectNames.BuildingButton)
               .GetComponent<Toggle>();
            _buildingPanelContent = unityObjectCacheService
               .GetGameObject(UiObjectNames.BuildingPanelContent);

            _cachedDistrictModels = new List<DistrictModel>();
        }

        public override void Init()
        {
            _buildingButton.onValueChanged = BuildingButtonEvent();
            _buildingPanel.SetActive(false);
        }
        
        public override void Update()
        {
            if (!_buildingPanel.activeSelf || !NeedUpdate()) 
                return;
            
            var districtTree = _districtService.GetDistrictTree().GetAvailable();

            if (!districtTree.WasChangedBuildingList(_cachedDistrictModels))
                return;

            UpdateBuildingList(districtTree);
            _cachedDistrictModels = districtTree;
        }

        private void UpdateBuildingList(IList<DistrictModel> districtTree)
        {
            Debug.Log("Update building list");
            
            _buildingPanelContent.transform.DeleteAllChildren();
            
            foreach (var districtModel in districtTree)
            {
                var item = _objectInstantiateHelper
                   .Instanate(PrefabNames.DistrictListItem, _buildingPanelContent.transform);

                item.transform.Find("Text").GetComponent<Text>().text = districtModel.Name;
            }
        }

        private Toggle.ToggleEvent BuildingButtonEvent()
        {
            var buildingOnClickEvent = new Toggle.ToggleEvent();
            buildingOnClickEvent.AddListener(value => _buildingPanel.SetActive(value));
            return buildingOnClickEvent;
        }
    }
}