
using ObjectEcs.Models;
using ObjectEcs.Services;
using Services;
using UnityEngine;

public class InitWorld : MonoBehaviour
{
    private EcsWorld _ecsWorld;
    private EcsStoreService _ecsStoreService;
    
    // Start is called before the first frame update
    void Start()
    {
        _ecsStoreService = new EcsStoreService(new EcsStore());
        _ecsWorld = new EcsWorld(_ecsStoreService);

        _ecsWorld.AddService<MonitoringEcsService>();
        
        _ecsWorld.Init();
    }

    // Update is called once per frame
    void Update()
    {
        _ecsWorld.Update();

    }

    private void OnDestroy()
    {
        _ecsWorld.Destroy();
    }
}
