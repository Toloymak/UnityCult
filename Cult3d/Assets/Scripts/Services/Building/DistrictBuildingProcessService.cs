using Core.Services;
using Extensions;
using Helpers;
using Interfaces;
using Models;

namespace Services.Building
{
    public class DistrictBuildingProcessService : IUpdateService
    {
        private readonly IStorageService _storageService;
        private readonly IMouseHelper _mouseHelper;

        public DistrictBuildingProcessService(IStorageService storageService,
                                              IMouseHelper mouseHelper)
        {
            _storageService = storageService;
            _mouseHelper = mouseHelper;
        }

        public void Update()
        {
            var districtInProcess = _storageService.GetOrCreate<BuildingProcessModel>();
            
            if (districtInProcess.DistrictInProcess == null)
                return;


            if (_mouseHelper.TryGetMousePosition(out var position))
            {
                districtInProcess.DistrictInProcess.transform.position = position.GetRoundVector().SetY(1.5f);
            }
        }
    }
}