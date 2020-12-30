using Core.Services;
using SimpleInjector;

namespace Core
{
    public class ContainerFacture
    {
        public static Container Create()
        {
            var container = new Container();
            
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
        }
    }
}