using System;
using System.Collections.Generic;
using Models.Models;
using Models.Models.Village;
using NUnit.Framework;

namespace Tests.Tests.Data
{
    [TestFixture]
    [Parallelizable]
    public class VillageMapModelTests
    {
        [TestCase(1, 1)]
        [TestCase(100, 100)]
        public void Create(int row, int column)
        {
            var matrix = new VillageMapModel(row, column, new Coordinates());
            Assert.AreEqual(row * column, matrix.MapCoordinateDictionary.Count);
        }
        
        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(1, 0)]
        public void Create_EmptyMatrix_Exception(int row, int column)
        {
            // ReSharper disable once ObjectCreationAsStatement
            Assert.Throws<ArgumentException>(() => new VillageMapModel(row, column, new Coordinates()));
        }
        
        [Test]
        public void GetByCoordinates_notFound()
        {
            var matrix = new VillageMapModel(10, 10, new Coordinates());

            Assert.Throws<KeyNotFoundException>(() =>
            {
                var data = matrix.MapCoordinateDictionary[new Coordinates(100, 100)];
            });
        }
        
        [Test]
        public void GetByCoordinates()
        {
            var matrix = new VillageMapModel(10, 10, new Coordinates(10, 10));
            var data = matrix.MapCoordinateDictionary[new Coordinates(13, 13)];
            
            Assert.AreEqual(new Coordinates(13, 13), data.WorldCoordinates);
        }
    }
}