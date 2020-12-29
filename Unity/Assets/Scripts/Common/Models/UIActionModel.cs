using Common.Enums;
using UnityEngine;

namespace Common.Models
{
    public class UIActionModel
    {
        public string ObjectName { get; set; }
        public UiActionType Type { get; set; }
        public GameObject GameObject { get; set; }

        public UIActionModel(string objectName, UiActionType type, GameObject gameObject)
        {
            ObjectName = objectName;
            Type = type;
        }
    }
}