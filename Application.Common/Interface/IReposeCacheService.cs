using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interface
{
    public interface IReposeCacheService
    {
        Task SetCacheReponseAsync(string cacheKey, object response, TimeSpan timeOut);
        Task<String> GetCacheReponseAsync(string cacheKey);
        Task RemoveCacheResponseAsync(string partern);
    }
}
