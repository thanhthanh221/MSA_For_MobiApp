using Application.Common.Extensions;
using CatchingRedis.RedisDI;

namespace Market.Product.Api.Installers
{
    public class CacheRedisInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddRedisCache(configuration);
        }
    }
}