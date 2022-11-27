using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StackExchange.Redis;

namespace CatchingRedis.Services
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

        // Lấy Cache
        public async Task<string> GetCacheReponseAsync(string cacheKey)
        {
            // Lấy ra cái Catche có Key = cacheKey
            string cacheRespone = await distributedCache.GetStringAsync(cacheKey);
            return string.IsNullOrEmpty(cacheRespone) ? null : cacheRespone;
        }

        public async Task<List<string>> GetPageCacheReponseAsync(string partern,int pageSize, int page)
        {
            List<string> readByCatcheRedis = new ();
            if (string.IsNullOrWhiteSpace(partern) || partern.Equals("_")) {
                throw new AggregateException("Dữ liệu không thể null hoặc khoảng trắng");
            }
            // Lấy ra cái Catche có Key = cacheKey

            foreach (var key in this.GetKeyAsync(partern + "*")) {
                string cacheRespone = await distributedCache.GetStringAsync(key);
                if(!string.IsNullOrEmpty(cacheRespone))
                {
                    readByCatcheRedis.Add(cacheRespone);
                }          
            }
            return readByCatcheRedis.Skip(page* pageSize).Take(pageSize).ToList();
        }
        public async Task<List<string>> GetAllCacheReponseAsync(string partern)
        {
            List<string> readByCatcheRedis = new ();
            if (string.IsNullOrWhiteSpace(partern) || partern.Equals("_")) {
                throw new AggregateException("Dữ liệu không thể null hoặc khoảng trắng");
            }
            // Lấy ra cái Catche có Key = cacheKey

            foreach (var key in this.GetKeyAsync(partern + "*")) {
                string cacheRespone = await distributedCache.GetStringAsync(key);
                if(!string.IsNullOrEmpty(cacheRespone))
                {
                    readByCatcheRedis.Add(cacheRespone);
                }          
            }
            return readByCatcheRedis;
        }

        // Remove
        public async Task RemoveCacheResponseAsync(string partern)
        {
            if (string.IsNullOrWhiteSpace(partern)) {
                throw new AggregateException("Dữ liệu không thể null hoặc khoảng trắng");
            }
            foreach (var key in this.GetKeyAsync(partern + "*")) {
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
            string serializerRespone = JsonConvert.SerializeObject(response,
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