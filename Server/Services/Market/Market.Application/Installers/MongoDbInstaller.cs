using Market.Domain.CouponService.Model;
using Market.Domain.ProductService.Model;
using Market.Infra.MongoDb;

namespace Market.Application.Installers
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Add MongoDb For Service -EventSouring
            services.AddMongoDb();

            // Create Db
            services.AddMongoRepostory<ProductAggregate>("Product");
            services.AddMongoRepostory<CouponAggregate>("Coupon");
        }
    }
}
