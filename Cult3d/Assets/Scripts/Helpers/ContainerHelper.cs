using Core;
using Core.UnityServiceContracts;
using Interfaces;
using Services;
using Services.Building;
using Services.Village;
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
            container.Collection.Register<IInitService>(
                                                        typeof(BuildingPanelService),
                                                        typeof(VillageService)
                                                       );
        }

        private void RegisterUpdateServices(Container container)
        {
            container.Collection.Register<IUpdateService>(
                                                          typeof(BuildingPanelService),
                                                          typeof(CameraControlService),
                                                          typeof(DistrictBuildingProcessService)
                                                         );
        }

        private void RegisterUnityAssemblyServices(Container container)
        {
            container.Register<UnityObjectCacheService>(Lifestyle.Singleton);
            container.Register<PrefabCacheService>(Lifestyle.Singleton);
            container.Register<IUnityBuildingService, UnityBuildingService>();
            container.Register<IObjectInstantiateHelper, ObjectInstantiateHelper>();
            container.Register<IButtonHelper, ButtonHelper>();
            container.Register<IEventHelper, EventHelper>();
            container.Register<IMouseHelper, MouseHelper>();
        }

        private void RegisterSettingServices(Container container)
        {
            
        }
    }
}