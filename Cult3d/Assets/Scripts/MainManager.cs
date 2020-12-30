using Core;
using Core.UnityServiceContracts;
using Services;
using SimpleInjector;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private CameraControlService _cameraControlService;
    private Container _container;
    
    // Start is called before the first frame update
    void Start()
    {
        _container = ContainerFacture.Create();
        RegisterUnityAssemblyServices(_container);
        
        _cameraControlService = _container.GetInstance<CameraControlService>();
    }

    // Update is called once per frame
    void Update()
    {
        _cameraControlService.MoveCamera();
    }

    private void RegisterUnityAssemblyServices(Container container)
    {
        var defaultLifeStyle = Lifestyle.Singleton;
        
        container.Register<CameraControlService>(defaultLifeStyle);
        container.Register<IUnityBuildingService, UnityBuildingService>();
    }
}
