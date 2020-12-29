using System;
using System.Collections.Generic;
using Common.Enums;
using Common.Models;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Common.Components
{
    public class LogService
    {
        // private static LogService _logService;
        //
        // public static LogService Get()
        // {
        //     if (_logService != null)
        //         return _logService;
        //
        //     
        //         Service<LogService>.Set(new LogService());
        //         return _logService = Service<LogService>.Set(new LogService())
        // }
        
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