using Market.Domain.Core.Models;
using Market.Domain.Interface;
using Market.Domain.Model;
using Market.Infra.Data.Repository;
using Market.Infra.Data.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Market.Infra.Data.MongoDb
{
    public static class MongoDbExtensions
    {
        // Cài đặt kết nối Mongodb
        public static IServiceCollection AddMongoDb(this IServiceCollection Services)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String)); // Chỉnh Giud thành String
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String)); // Ngày tháng thành String

            Services.AddSingleton(ServiceProvider =>
            {
                IConfiguration Configuration = ServiceProvider.GetService<IConfiguration>();

                MongoDbSettings mongoDbSettings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                MongoClient mongoClient = new MongoClient(mongoDbSettings.ConnectionString);

                return mongoClient.GetDatabase(mongoDbSettings.Name);

            });
            return Services;
        }

    

        // Abs DB mongodb
         public static IServiceCollection AddMongoRepostory<T>(this IServiceCollection Services, string CollectionName) where T : EntityAudit
        {
            Services.AddSingleton<IAsyncRepository<T>>(serviceProvider => 
            {
                IMongoDatabase database = serviceProvider.GetService<IMongoDatabase>();
                return new MongoDbRepositoryAsync<T>(database, CollectionName);
            });
            return Services;
        }

        // Customer Db For Product
        public static IServiceCollection AddProductMongoRepostory(this IServiceCollection Services, string CollectionName)
        {
            Services.AddSingleton<IAsyncProductRepository>(serviceProvider => 
            {
                IMongoDatabase database = serviceProvider.GetService<IMongoDatabase>();
                return new ProductMongoDbRepository(database, CollectionName);
            });
            return Services;
        }
    }
}
