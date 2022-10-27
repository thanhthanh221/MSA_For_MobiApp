using Market.Domain.CommandHandlers;
using Market.Domain.Commands.ProductCommand;
using MediatR;

namespace Market.Application.Api.Installers
{
    public class CommandsInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Command For Product
            services.AddScoped<IRequestHandler<ProductCreateCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<ProductDeleteCommand, bool>, ProductCommandHandler>();
            services.AddScoped<IRequestHandler<ProductUpdateCommand, bool>, ProductCommandHandler>();

            // Command For Category
        }
    }
}