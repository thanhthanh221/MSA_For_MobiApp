using Application.Common.Interface;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace Application.Common.Services
{
    public class ReposeCacheService : IReposeCacheService
    {
        private readonly IDistributedCache distributedCache;

        // Tạo nhiều server thì cần
        private readonly IConnectionMultiplexer connectionMultiplexer;

        public ReposeCacheService(
            IDistributedCache distributedCache,
            IConnectionMultiplexer connectionMultiplexer)
        {
            this.distributedCache = distributedCache;
            this.connectionMultiplexer = connectionMultiplexer;
        }

        public async Task<string> GetCacheReponseAsync(string cacheKey)
        {
            // Lấy ra cái Catche có Key = cacheKey
            String cacheRespone = await distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cacheRespone) ? null : cacheRespone;
        }

        // Remove
        public async Task RemoveCacheResponseAsync(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern)) {
                throw new AggregateException("Dữ liệu không thể null hoặc khoảng trắng");
            }
            foreach (var key in GetKeyAsync(pattern + "*")) {
                await distributedCache.RemoveAsync(key); // Xóa key bắt đầu bằng pattern    
            }
        }

        private IEnumerable<string> GetKeyAsync(string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern)) {
                throw new AggregateException("Dữ liệu không thể null hoặc khoảng trắng");
            }

            foreach (var endPoint in connectionMultiplexer.GetEndPoints()) {
                var server = connectionMultiplexer.GetServer(endPoint);

                foreach (var key in server.Keys(pattern: pattern)) {
                    yield return key.ToString();
                }
            }
        }

        public async Task SetCacheReponseAsync(string cacheKey, object response, TimeSpan timeOut)
        {
            if (response == null) {
                return;
            }
            String serializerRespone = JsonConvert.SerializeObject(response,
                new JsonSerializerSettings() {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            );

            await distributedCache.SetStringAsync(cacheKey, serializerRespone,
                new DistributedCacheEntryOptions {
                    AbsoluteExpirationRelativeToNow = timeOut
                }
            );
        }
    }
}
