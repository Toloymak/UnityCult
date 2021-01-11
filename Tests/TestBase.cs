using Core.Services;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    [Parallelizable]
    public abstract class TestBase<T>
    {
        protected T Service;
        protected Mock<ILogService> LogService;

        protected TestBase()
        {
            LogService = new Mock<ILogService>();
        }
    }
}