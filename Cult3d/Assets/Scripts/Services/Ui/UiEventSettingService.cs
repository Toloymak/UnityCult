using Consts;
using UnityEngine.UI;

namespace Services
{
    public class UiEventSettingService
    {
        private readonly UiPanelControlService _uiPanelControlService;
        private readonly UnityObjectCacheService _unityObjectCacheService;
        
        private Toggle _buildingButton;

        public UiEventSettingService(UiPanelControlService uiPanelControlService,
                                     UnityObjectCacheService unityObjectCacheService)
        {
            _uiPanelControlService = uiPanelControlService;
            _unityObjectCacheService = unityObjectCacheService;

            _buildingButton = _unityObjectCacheService
               .GetGameObject(UiObjectNames.BuildingButton)
               .GetComponent<Toggle>();
        }
        
        public void SetUpBaseButtons()
        {
            _uiPanelControlService.HideAllPanels();
            
            _buildingButton.onValueChanged = BuildingButtonEvent();
        }

        private Toggle.ToggleEvent BuildingButtonEvent()
        {
            var buildingOnClickEvent = new Toggle.ToggleEvent();
            buildingOnClickEvent.AddListener(value => _uiPanelControlService.ChangeBuildingPanelActiveStatus(value));
            return buildingOnClickEvent;
        }
    }
}