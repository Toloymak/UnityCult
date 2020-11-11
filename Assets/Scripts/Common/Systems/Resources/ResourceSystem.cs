using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.Extensions;
using Common.Services;
using Common.Storages;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.UI;

namespace Common.Systems.Resources
{
    public class ResourceSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private ResourceService _resourceService = null;
        private EcsFilter<LogComponent> _logComponentFilter = null;

        private ResourceComponent _energy;
        private ResourceComponent _ordinarySoulStone;
        private ResourceComponent _goodSoulStone;
        private ResourceComponent _perfectSoulStone;
        private ResourceComponent _food;
        private ResourceComponent _mysticMetal;
        
        public void Init()
        {
            SetLogComponent(_logComponentFilter);
            FillResourcePanel();
        }

        public void Run()
        {
        }

        private void FillResourcePanel()
        {
            var resourcePanel = GameObject.Find(UiObjectNames.ResourcePanel);
            resourcePanel.transform.DeleteAllChildren();
            
            var resourceName = UnityEngine.Resources.Load(ComponentPrefabNames.ResourceName);
            var resourceValue = UnityEngine.Resources.Load(ComponentPrefabNames.ResourceValue);

            var resourceDependeces = new ResourceService.ResourceDependences()
            {
                EcsWorld = _ecsWorld,
                ResourcePanel = resourcePanel,
                ResourceNamePrefab = resourceName,
                ResourceValuePrefab = resourceValue
            };
            
            _energy = _resourceService.AddResource(ResourceType.Energy, resourceDependeces);
            _ordinarySoulStone = _resourceService.AddResource(ResourceType.OrdinarySoulStone, resourceDependeces);
            _goodSoulStone = _resourceService.AddResource(ResourceType.GoodSoulStone, resourceDependeces);
            _perfectSoulStone = _resourceService.AddResource(ResourceType.PerfectSoulStone, resourceDependeces);
            _food = _resourceService.AddResource(ResourceType.Food, resourceDependeces);
            _mysticMetal = _resourceService.AddResource(ResourceType.MysticMetal, resourceDependeces);
        }
    }
}