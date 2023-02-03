using System.Reflection;
using Application.Common.Extensions;
using Application.Common.Installer;
using CatchingRedis.RedisDI;
using MediatR;

namespace Market.Product.Api.Installers
{
    public class AppCommonInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);
            services.AddAuthenticationInCommon();
            services.AddSystemBase();
            services.AddRedisCache(configuration); 
        }
    }
}