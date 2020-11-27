using System;
using System.Collections.Generic;
using Business.Models.Unit;
using Common.Components;
using UnityEngine;

namespace Common.Services
{
    public class DistrictService
    {
        private IDictionary<Guid, TimeSpan> _lastUpdateDateTimes;

        private readonly TimerComponent _timerComponent;
        
        private readonly TimeSpan _period = new TimeSpan(0, 0, 5);

        public DistrictService(TimerComponent timerComponent)
        {
            _timerComponent = timerComponent;
            _lastUpdateDateTimes = new Dictionary<Guid, TimeSpan>();
        }
        
        public void DoCampAction(UnitComponent unitComponent)
        {
            if (_lastUpdateDateTimes.TryGetValue(unitComponent.Id, out var lastActionTime))
            {
                if (_timerComponent.TotalTime - lastActionTime < _period)
                    return;

                _lastUpdateDateTimes[unitComponent.Id] = _timerComponent.TotalTime;
            }
            else
            {
                _lastUpdateDateTimes.Add(unitComponent.Id, _timerComponent.TotalTime);
            }

            unitComponent.BodyChi++;
        }
    }
}