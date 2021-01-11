using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Models.Village
{
    public class VillageMapModel
    {
        public IDictionary<Coordinates, VillageCellModel> MapCoordinateDictionary { get; } 

        public VillageMapModel(int rowCount, int columnCount, Coordinates startPoint)
        {
            if (rowCount == 0 || columnCount == 0)
                throw new ArgumentException("Map cannot be empty");
            
            MapCoordinateDictionary = new Dictionary<Coordinates, VillageCellModel>();
            
            for (var rowNumber = 0; rowNumber < rowCount; rowNumber++)
                for (var columnNumber = 0; columnNumber < columnCount; columnNumber++)
                {
                    var mapCoordinates = new Coordinates(startPoint.X + rowNumber, startPoint.Z + columnNumber);
                    MapCoordinateDictionary.Add(mapCoordinates, new VillageCellModel(mapCoordinates));
                }
        }
    }
}