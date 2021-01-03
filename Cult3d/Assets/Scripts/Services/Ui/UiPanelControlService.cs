using Consts;
using UnityEngine;

namespace Services
{
    public class UiPanelControlService
    {
        private readonly UnityObjectCacheService _unityObjectCacheService;
        
        private GameObject _buildingPanel;
        
        public UiPanelControlService(UnityObjectCacheService unityObjectCacheService)
        {
            _unityObjectCacheService = unityObjectCacheService;
            
            _buildingPanel = _unityObjectCacheService.GetGameObject(UiObjectNames.BuildingPanel);
        }

        public void HideAllPanels()
        {
            _buildingPanel.SetActive(false);
        }

        public void ChangeBuildingPanelActiveStatus(bool status)
        {
            _buildingPanel.SetActive(status);
        }
    }
}