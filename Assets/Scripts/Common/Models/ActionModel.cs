using System;
using UnityEngine;

namespace Common.Models
{
    public class ActionModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TimeInSeconds { get; set; }
        public Guid Id { get; }

        public ActionModel()
        {
            Id = Guid.NewGuid();
        }
    }
}