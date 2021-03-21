using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Managers.Managers;
using Models.Enums;
using Models.Models;
using Models.Models.Effects;
using Models.Models.Player;

namespace Services.Services
{
    public interface IWorldGenerationService
    {
        Task<GameStateModel> GenerateGame();
    }

    public class WorldGenerationService : IWorldGenerationService
    {
        private readonly IPlayerGenerateService _playerGenerateService;
        private readonly IEffectManager _effectManager;

        public WorldGenerationService(IPlayerGenerateService playerGenerateService,
                                      IEffectManager effectManager)
        {
            _playerGenerateService = playerGenerateService;
            _effectManager = effectManager;
        }

        public async Task<GameStateModel> GenerateGame()
        {
            var gameModel = new GameStateModel();
            
            await CreatePlayers(gameModel);
            await AddDefaultEffects(gameModel);

            return gameModel;
        }

        private async Task CreatePlayers(GameStateModel gameModel)
        {
            var computerPlayerTasks = _playerGenerateService.GenerateComputerPlayers(10);
            var humanPlayer = _playerGenerateService.GenerateHumanPlayers();
            gameModel.PlayerId = humanPlayer.Id;

            AddPlayer(gameModel.Players, humanPlayer);

            var computerPlayer = await computerPlayerTasks;
            var addPlayerTasks = computerPlayer
               .Select(x => Task.Run(() => AddPlayer(gameModel.Players, x)));

            await Task.WhenAll(addPlayerTasks);
        }
        
        private static void AddPlayer(ConcurrentDictionary<Guid, PlayerStorageModel> dictionary,
                                      PlayerStorageModel playerStorage)
        {
            dictionary.TryAdd(playerStorage.Id, playerStorage);
        }

        private Task AddDefaultEffects(GameStateModel gameModel)
        {
            var defaultEffects = new List<EffectModel>()
            {
                new EffectModel()
                {
                    Name = "World energy",
                    ResourceEffects = new List<ResourceEffectModel>()
                    {
                        new ResourceEffectModel()
                        {
                            Amount = 10,
                            ResourceType = ResourceType.Energy
                        }
                    }
                }
            };

            var tasks = gameModel.Players
               .Select(x => x.Value)
               .Select(player => Task.Run(async () =>
                {
                    await Task.WhenAll(defaultEffects.Select(effect => Task.Run(() =>
                    {
                        _effectManager.Add(player.EffectStorage, effect);
                    })));
                }));

            return Task.WhenAll(tasks);
        }
    }
}