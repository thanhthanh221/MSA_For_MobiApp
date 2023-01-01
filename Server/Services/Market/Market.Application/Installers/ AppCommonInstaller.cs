using Application.Common.Extensions;
using Application.Common.Installer;
using CatchingRedis.RedisDI;

namespace Market.Application.Installers
{
    public class AppCommonInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtAuth();
            services.AddSystemBase();
            // Redis Cache
            services.AddRedisCache(configuration);  
        }
    }
}