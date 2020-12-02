using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Extensions;
using Business.Interfaces;
using Common.Consts;
using Common.TypeExtensions;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Common.Services
{
    public class ItemListService
    {
        private Object _itemPrefab;
        private Object ItemPrefab =>
            _itemPrefab == null
                ? _itemPrefab = Resources.Load(ComponentPrefabNames.ListItem)
                : _itemPrefab;

        private Object _priceItem;
        private Object PriceItem =>
            _priceItem == null
                ? _priceItem = Resources.Load(ComponentPrefabNames.ResourceItem)
                : _priceItem;

        public void AddItem(Transform listTransform, IListItem listItem)
        {
            var itemGameObject = (GameObject) Object.Instantiate(ItemPrefab, listTransform);
            itemGameObject.name = $"item_{listItem.GetType()}";

            itemGameObject.transform.Find("Name").GetComponent<Text>().text = listItem.Name;
            itemGameObject.transform.Find("Description").GetComponent<Text>().text = listItem.Description;

            var button = itemGameObject.GetComponent<Button>();
            button.interactable = listItem.IsActive;

            var buttonEvent = new Button.ButtonClickedEvent();
            buttonEvent.AddListener(() => listItem.ClickAction());

            button.onClick = buttonEvent;

            var priceListGameObject = itemGameObject.transform.Find(UiObjectNames.PriceItemInListItem);
            priceListGameObject.transform.DeleteAllChildren();

            foreach (var price in listItem.Resources)
            {
                var newPrice = (GameObject) Object.Instantiate(PriceItem, priceListGameObject.transform);

                newPrice.transform.Find("Name").GetComponent<Text>().text = price.Key.GetShortName();
                newPrice.transform.Find("Value").GetComponent<Text>().text = price.Value.ToString();
            }
        }
        
        public void AddItems(Transform listGameObject, IList<IListItem> listItem)
        {
            Parallel.ForEach(listItem, x => AddItem(listGameObject, x));
        }
    }
}