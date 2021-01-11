using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Models.Village
{
    public class VillageMapModel
    {
        public IList<IList<VillageCellModel>> Matrix { get; set; }
        public IDictionary<(int x, int z), VillageCellModel> CoordinateDictionary { get; set; } 

        public VillageMapModel(int rowCount, int columnCount)
        {
            if (rowCount == 0 || columnCount == 0)
                throw new ArgumentException("Matrix cannot be empty");
            
            Matrix = new List<IList<VillageCellModel>>();
            CoordinateDictionary = new Dictionary<(int x, int z), VillageCellModel>();
            
            for (int i = 0; i < rowCount; i++)
            {
                var row = new List<VillageCellModel>();
                
                for (int j = 0; j < columnCount; j++)
                {
                    row.Add(new VillageCellModel((coordinates, model) =>
                    {
                        if (CoordinateDictionary.TryGetValue(coordinates, out _))
                            CoordinateDictionary.Remove(coordinates);
                        
                        CoordinateDictionary.Add(coordinates, model);
                    }));
                }
                
                Matrix.Add(row);
            }
        }
        
        public IList<VillageCellModel> GetRow(int number)
        {
            CheckRowNumber(number);

            return Matrix[number];
        }

        public List<VillageCellModel> GetColumn(int number)
        {
            CheckColumnCount(number);

            return Matrix.Select(row => row[number]).ToList();
        }

        public VillageCellModel GetItem(int rowNumber, int columnNumber)
        {
            CheckRowNumber(rowNumber);
            CheckColumnCount(columnNumber);
            
            return GetRow(rowNumber)[columnNumber];
        }

        public IEnumerable<VillageCellModel> GetEnumerable()
        {
            return Matrix.SelectMany(x => x);
        }

        private void CheckRowNumber(int number)
        {
            if (number >= Matrix.Count)
                throw new ArgumentException($"Matrix contain just {Matrix.Count} rows");
        }

        private void CheckColumnCount(int number)
        {
            if (number >= Matrix.First().Count)
                throw new ArgumentException($"Matrix contain just {Matrix.Count} columns");
        }
    }
}