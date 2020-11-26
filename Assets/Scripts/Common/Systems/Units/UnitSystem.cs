using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Models.Unit;
using Common.Consts;
using Leopotam.Ecs;

namespace Common.Systems.Units
{
    public class UnitSystem : BaseSystem, IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<UnitModel> _unitModelFilters = null;
        
        public void Init()
        {
            var firstDefaultDistrict = BaseStateOfGame.Districts.First();
            
            foreach (var unitModel in _defaultUnitModels)
            {
                var unitEntity = _ecsWorld.NewEntity();
                var unitComponent = unitEntity.Set<UnitModel>();

                unitComponent.Name = unitModel.Name;

                var positionComponent = unitEntity.Set<UnitPositionComponent>();
                positionComponent.VillagePosition = (firstDefaultDistrict.row, firstDefaultDistrict.column);
                positionComponent.IsInVillage = true;
            }
        }
        
        private IList<UnitModel> _defaultUnitModels = new List<UnitModel>()
        {
            new UnitModel()
            {
                Name = "Ivan"
            },
            new UnitModel()
            {
                Name = "Mike"
            },
            new UnitModel()
            {
                Name = "Frodo"
            },
        };
    }
}