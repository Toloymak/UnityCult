using System;
using Common.Models;
using Common.Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common.Helpers
{
    public class ObjectInstantiateHelper
    {
        private readonly UiPrefabStoreService _uiPrefabStoreService;

        public ObjectInstantiateHelper(UiPrefabStoreService uiPrefabStoreService)
        {
            _uiPrefabStoreService = uiPrefabStoreService;
        }

        public GameObject Instanate(string prefabName, Transform parent, string newObjectName = null)
        {
            var createdObject = (GameObject) Object
               .Instantiate(_uiPrefabStoreService.GetPrefab(prefabName), parent);

            if (!string.IsNullOrEmpty(newObjectName))
                createdObject.name = newObjectName;
            
            return createdObject;
        }
    }
}