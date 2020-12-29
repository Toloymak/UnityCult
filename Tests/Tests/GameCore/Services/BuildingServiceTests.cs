using System.Collections.Generic;
using Business.Enums;
using Business.Models.Districts;
using Core.Services;
using Core.UnityServiceContracts;
using Models.Models.Village;
using Moq;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Services
{
    public class BuildingServiceTests : TestBase<BuildingService>
    {
        private Mock<IUnityBuildingService> _unityBuildingServiceMock;
        private Mock<IResourceService> _resoutrceService;
        
        [SetUp]
        public void SetUp()
        {
            _unityBuildingServiceMock = new Mock<IUnityBuildingService>();
            _resoutrceService = new Mock<IResourceService>();
            
            Service = new BuildingService(_unityBuildingServiceMock.Object,
                                          _resoutrceService.Object,
                                          LogService.Object);
        }
        
        [Test]
        public void Build()
        {
            var cell = new VillageCellModel();
            var districtModel = new DistrictModel();

            _resoutrceService
               .Setup(x => x.TryTakeResources(It.IsAny<IDictionary<ResourceType, int>>()))
               .Returns(true);
            
            Service.Build(cell, districtModel);
            
            Assert.AreEqual(cell.DistrictModel, districtModel);
            
            _resoutrceService.Verify(x => x.TryTakeResources(districtModel.Resources), Times.Once);
            _unityBuildingServiceMock.Verify(x => x.UpdateCellView(cell), Times.Once);
        }
        
        [Test]
        public void Build_IsNotEnoughMoney()
        {
            var cell = new VillageCellModel();
            var districtModel = new DistrictModel();

            _resoutrceService
               .Setup(x => x.TryTakeResources(It.IsAny<IDictionary<ResourceType, int>>()))
               .Returns(false);
            
            Service.Build(cell, districtModel);
            
            Assert.AreEqual(cell.DistrictModel, null);
            
            _resoutrceService.Verify(x => x.TryTakeResources(districtModel.Resources), Times.Once);
            _unityBuildingServiceMock.Verify(x => x.UpdateCellView(cell), Times.Never);
        }
    }
}