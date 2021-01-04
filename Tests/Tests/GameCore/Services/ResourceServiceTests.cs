using System.Collections.Generic;
using Business.Enums;
using Core.Services;
using Models.Models;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Services
{
    public class ResourceServiceTests : TestBase<ResourceService>
    {
        private ResourcesModel _resourcesModel;
        
        [SetUp]
        public void SetUp()
        {
            var storageService = new StorageService();
            _resourcesModel = storageService.GetOrCreate<ResourcesModel>();
            
            Service = new ResourceService(storageService);
        }

        [TestCase(100, 100, true)]
        [TestCase(50, 100, true)]
        [TestCase(100, 50, false)]
        [TestCase(0, 100, true)]
        [TestCase(100, 0, false)]
        [TestCase(0, 0, true)]
        public void TryTakeResources(int price, int onStorage, bool expectedResult)
        {
            var priceList = new Dictionary<ResourceType, int>()
            {
                {ResourceType.Food, price}
            };

            _resourcesModel[ResourceType.Food] = onStorage;
            
            var actualResult = Service.TryTakeResources(priceList);
            
            Assert.AreEqual(expectedResult, actualResult);
            
            
            if (actualResult)
            {
                Assert.AreEqual(onStorage - price, _resourcesModel[ResourceType.Food]);
            }
        }
        
        [TestCase(100, 100, 100, 100, true)]
        [TestCase(100, 50, 100, 100, false)]
        [TestCase(100, 100, 100, 50, false)]
        [TestCase(100, 50, 100, 50, false)]
        [TestCase(100, 100, 100, 100, true)]
        [TestCase(50, 100, 50, 100, true)]
        public void TryTakeResources_FewResources(int foodPrice, int foodOnStorage,
                                                  int energyPrice, int energyOnStorage,
                                                  bool expectedResult)
        {
            var priceList = new Dictionary<ResourceType, int>()
            {
                {ResourceType.Food, foodPrice},
                {ResourceType.Energy, energyPrice}
            };

            _resourcesModel[ResourceType.Food] = foodOnStorage;
            _resourcesModel[ResourceType.Energy] = energyOnStorage;
            
            var actualResult = Service.TryTakeResources(priceList);
            
            Assert.AreEqual(expectedResult, actualResult);
            
            if (actualResult)
            {
                Assert.AreEqual(foodOnStorage - foodPrice, _resourcesModel[ResourceType.Food]);
                Assert.AreEqual(energyOnStorage - energyPrice, _resourcesModel[ResourceType.Energy]);
            }
        }

        [TestCase(100, 100, 100, 100)]
        [TestCase(50, 100, 100, 100)]
        [TestCase(100, 100, 50, 100)]
        [TestCase(0, 100, 100, 100)]
        [TestCase(100, 100, 0, 100)]
        [TestCase(100, 0, 100, 100)]
        [TestCase(100, 100, 100, 0)]
        public void AddResources(int foodPrice, int foodOnStorage,
                                 int energyPrice, int energyOnStorage)
        {
            var addList = new Dictionary<ResourceType, int>()
            {
                {ResourceType.Food, foodPrice},
                {ResourceType.Energy, energyPrice}
            };

            _resourcesModel[ResourceType.Food] = foodOnStorage;
            _resourcesModel[ResourceType.Energy] = energyOnStorage;

            Service.AddResources(addList);
            
            Assert.AreEqual(foodOnStorage + foodPrice, _resourcesModel[ResourceType.Food]);
            Assert.AreEqual(energyOnStorage + energyPrice, _resourcesModel[ResourceType.Energy]);
        }
    }
}