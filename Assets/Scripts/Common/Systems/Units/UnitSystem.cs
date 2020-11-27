using System;
using System.Collections.Generic;
using System.Linq;
using Business.Models;
using Business.Models.Unit;
using Common.Consts;
using Common.Services;
using Leopotam.Ecs;
using Newtonsoft.Json;

namespace Common.Systems.Units
{
    public class UnitSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<UnitComponent> _unitModelFilters = null;
        private UiStoreService _uiStoreService = null;

        public void Init()
        {
            var firstDefaultDistrict = BaseStateOfGame.Districts.First();
            
            foreach (var unitModel in GetDefaultUnitModels())
            {
                var unitEntity = _ecsWorld.NewEntity();
                var unitComponent = unitEntity.Set<UnitComponent>();

                unitComponent.Name = unitModel.Name;

                var positionComponent = unitEntity.Set<UnitPositionComponent>();
                positionComponent.VillagePosition = (firstDefaultDistrict.row, firstDefaultDistrict.column);
                positionComponent.IsInVillage = true;
            }
        }

        public void Run()
        {
            // var unitModels = new List<UnitComponent>();
            //
            // foreach (var unitModel in _unitModelFilters)
            // {
            //     unitModels.Add(_unitModelFilters.Get1[unitModel]);
            // }
            //
            // _uiStoreService.UnitList.text = JsonConvert.SerializeObject(unitModels, Formatting.Indented);
        }

        private IList<UnitComponent> GetDefaultUnitModels()
        {
            var list = new List<UnitComponent>();

            for (var i = 0; i < 5000; i++)
            {
                list.Add(new UnitComponent()
                {
                    Name = new Guid().ToString()
                });
            }

            return list;
        }
    }
}