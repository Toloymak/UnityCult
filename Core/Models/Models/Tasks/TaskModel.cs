using System;
using System.Collections.Generic;
using Models.Enums;

namespace Models.Models.Tasks
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ResourceTaskReward Reward { get; set; }
    }
}