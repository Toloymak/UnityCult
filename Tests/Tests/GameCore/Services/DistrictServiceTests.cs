using System.IO;
using Core.Services;
using Core.Services.District;
using Moq;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Services
{
    public class DistrictServiceTests : TestBase<DistrictService>
    {
        private Mock<ConfigService> _configServiceMock;
        private Mock<IFilePathProvider> _filePathProviderMock;
        
        [SetUp]
        public void SetUp()
        {
            _configServiceMock = new Mock<ConfigService>();
            
            _filePathProviderMock = new Mock<IFilePathProvider>();
            var configDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\TestObjects\\Configs";
            _filePathProviderMock.Setup(provider => provider.GetConfigDirectory())
               .Returns(configDirectory);
            
            Service = new DistrictService(new ConfigService(_filePathProviderMock.Object));
        }

        [Test]
        public void GetTree()
        {
            Service.PrintDistrictTree();
        }
    }
}