using ObjectEcs.Interfaces;
using ObjectEcs.Services;
using UnityEngine;

namespace Services
{
    public class MonitoringEcsService : BaseEcsService, IEcsInitService, IEcsDestroyService, IEcsUpdateService
    {
        public MonitoringEcsService(EcsStoreService storeService) : base(storeService)
        {
        }

        public void Init()
        {
            Debug.Log("Run monitoring service");
        }

        public void Destroy()
        {
            Debug.Log("Destroy monitoring service");
        }

        public void Update()
        {
        }
    }
}