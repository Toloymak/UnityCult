using System;
using System.Linq;
using Models.Models.Village;
using NUnit.Framework;

namespace Tests.Tests.Data
{
    public class VillageMapModelTests
    {
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
    }
}