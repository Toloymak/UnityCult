using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models.Players;

namespace Services.Services
{
    public interface IPlayerGenerateService
    {
        Task<IEnumerable<PlayerStorageModel>> GenerateComputerPlayers(int count);
        PlayerStorageModel GenerateHumanPlayers();
    }

    public class PlayerGenerateService : IPlayerGenerateService
    {
        public async Task<IEnumerable<PlayerStorageModel>> GenerateComputerPlayers(int count)
        {
            var playerCreatingTasks = new List<Task<PlayerStorageModel>>();

            for (int i = 0; i < count; i++)
            {
                playerCreatingTasks.Add(Task.Run(() => CreateComputerPlayer(i)));
            }

            return await Task.WhenAll(playerCreatingTasks);
        }

        public PlayerStorageModel GenerateHumanPlayers()
        {
            var playerModel = new PlayerStorageModel("Player");
            return playerModel;
        }

        private PlayerStorageModel CreateComputerPlayer(int number)
        {
            return new PlayerStorageModel($"Computer player {number}");
        }
    }
}