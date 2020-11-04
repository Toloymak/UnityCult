using Common.Components;
using Common.Enums;
using Leopotam.Ecs;

namespace Common.Systems.Logging
{
    public class TestSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        private EcsFilter<LogComponent> _logComponentSystem = null;
        
        public void Init()
        {
            SetLogComponent(_logComponentSystem);
            
            LogComponent.AddLog(LogLevel.Debug, "Run Init");
        }

        public void Run()
        {
        }

        public void Destroy()
        {
            LogComponent.AddLog(LogLevel.Debug, "Run Destroy");
        }
    }
}