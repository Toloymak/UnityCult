using AutoFixture;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class BaseTest<TService>
    {
        protected TService Service;

        protected IFixture Fixture;

        public BaseTest()
        {
            Fixture = new Fixture();
        }
    }
}