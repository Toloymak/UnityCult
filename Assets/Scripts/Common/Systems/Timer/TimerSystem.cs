using Common.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Systems.Timer
{
    public class TimerSystem: BaseSystem, IEcsRunSystem
    {
        private TimerStorage _timerStorage = null;
        private bool _isFirstFrame = true;

        public void Run()
        {
            if (_isFirstFrame)
            {
                _isFirstFrame = false;
                _timerStorage.Start();
            }

            UpdateTimerView();

            if (!Input.GetKeyDown(KeyCode.Space)) return;
            
            StartOrStop();
        }

        private void StartOrStop()
        {
            switch (_timerStorage.IsActive)
            {
                case true:
                    LogService.AddLog("Stop");
                    _timerStorage.Stop();
                    break;
                case false:
                    LogService.AddLog("Start");
                    _timerStorage.Start();
                    break;
            }
        }

        private Text _timerText;
        
        private void UpdateTimerView()
        {
            if (_timerText == null)
                _timerText = GameObject.Find("TimerText").GetComponent<Text>();

            _timerText.text = _timerStorage.TotalTime.ToString(@"hh\:mm\:ss");
        }
    }
}