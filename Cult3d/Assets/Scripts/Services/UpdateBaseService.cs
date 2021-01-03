using System;

namespace Services
{
    public abstract class UpdateBaseService
    {
        private DateTime LastUpdate { get; set; }
        private TimeSpan Period { get; set; }

        protected UpdateBaseService(TimeSpan period)
        {
            Period = TimeSpan.Zero;
            LastUpdate = DateTime.MinValue;
        }

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