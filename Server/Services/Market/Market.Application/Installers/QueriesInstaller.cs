using Market.Domain.Model;
using Market.Domain.Queries.FilterProduct;
using Market.Domain.Queries.ProductByCategory;
using Market.Domain.Queries.ProductById;
using MediatR;

namespace Market.Application.Installers
{
    public class QueriesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRequestHandler<ProductByCategoryQuery, List<Product>>, ProductByCategoryQueryHandler>();
            services.AddScoped<IRequestHandler<FilterProductQuery, List<Product>>, FilterProductQueryHandler>();
            services.AddScoped<IRequestHandler<ProductByIdQuery, Product>, ProductByIdQueryHandler>();
        }
    }
}
