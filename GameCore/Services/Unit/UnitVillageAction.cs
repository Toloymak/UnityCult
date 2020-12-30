using System;
using Models.Models;

namespace Core.Services.Unit
{
    public interface IUnitVillageAction
    {
        Guid CalculateTargetBuilding(UnitModel unitModel);
    }

    public class UnitVillageAction : IUnitVillageAction
    {
        private readonly IStorageService _storageService;
        private readonly IUnitPriorityProvider _unitPriorityProvider;

        public UnitVillageAction(IStorageService storageService,
                                 IUnitPriorityProvider unitPriorityProvider)
        {
            _storageService = storageService;
            _unitPriorityProvider = unitPriorityProvider;
        }

        public Guid CalculateTargetBuilding(UnitModel unitModel)
        {
            var priorities = _unitPriorityProvider.GetPriority(unitModel);
            return Guid.NewGuid();
        }
    }
}