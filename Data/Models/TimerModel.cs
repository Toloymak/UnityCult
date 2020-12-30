using System;

namespace Models.Models
{
    public class TimerModel
    {
        private TimeSpan _timeBeforeStop;

        private DateTime _lastStart;

        public bool IsActive { get; private set; }
        public TimeSpan TotalTime =>
            IsActive
                ? _timeBeforeStop + TimeFromLastStart
                : _timeBeforeStop;

        public TimerModel()
        {
            _timeBeforeStop = TimeSpan.Zero;
        }
        
        public void Stop()
        {
            IsActive = false;
            _timeBeforeStop += TimeFromLastStart;
        }

        public void Start()
        {
            IsActive = true;
            _lastStart = DateTime.Now;
        }

        private TimeSpan TimeFromLastStart => DateTime.Now - _lastStart;
    }
}