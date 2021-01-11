using System.Collections.Generic;
using Consts;
using Core.Extensions;
using Core.Services;
using Core.Services.District;
using Core.UnityServiceContracts;
using Extensions;
using Helpers;
using Interfaces;
using Models;
using Models.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Building
{
    public class BuildingPanelService : UpdatableMenuBaseService, IInitService
    {
        private readonly IDistrictService _districtService;
        private readonly GameObject _buildingPanel;
        private readonly Toggle _buildingButton;
        private readonly GameObject _buildingPanelContent;
        private readonly IButtonHelper _buttonHelper;
        private readonly IEventHelper _eventHelper;
        private readonly IUnityBuildingService _unityBuildingService;

        private IList<DistrictModel> _cachedDistrictModels;
            
        public BuildingPanelService(UnityObjectCacheService unityObjectCacheService,
                                    IDistrictService districtService,
                                    IButtonHelper buttonHelper,
                                    IEventHelper eventHelper,
                                    IUnityBuildingService unityBuildingService)
            : base(Parameters.DefaultUpdatePeriod)
        {
            _districtService = districtService;
            _buttonHelper = buttonHelper;
            _eventHelper = eventHelper;
            _unityBuildingService = unityBuildingService;
            _buildingPanel = unityObjectCacheService.GetGameObject(UiObjectNames.BuildingPanel);
            _buildingButton = unityObjectCacheService
               .GetGameObject(UiObjectNames.BuildingButton)
               .GetComponent<Toggle>();
            _buildingPanelContent = unityObjectCacheService
               .GetGameObject(UiObjectNames.BuildingPanelContent);

            _cachedDistrictModels = new List<DistrictModel>();
        }

        public void Init()
        {
            _buildingButton.onValueChanged = _eventHelper.CreateToggleEvent(value => _buildingPanel.SetActive(value));
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
            _buildingPanelContent.transform.DeleteAllChildren();

            foreach (var districtModel in districtTree)
            {
                _buttonHelper
                   .CreateListItem(districtModel.ToListItemModel(() =>
                                   {
                                       _unityBuildingService.ShowDistrictForBuilding(districtModel.DistrictType);
                                   }),
                                   _buildingPanelContent.transform);
            }
        }
    }
}