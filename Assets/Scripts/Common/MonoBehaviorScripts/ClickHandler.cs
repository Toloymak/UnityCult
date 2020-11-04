using System;
using System.Collections.Generic;
using Common.Consts;
using Common.Enums;
using Common.Storages;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Common.MonoBehaviorScripts
{
    public class ClickHandler : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
        IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnEndDrag(PointerEventData eventData)
        {
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UiEventStorage.AddAction(ObjectGroups.FieldGroup, name);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }

        public void OnPointerUp(PointerEventData eventData)
        {
        }
    }
}