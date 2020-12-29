﻿using System;

namespace Business.Attributes
{
    // todo: Remove
    public class ResourcePropertyAttribute : Attribute
    {
        public int DefaultValue { get; }
        
        public ResourcePropertyAttribute(int defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}