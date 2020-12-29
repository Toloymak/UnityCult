using System;
using System.Collections.Generic;
using Business.Enums;
using Business.Models.Districts;
using Models.Enums;
using Newtonsoft.Json;

namespace Core.Services
{
    public interface IConfigService
    {
        string GetConfigFile(ConfigType configType);
    }

    public class ConfigService : IConfigService
    {
        public string GetConfigFile(ConfigType configType)
        {
            if (configType == ConfigType.District)
            {
                return GetTestDistrictConfig();
            }

            return "";
        }

        private string GetTestDistrictConfig()
        {
            var district = new List<DistrictModel>()
            {
                new DistrictModel(),
                new DistrictModel()
                {
                    DistrictType = DistrictType.Arena,
                    Resources = new Dictionary<ResourceType, int>()
                    {
                        {ResourceType.Food, 100}
                    },
                    RequiredDistricts = new[] {1L},
                    RequiredResearches = new[] {1L},
                    ChildDistricts = new List<DistrictModel>()
                    {
                        new DistrictModel()
                        {
                            DistrictType = DistrictType.Arena2,
                            Resources = new Dictionary<ResourceType, int>()
                            {
                                {ResourceType.Food, 100}
                            },
                            RequiredDistricts = new[] {1L},
                            RequiredResearches = new[] {1L},
                            ChildDistricts = new List<DistrictModel>()
                            {
                            }
                        },
                    }
                },
            };

            Console.WriteLine(JsonConvert.SerializeObject(district));

            return JsonConvert.SerializeObject(district);
        }
    }
}