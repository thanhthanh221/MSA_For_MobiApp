using Application.Common.Repository;
using CatchingRedis.Data;
using CatchingRedis.Services;
using Market.Coupon.Domain.Model;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Market.Coupon.Domain.Events.UpdateCache
{
    public class UpdateCacheHandler : INotificationHandler<UpdateCacheEvent>
    {
        private readonly IRepository<CouponAggregate> couponRepository;
        private readonly IReposeCacheService cacheService;
        private readonly ILogger<UpdateCacheHandler> logger;

        public UpdateCacheHandler(
            IRepository<CouponAggregate> couponRepository, IReposeCacheService cacheService, ILogger<UpdateCacheHandler> logger)
        {
            this.couponRepository = couponRepository;
            this.cacheService = cacheService;
            this.logger = logger;
        }

        public async Task Handle(UpdateCacheEvent message, CancellationToken cancellationToken)
        {
            try {
                // Update lại toàn bộ Cache
                await cacheService.RemoveCacheResponseAsync(RedisCachePattern.CouponPattern);
                (await couponRepository.GetAllAsync()).ToList().ForEach(async c => {
                    await cacheService.SetCacheReponseAsync(RedisCachePattern.CouponPattern + c.Id, c, new TimeSpan(10, 10, 10));
                });
                logger.LogInformation("Cập nhật lại Cache cho service: Coupon");
            }
            catch (Exception ex) {
                logger.LogError("Lỗi cập nhật lại Cache: {message}", ex.Message);
            }
        }
    }
}