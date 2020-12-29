using System;
using Models.Enums;

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
                throw new NotImplementedException();
            }

            return "";
        }
    }
}