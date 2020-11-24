using Common.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

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

            UpdateTimerView();

            if (!Input.GetKeyDown(KeyCode.Space)) return;
            
            StartOrStop();
        }

        private void StartOrStop()
        {
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

        private Text _timerText;
        
        private void UpdateTimerView()
        {
            if (_timerText == null)
                _timerText = GameObject.Find("TimerText").GetComponent<Text>();

            _timerText.text = _timerComponent.TotalTime.ToString(@"hh\:mm\:ss");
        }
    }
}