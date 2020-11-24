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
        public TimeSpan TotalTime =>
            _isActive
                ? _timeBeforeStop + TimeFromLastStart
                : _timeBeforeStop;

        public TimerComponent()
        {
            _timeBeforeStop = TimeSpan.Zero;
        }
        
        public void Stop()
        {
            _isActive = false;
            _timeBeforeStop += TimeFromLastStart;
        }

        public void Start()
        {
            _isActive = true;
            _lastStart = DateTime.Now;
        }

        private TimeSpan TimeFromLastStart => DateTime.Now - _lastStart;
    }
}