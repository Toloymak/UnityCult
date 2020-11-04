using Common.Components;
using Common.Enums;
using Common.Models;
using Leopotam.Ecs;
using UnityEngine;

namespace Common.Systems
{
    public class TestSystem : IEcsSystem, IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsWorld _world = null;
        private EcsFilter<LogComponent> _logComponentSystem = null;

        private LogComponent _logComponent;

        public void Init()
        {
            _logComponent = _logComponentSystem.Get1[0];
            _logComponent.AddLog(LogLevel.Debug, "Run Init");
        }

        public void Run()
        {
        }

        public void Destroy()
        {
            _logComponent.AddLog(LogLevel.Debug, "Run Destroy");
        }
    }
}