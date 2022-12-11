using Market.Domain.Models;
using Market.Domain.Interface;
using Market.Infra.Repository;
using Market.Infra.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Market.Infra.MongoDb
{
    public static class MongoDbExtensions
    {
        // Cài đặt kết nối Mongodb
        public static IServiceCollection AddMongoDb(this IServiceCollection Services)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String)); // Chỉnh Giud thành String
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String)); // Ngày tháng thành String
            BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));
            
            // TimeSpan to String
            BsonSerializer.RegisterSerializer(new TimeSpanSerializer(BsonType.String)); 


            Services.AddSingleton(ServiceProvider =>
            {
                var Configuration = ServiceProvider.GetService<IConfiguration>();

                var mongoDbSettings = Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                MongoClient mongoClient = new (mongoDbSettings.ConnectionString);

                return mongoClient.GetDatabase(mongoDbSettings.Name);

            });
            return Services;
        }

        // Abs DB mongodb
        public static IServiceCollection AddMongoRepostory<T>(this IServiceCollection Services, string CollectionName) where T : IAggregate
        {
            Services.AddSingleton<IAsyncRepository<T>>(serviceProvider => 
            {
                var database = serviceProvider.GetService<IMongoDatabase>();
                return new MongoDbAsyncRepository<T>(database, CollectionName);
            });
            return Services;
        }
    }
}
