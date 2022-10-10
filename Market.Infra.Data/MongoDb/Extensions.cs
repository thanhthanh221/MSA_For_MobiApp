using Market.Infra.Data.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace Market.Infra.Data.MongoDb
{
    public static class Extensions
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
    }
}
