using System.Collections.Generic;
using Core.Services;
using Helpers;
using Interfaces;
using Models.Enums;
using SimpleInjector;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    private Container _container;
    private IEnumerable<IUpdateService> _updatableServices;
    
    void Start()
    {
        _container = new ContainerHelper().GetContainer();
        
        _updatableServices = _container.GetAllInstances<IUpdateService>();

        _container.GetInstance<IConfigService>().GetConfigFile(ConfigType.District);

        foreach (var initService in _container.GetAllInstances<IInitService>())
            initService.Init();
    }
    
    void Update()
    {
        foreach (var updatableService in _updatableServices)
        {
            updatableService.Update();
        }
    }
}
