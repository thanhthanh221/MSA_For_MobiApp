using Market.Infra.Data.MongoDb;

namespace Market.Application.Api.Installers
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMongoDb();
            services.AddProductMongoRepostory("Product");
        }
    }
}
