using System;
using System.Collections.Generic;
using Business.Enums;

namespace Business.Interfaces
{
    public interface IListItem
    {
        string Name { get; set; }
        string Description { get; set; }
        
        IDictionary<ResourceType, int> Resources { get; set; }

        bool IsActive { get; }

        Action ClickAction { get; set; }
    }
}