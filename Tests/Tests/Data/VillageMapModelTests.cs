using System;
using System.Collections.Generic;
using System.Linq;
using Models.Models.Village;
using NUnit.Framework;

namespace Tests.Tests.Data
{
    public class VillageMapModelTests
    {
        private VillageMapModel matrix;
        
        [TestCase(1, 1)]
        [TestCase(999, 999)]
        public void Create(int row, int column)
        {
            var matrix = new VillageMapModel(row, column);
            Assert.AreEqual(matrix.Matrix.Count, row);
            Assert.AreEqual(matrix.Matrix.First().Count, column);
        }
        
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void Create_EmptyMatrix_Exception(int row, int column)
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new VillageMapModel(row, column));
        }
        
        [Test]
        public void GetByCoordinates_notFound()
        {
            matrix = new VillageMapModel(10, 10);

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var data = matrix.CoordinateDictionary[(1, 1)];
            });
        }
        
        [Test]
        public void GetByCoordinates()
        {
            matrix = new VillageMapModel(10, 10);
            var item = matrix.GetItem(1, 1);
            item.Coordinates = (5, 5);

            var data = matrix.CoordinateDictionary[(5, 5)];
            
            Assert.AreEqual(item, data);
        }
    }
}