using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Models.Actions;
using Common.Components;

namespace Common.Storages
{
    public static class VillageStateStorage
    {
        public static IDictionary<ResourceType, ResourceComponent> ResourceComponents { get; set; }
        public static IDictionary<Guid, ActionModel> ActionModels { get; set; } = new Dictionary<Guid, ActionModel>();
    }
}