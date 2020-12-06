using System;
using System.Collections.Generic;
using System.Reflection;
using Common.Components;
using Common.Helpers;
using Common.Services;
using Common.Storages;
using Common.Systems.Actions;
using Common.Systems.Logging;
using Common.Systems.Resources;
using Common.Systems.Timer;
using Common.Systems.Units;
using Common.Systems.Village;
using Leopotam.Ecs;
using SimpleInjector;
using UnityEngine;

namespace Common
{
    public abstract class BaseStartUp : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;

        private Container _container;
        
        public void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            
            _container = new Container();
            RegisterSingletonServices();
            RegisterServicesOnEcs(_systems);

            AddServices(_systems);

            AddCommonSystems(_systems);
            AddSystems(_systems);
            
            _systems.Init();
        }

        public void Update()
        {
            if (_systems != null)
            {
                _systems.Run();
            }
        }

        public void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }

        private void AddCommonSystems(EcsSystems systems)
        {
            systems
               .Add(new LogSystem())
               .Add(new TestSystem())
               .Add(new FieldControlSystem())
               .Add(new BuildingMenuControlSystem())
               .Add(new ActionMenuControlSystem())
               .Add(new ResourceSystem())
               .Add(new TimerSystem())
               .Add(new UnitSystem())
               .Add(new UnitMovementSystem())
               .Add(new UnitVillageActionSystem())
               .Add(new FpsSystem());
        }
        
        private void RegisterServicesOnEcs(EcsSystems systems)
        {
            systems
               .Inject(_container)
               .Inject(_container.GetInstance<UiPrefabStoreService>())
               .Inject(_container.GetInstance<UiStoreService>())
               .Inject(_container.GetInstance<ObjectInstantiateHelper>())
               .Inject(_container.GetInstance<FieldService>())
               .Inject(_container.GetInstance<BuildingService>())
               .Inject(_container.GetInstance<ResourceService>())
               .Inject(_container.GetInstance<ItemListService>())
               ;
        }

        private void RegisterSingletonServices()
        {
            var singletonLifestyle = Lifestyle.Singleton;
            
            _container.Register<UiPrefabStoreService>(singletonLifestyle);
            _container.Register<UiStoreService>(singletonLifestyle);
            _container.Register<ObjectInstantiateHelper>(singletonLifestyle);
            _container.Register<FieldService>(singletonLifestyle);
            _container.Register<BuildingService>(singletonLifestyle);
            _container.Register<ResourceService>(singletonLifestyle);
            _container.Register<ItemListService>(singletonLifestyle);
        }

        protected virtual void AddSystems(EcsSystems systems)
        {
        }

        protected virtual void AddServices(EcsSystems systems)
        {
        }
    }
}