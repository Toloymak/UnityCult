using Common.Enums;
using UnityEngine.UI;

namespace Common.Components
{
    public class ResourceComponent
    {
        public ResourceType ResourceType { get; set; }
        public int Count { get; set; }
        public Text ValueText { get; set; }
    }
}