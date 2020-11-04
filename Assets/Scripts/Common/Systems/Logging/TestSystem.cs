using Common.Components;
using Common.Enums;
using Leopotam.Ecs;

namespace Common.Systems.Logging
{
    public class TestSystem : IEcsSystem, IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
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