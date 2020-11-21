using System.Linq;
using Common.Components;
using Common.Consts;
using Common.Enums;
using Common.Models;
using Common.Storages;
using Common.TypeExtensions;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Services
{
    public class FieldService
    {
        public void CreateVillageField(VillageFieldComponent villageFieldComponent, int rowCount, int columnCount)
        {
            villageFieldComponent.FieldModel = new FieldModel<DistrictCellModel>(rowCount, columnCount, () => new DistrictCellModel());
            
            var filedPanelGameObject = PrepareFieldGrid(columnCount);

            var cellPrefab = Resources.Load(ComponentPrefabNames.VillageCell);

            FillField(villageFieldComponent, cellPrefab, filedPanelGameObject, rowCount, columnCount);
        }

        private void FillField(VillageFieldComponent villageFieldComponent,
                                      Object cellPrefab,
                                      GameObject filedPanelGameObject,
                                      int rowCount,
                                      int columnCount)
        {
            for (int row = 0; row < rowCount; row++)
            {
                for (int column = 0; column < columnCount; column++)
                {
                    var cellModel = villageFieldComponent.FieldModel.GetItem(row, column);

                    var newCell = Object.Instantiate(cellPrefab, filedPanelGameObject.transform);
                    newCell.name = $"{row}_{column}";
                    cellModel.Name = newCell.name;

                    var cell = GameObject.Find(newCell.name);
                    cell.transform.Find("Number").GetComponent<Text>().text = $"{row}_{column}";

                    var currentToggle = cell.GetComponent<Toggle>();
                    
                    var toggleEvent = new Toggle.ToggleEvent();
                    toggleEvent.AddListener(value =>
                        {
                            if (currentToggle.isOn)
                            {
                                Debug.Log("On");

                                UiEventStorage.AddAction(ObjectGroups.FieldGroup,
                                                         newCell.name,
                                                         cell,
                                                         UiActionType.Selected);
                            
                                var togglesForDisabling = villageFieldComponent.FieldModel.GetEnumerable()
                                   .Where(x => x.Name != newCell.name)
                                   .Select(x => x.GameObject.GetComponent<Toggle>());
                                
                                foreach (var toggle in togglesForDisabling)
                                {
                                    toggle.isOn = false;
                                    
                                    var disabledToggleColor = toggle.colors;
                                
                                    disabledToggleColor.normalColor = Color.white;
                                    disabledToggleColor.selectedColor = Color.white;

                                    toggle.colors = disabledToggleColor;
                                }
                                
                                var toggleColors = currentToggle.colors;
                                
                                toggleColors.normalColor = Color.green;
                                toggleColors.selectedColor = Color.green;

                                currentToggle.colors = toggleColors;
                            }
                        }
                    );

                    currentToggle.onValueChanged = toggleEvent;

                    cellModel.GameObject = cell;
                }
            }
        }

        private GameObject PrepareFieldGrid(int columnCount)
        {
            var filedPanelGameObject = GameObject.Find("Fields");
            var grid = filedPanelGameObject.GetComponent<GridLayoutGroup>();
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = columnCount;
            
            filedPanelGameObject.transform.DeleteAllChildren();

            return filedPanelGameObject;
        }
    }
}