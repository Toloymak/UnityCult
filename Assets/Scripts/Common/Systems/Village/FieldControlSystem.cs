using Common.Components;
using Leopotam.Ecs;

namespace Common.Systems.Village
{
    public class FieldControlSystem : IEcsSystem, IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        
        public void Init()
        {
            var villageEntity = _ecsWorld.NewEntity();
            villageEntity.Set<VillageFieldComponent>();
        }
    }
}