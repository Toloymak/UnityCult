using Business.Enums;
using Business.Extensions;
using Common.Components;
using Common.Enums;
using Common.Models.Dtos;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Services
{
    public partial class ResourceService
    {
        public ResourceComponent AddResource(ResourceType resourceType,
                                             LabelCreateDto resourceDependences)
        {
            var entity = resourceDependences.EcsWorld.NewEntity();
            var component = entity.Set<ResourceComponent>();
            component.ResourceType = resourceType;

            var nameObject = (GameObject) Object.Instantiate(
                resourceDependences.LabelNamePrefab,
                resourceDependences.ParentObject.transform);
            nameObject.name = GetResourceNameLabel(resourceType.ToString());
            nameObject.GetComponent<Text>().text = resourceType.GetShortName();

            var valueObject = (GameObject) Object.Instantiate(
                resourceDependences.LabelValuePrefab,
                resourceDependences.ParentObject.transform);
            valueObject.name = GetResourceValueLabel(resourceType.ToString());

            component.ValueText = valueObject.GetComponent<Text>();
            component.Count = resourceType.GetDefaultValue();
            return component;
        }
        
        private string GetResourceNameLabel(string resourceType) => $"{resourceType}ResourceName";
        private string GetResourceValueLabel(string resourceType) => $"{resourceType}ResourceValue";
    }
}