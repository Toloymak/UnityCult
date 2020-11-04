using System.Collections.Generic;
using System.Linq;
using Common.Enums;
using Common.Models;

namespace Common.Storages
{
    public static class UiEventStorage
    {
        private static readonly Dictionary<string, HashSet<UIActionModel>> ClickEvents = 
            new Dictionary<string, HashSet<UIActionModel>>();

        public static HashSet<UIActionModel> GetGroup(string groupName)
        {
            if (ClickEvents.ContainsKey(groupName))
                return ClickEvents[groupName];
            
            ClickEvents.Add(groupName, new HashSet<UIActionModel>());
            return ClickEvents[groupName];
        }

        public static void AddAction(string groupName, string name, UiActionType type = UiActionType.Click)
        {
            if (!ClickEvents.ContainsKey(groupName))
                ClickEvents.Add(groupName, new HashSet<UIActionModel>());

            if (ClickEvents[groupName].Any(x => x.ObjectName == name && x.Type == type))
                RemoveClick(groupName, name, type);
            
            ClickEvents[groupName].Add(new UIActionModel(name, type));
        }

        public static void RemoveClick(string groupName, string name, UiActionType type = UiActionType.Click)
        {
            if (!ClickEvents.ContainsKey(groupName))
                ClickEvents.Add(groupName, new HashSet<UIActionModel>());

            ClickEvents[groupName].RemoveWhere(x => x.ObjectName == name && x.Type == type);
        }
    }
}