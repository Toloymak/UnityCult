using System;
using System.Collections.Generic;
using Business.Models.Districts;
using Models.Enums;
using Newtonsoft.Json;

namespace Core.Services
{
    public interface IDistrictService
    {
    }

    public class DistrictService : IDistrictService
    {
        private readonly IConfigService _configService;

        public DistrictService(IConfigService configService)
        {
            _configService = configService;
        }

        public void GetDistrictTree()
        {
            var stringConfig = _configService.GetConfigFile(ConfigType.District);
            var districtModels = JsonConvert.DeserializeObject<IList<DistrictModel>>(stringConfig);
            Print(districtModels);
        }

        private void Print(IList<DistrictModel> districtModels)
        {
            if (districtModels == null)
                return;
            
            foreach (var model in districtModels)
            {
                Console.WriteLine(model.DistrictType);
                Print(model.ChildDistricts);
            }
        }
    }
}