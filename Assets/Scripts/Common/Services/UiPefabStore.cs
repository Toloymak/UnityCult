using Common.Consts;
using UnityEngine;

namespace Common.Services
{
    public class UiPrefabStoreService
    {
        private Object _actionItem;

        public Object ListItem
        {
            get => _actionItem == null
                    ? _actionItem = Resources.Load(ComponentPrefabNames.ListItem)
                    : _actionItem;
            set => _actionItem = value;
        }
    }
}