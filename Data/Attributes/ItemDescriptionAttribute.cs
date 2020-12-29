using System;

namespace Models.Attributes
{
    public class ItemDescriptionAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TexturePath { get; set; }

        public ItemDescriptionAttribute(string name,
                                            string description,
                                            string texture = "")
        {
            Name = name;
            Description = description;
            TexturePath = texture;
        }
        
        public ItemDescriptionAttribute(string name)
            : this(name, string.Empty)
        {
            
        }
    }
}