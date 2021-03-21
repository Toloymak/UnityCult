using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Models.Models.Districts
{
    public class DistrictStorage
    {
        public ConcurrentDictionary<Guid, DistrictModel> Districts { get; }
        public ConcurrentDictionary<Guid, DistrictModel> DistrictWithResourceEffects { get; }

        public DistrictStorage()
        {
            Districts = new ConcurrentDictionary<Guid, DistrictModel>();
            DistrictWithResourceEffects = new ConcurrentDictionary<Guid, DistrictModel>();
        }
    }
}