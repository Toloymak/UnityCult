using System;

namespace Models.Attributes
{
    public class DistrictDescriptionAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }
        
        public DistrictDescriptionAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}