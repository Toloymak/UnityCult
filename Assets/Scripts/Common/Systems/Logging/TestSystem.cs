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
        }

        private bool _isFirstRun = true;

        public void Run()
        {
            if (_isFirstRun)
            {
                // TestBuildingsStructure();
            }
            
            _isFirstRun = false;
        }

        public void Destroy()
        {
        }

        private void TestBuildingsStructure()
        {
            LogService.AddLog("Test of building structure\n" + new DistrictHelper().GetTestStructure());
        }
    }
}