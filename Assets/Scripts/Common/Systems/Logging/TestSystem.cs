using System.Diagnostics.SymbolStore;
using Business.Helpers;
using Common.Components;
using Common.Enums;
using Leopotam.Ecs;

namespace Common.Systems.Logging
{
    public class TestSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem, IEcsDestroySystem
    {
        public void Init()
        {
            LogService.AddLog(LogLevel.Debug, "Run test init");
        }

        private bool _isFirstRun = true;

        public void Run()
        {
            if (_isFirstRun)
            {
                
                LogService.AddLog("Test of building structure\n" + new DistrictHelper().GetTestStructure());
            }
            
            _isFirstRun = false;
        }

        public void Destroy()
        {
            LogService.AddLog(LogLevel.Debug, "Run Destroy");
        }
    }
}