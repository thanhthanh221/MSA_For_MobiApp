using Application.Common.Repository;
using CatchingRedis.Data;
using CatchingRedis.Services;
using Market.Coupon.Domain.Events.UpdateCache;
using Market.Coupon.Domain.Model;
using MediatR;
using Newtonsoft.Json;

namespace Market.Coupon.Domain.Query.FilterCouponByUserId
{
    public class FindCouponByUserIdHandler : IRequestHandler<FindCouponByUserIdQuery, List<CouponAggregate>>
    {
        private readonly IRepository<CouponAggregate> couponRepository;
        private readonly IReposeCacheService cacheService;
        private readonly IMediator mediator;

        public FindCouponByUserIdHandler(
            IRepository<CouponAggregate> couponRepository, IReposeCacheService cacheService, IMediator mediator)
        {
            this.couponRepository = couponRepository;
            this.cacheService = cacheService;
            this.mediator = mediator;
        }

        public async Task<List<CouponAggregate>> Handle(FindCouponByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<CouponAggregate> getCouponByUserId;
            var couponInCaches = await cacheService.GetAllCacheReponseAsync(RedisCachePattern.CouponPattern);
            if (couponInCaches.Count != 0) {
                List<CouponAggregate> GetAllCouponInCache = couponInCaches.Select(c => JsonConvert.DeserializeObject<CouponAggregate>(c)).ToList();
                getCouponByUserId = GetAllCouponInCache.Where(c => c.UserId.Contains(request.UserId)).ToList();
                if (getCouponByUserId.Count != 0) {
                    return PageCoupon(getCouponByUserId, request.Page, request.PageSize);
                }
            }
            getCouponByUserId = await couponRepository.GetsAsync(c => c.UserId.Contains(request.UserId));
            // Update lại toàn bộ Cache
            await mediator.Publish(new UpdateCacheEvent(), cancellationToken);
            
            return PageCoupon(getCouponByUserId, request.Page, request.PageSize);
        }
        private static List<CouponAggregate> PageCoupon(List<CouponAggregate> coupons, int Page, int PageSize)
        {
            return coupons.OrderBy(p => p.MinPriceOrder).Skip(PageSize * Page).Take(PageSize).ToList();
        }
    }
}