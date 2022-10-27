using Market.Domain.Model;
using Market.Infra.Data.MongoDb;

namespace Market.Application.Api.Installers
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            // Add MongoDb For Service -EventSouring
            services.AddMongoDb();

            // Create Db
            services.AddProductMongoRepostory("Product");
            services.AddMongoRepostory<Category>("Categories");
        }
    }
}
