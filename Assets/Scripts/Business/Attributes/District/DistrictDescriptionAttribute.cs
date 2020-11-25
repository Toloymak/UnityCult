using System;

namespace Business.Attributes.District
{
    public class DistrictDescriptionAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TexturePath { get; set; }
        public int MaxCount { get; set; }

        public DistrictDescriptionAttribute(string name,
                                            string description,
                                            string texture = "",
                                            int maxCount = int.MaxValue)
        {
            Name = name;
            Description = description;
            TexturePath = texture;
            MaxCount = maxCount;
        }
        
        public DistrictDescriptionAttribute(string name)
            : this(name, string.Empty)
        {
            
        }
    }
}