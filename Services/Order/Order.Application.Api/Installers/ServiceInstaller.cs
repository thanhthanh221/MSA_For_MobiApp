using Order.Application.Interfaces;
using Order.Application.Services;

namespace Order.Application.Api.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
