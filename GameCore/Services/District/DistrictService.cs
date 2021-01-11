using System;
using System.Collections.Generic;
using Models.Enums;
using Models.Models;
using Models.Models.Village;
using Newtonsoft.Json;

namespace Core.Services.District
{
    public interface IDistrictService
    {
        IList<DistrictInfoModel> GetDistrictTree();
        void PrintDistrictTree();
    }

    public class DistrictService : IDistrictService
    {
        private readonly IConfigService _configService;

        public DistrictService(IConfigService configService)
        {
            _configService = configService;
        }

        public IList<DistrictInfoModel> GetDistrictTree()
        {
            var stringConfig = _configService.GetConfigFile(ConfigType.District);
            var districtModels = JsonConvert.DeserializeObject<IList<DistrictInfoModel>>(stringConfig);
            return districtModels;
        }

        public void PrintDistrictTree()
        {
            Print(GetDistrictTree());
        }

        private void Print(IList<DistrictInfoModel> districtModels)
        {
            if (districtModels == null)
                return;
            
            foreach (var model in districtModels)
            {
                Console.WriteLine(model.ToString());
                Print(model.ChildDistricts);
            }
        }
    }
}