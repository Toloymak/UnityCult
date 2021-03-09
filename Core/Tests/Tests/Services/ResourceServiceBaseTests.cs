using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using AutoFixture;
using Managers.Managers;
using Models.Enums;
using Models.Models;
using Moq;
using NUnit.Framework;
using Services.Services;

namespace Tests.Tests.Services
{
    public class ResourceServiceBaseTests : BaseTest<ResourceService>
    {
        private Mock<IResourceManager> _resourceManagerMock;
        private Mock<IEffectManager> _effectManagerMock;
        private Mock<IDistrictManager> _districtManagerMock;
        
        private const int TestResourceCount = 123;
        private const int SecondTestResourceCount = 321;
        
        [SetUp]
        public void Setup()
        {
            _resourceManagerMock = new Mock<IResourceManager>();
            _effectManagerMock = new Mock<IEffectManager>();
            _effectManagerMock
                .Setup(x => x.GetResourceEffects())
                .Returns(new List<ResourceEffectModel>());
            _districtManagerMock = new Mock<IDistrictManager>();
            _districtManagerMock
                .Setup(x => x.GetResourceEffectModels())
                .ReturnsAsync(new List<ResourceEffectModel>());

            Service = new ResourceService(
                _resourceManagerMock.Object,
                _effectManagerMock.Object,
                _districtManagerMock.Object);
        }
        
        [Test]
        public async Task Calculate_Success_NoException()
        {
            await Service.Calculate();
        }
        
        [Test]
        public async Task Calculate_NoEffects_NotAddedResources()
        {
            await Service.Calculate();
            _resourceManagerMock
                .Verify(x => x.Add(It.IsAny<ResourceType>(), It.IsAny<int>()), Times.Never);
        }

        [Test]
        public async Task Calculate_GetEffects()
        {
            await Service.Calculate();
            _effectManagerMock.Verify(x => x.GetResourceEffects());
        }
        
        [Theory]
        public async Task Calculate_AddEffectsToResources(ResourceType resourceType)
        {
            var effects = new List<ResourceEffectModel>()
            {
                CreateResourceEffectModel(resourceType, TestResourceCount)
            };

            _effectManagerMock
                .Setup(x => x.GetResourceEffects())
                .Returns(effects);
            
            await Service.Calculate();
            _resourceManagerMock.Verify(x => x.Add(resourceType, TestResourceCount), Times.Once);
        }
        
        [Theory]
        public async Task Calculate_DoubleEffect_AddEffectsToResources(ResourceType resourceType)
        {
            var effect = CreateResourceEffectModel(resourceType, TestResourceCount);

            _effectManagerMock
                .Setup(x => x.GetResourceEffects())
                .Returns(new List<ResourceEffectModel>() {effect, effect});
            
            await Service.Calculate();
            _resourceManagerMock
                .Verify(x => x.Add(resourceType, TestResourceCount * 2), Times.Once);
        }
        
        
        [Theory]
        public async Task Calculate_TwoEffect_AddEffectsToResources(ResourceType firstResourceType, ResourceType secondResourceType)
        {
            if (firstResourceType == secondResourceType)
                return;

            var firstEffect = CreateResourceEffectModel(firstResourceType, TestResourceCount);
            var secondEffect = CreateResourceEffectModel(secondResourceType, SecondTestResourceCount );

            _effectManagerMock
                .Setup(x => x.GetResourceEffects())
                .Returns(new List<ResourceEffectModel>() {firstEffect, secondEffect});
            
            await Service.Calculate();
            _resourceManagerMock
                .Verify(x => x.Add(firstResourceType, TestResourceCount), Times.Once);
            
            _resourceManagerMock
                .Verify(x => x.Add(secondResourceType, SecondTestResourceCount), Times.Once);
        }

        [Test]
        public async Task Calculate_CallDistrictEffects()
        {
            await Service.Calculate();
            _districtManagerMock.Verify(x => x.GetResourceEffectModels(), Times.Once);
        }
        
        [Theory]
        public async Task Calculate_ExistDistrictEffect_AddResource(ResourceType resourceType)
        {
            var effect = CreateResourceEffectModel(resourceType, TestResourceCount);
            _districtManagerMock
                .Setup(x => x.GetResourceEffectModels())
                .ReturnsAsync(new List<ResourceEffectModel>() {effect});
            
            await Service.Calculate();
            _resourceManagerMock.Verify(x => x.Add(resourceType, TestResourceCount), Times.Once);
        }
        
        [Theory]
        public async Task Calculate_ExistDoubleEffect_AddResource(ResourceType resourceType)
        {
            var effect = CreateResourceEffectModel(resourceType, TestResourceCount);
            _districtManagerMock
                .Setup(x => x.GetResourceEffectModels())
                .ReturnsAsync(new List<ResourceEffectModel>() {effect, effect});
            
            await Service.Calculate();
            _resourceManagerMock.Verify(x => x.Add(resourceType, TestResourceCount * 2), Times.Once);
        }
        
        [Theory]
        public async Task Calculate_ExistFewDistrictEffects_AddResource(ResourceType firstResourceType, ResourceType secondResourceType)
        {
            if (firstResourceType == secondResourceType)
                return;
            
            var firstEffect = CreateResourceEffectModel(firstResourceType, TestResourceCount);
            var secondEffect = CreateResourceEffectModel(secondResourceType, SecondTestResourceCount );
            
            _districtManagerMock
                .Setup(x => x.GetResourceEffectModels())
                .ReturnsAsync(new List<ResourceEffectModel>() {firstEffect, secondEffect});
            
            await Service.Calculate();
            _resourceManagerMock.Verify(x => x.Add(firstResourceType, TestResourceCount), Times.Once);
            _resourceManagerMock.Verify(x => x.Add(secondResourceType, SecondTestResourceCount), Times.Once);
        }
        
        [Theory]
        public async Task Calculate_ExistFewDistrictEffectsAndEffect_AddResource(ResourceType resourceType)
        {
            var effect = CreateResourceEffectModel(resourceType, TestResourceCount);
            
            _districtManagerMock
                .Setup(x => x.GetResourceEffectModels())
                .ReturnsAsync(new List<ResourceEffectModel>() {effect});

            _effectManagerMock
                .Setup(x => x.GetResourceEffects())
                .Returns(new List<ResourceEffectModel>() {effect});
            
            await Service.Calculate();
            _resourceManagerMock.Verify(x => x.Add(resourceType, TestResourceCount * 2), Times.Once);
        }

        private ResourceEffectModel CreateResourceEffectModel(ResourceType resourceType, int amount)
        {
            var effect = Fixture.Build<ResourceEffectModel>()
                .With(x => x.ResourceType, resourceType)
                .With(x => x.Amount, amount)
                .Create();

            return effect;
        }
    }
}