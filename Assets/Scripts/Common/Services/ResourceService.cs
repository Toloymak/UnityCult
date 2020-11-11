using Common.Components;
using Common.Enums;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Services
{
    public class ResourceService
    {
        public ResourceComponent AddResource(ResourceType resourceType,
                                             ResourceDependences resourceDependences)
        {
            var entity = resourceDependences.EcsWorld.NewEntity();
            var component = entity.Set<ResourceComponent>();
            component.ResourceType = resourceType;

            var nameObject = (GameObject) Object.Instantiate(
                resourceDependences.ResourceNamePrefab,
                resourceDependences.ResourcePanel.transform);
            nameObject.name = GetResourceNameLabel(resourceType.ToString());
            nameObject.GetComponent<Text>().text = resourceType.ToString();

            var valueObject = (GameObject) Object.Instantiate(
                resourceDependences.ResourceValuePrefab,
                resourceDependences.ResourcePanel.transform);
            valueObject.name = GetResourceValueLabel(resourceType.ToString());
            valueObject.GetComponent<Text>().text = 0.ToString();


            component.ValueText = valueObject.GetComponent<Text>();

            return component;
        }

        private string GetResourceNameLabel(string resourceType) => $"{resourceType}ResourceName";
        private string GetResourceValueLabel(string resourceType) => $"{resourceType}ResourceValue";
        
        public class ResourceDependences
        {
            public Object ResourceNamePrefab { get; set; }
            public Object ResourceValuePrefab { get; set; }
            public EcsWorld EcsWorld { get; set; }
            public GameObject ResourcePanel { get; set; }
        }
    }
}