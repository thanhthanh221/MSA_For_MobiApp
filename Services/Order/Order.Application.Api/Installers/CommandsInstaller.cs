using MediatR;
using Order.Domain.Commands.OrderCommand;
using Order.Domain.CommandsHandler;

namespace Order.Application.Api.Installers
{
    public class CommandsInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Command DI/IOC

            // Order Command
            services.AddScoped<IRequestHandler<OrderCreateCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<OrderDeleteCommand, bool>, OrderCommandHandler>();
            services.AddScoped<IRequestHandler<OrderUpdateCommand, bool>, OrderCommandHandler>();
        }
    }
}
