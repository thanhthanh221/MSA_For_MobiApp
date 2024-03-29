using Application.Common.Extensions;
using Market.Category.Api.Model;
using Mongodb.Extensions;

namespace Market.Category.Api.Installers
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDb();
            services.AddMongoRepostory<CategoryAggregate>("Category");
        }
    }
}