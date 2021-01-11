using System.Collections.Generic;
using Business.Enums;
using Core.Extensions;
using Models.Models;
using Models.Models.Village;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Extensions
{
    [TestFixture]
    [Parallelizable]
    public class DistrictExtensionsTests
    {
        [Test]
        public void GetByType()
        {
            var alchemyModel = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Alchemy
            };
            var districtModels = new List<DistrictInfoModel>() {alchemyModel};

            var actual = districtModels.GetByType(DistrictType.Alchemy);
            
            Assert.AreEqual(alchemyModel, actual);
        }
        
        [Test]
        public void GetByType_InChild()
        {
            var arena2 = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Arena2
            };
            
            var arena = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Arena,
                ChildDistricts = new List<DistrictInfoModel>() {arena2}
            };

            var districtModels = new List<DistrictInfoModel>() {arena};

            var actual = districtModels.GetByType(DistrictType.Arena2);
            
            Assert.AreEqual(arena2, actual);
        }
        
        [Test]
        public void GetByType_TakeParentWithChild()
        {
            var arena2 = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Arena2
            };
            
            var arena = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Arena,
                ChildDistricts = new List<DistrictInfoModel>() {arena2}
            };

            var districtModels = new List<DistrictInfoModel>() {arena};

            var actual = districtModels.GetByType(DistrictType.Arena);
            
            Assert.AreEqual(arena, actual);
        }
        
        [Test]
        public void GetByType_notFound()
        {
            var alchemyModel = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Alchemy
            };
            var districtModels = new List<DistrictInfoModel>() {alchemyModel};

            var actual = districtModels.GetByType(DistrictType.Arena);
            
            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetByType_emptyCollection()
        {
            var districtModels = new List<DistrictInfoModel>()
            {
            };
            
            var actual = districtModels.GetByType(DistrictType.Alchemy);
            
            Assert.IsNull(actual);
        }
    }
}