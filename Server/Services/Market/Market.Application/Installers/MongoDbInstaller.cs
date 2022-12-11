using Market.Domain.Model;
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
            services.AddMongoRepostory<Product>("Product");
            services.AddMongoRepostory<Category>("Categories");
        }
    }
}
