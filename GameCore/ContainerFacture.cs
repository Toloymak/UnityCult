﻿using Core.Services;
using Core.Services.District;
using SimpleInjector;

namespace Core
{
    public class ContainerFacture
    {
        public static Container Create(Lifestyle defaultLifestyle)
        {
            var container = new Container();
            container.Options.DefaultLifestyle = defaultLifestyle;
            
            RegisterSingletons(container);
            RegisterServices(container);

            return container;
        }

        private static void RegisterSingletons(Container container)
        {
            container.Register<IStorageService, StorageService>(Lifestyle.Singleton);
        }

        private static void RegisterServices(Container container)
        {
            container.Register<IBuildingService, BuildingService>();
            container.Register<IConfigService, ConfigService>();
            container.Register<IDistrictService, DistrictService>();
            container.Register<ILogService, LogService>();
            container.Register<IResourceService, ResourceService>();
            container.Register<IFilePathProvider, FilePathProvider>();
        }
    }
}