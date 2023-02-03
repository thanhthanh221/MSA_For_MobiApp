using Application.Common.Extensions;
using Market.Product.Domain.Commands.CreateProduct;
using Market.Product.Domain.Interfaces;
using Market.Product.Domain.Model;
using Market.Product.Domain.Services;
using MediatR;

namespace Market.Product.Api.Installers
{
    public class DomainInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Command
            services.AddScoped<IRequestHandler<CreateProductCommand, ProductAggregate>, CreateProductHandler>();


            //Service
            services.AddScoped<IProductManager, ProductManager>();
        }
    }
}