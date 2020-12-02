using System.Collections.Generic;
using Business.Enums;
using Common.Components;

namespace Common.Storages
{
    public static class VillageStateStorage
    {
        public static IDictionary<ResourceType, ResourceComponent> ResourceComponents { get; set; }
    }
}