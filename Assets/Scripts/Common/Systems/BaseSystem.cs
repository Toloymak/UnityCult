using System.Linq;
using Common.Components;
using Leopotam.Ecs;

namespace Common.Systems
{
    public abstract class BaseSystem: IEcsSystem
    {
        protected LogComponent LogComponent;
        
        protected void SetLogComponent(EcsFilter<LogComponent> logFilter)
        {
            LogComponent = logFilter.Get1[0];
        }
    }
}