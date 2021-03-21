using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Models.Models.Districts
{
    public class DistrictStorageModel
    {
        public ConcurrentDictionary<Guid, DistrictModel> Districts { get; }
        public ConcurrentDictionary<Guid, DistrictModel> DistrictWithResourceEffects { get; }

        public DistrictStorageModel()
        {
            Districts = new ConcurrentDictionary<Guid, DistrictModel>();
            DistrictWithResourceEffects = new ConcurrentDictionary<Guid, DistrictModel>();
        }
    }
}