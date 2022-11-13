using MediatR;
using Order.Domain.Events.OrderEvent;
using Order.Domain.EventsHandler;

namespace Order.Application.Api.Installers
{
    public class EventsHandler : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Order Event
            services.AddScoped<INotificationHandler<OrderCreatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderUpdatedEvent>, OrderEventHandler>();
            services.AddScoped<INotificationHandler<OrderDeletedEvent>, OrderEventHandler>();
        }
    }
}
