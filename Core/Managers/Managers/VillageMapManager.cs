using System.Collections.Generic;
using Models.Models.Players;
using Models.Models.Villages;

namespace Managers.Managers
{
    public interface IVillageMapManager
    {
        VillageMapModel GetNewMap(int xSize, int ySize);
    }

    public class VillageMapManager : IVillageMapManager
    {
        public VillageMapModel GetNewMap(int xSize, int ySize)
        {
            return new VillageMapModel
            {
                Cells = CreateCells(xSize, ySize)
            };
        }

        private static List<IList<VillageCellModel>> CreateCells(int xSize, int ySize)
        {
            var villageMap = new List<IList<VillageCellModel>>(ySize);

            for (var y = 0; y < ySize; y++)
                villageMap.Add(CreateRow(xSize, y));
            
            return villageMap;
        }

        private static List<VillageCellModel> CreateRow(int xSize, int y)
        {
            var row = new List<VillageCellModel>(xSize);

            for (var x = 0; x < xSize; x++)
                row.Add(new VillageCellModel(x, y));
            return row;
        }
    }
}