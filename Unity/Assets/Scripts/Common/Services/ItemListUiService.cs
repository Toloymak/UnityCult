using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Extensions;
using Business.Interfaces;
using Common.Consts;
using Common.Helpers;
using Common.TypeExtensions;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Services
{
    public class ItemListUiService
    {
        private readonly ObjectInstantiateHelper _objectInstantiateHelper;

        public ItemListUiService(ObjectInstantiateHelper objectInstantiateHelper)
        {
            _objectInstantiateHelper = objectInstantiateHelper;
        }

        public void AddItem(Transform listTransform, IListItem listItem)
        {
            var itemGameObject =
                _objectInstantiateHelper.Instanate(ComponentPrefabNames.ListItem,
                                                     listTransform,
                                                     $"item_{listItem.GetType()}");

            itemGameObject.transform.Find("Name").GetComponent<Text>().text = listItem.Name;
            itemGameObject.transform.Find("Description").GetComponent<Text>().text = listItem.Description;

            var button = itemGameObject.GetComponent<Button>();
            button.interactable = listItem.IsActive;

            var buttonEvent = new Button.ButtonClickedEvent();
            buttonEvent.AddListener(() => listItem.ClickAction());

            button.onClick = buttonEvent;

            var priceListGameObject = itemGameObject.transform.Find(UiObjectNames.PriceItemInListItem).transform;
            priceListGameObject.DeleteAllChildren();

            foreach (var price in listItem.Resources)
            {
                var newPrice = _objectInstantiateHelper.Instanate(ComponentPrefabNames.ListPriceItem,
                                                                  priceListGameObject);

                newPrice.transform.Find("Name").GetComponent<Text>().text = price.Key.GetShortName();
                newPrice.transform.Find("Value").GetComponent<Text>().text = price.Value.ToString();
            }
        }
        
        public void AddItems(Transform listGameObject, IEnumerable<IListItem> listItems)
        {
            foreach (var listItem in listItems)
                AddItem(listGameObject, listItem);
        }
    }
}