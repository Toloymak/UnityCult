using System.Linq;
using Models.Models;
using NUnit.Framework;

namespace Tests.Tests.Data
{
    public class ResourceModelTests
    {
        [Test]
        public void NewModel()
        {
            var model = new ResourcesModel();
            Assert.AreEqual(6, model.Count);

            foreach (var value in model.Select(x => x.Value))
            {
                Assert.AreEqual(0, value);
            }
        }
    }
}