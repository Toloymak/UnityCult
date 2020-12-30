using System;
using System.Collections.Generic;
using Models.Models;

namespace Core.Services
{
    public interface IStorageService
    {
        T Get<T>();
        T GetOrCreate<T>() where T : class, new();
        T Create<T>(T newObject) where T : class;
    }

    public class StorageService : IStorageService
    {
        private readonly IDictionary<Type, object> _cachedObjects;

        public StorageService()
        {
            _cachedObjects = new Dictionary<Type, object>();
            
            AddDefaultTypes();
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

        private void AddDefaultTypes()
        {
            Create(new TimerModel());
            Create(new ResourcesModel());
        }
    }
}