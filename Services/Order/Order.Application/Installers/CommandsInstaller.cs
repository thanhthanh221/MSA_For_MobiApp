using MediatR;
using Order.Domain.Commands.CancelOrder;
using Order.Domain.Commands.CreateOrder;
using Order.Domain.Commands.SetOrderStatus;

namespace Order.Application.Installers
{
    public class CommandsInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Command DI/IOC

            // Order Command
            services.AddScoped<IRequestHandler<CreateOrderCommand, bool>, CreateOrderCommandHandler>();
            services.AddScoped<IRequestHandler<CancelOrderCommand, bool>, CancelOrderCommandHandler>();
            services.AddScoped<IRequestHandler<SetOrderStatusCommand, bool>, SetOrderStatusCommandHandler>();
        }
    }
}
