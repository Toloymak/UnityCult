using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Interfaces;

namespace Business.Models.Actions
{
    public class ActionListItemModel : IListItem
    {
        public Guid Id { get; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public TimeSpan During { get; set; }

        public IDictionary<ResourceType, int> Resources { get; set; }
        public bool IsActive => true;

        public Action ClickAction { get; }

        public ActionListItemModel()
        {
            Id = Guid.NewGuid();
            Resources = new Dictionary<ResourceType, int>();
            ClickAction = () => {};
        }
    }
}