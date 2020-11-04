using Common.Enums;

namespace Common.Models
{
    public class UIActionModel
    {
        public string ObjectName { get; set; }
        public UiActionType Type { get; set; }

        public UIActionModel(string objectName, UiActionType type)
        {
            ObjectName = objectName;
            Type = type;
        }
    }
}