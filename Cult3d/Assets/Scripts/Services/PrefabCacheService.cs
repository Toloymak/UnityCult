﻿using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class PrefabCacheService
    {
        private readonly IDictionary<string, Object> _prefabs;

        public PrefabCacheService()
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