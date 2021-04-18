using Managers.Managers;
using Microsoft.Extensions.DependencyInjection;
using Models.Models.Villages;
using Services.Services;

namespace Services.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services
               .AddScoped<IResourceService, ResourceService>()
               .AddScoped<IPlayerGenerateService, PlayerGenerateService>()
               .AddScoped<IWorldGenerationService, WorldGenerationService>()
               .AddScoped<IProcedureService, ProcedureService>()
               .AddScoped<ITimeService, TimeService>()
               .AddScoped<IInfoProvider, InfoProvider>();
        }

        public static IServiceCollection RegisterMangers(this IServiceCollection services)
        {
            return services
               .AddScoped<IDistrictManager, DistrictManager>()
               .AddScoped<IVillageMapManager, VillageMapManager>()
               .AddScoped<IEffectManager, EffectManager>()
               .AddScoped<IResourceManager, ResourceManager>()
               .AddScoped<IStorageManager, StorageManager>();
        }
    }
}