using System;
using System.Linq;
using Business.Enums;
using Business.Models.Unit;
using Common.Components;
using Common.Services;
using Leopotam.Ecs;

namespace Common.Systems.Units
{
    public class UnitVillageActionSystem : BaseSystem, IEcsRunSystem
    {
        private EcsFilter<VillageFieldComponent> _filedComponetn = null;
        private EcsFilter<UnitComponent, UnitPositionComponent> _unitFilter = null;
        private DistrictService _districtService = null;

        private VillageFieldComponent _villageFieldComponent;

        public void Run()
        {
            if (_villageFieldComponent == null)
                _villageFieldComponent = _filedComponetn.Get1.First();

            foreach (var unitId in _unitFilter)
            {
                var entity = _unitFilter.Entities[unitId];

                var unitComponent = entity.Get<UnitComponent>();
                var positionComponent = entity.Get<UnitPositionComponent>();

                DoAction(unitComponent, positionComponent);
            }
        }

        private void DoAction(UnitComponent unitComponent, UnitPositionComponent positionComponent)
        {
            var district = _villageFieldComponent.FieldModel.GetItem(positionComponent.VillagePosition.row,
                                                                     positionComponent.VillagePosition.column);
            
            switch (district.Type)
            {
                case DistrictType.None:
                    break;
                case DistrictType.Residential:
                    break;
                case DistrictType.EliteResidential:
                    break;
                case DistrictType.School:
                    break;
                case DistrictType.Library:
                    break;
                case DistrictType.Arena:
                    break;
                case DistrictType.Arena2:
                    break;
                case DistrictType.Arena3:
                    break;
                case DistrictType.Arena4:
                    break;
                case DistrictType.Factory:
                    break;
                case DistrictType.Alchemy:
                    break;
                case DistrictType.Farm:
                    break;
                case DistrictType.Research:
                    break;
                case DistrictType.Challenge:
                    break;
                case DistrictType.Camp:
                    _districtService.DoCampAction(unitComponent);
                    break;
                case DistrictType.Administration:
                    break;
                case DistrictType.Issuance:
                    break;
                case DistrictType.Livestock:
                    break;
                case DistrictType.Storage:
                    break;
                case DistrictType.Meditation:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}