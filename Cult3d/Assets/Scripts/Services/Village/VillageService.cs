using Core.Services;
using Interfaces;
using Models.Models;
using Models.Models.Village;

namespace Assets.Scripts.Services.Village
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
            var map = new VillageMapModel(100, 100, new Coordinates(200, 200));

            _storageService.Create(map);
        }
    }
}