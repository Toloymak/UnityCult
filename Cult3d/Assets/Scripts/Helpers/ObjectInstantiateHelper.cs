using Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Helpers
{
    public class ObjectInstantiateHelper
    {
        private readonly PrefabCacheService _uiPrefabStorage;

        public ObjectInstantiateHelper(PrefabCacheService uiPrefabStorage)
        {
            _uiPrefabStorage = uiPrefabStorage;
        }

        public GameObject Instanate(string prefabName, Transform parent, string newObjectName = null)
        {
            var createdObject = (GameObject) Object.Instantiate(_uiPrefabStorage.GetPrefab(prefabName), parent);

            if (!string.IsNullOrEmpty(newObjectName))
                createdObject.name = newObjectName;
            
            return createdObject;
        }
    }
}