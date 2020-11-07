using System;

namespace Common.Attributes
{
    public class DistrictDescriptionAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DistrictDescriptionAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        public DistrictDescriptionAttribute(string name)
            : this(name, string.Empty)
        {
            
        }
    }
}