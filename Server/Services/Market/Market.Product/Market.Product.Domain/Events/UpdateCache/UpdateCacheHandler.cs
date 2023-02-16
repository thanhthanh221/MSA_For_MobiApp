using CatchingRedis.Services;
using MediatR;

namespace Market.Product.Domain.Events.UpdateCache
{
    public class UpdateCacheHandler : INotificationHandler<UpdateCacheEvent>
    {
        private readonly IReposeCacheService cacheService;

        public UpdateCacheHandler(IReposeCacheService cacheService)
        {
            this.cacheService = cacheService;
        }

        public Task Handle(UpdateCacheEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}