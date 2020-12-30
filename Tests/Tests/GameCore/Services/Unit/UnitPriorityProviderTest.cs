using Core.Services.Unit;
using Models.Models;
using NUnit.Framework;

namespace Tests.Tests.GameCore.Services.Unit
{
    public class UnitPriorityProviderTest : TestBase<UnitPriorityProvider>
    {
        [SetUp]
        public void SetUp()
        {
            Service = new UnitPriorityProvider();
        }

        [Test]
        public void GetPriority()
        {
            var list = Service.GetPriority(new UnitModel());
            
            Assert.NotNull(list);
        }
    }
}