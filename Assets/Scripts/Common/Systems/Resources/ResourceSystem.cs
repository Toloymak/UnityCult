using Business.Enums;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.Models.Dtos;
using Common.Services;
using Common.TypeExtensions;
using Leopotam.Ecs;
using UnityEngine;

namespace Common.Systems.Resources
{
    public class ResourceSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private ResourceService _resourceService = null;

        private ResourceComponent _energy;
        private ResourceComponent _ordinarySoulStone;
        private ResourceComponent _goodSoulStone;
        private ResourceComponent _perfectSoulStone;
        private ResourceComponent _food;
        private ResourceComponent _mysticMetal;
        
        public void Init()
        {
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

            var resourceDependeces = new LabelCreateDto()
            {
                EcsWorld = _ecsWorld,
                ParentObject = resourcePanel,
                LabelNamePrefab = resourceName,
                LabelValuePrefab = resourceValue
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