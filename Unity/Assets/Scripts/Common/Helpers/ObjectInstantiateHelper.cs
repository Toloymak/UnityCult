using System;
using Common.Models;
using Common.Services;
using Common.Storages;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common.Helpers
{
    public class ObjectInstantiateHelper
    {
        private readonly UiPrefabStorage _uiPrefabStorage;

        public ObjectInstantiateHelper(UiPrefabStorage uiPrefabStorage)
        {
            _uiPrefabStorage = uiPrefabStorage;
        }

        public GameObject Instanate(string prefabName, Transform parent, string newObjectName = null)
        {
            var createdObject = (GameObject) Object
               .Instantiate(_uiPrefabStorage.GetPrefab(prefabName), parent);

            if (!string.IsNullOrEmpty(newObjectName))
                createdObject.name = newObjectName;
            
            return createdObject;
        }
    }
}