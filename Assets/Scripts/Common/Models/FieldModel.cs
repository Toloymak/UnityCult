using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Models
{
    public class FieldModel<T> where T : class
    {
        public IList<IList<T>> Matrix { get; set; }

        public FieldModel(int rowCount, int columnCount, Func<T> createStrategy)
        {
            Matrix = new List<IList<T>>();
            
            for (int i = 0; i < rowCount; i++)
            {
                var row = new List<T>();
                
                for (int j = 0; j < columnCount; j++)
                {
                    row.Add(createStrategy.Invoke());
                }
                
                Matrix.Add(row);
            }
        }
        
        public IList<T> GetRow(int number)
        {
            CheckRowNumber(number);

            return Matrix[number];
        }

        public List<T> GetColumn(int number)
        {
            CheckColumnCount(number);

            return Matrix.Select(row => row[number]).ToList();
        }

        public T GetItem(int rowNumber, int columnNumber)
        {
            CheckRowNumber(rowNumber);
            CheckColumnCount(columnNumber);
            
            return GetRow(rowNumber)[columnNumber];
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