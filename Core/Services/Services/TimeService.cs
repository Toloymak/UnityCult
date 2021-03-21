using Models.Models;

namespace Services.Services
{
    public interface ITimeService
    {
        bool IsNextStep(GameStateModel gameStateModel);
    }

    public class TimeService : ITimeService
    {
        public bool IsNextStep(GameStateModel gameStateModel)
        {
            return true;
        }
    }
}