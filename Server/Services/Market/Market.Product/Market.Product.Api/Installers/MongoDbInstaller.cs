using Application.Common.Extensions;
using Market.Infra.MongoDb;
using Market.Product.Domain.Model;

namespace Market.Product.Api.Installers
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDb();
            services.AddMongoRepostory<ProductAggregate>("Product");
        }
    }
}