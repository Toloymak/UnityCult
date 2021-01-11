using System.Collections.Generic;
using Business.Enums;
using Core.Services;
using Core.Services.District;
using Core.UnityServiceContracts;
using Models.Models;
using Models.Models.Village;
using Moq;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Services
{
    public class BuildingServiceTests : TestBase<BuildingService>
    {
        private Mock<IUnityBuildingService> _unityBuildingServiceMock;
        private Mock<IResourceService> _resourceService;
        private Mock<IDistrictService> _districtService;
        
        [SetUp]
        public void SetUp()
        {
            _unityBuildingServiceMock = new Mock<IUnityBuildingService>();
            _resourceService = new Mock<IResourceService>();
            _districtService = new Mock<IDistrictService>();

            Service = new BuildingService(_unityBuildingServiceMock.Object,
                                          _resourceService.Object,
                                          LogService.Object,
                                          _districtService.Object);
        }
        
        [Test]
        public void Build()
        {
            var cell = new VillageCellModel(new Coordinates());
            var districtModel = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Administration
            };

            _resourceService
               .Setup(x => x.TryTakeResources(It.IsAny<IDictionary<ResourceType, int>>()))
               .Returns(true);

            CreateDistrictTree(districtModel);
            
            Service.Build(cell, DistrictType.Administration);
            
            Assert.AreEqual(cell.DistrictInfoModel, districtModel);
            
            _resourceService.Verify(x => x.TryTakeResources(districtModel.Resources), Times.Once);
            _unityBuildingServiceMock.Verify(x => x.UpdateCellView(cell), Times.Once);
        }

        private void CreateDistrictTree(DistrictInfoModel districtInfoModel)
        {
            _districtService.Setup(service => service.GetDistrictTree())
               .Returns(() => new List<DistrictInfoModel>() {districtInfoModel});
        }

        [Test]
        public void Build_IsNotEnoughMoney()
        {
            var cell = new VillageCellModel(new Coordinates());
            var districtModel = new DistrictInfoModel()
            {
                DistrictType = DistrictType.Administration
            };

            _resourceService
               .Setup(x => x.TryTakeResources(It.IsAny<IDictionary<ResourceType, int>>()))
               .Returns(false);
            
            CreateDistrictTree(districtModel);

            Service.Build(cell, DistrictType.Administration);
            
            Assert.AreEqual(cell.DistrictInfoModel, null);
            
            _resourceService.Verify(x => x.TryTakeResources(districtModel.Resources), Times.Once);
            _unityBuildingServiceMock.Verify(x => x.UpdateCellView(cell), Times.Never);
        }
    }
}