using System;
using System.Collections.Generic;
using Common.Enums;
using Common.Models;

namespace Common.Components
{
    public class LogComponent
    {
        public HashSet<LogModel> LogModels { get; set; } = new HashSet<LogModel>();

        public void AddLog(LogLevel level, string message, Exception exception = null)
        {
            LogModels.Add(new LogModel()
            {
                Level = level,
                Message = message,
                Exception = exception
            });
        }
        
        public void AddLog(string message) =>
            AddLog(LogLevel.Debug, message);
    }
}