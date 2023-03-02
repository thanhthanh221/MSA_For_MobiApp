using Application.Common.Extensions;
using Market.Product.Domain.Commands.CreateProduct;
using Market.Product.Domain.Commands.RemoveProduct;
using Market.Product.Domain.Commands.UserFavouriteProduct;
using Market.Product.Domain.Interfaces;
using Market.Product.Domain.Model;
using Market.Product.Domain.Queries.FindProductByCategory;
using Market.Product.Domain.Queries.FindProductById;
using Market.Product.Domain.Queries.SearchProduct;
using Market.Product.Domain.Services;
using MediatR;

namespace Market.Product.Api.Installers;

public class DomainInstaller : IInstaller
{
    public void InstallService(IServiceCollection services, IConfiguration configuration)
    {
        // Command
        services.AddScoped<IRequestHandler<CreateProductCommand, ProductAggregate>, CreateProductHandler>();
        services.AddScoped<IRequestHandler<RemoveProductCommand, bool>, RemoveProductHandler>();
        services.AddScoped<IRequestHandler<UserFavouriteProductCommand, Unit>, UserFavouriteProductHandler>();


        //Query
        services.AddScoped<IRequestHandler<ProductByIdQuery, ProductAggregate>, ProductByIdHandler>();
        services.AddScoped<IRequestHandler<ProductByCategoryQuery, List<ProductAggregate>>, ProductByCategoryHandler>();
        services.AddScoped<IRequestHandler<SearchProductQuery, List<ProductAggregate>>, SearchProductHandler>();

        //Service
        services.AddScoped<IProductManager, ProductManager>();
    }
}
