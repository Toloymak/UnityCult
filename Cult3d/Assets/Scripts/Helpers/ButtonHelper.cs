using Consts;
using Models.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Helpers
{
    public interface IButtonHelper
    {
        void CreateListItem(ListItemModel listItemModel, Transform parent);
    }

    public class ButtonHelper : IButtonHelper
    {
        private readonly IObjectInstantiateHelper _objectInstantiateHelper;
        private readonly IEventHelper _eventHelper;

        public ButtonHelper(IObjectInstantiateHelper objectInstantiateHelper,
                            IEventHelper eventHelper)
        {
            _objectInstantiateHelper = objectInstantiateHelper;
            _eventHelper = eventHelper;
        }

        public void CreateListItem(ListItemModel listItemModel, Transform parent)
        {
            var newItem = _objectInstantiateHelper.Instanate(PrefabNames.DistrictListItem, parent);
            newItem.transform.Find("Text").GetComponent<Text>().text = listItemModel.Name;
            newItem.transform.Find("Description").GetComponent<Text>().text = listItemModel.Description;
            newItem.GetComponent<Button>().onClick = _eventHelper.CreateButtonEvent(listItemModel.ClickAction);
        }
    }
}