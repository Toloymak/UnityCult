using System;
using System.Collections.Concurrent;
using Models.Models.Players;

namespace Models.Models
{
    public class GameStateModel
    {
        public TimeModel TimeModel { get; }
        public Guid PlayerId { get; set; }
        public ConcurrentDictionary<Guid, PlayerStorageModel> Players { get; }

        public GameStateModel()
        {
            Players = new ConcurrentDictionary<Guid, PlayerStorageModel>();
            TimeModel = new TimeModel()
            {
                GameTime = new TimeSpan(),
                LastProcure = new TimeSpan(),
                IsStopped = false
            };
        }
    }
}