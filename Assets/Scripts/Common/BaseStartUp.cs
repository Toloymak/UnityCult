using Common.Components;
using Common.Services;
using Common.Storages;
using Common.Systems.Actions;
using Common.Systems.Logging;
using Common.Systems.Resources;
using Common.Systems.Timer;
using Common.Systems.Units;
using Common.Systems.Village;
using Leopotam.Ecs;
using UnityEngine;

namespace Common
{
    public abstract class BaseStartUp : MonoBehaviour
    {
        EcsWorld _world;
        EcsSystems _systems;
        
        public void Start()
        {
            // void can be switched to IEnumerator for support coroutines.

            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            
            AddCommonServices(_systems);
            AddCommonSystems(_systems);
            AddSystems(_systems);
            AddServices(_systems);
            
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
        
        private void AddCommonServices(EcsSystems systems)
        {
            systems
               .Inject(new UiStoreService())
               .Inject(new UiPrefabStoreService())
               .Inject(new FieldService())
               .Inject(new BuildingService())
               .Inject(new ResourceService());
        }
        
        protected virtual void AddSystems(EcsSystems systems)
        {
        }
        
        protected virtual void AddServices(EcsSystems systems)
        {
        }
    }
}