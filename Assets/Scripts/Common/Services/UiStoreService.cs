using Common.Consts;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Services
{
    public class UiStoreService
    {
        private GameObject _field;

        public GameObject Filed
        {
            get => _field != null ? _field : _field = GameObject.Find(UiObjectNames.FieldPanel);
            set => _field = value;
        }
        
        private GameObject _actionList;

        public GameObject ActionList
        {
            get => _actionList != null ? _actionList : _actionList = GameObject.Find(UiObjectNames.ActionList);
            set => _actionList = value;
        }
        
        private GameObject _buildActionList;

        public GameObject BuildActionList
        {
            get => _buildActionList != null
                ? _buildActionList
                : _buildActionList = GameObject.Find(UiObjectNames.BuildingActionList);
            set => _buildActionList = value;
        }

        private Text _unitList;

        public Text UnitList
        {
            get => _unitList != null
                ? _unitList
                : _unitList = GameObject.Find(UiObjectNames.UnitList).GetComponent<Text>();
            set => _unitList = value;
        }
    }
}