using System;

namespace Business.Attributes
{
    public class ResourcePropertyAttribute : Attribute
    {
        public int DefaultValue { get; }
        
        public ResourcePropertyAttribute(int defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}