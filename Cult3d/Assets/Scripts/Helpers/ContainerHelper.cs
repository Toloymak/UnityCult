using Core;
using Core.UnityServiceContracts;
using Services;
using SimpleInjector;
using UnityEditor;

namespace Helpers
{
    public class ContainerHelper
    {
        public Container GetContainer()
        {
            var container = ContainerFacture.Create(Lifestyle.Singleton);
            
            RegisterUnityAssemblyServices(container);
            RegisterSettingServices(container);
            
            return container;
        }

        private void RegisterUnityAssemblyServices(Container container)
        {
            container.Register<CameraControlService>();
            container.Register<IUnityBuildingService, UnityBuildingService>();
            container.Register<UiPanelControlService>();
        }

        private void RegisterSettingServices(Container container)
        {
            container.Register<UiEventSettingService>();
        }
    }
}