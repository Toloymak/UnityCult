using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Models.Models;

namespace Services.Services
{
    public interface IProcedureService
    {
        Task ProcessStep(GameStateModel gameState);
    }

    public class ProcedureService : IProcedureService
    {
        private readonly IResourceService _resourceService;
        private readonly ITimeService _timeService;

        public ProcedureService(IResourceService resourceService,
                                ITimeService timeService)
        {
            _resourceService = resourceService;
            _timeService = timeService;
        }

        public async Task ProcessStep(GameStateModel gameState)
        {
            if (_timeService.IsNextStep(gameState.TimeModel))
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                
                await Task.WhenAll(gameState
                                      .Players.Select(x => x.Value)
                                      .Select(player =>
                                                  _resourceService.Calculate(player.DistrictStorage,
                                                                             player.EffectStorage,
                                                                             player.ResourcesStorage)));
                
                stopwatch.Stop();
                gameState.TimeModel.ProcedureTime = stopwatch.Elapsed;
            }
        }
    }
}