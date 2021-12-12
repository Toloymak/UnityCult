using System;

namespace Village.Models.Models
{
    public interface IVillageObject
    {
        public Guid Id { get; init; }
    }
    
    public record VillageObject : IVillageObject
    {
        public Guid Id { get; init; }

        public VillageObject()
        {
            Id = Guid.NewGuid();
        }
    }
}