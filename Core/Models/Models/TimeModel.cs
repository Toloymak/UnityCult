using System;

namespace Models.Models
{
    public class TimeModel
    {
        // 1 sec
        private static readonly TimeSpan DefaultProcedurePeriod = new TimeSpan(0, 0, 1);

        public TimeSpan ProcedurePeriod { get; set; } = DefaultProcedurePeriod;
        public TimeSpan GameTime { get; set; }
        public TimeSpan LastProcure { get; set; }
        
        public bool IsStopped { get; set; }
    }
}