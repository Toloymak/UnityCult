using System;

namespace Web.WebServices
{
    public static class TimeHelper
    {
        private static DateTime _dateTime;
        private static object _lock = new object();
        
        private static DateTime _lastProcedureTime = DateTime.Now;

        public static TimeSpan GetDeltaTime()
        {
            lock (_lock)
            {
                var delta = DateTime.Now - _lastProcedureTime;
                _lastProcedureTime = DateTime.Now;
                return delta;
            }
        }
    }
}