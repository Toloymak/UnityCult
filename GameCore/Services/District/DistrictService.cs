using System;
using System.Collections.Generic;
using Business.Models.Districts;
using Models.Enums;
using Newtonsoft.Json;

namespace Core.Services.District
{
    public interface IDistrictService
    {
        IList<DistrictModel> GetDistrictTree();
        void PrintDistrictTree();
    }

    public class DistrictService : IDistrictService
    {
        private readonly IConfigService _configService;

        public DistrictService(IConfigService configService)
        {
            _configService = configService;
        }

        public IList<DistrictModel> GetDistrictTree()
        {
            var stringConfig = _configService.GetConfigFile(ConfigType.District);
            var districtModels = JsonConvert.DeserializeObject<IList<DistrictModel>>(stringConfig);
            return districtModels;
        }

        public void PrintDistrictTree()
        {
            Print(GetDistrictTree());
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