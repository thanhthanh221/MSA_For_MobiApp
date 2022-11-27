using Market.Domain.Commands.CreateCategory;
using Market.Domain.Commands.CreateProduct;
using Market.Domain.Commands.DeleteProduct;
using Market.Domain.Commands.UpdatePriceProduct;
using Market.Domain.Commands.UpdateQuantityProduct;
using Market.Domain.Model;
using MediatR;

namespace Market.Application.Installers
{
    public class CommandsInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Command For Product
            services.AddScoped<IRequestHandler<CreateProductCommand, Product>, CreateProductHandler>();
            services.AddScoped<IRequestHandler<UpdateQuantityProductCommand, bool>, UpdateQuantityProductHandler>();
            services.AddScoped<IRequestHandler<UpdatePriceProductCommand, bool>, UpdatePriceProductHandler>();
            services.AddScoped<IRequestHandler<DeleteProductCommand, bool>, DeleteProductHandler>();
            
            // Command For Category
            services.AddScoped<IRequestHandler<CreateCategoryCommand, bool>, CreateCategoryHandler>();
        }
    }
}