using System;
using System.Collections.Generic;
using Business.Models.Unit;
using Common.Components;

namespace Common.Services
{
    public class DistrictService
    {
        private readonly TimeEventStorage _timeEventStorage;
        private readonly TimerStorage _timerStorage;

        private readonly TimeSpan _period = new TimeSpan(0, 0, 5);

        public DistrictService(TimeEventStorage timeEventStorage,
                               TimerStorage timerStorage)
        {
            _timeEventStorage = timeEventStorage;
            _timerStorage = timerStorage;
        }
        
        public void DoCampAction(UnitComponent unitComponent)
        {
            if (_timeEventStorage.EventList.TryGetValue(unitComponent.Id, out var lastActionTime))
            {
                if (_timerStorage.TotalTime - lastActionTime < _period)
                    return;

                _timeEventStorage.EventList[unitComponent.Id] = _timerStorage.TotalTime;
            }
            else
            {
                _timeEventStorage.EventList.Add(unitComponent.Id, _timerStorage.TotalTime);
            }

            unitComponent.BodyChi++;
        }
    }

    public class TimeEventStorage
    {
        public IDictionary<Guid, TimeSpan> EventList { get; }
        
        public TimeEventStorage()
        {
            EventList = new Dictionary<Guid, TimeSpan>();
        }
    }
}