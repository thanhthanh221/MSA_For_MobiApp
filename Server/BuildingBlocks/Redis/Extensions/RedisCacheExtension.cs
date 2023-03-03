using CatchingRedis.Services;
using CatchingRedis.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace CatchingRedis.RedisDI
{
    public static class RedisCacheExtension
    {
        public static IServiceCollection AddRedisCache(this IServiceCollection services, IConfiguration configuration)
        {
            RedisSettings redisSettings = new();
            configuration.GetSection(nameof(RedisSettings)).Bind(redisSettings);

            services.AddSingleton(redisSettings);

            if (!redisSettings.Enable) {
                return services;
            }
            services.AddSingleton<IConnectionMultiplexer>(_
                => ConnectionMultiplexer.Connect(redisSettings.ConnectionString));

            services.AddStackExchangeRedisCache(option => option.Configuration = redisSettings.ConnectionString);

            // Quản lí
            services.AddTransient<IReposeCacheService, ReposeCacheService>();

            return services;
        }
    }
}
