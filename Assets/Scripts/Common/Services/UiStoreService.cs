using Common.Consts;
using UnityEditor;
using UnityEngine;

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
    }
}