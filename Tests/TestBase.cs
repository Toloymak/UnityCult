using Core.Services;
using Moq;

namespace Tests
{
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