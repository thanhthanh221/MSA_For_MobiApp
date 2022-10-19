using System.Reflection;
using Market.Domain.Core.Bus;
using MediatR;

namespace Market.Application.Api.Installers
{
    public class BusInstaller : IInstaller
        {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            //AddBus
            services.AddScoped<IMediatorHandler,InMemoryBus>();
        }
    }
}