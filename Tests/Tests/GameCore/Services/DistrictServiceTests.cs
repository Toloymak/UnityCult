using Core.Services;
using Moq;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Services
{
    public class DistrictServiceTests : TestBase<DistrictService>
    {
        private Mock<ConfigService> _configServiceMock;
        
        [SetUp]
        public void SetUp()
        {
            _configServiceMock = new Mock<ConfigService>();
            Service = new DistrictService(new ConfigService());
        }

        [Test]
        public void GetTree()
        {
            Service.GetDistrictTree();
        }
    }
}