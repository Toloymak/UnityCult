using System;
using Common.Enums;

namespace Common.Models
{
    public class LogModel
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}