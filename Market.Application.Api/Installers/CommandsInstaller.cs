using Market.Domain.CommandHandlers;
using Market.Domain.Commands;
using MediatR;

namespace Market.Application.Api.Installers
{
    public class CommandsInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Command For Product
            services.AddScoped<IRequestHandler<CreateNewProductCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, bool>, ProductCommandHandler>();

        }
    }
}