using Consts;
using UnityEngine;

namespace Services.Building
{
    public class BuildingService : UpdateBaseService
    {
        private GameObject _buildingPanel;
        
        public BuildingService(UnityObjectCacheService unityObjectCacheService)
            : base(Parameters.DefaultUpdatePeriod)
        {
            _buildingPanel = unityObjectCacheService.GetGameObject(UiObjectNames.BuildingPanel);
        }

        public override void Update()
        {
            if (_buildingPanel.activeSelf && NeedUpdate())
            {
                Debug.Log("Update");
                //_buildingPanel.
            }
        }
    }
}