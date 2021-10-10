using System;
using Models.Models;
using Models.Models.Players;

namespace Services.Providers
{
    public class PlayerProvider
    {
        private readonly GameStateModel _gameState;

        public PlayerProvider(GameStateModel gameState)
        {
            _gameState = gameState;
        }

        public PlayerStorageModel GetPlayer(Guid playerGuid)
        {
            return _gameState.Players[playerGuid];
        }

        public PlayerStorageModel GetCurrentPlayer()
        {
            return GetPlayer(_gameState.PlayerId);
        }
    }
}