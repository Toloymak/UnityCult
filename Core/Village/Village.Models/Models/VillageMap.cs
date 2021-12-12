using System;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;

namespace Village.Models.Models
{
    [SuppressMessage("ReSharper", "ArrangeObjectCreationWhenTypeNotEvident")]
    public record VillageMap
    {
        public int XSize { get; init; }
        public int YSize { get; init; }

        private ConcurrentDictionary<Coordinates, ConcurrentDictionary<Guid, IVillageObject>> ObjectsOnMap { get; } = new();
        private ConcurrentDictionary<Guid, Coordinates> ObjectPositions { get; } = new();

        private void AddObject(IVillageObject villageObject, Coordinates coordinates)
            => AddObject(villageObject, coordinates.X, coordinates.Y);
        
        public void AddObject(IVillageObject villageObject, int x, int y)
        {
            var coordinate = new Coordinates(x, y);

            var isSuccessAdd = ObjectsOnMap
                .GetOrAdd(coordinate, _ => new())
                .TryAdd(villageObject.Id, villageObject);

            if (!isSuccessAdd)
                return;
            
            ObjectPositions.AddOrUpdate(villageObject.Id,
                _ => coordinate,
                (_, _) => coordinate);
        }

        public bool MoveObject(IVillageObject villageObject, int xDelta, int yDelta)
        {
            if (!ObjectPositions.TryGetValue(villageObject.Id, out var oldPosition))
                return false;

            ObjectsOnMap
                .GetOrAdd(oldPosition,_ => new())
                .TryRemove(villageObject.Id, out _);

            var newPosition = oldPosition.CreateWithDelta(xDelta, yDelta);
            AddObject(villageObject, newPosition);
            return true;
        }

        public bool MoveToTarget(IVillageObject movedObject, IVillageObject target, int speed)
        {
            if (!ObjectPositions.TryGetValue(target.Id, out var targetPosition))
                return false;

            return MoveToTarget(movedObject, targetPosition, speed);
        }

        private bool MoveToTarget(IVillageObject movedObject, Coordinates targetPosition, int speed)
        {
            if (!ObjectPositions.TryGetValue(movedObject.Id, out var oldPosition))
                return false;
            
        }

        private record Coordinates(int X, int Y)
        {
            public Coordinates CreateWithDelta(int xDelta, int yDelta) =>
                new Coordinates(X + xDelta, Y + yDelta);
        };
    }
}