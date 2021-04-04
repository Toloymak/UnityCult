using Models.Models;

namespace Services.Services
{
    public interface ITimeService
    {
        bool IsNextStep(TimeModel timeModel);
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
    }
}