using System;
using System.Collections.Generic;

namespace Managers.Managers
{
    public interface IStorageManager
    {
        T Get<T>();
        T GetOrCreate<T>() where T : class, new();
        T Create<T>(T newObject) where T : class;
    }

    public class StorageManager : IStorageManager
    {
        private readonly IDictionary<Type, object> _cachedObjects;

        public StorageManager()
        {
            _cachedObjects = new Dictionary<Type, object>();
        }

        public T Get<T>()
        {
            return (T) _cachedObjects[typeof(T)];
        }
        
        public T GetOrCreate<T>() where T : class, new()
        {
            if (_cachedObjects.TryGetValue(typeof(T), out var obj))
                return (T) obj;

            var newObject = new T();
            _cachedObjects.Add(typeof(T), newObject);
            return newObject;
        }
        
        public T Create<T>(T newObject) where T : class
        {
            _cachedObjects.Add(typeof(T), newObject);
            return newObject;
        }
    }
}