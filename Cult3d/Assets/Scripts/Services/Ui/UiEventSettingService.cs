using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class UiEventSettingService
    {
        private readonly UiPanelControlService _uiPanelControlService;
        
        private Toggle _buildingButton;

        public UiEventSettingService(UiPanelControlService uiPanelControlService)
        {
            _uiPanelControlService = uiPanelControlService;
            
            _buildingButton = GameObject.Find("BuildingButton").GetComponent<Toggle>();
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