using System;
using Models.Enums;

namespace Models.Attributes
{
    public class TechnologyConditionsAttribute : Attribute
    {
        public TechnologyConditionsAttribute(params TechnologyTypes[] technologyTypes)
        {
            
        }
    }
}