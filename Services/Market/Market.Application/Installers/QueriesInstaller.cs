using Market.Domain.Model;
using Market.Domain.Queries.ProductByCategory;
using MediatR;

namespace Market.Application.Installers
{
    public class QueriesInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRequestHandler<ProductByCategoryQuery, Product>, ProductByCategoryQueryHandler>();
        }
    }
}
