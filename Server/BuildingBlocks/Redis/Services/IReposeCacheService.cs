namespace CatchingRedis.Services
{
    public interface IReposeCacheService
    {   
        Task SetCacheReponseAsync(string cacheKey, object response, TimeSpan timeOut);
        Task<string> GetCacheReponseAsync(string cacheKey);
        Task<List<string>> GetAllCacheReponseAsync(string pattern);
        Task RemoveCacheResponseAsync(string pattern);
        Task RemoveCacheAsync(string pattern, Guid Id);
    }
}
