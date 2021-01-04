using Consts;
using Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Services.Building
{
    public class BuildingPanelService : UpdatableMenuBaseService, IInitService
    { 
        private GameObject _buildingPanel;
        private Toggle _buildingButton;

        public BuildingPanelService(UnityObjectCacheService unityObjectCacheService)
            : base(Parameters.DefaultUpdatePeriod)
        {
            _buildingPanel = unityObjectCacheService.GetGameObject(UiObjectNames.BuildingPanel);
            _buildingButton = unityObjectCacheService
               .GetGameObject(UiObjectNames.BuildingButton)
               .GetComponent<Toggle>();
        }

        public override void Init()
        {
            _buildingButton.onValueChanged = BuildingButtonEvent();
            _buildingPanel.SetActive(false);
        }

        public override void Update()
        {
            if (_buildingPanel.activeSelf && NeedUpdate())
            {
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