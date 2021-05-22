﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managers.Managers;
using Models.Enums;
using Models.Models;
using Models.Models.Effects;
using Models.Models.People;
using Models.Models.Players;

namespace Services.Services
{
    public interface IWorldGenerationService
    {
        Task<GameStateModel> GenerateGame();
    }

    public class WorldGenerationService : IWorldGenerationService
    {
        private const int DefaultPlayerCount = 500;
        
        private const int DefaultMapXSize = 5;
        private const int DefaultMapYSize = 5;

        
        private readonly IPlayerGenerateService _playerGenerateService;
        private readonly IEffectManager _effectManager;
        private readonly IVillageMapManager _villageMapManager;
        private readonly IResourceManager _resourceManager;

        public WorldGenerationService(IPlayerGenerateService playerGenerateService,
                                      IEffectManager effectManager,
                                      IVillageMapManager villageMapManager,
                                      IResourceManager resourceManager)
        {
            _playerGenerateService = playerGenerateService;
            _effectManager = effectManager;
            _villageMapManager = villageMapManager;
            _resourceManager = resourceManager;
        }

        public async Task<GameStateModel> GenerateGame()
        {
            var gameModel = new GameStateModel();
            
            await CreatePlayers(gameModel);
            await AddDefaultEffects(gameModel);
            await AddDefaultResources(gameModel);
            await AddDefaultPeople(gameModel);
            await AddVillages(gameModel);

            return gameModel;
        }

        private Task AddVillages(GameStateModel gameModel)
        {
            return Task.WhenAll(gameModel.Players.Select(player => Task.Run(() =>
            {
                player.Value.VillageMap =
                    _villageMapManager.GetNewMap(DefaultMapXSize, DefaultMapYSize);
            })));
        }

        private async Task CreatePlayers(GameStateModel gameModel)
        {
            var computerPlayerTasks = _playerGenerateService
               .GenerateComputerPlayers(DefaultPlayerCount);
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
                            Amount = 1,
                            ResourceType = ResourceType.Energy
                        },
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
        
        private Task AddDefaultResources(GameStateModel gameModel)
        {
            var defaultResources = new Dictionary<ResourceType, int>()
            {
                {ResourceType.Food, 500},
                {ResourceType.Energy, 500},
                {ResourceType.OrdinarySoulStone, 1000}
            };
            
            var tasks = gameModel.Players
               .Select(x => x.Value)
               .Select(player => Task.Run(() =>
                {
                    foreach (var defaultResource in defaultResources)
                    {
                        _resourceManager.Add(player.ResourcesStorage,
                                             defaultResource.Key,
                                             defaultResource.Value);
                    }
                }));
            
            return Task.WhenAll(tasks);
        }

        public Task AddDefaultPeople(GameStateModel gameModel)
        {
            var tasks = gameModel.Players
               .Select(x => x.Value)
               .Select(player => Task.Run(() =>
                {
                    player.PeopleStorage.People.Add(
                        Guid.NewGuid(),
                        new PersonModel()
                        {
                            Name = "Warrior",
                            Health = { CurrentHp = 100, MaxHp = 100, DefaultRegeneration = 3},
                            Skills = { Agility = 10, Endurance = 10, Strength = 10, Intelligence = 10},
                            Level = { Level = 1, CurrentExp = 0, NexLevelExp = 1000}
                        });
                    
                    player.PeopleStorage.People.Add(
                        Guid.NewGuid(),
                        new PersonModel()
                        {
                            Name = "Farmer",
                            Health = { CurrentHp = 50, MaxHp = 50, DefaultRegeneration = 1},
                            Skills = { Agility = 10, Endurance = 10, Strength = 10, Intelligence = 10},
                            Level = { Level = 1, CurrentExp = 0, NexLevelExp = 1000},
                            SpecificSkills = { Farming = 10}
                        });
                }));

            return Task.WhenAll(tasks);
        }
    }
}