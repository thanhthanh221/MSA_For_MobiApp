using CatchingRedis.RedisDI;

namespace Market.Application.Installers
{
    public class RedisCacheInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedisCache(configuration);           
        }
    }
}
