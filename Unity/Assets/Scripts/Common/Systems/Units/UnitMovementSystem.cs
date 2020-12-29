using System.Linq;
using Business.Models.Unit;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Systems.Units
{
    public class UnitMovementSystem: BaseSystem, IEcsRunSystem
    {
        private EcsFilter<UnitComponent, UnitPositionComponent> _unitFilter = null;
        private EcsFilter<VillageFieldComponent> _villageComponet = null;

        private VillageFieldComponent _villageFieldComponent;
        private Object _unitPrefab;
        
        public void Run()
        {
            if (_villageFieldComponent == null)
                _villageFieldComponent = _villageComponet.Get1.First();

            if (_unitPrefab == null)
                _unitPrefab = UnityEngine.Resources.Load(ComponentPrefabNames.Unit);
            
            // DrawPosition();
        }

        private void DrawPosition()
        {
            foreach (var unitId in _unitFilter)
            {
                var entity = _unitFilter.Entities[unitId];

                var unitComponent = entity.Get<UnitComponent>();
                var positionComponent = entity.Get<UnitPositionComponent>();

                if (positionComponent.GameObject == null)
                {
                    var canvas = GameObject.Find(UiObjectNames.MainCanvas);
                    positionComponent.GameObject = (GameObject) Object.Instantiate(_unitPrefab, canvas.transform);
                    positionComponent.GameObject.GetComponent<Text>().text = unitComponent.Name;
                }

                var cell = _villageFieldComponent
                   .FieldModel
                   .GetItem(positionComponent.VillagePosition.row,
                            positionComponent.VillagePosition.column);

                positionComponent.GameObject.transform.position = cell.GameObject.transform.position;
            }
        }
    }
}