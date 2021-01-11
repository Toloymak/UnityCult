using System.Collections.Generic;
using Business.Enums;
using Core.Extensions;
using Models.Models;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Extensions
{
    public class DistrictExtensionsTests
    {
        [Test]
        public void GetByType()
        {
            var alchemyModel = new DistrictModel()
            {
                DistrictType = DistrictType.Alchemy
            };
            var districtModels = new List<DistrictModel>() {alchemyModel};

            var actual = districtModels.GetByType(DistrictType.Alchemy);
            
            Assert.AreEqual(alchemyModel, actual);
        }
        
        [Test]
        public void GetByType_InChild()
        {
            var arena2 = new DistrictModel()
            {
                DistrictType = DistrictType.Arena2
            };
            
            var arena = new DistrictModel()
            {
                DistrictType = DistrictType.Arena,
                ChildDistricts = new List<DistrictModel>() {arena2}
            };

            var districtModels = new List<DistrictModel>() {arena};

            var actual = districtModels.GetByType(DistrictType.Arena2);
            
            Assert.AreEqual(arena2, actual);
        }
        
        [Test]
        public void GetByType_TakeParentWithChild()
        {
            var arena2 = new DistrictModel()
            {
                DistrictType = DistrictType.Arena2
            };
            
            var arena = new DistrictModel()
            {
                DistrictType = DistrictType.Arena,
                ChildDistricts = new List<DistrictModel>() {arena2}
            };

            var districtModels = new List<DistrictModel>() {arena};

            var actual = districtModels.GetByType(DistrictType.Arena);
            
            Assert.AreEqual(arena, actual);
        }
        
        [Test]
        public void GetByType_notFound()
        {
            var alchemyModel = new DistrictModel()
            {
                DistrictType = DistrictType.Alchemy
            };
            var districtModels = new List<DistrictModel>() {alchemyModel};

            var actual = districtModels.GetByType(DistrictType.Arena);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetByType_emptyCollection()
        {
            var districtModels = new List<DistrictModel>()
            {
            };
            
            var actual = districtModels.GetByType(DistrictType.Alchemy);
            
            Assert.IsNull(actual);
        }
    }
}