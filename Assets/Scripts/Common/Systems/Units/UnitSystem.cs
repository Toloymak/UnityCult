using System.Collections.Generic;
using System.Linq;
using Business.Models.Unit;
using Common.Consts;
using Common.Storages;
using Leopotam.Ecs;
using Newtonsoft.Json;
using UnityEngine.UI;

namespace Common.Systems.Units
{
    public class UnitSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<UnitComponent> _unitModelFilters = null;
        private UiObjectStorage _uiObjectStorage = null;

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
            var unitModels = new List<string>();
            
            foreach (var unitModel in _unitModelFilters)
            {
                unitModels.Add(_unitModelFilters.Get1[unitModel].ToString());
            }
            
            _uiObjectStorage.GetComponent<Text>(UiObjectNames.UnitList).text = JsonConvert
               .SerializeObject(unitModels, Formatting.Indented);
        }

        private IList<UnitComponent> GetDefaultUnitModels()
        {
            return Names.Select(x => new UnitComponent(){Name = x}).ToList();
        }
        
        private IList<string> Names = new List<string>()
        {
            "George",
            "John",
            "Thomas",
            "James",
            "Andrew",
            "Martin",
            "William",
            "Zachary",
            "Andrew",
            "Millard",
            "Franklin",
            "Abraham",
        };
    }
}