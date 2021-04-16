using System;
using Models.Models;

namespace Services.Services
{
    public interface ITimeService
    {
        bool IsNextStep(TimeModel timeModel);
        void StopTimer(TimeModel timeModel);
        void StartTimer(TimeModel timeModel);
    }

    public class TimeService : ITimeService
    {
        public bool IsNextStep(TimeModel timeModel)
        {
            if (timeModel.GameTime - timeModel.LastProcure > timeModel.ProcedurePeriod)
            {
                timeModel.LastProcure = timeModel.GameTime;
                return true;
            }
            
            return false;
        }

        public void StopTimer(TimeModel timeModel)
        {
            timeModel.IsStopped = true;
        }

        public void StartTimer(TimeModel timeModel)
        {
            timeModel.IsStopped = false;
        }
    }
}