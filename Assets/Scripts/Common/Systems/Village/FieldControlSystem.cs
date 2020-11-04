using System.Collections.Generic;
using System.Linq;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.Models;
using Common.Storages;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Systems.Village
{
    public class FieldControlSystem : BaseSystem, IEcsInitSystem, IEcsRunSystem
    {
        private EcsWorld _ecsWorld = null;
        private EcsFilter<LogComponent> _logComponentFilter = null;
        
        public void Init()
        {
            SetLogComponent(_logComponentFilter);
            
            var villageEntity = _ecsWorld.NewEntity();
            var villageFieldComponent = villageEntity.Set<VillageFieldComponent>();

            CreateVillageField(villageFieldComponent);

            LogComponent.AddLog(LogLevel.Debug, "Village matrix has been created");
        }

        
        private const int RowCount = 10;
        private const int ColumnCount = 10;
        private const string ComponentsVillageCell = "Components/VillageCell";

        private static void CreateVillageField(VillageFieldComponent villageFieldComponent)
        {
            villageFieldComponent.FieldModel = new FieldModel<DistrictCellModel>(
                RowCount,
                ColumnCount,
                () => new DistrictCellModel());

            var filedPanel = GameObject.Find("Fields");
            var grid = filedPanel.GetComponent<GridLayoutGroup>();
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = ColumnCount;

            for (var i = 0; i < filedPanel.transform.childCount; i++)
            {
                var child = filedPanel.transform.GetChild(i);
                Object.Destroy(child.gameObject);
            }

            var cellPrefab = Resources.Load(ComponentsVillageCell);

            for (int row = 0; row < RowCount; row++)
            {
                for (int column = 0; column < ColumnCount; column++)
                {
                    var cellModel = villageFieldComponent.FieldModel.GetItem(row, column);
                    
                    var newCell = Object.Instantiate(cellPrefab, filedPanel.transform);
                    newCell.name = $"area_{row}_{column}";

                    var cell = GameObject.Find(newCell.name);
                    cell.transform.GetChild(0).GetComponent<Text>().text = $"{row}_{column}";
                    cellModel.GameObject = cell;
                }
            }
        }


        private HashSet<UIActionModel> _fieldGroup;
        
        public void Run()
        {
            if (_fieldGroup == null)
                _fieldGroup = UiEventStorage.GetGroup(ObjectGroups.FieldGroup);

            while (_fieldGroup.Any())
            {
                var action = _fieldGroup.First();
                
                LogComponent.AddLog($"{action.ObjectName } has been clicked");
                UiEventStorage.RemoveClick(ObjectGroups.FieldGroup, action.ObjectName, UiActionType.Click);
            }
        }
    }
}