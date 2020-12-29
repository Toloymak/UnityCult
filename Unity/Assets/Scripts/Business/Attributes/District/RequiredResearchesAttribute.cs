using System;
using Business.Enums;

namespace Business.Attributes.District
{
    public class RequiredResearchesAttribute : Attribute
    {
        public ResearchType[] ResearchTypes { get; set; }

        public RequiredResearchesAttribute(params ResearchType[] districtType)
        {
            ResearchTypes = districtType;
        }
    }
}