using System;
using System.Collections.Generic;
using Business.Enums;

namespace Models.Models
{
    public class ListItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        
        public IDictionary<ResourceType, int> Resources { get; set; }
        public Action ClickAction { get; set; }
    }
}