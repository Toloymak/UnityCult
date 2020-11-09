using System.Collections.Generic;
using Common.Components;
using Common.Extensions;
using Common.Models;
using Common.Services;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Systems.Actions
{
    public class ActionMenuControlSystem : BaseSystem, IEcsInitSystem
    {
        private EcsFilter<LogComponent> _logComponent = null;
        
        private UiPrefabStoreService _uiPrefabStoreService = null;
        private UiStoreService _uiStoreService = null;

        public void Init()
        {
            SetLogComponent(_logComponent);

            _uiStoreService.ActionList.transform.DeleteAllChildren();
            FillActionPanel();
        }

        private static IList<ActionModel> _testActionModels = new List<ActionModel>()
        {
            new ActionModel() { Name = "Exploring something", Description = "Go to exploring something", TimeInSeconds = 60 * 10},
            new ActionModel() { Name = "Attack something", Description = "Go to attack somebody", TimeInSeconds = 60 * 60},
            new ActionModel() { Name = "Trading", Description = "Go to buy or sell something", TimeInSeconds = 60},
        };
        
        private void FillActionPanel()
        {
            foreach (var actionModel in _testActionModels)
            {
                var newObject = Object.Instantiate(_uiPrefabStoreService.ListItem, _uiStoreService.ActionList.transform);
                newObject.name = $"action_{actionModel.Id}";

                var actionGO = GameObject.Find(newObject.name);
                actionGO.transform.Find("Name").GetComponent<Text>().text = actionModel.Name;
                actionGO.transform.Find("Description").GetComponent<Text>().text = actionModel.Description;
            }
        }
    }
}