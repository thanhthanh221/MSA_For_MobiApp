using Application.Common.Extensions;
using Market.Product.Domain.Model;
using Mongodb.Extensions;

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