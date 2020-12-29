using Business.Models.Districts;
using Core.Services;
using Core.UnityServiceContracts;
using Models.Models.Village;
using Moq;
using NUnit.Framework;

namespace Tests.GameCore.Services
{
    public class BuildingServiceTests : TestBase<IBuildingService>
    {
        private Mock<IUnityBuildingService> unityBuildingServiceMock;
        
        [SetUp]
        public void SetUp()
        {
            unityBuildingServiceMock = new Mock<IUnityBuildingService>();
            Service = new BuildingService(unityBuildingServiceMock.Object);
        }
        
        [Test]
        public void Build()
        {
            var cell = new VillageCellModel();
            var districtModel = new DistrictModel();
            
            Service.Build(cell, districtModel);
            
            Assert.AreEqual(cell.DistrictModel, districtModel);
            unityBuildingServiceMock.Verify(x => x.UpdateCellView(cell), Times.Once);
        }
    }
}