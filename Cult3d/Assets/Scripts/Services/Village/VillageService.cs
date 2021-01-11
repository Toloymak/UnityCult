using Core.Services;
using Interfaces;
using Models.Models.Village;

namespace Services.Village
{
    public class VillageService : IInitService
    {
        private readonly IStorageService _storageService;

        public VillageService(IStorageService storageService)
        {
            _storageService = storageService;
        }

        public void Init()
        {
            var map = new VillageMapModel(100, 100);


            for (var row = 0; row < map.Matrix.Count; row++)
            {
                for (var column = 0; column < map.Matrix[row].Count; column++)
                {
                    map.GetItem(row, column).Coordinates = (200 + row, 200 + column);
                }
            }
            
            _storageService.Create(map);
        }
    }
}