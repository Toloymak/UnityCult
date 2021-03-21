using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Models.Models;
using Models.Models.Player;
using Services.Extensions;
using Services.Services;

namespace ConsoleApp
{
    class Program
    {
        private static IServiceProvider _services;
        private static GameStateModel _gameModel;
        private static PlayerStorageModel _playerModel;
        private static IProcedureService _procedureService;
        
        static async Task Main(string[] args)
        {
            _services = RegisterServices(new ServiceCollection()).BuildServiceProvider();
            var worldGenerationService = _services.GetService<IWorldGenerationService>();
            _procedureService = _services.GetService<IProcedureService>();
            
            _gameModel = await worldGenerationService.GenerateGame();
            _playerModel = _gameModel.Players[_gameModel.PlayerId];
            
#pragma warning disable 4014
            Task.Run(PrintContent);
#pragma warning restore 4014
            
            while (true)
            {
                var input = Console.ReadKey();
            }
        }

        private static async Task PrintContent()
        {
            while (true)
            {
                await Task.Delay(1000);
                await _procedureService.ProcessStep(_gameModel);
                
                Console.Clear();
                Console.WriteLine(new string('=', 15));
                Console.WriteLine(DateTime.Now.ToString("hh:mm:ss t z"));
                Console.WriteLine(_playerModel.Name);
                Console.WriteLine(new string('=', 15));

                
                PrintResources();
                PrintEffects();
            }
        }

        private static void PrintResources()
        {
            Console.WriteLine("Resources: ");
            Console.Write("| ");
            foreach (var resource in _playerModel.ResourcesStorage)
                Console.Write($"{resource.Key.ToString()}: {resource.Value} | ");

            Console.WriteLine();
        }

        private static void PrintEffects()
        {
            Console.WriteLine("Effects: ");
            foreach (var effect in _playerModel.EffectStorage.Effects.Select(x => x.Value))
            {
                Console.WriteLine(effect.ToString());
            }
        }

        private static IServiceCollection RegisterServices(IServiceCollection services)
        {
            return services
               .RegisterMangers()
               .RegisterServices();
        }
    }
}