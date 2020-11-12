using System;

namespace Common.Attributes
{
    public class ResourceDescriptionAttribute : Attribute
    {
        public string ShortName { get; }
        public string Name { get; }

        public ResourceDescriptionAttribute(string shortName, string name)
        {
            ShortName = shortName;
            Name = name;
        }
    }
}