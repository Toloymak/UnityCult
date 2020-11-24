using Common.Components;
using Leopotam.Ecs;
using LeopotamGroup.Globals;

namespace Common.Systems
{
    public abstract class BaseSystem: IEcsSystem
    {
        private LogService _logService;
        
        protected LogService LogService => _logService ?? (_logService = Service<LogService>.Get(true));
    }
}