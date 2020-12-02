using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Interfaces;

namespace Business.Models.Actions
{
    public class ActionModel : IListItem
    {
        public Guid Id { get; }

        public string Name { get; set; }
        public string Description { get; set; }
        
        public TimeSpan BaseDuring { get; set; }
        public TimeSpan ExtraDuring { get; set; }

        public IDictionary<ResourceType, int> Resources { get; set; }
        public bool IsActive => true;
        public Action ClickAction { get; set; }

        public ActionModel()
        {
            Id = Guid.NewGuid();
            ExtraDuring = new TimeSpan();
            Resources = new Dictionary<ResourceType, int>();
        }
    }
}