using System;
using System.Collections.Concurrent;

namespace Models.Models.Districts
{
    public class DistrictStorage
    {
        public ConcurrentDictionary<Guid, DistrictModel> Districts { get; }

        public DistrictStorage()
        {
            Districts = new ConcurrentDictionary<Guid, DistrictModel>();
        }
    }
}