using System.Collections.Generic;
using Core.Services;
using NUnit.Framework;
using Tests.TestObjects.Classes;

namespace Tests.Tests.GameCore.Services
{
    public class StorageServiceTests : TestBase<StorageService>
    {
        [SetUp]
        public void SetUp()
        {
            Service = new StorageService();
        }

        [Test]
        public void GetOrCreate_New()
        {
            var createdObject = Service.GetOrCreate<TestClassWithoutConstructor>();
            Assert.NotNull(createdObject);
        }
        
        [Test]
        public void GetOrCreate_GetAfter()
        {
            var createdObject = Service.GetOrCreate<TestClassWithoutConstructor>();
            var resultObject = Service.Get<TestClassWithoutConstructor>();

            Assert.AreSame(createdObject, resultObject);
        }
        
        [Test]
        public void Create()
        {
            var newObject = new TestClassWithConstructor(new object());
            var resultObject = Service.Create(newObject);

            Assert.AreSame(newObject, resultObject);
        }
        
        [Test]
        public void Create_GetAfter()
        {
            var newObject = new TestClassWithConstructor(new object());
            var resultObject = Service.Create(newObject);
            var objectAfterGet = Service.Get<TestClassWithConstructor>();

            Assert.AreSame(newObject, resultObject);
            Assert.AreSame(newObject, objectAfterGet);
        }
        
        [Test]
        public void Get_NotExist()
        {
            Assert.Throws<KeyNotFoundException>(() => Service.Get<TestClassWithConstructor>());
        }
    }
}