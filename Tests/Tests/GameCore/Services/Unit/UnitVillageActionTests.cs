using Core.Services;
using Core.Services.Unit;
using Models.Models;
using Moq;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Services.Unit
{
    public class UnitVillageActionTests : TestBase<UnitVillageAction>
    {
        private IMock<IUnitPriorityProvider> _unitPriorityProviderMock;
        private IMock<IStorageService> _storageServiceMock;
        
        [SetUp]
        public void SetUp()
        {
            _storageServiceMock = new Mock<IStorageService>();
            _unitPriorityProviderMock = new Mock<IUnitPriorityProvider>();
            
            Service = new UnitVillageAction(_storageServiceMock.Object,
                                            _unitPriorityProviderMock.Object);
        }

        [Test]
        public void CalculateTargetBuilding()
        {
            var guid = Service.CalculateTargetBuilding(new UnitModel());
            
            Assert.NotNull(guid);
        }
    }
}