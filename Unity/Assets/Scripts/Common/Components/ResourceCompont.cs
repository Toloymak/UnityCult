using Business.Enums;
using Common.Enums;
using UnityEngine.UI;

namespace Common.Components
{
    public class ResourceComponent
    {
        public ResourceType ResourceType { get; set; }

        private int _count;

        public int Count
        {
            get => _count;
            
            set
            {
                _count = value;
                ValueText.text = _count.ToString();
            }
        }

        public Text ValueText { get; set; }
    }
}