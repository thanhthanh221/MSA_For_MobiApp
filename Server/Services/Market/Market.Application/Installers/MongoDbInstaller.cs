using Application.Common.Extensions;
using Market.Domain.CouponService.Model;
using Market.Domain.ProductService.Model;
using Market.Infra.MongoDb;

namespace Market.Application.Installers
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
