using System;
using System.Collections.Generic;
using Business.Enums;

namespace Models.Models
{
    public class ActionModel : BaseItem
    {
        public TimeSpan BaseDuring { get; set; }
        public TimeSpan ExtraDuring { get; set; }
        
        public TimeSpan StartTime { get; set; }

        public IDictionary<ResourceType, int> Resources { get; set; }
    }
}