using System;
using UnityEngine.UI;

namespace Helpers
{
    public interface IEventHelper
    {
        Button.ButtonClickedEvent CreateButtonEvent(Action action);
        Toggle.ToggleEvent CreateToggleEvent(Action<bool> action);
    }

    public class EventHelper : IEventHelper
    {
        public Button.ButtonClickedEvent CreateButtonEvent(Action action)
        {
            var onClickEvent = new Button.ButtonClickedEvent();
            onClickEvent.AddListener(action.Invoke);
            return onClickEvent;
        }

        public Toggle.ToggleEvent CreateToggleEvent(Action<bool> action)
        {
            var onClickEvent = new Toggle.ToggleEvent();
            onClickEvent.AddListener(action.Invoke);
            return onClickEvent;
        }
    }
}