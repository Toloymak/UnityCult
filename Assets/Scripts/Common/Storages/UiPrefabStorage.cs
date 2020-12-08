using System.Collections.Generic;
using UnityEngine;

namespace Common.Storages
{
    public class UiPrefabStorage
    {
        private readonly IDictionary<string, Object> _prefabs;

        public UiPrefabStorage()
        {
            _prefabs = new Dictionary<string, Object>();
        }

        public Object GetPrefab(string name)
        {
            if (_prefabs.TryGetValue(name, out Object prefab))
                return prefab;

            var newPrefab = Resources.Load(name);
            _prefabs.Add(name, newPrefab);

            return newPrefab;
        }
    }
}