using System;
using Interfaces;

namespace Services
{
    public abstract class UpdatableMenuBaseService : IUpdateService
    {
        private DateTime LastUpdate { get; set; }
        private TimeSpan Period { get; set; }

        protected UpdatableMenuBaseService(TimeSpan period)
        {
            Period = period;
            LastUpdate = DateTime.MinValue;
        }

        public abstract void Init();
        public abstract void Update();

        protected bool NeedUpdate()
        {
            if (DateTime.Now - LastUpdate < Period)
            {
                return false;
            }
            else
            {
                LastUpdate = DateTime.Now;
                return true;
            }
        }
    }
}