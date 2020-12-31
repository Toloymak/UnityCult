using Helpers;
using Services;
using SimpleInjector;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private CameraControlService _cameraControlService;
    private UiEventSettingService _uiEventSettingService;
    
    private Container _container;
    
    // Start is called before the first frame update
    void Start()
    {
        _container = new ContainerHelper().GetContainer();
        
        _cameraControlService = _container.GetInstance<CameraControlService>();
        _uiEventSettingService = _container.GetInstance<UiEventSettingService>();
        
        _uiEventSettingService.SetUpBaseButtons();
    }

    // Update is called once per frame
    void Update()
    {
        _cameraControlService.MoveCamera();
    }
}
