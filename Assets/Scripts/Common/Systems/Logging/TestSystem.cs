using System.Diagnostics.SymbolStore;
using Business.Helpers;
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
            
            LogComponent.AddLog(LogLevel.Debug, "Run test init");
        }

        private bool isFirstRun = true;

        public void Run()
        {
            if (isFirstRun)
            {
                
                LogComponent.AddLog("Test of building structure\n" + new DistrictHelper().GetTestStructure());
            }
            
            isFirstRun = false;
        }

        public void Destroy()
        {
            LogComponent.AddLog(LogLevel.Debug, "Run Destroy");
        }
    }
}