using System;
using System.Collections.Generic;
using Business.Enums;

namespace Business.Models.Actions
{
    public class ActionModel
    {
        public Guid Id { get; set; }
        
        public bool IsActive { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        
        public TimeSpan BaseDuring { get; set; }
        public TimeSpan ExtraDuring { get; set; }
        
        public TimeSpan StartTime { get; set; }

        public IDictionary<ResourceType, int> Resources { get; set; }
    }
}