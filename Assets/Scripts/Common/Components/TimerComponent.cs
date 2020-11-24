using System;
using System.Diagnostics.SymbolStore;

namespace Common.Components
{
    public class TimerComponent
    {
        private bool _isActive;
        private TimeSpan _timeBeforeStop;

        private DateTime _lastStart;

        public bool IsActive => _isActive;

        public TimerComponent()
        {
            _timeBeforeStop = TimeSpan.Zero;
        }
        
        public void Stop()
        {
            _isActive = false;
            _timeBeforeStop += _lastStart - DateTime.Now;
        }

        public void Start()
        {
            _isActive = true;
            _lastStart = DateTime.Now;
        }
    }
}