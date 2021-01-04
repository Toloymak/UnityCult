using System;
using System.IO;
using Models.Enums;

namespace Core.Services
{
    public interface IConfigService
    {
        string GetConfigFile(ConfigType configType);
    }

    public class ConfigService : IConfigService
    {
        private readonly IFilePathProvider _filePathProvider;

        public ConfigService(IFilePathProvider filePathProvider)
        {
            _filePathProvider = filePathProvider;
        }

        public string GetConfigFile(ConfigType configType)
        {
            if (configType == ConfigType.District)
            {
                var directory = Directory.GetCurrentDirectory();
                var file = $"{_filePathProvider.GetConfigDirectory()}\\DistrictConfig.json";
                return File.ReadAllText(file);
            }

            return "";
        }
    }
}