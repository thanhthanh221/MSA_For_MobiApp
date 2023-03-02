using Application.Common.Extensions;
using Market.Coupon.Domain.Model;
using Mongodb.Extensions;

namespace Market.Coupon.Api.Installers
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDb();
            services.AddMongoRepostory<CouponAggregate>("Coupon");
        }
    }
}