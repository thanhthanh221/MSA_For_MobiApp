using Application.Common.Interface;
using Application.Common.Services;
using Application.Common.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Application.Common.Redis
{
    public static class RedisExtension
    {
        public static IServiceCollection
            AddRedisForCache(IServiceCollection services, IConfiguration configuration)
        {
            // Chuyển Config thành Entity RedisSettings
            RedisSettings redisSettings = configuration.GetSection(nameof(RedisSettings)).Get<RedisSettings>();
            services.AddSingleton(redisSettings);

            // Catche Extension

            services.AddSingleton<IConnectionMultiplexer>(_
                => ConnectionMultiplexer.Connect(redisSettings.ConnectionString));

            services.AddStackExchangeRedisCache(option => {
                option.Configuration = redisSettings.ConnectionString;
            });

            // Quản lí
            services.AddSingleton<IReposeCacheService, ReposeCacheService>();

            return services;
        }

    }
}
