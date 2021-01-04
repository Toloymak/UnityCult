using Core;
using Core.UnityServiceContracts;
using Interfaces;
using Services;
using Services.Building;
using SimpleInjector;

namespace Helpers
{
    public class ContainerHelper
    {
        public Container GetContainer()
        {
            var container = ContainerFacture.Create(Lifestyle.Singleton);
            
            RegisterUnityAssemblyServices(container);
            RegisterSettingServices(container);
            RegisterInitServices(container);
            RegisterUpdateServices(container);
            
            return container;
        }

        private void RegisterInitServices(Container container)
        {
            container.Collection.Register<IInitService>(new []
            {
                typeof(BuildingPanelService)
                
            });
        }
        
        private void RegisterUpdateServices(Container container)
        {
            container.Collection.Register<IUpdateService>(new []
            {
                typeof(BuildingPanelService),
                typeof(CameraControlService)
            });
        }

        private void RegisterUnityAssemblyServices(Container container)
        {
            container.Register<UnityObjectCacheService>(Lifestyle.Singleton);
            container.Register<PrefabCacheService>(Lifestyle.Singleton);
            container.Register<IUnityBuildingService, UnityBuildingService>();
            container.Register<ObjectInstantiateHelper>();
        }

        private void RegisterSettingServices(Container container)
        {
            
        }
    }
}