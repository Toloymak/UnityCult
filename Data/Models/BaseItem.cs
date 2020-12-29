using System;

namespace Models.Models
{
    public abstract class BaseItem
    {
        public Guid Id { get; }

        public string Name { get; set; }
        public string Description { get; set; }

        protected BaseItem()
        {
            Id = new Guid();
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}