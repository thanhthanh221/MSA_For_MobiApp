using Market.Domain.Events.CreateProduct;
using MediatR;

namespace Market.Application.Installers
{
    public class EventInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Product Event
            services.AddScoped<INotificationHandler<CreateProductEvent>, CreateProductEventHandler>();
                        
        }
    }
}