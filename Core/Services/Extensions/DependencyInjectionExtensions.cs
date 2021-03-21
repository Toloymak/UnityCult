using Managers.Managers;
using Microsoft.Extensions.DependencyInjection;
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
               .AddScoped<IProcedureService, ProcedureService>();
        }

        public static IServiceCollection RegisterMangers(this IServiceCollection services)
        {
            return services
               .AddScoped<IDistrictManager, DistrictManager>()
               .AddScoped<IEffectManager, EffectManager>()
               .AddScoped<IResourceManager, ResourceManager>()
               .AddScoped<IStorageManager, StorageManager>();
        }
    }
}