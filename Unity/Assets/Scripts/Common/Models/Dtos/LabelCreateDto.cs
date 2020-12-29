using Leopotam.Ecs;
using UnityEngine;

namespace Common.Models.Dtos
{
    public class LabelCreateDto
    {
            public EcsWorld EcsWorld { get; set; }
            public Object LabelNamePrefab { get; set; }
            public Object LabelValuePrefab { get; set; }
            public GameObject ParentObject { get; set; }
    }
}