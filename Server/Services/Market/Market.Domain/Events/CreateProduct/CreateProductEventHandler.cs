using CatchingRedis.Services;
using MediatR;

namespace Market.Domain.Events.CreateProduct
{
    public class CreateProductEventHandler : INotificationHandler<CreateProductEvent>
    {
        private readonly TimeSpan timeToLiveSeconds;
        private readonly IReposeCacheService reposeCacheService;

        public CreateProductEventHandler(IReposeCacheService reposeCacheService)
        {
            timeToLiveSeconds = new TimeSpan(10, 10, 10, 10, 10);
            this.reposeCacheService = reposeCacheService;
        }

        public async Task Handle(CreateProductEvent message, CancellationToken cancellationToken)
        {
            string cacheKey2 = new("GetProduct_" + message.Product.Id);
            await reposeCacheService.SetCacheReponseAsync(cacheKey2, message.Product, timeToLiveSeconds);
        }
    }
}