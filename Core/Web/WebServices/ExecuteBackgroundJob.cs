using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.Models;
using Services.Services;

namespace Web.WebServices
{
    public class ExecuteBackgroundJob : BackgroundService
    {
        private readonly IProcedureService _procedureService;
        private readonly GameStateModel _gameStateModel;

        public ExecuteBackgroundJob(IServiceScopeFactory serviceScopeFactory, GameStateModel gameStateModel)
        {
            _gameStateModel = gameStateModel;
            using var scope = serviceScopeFactory.CreateScope();
            _procedureService = scope.ServiceProvider.GetService<IProcedureService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(100, stoppingToken);

                if (!_gameStateModel.TimeModel.IsStopped)
                {
                    _gameStateModel.TimeModel.GameTime += TimeHelper.GetDeltaTime();
                    await _procedureService.ProcessStep(_gameStateModel);  
                }
                else
                {
                    TimeHelper.GetDeltaTime();
                }
            }
        }
    }
}