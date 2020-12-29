using System;
using Common.Enums;

namespace Core.Services
{
    public interface ILogService
    {
        void Log(LogLevel logLevel, string message, Exception exception = null);
    }
    
    public class LogService : ILogService
    {
        public void Log(LogLevel logLevel, string message, Exception exception = null)
        {
            throw new NotImplementedException();
        }
    }
}