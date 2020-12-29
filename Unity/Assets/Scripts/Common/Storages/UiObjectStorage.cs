using System;
using System.Collections.Generic;
using Common.Consts;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Storages
{
    public class UiObjectStorage
    {
        private readonly IDictionary<string, GameObject> _uiObjects;
        private readonly IDictionary<string, (Type type, object component)> _components;

        public UiObjectStorage()
        {
            _uiObjects = new Dictionary<string, GameObject>();
            _components = new Dictionary<string, (Type type, object component)>();
        }

        public GameObject GetGameObject(string name)
        {
            if (_uiObjects.TryGetValue(name, out var gameObject))
                return gameObject;

            var newObject = GameObject.Find(name);
            _uiObjects.Add(name, newObject);

            return newObject;
        }

        public T GetComponent<T>(string gameObjectName) where T : Component
        {
            if (_components.TryGetValue(gameObjectName, out var foundResult))
            {
                return foundResult.type == typeof(T)
                    ? (T) foundResult.component
                    : throw new ArgumentException($"Expected type {typeof(T)}, but was {foundResult}");
            }

            var newObject = GameObject.Find(gameObjectName);
            var component = newObject.GetComponent<T>();
            _components.Add(gameObjectName, (typeof(T), component));

            return component;
        }
    }
}