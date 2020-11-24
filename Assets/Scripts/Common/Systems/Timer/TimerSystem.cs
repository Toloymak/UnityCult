using Common.Components;
using Leopotam.Ecs;
using UnityEngine;

namespace Common.Systems.Timer
{
    public class TimerSystem: BaseSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;

        private TimerComponent _timerComponent;
        private bool _isFirstFrame;

        public void Init()
        {
            _timerComponent = _ecsWorld.NewEntity().Set<TimerComponent>();
            _isFirstFrame = true;
        }

        public void Run()
        {
            if (_isFirstFrame)
            {
                _isFirstFrame = false;
                _timerComponent.Start();
            }

            var isPushedStopButton = Input.GetKeyDown(KeyCode.Space);

            if (!isPushedStopButton) return;
            
            switch (_timerComponent.IsActive)
            {
                case true:
                    LogService.AddLog("Stop");
                    _timerComponent.Stop();
                    break;
                case false:
                    LogService.AddLog("Start");
                    _timerComponent.Start();
                    break;
            }
        }
    }
}