using UnityEngine;

namespace Services
{
    public class UiPanelControlService
    {
        private GameObject _buildingPanel;
        
        public UiPanelControlService()
        {
            _buildingPanel = GameObject.Find("BuildingPanel");
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