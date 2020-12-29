using System;
using System.Collections.Generic;
using System.Linq;

namespace Models.Models.Village
{
    public class VillageMapModel
    {
        public IList<IList<VillageCellModel>> Matrix { get; set; }

        public VillageMapModel(int rowCount, int columnCount)
        {
            if (rowCount == 0 || columnCount == 0)
                throw new ArgumentException("Matrix cannot be empty");
            
            Matrix = new List<IList<VillageCellModel>>();
            
            for (int i = 0; i < rowCount; i++)
            {
                var row = new List<VillageCellModel>();
                
                for (int j = 0; j < columnCount; j++)
                {
                    row.Add(new VillageCellModel());
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
        
        public VillageCellModel GetItemByName(string name)
        {
            var addresses = name.Split('_').Select(int.Parse).ToArray();
            var cell = GetItem(addresses[0], addresses[1]);

            return cell;
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