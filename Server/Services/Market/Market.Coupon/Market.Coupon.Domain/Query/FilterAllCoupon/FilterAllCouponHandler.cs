using Application.Common.Repository;
using CatchingRedis.Data;
using CatchingRedis.Services;
using Market.Coupon.Domain.Events.UpdateCache;
using Market.Coupon.Domain.Model;
using MediatR;
using Newtonsoft.Json;

namespace Market.Coupon.Domain.Query.FilterAllCoupon
{
    public class FilterAllCouponHandler : IRequestHandler<FilterAllCouponQuery, List<CouponAggregate>>
    {
        private readonly IRepository<CouponAggregate> couponRepository;
        private readonly IReposeCacheService cacheService;
        private readonly IMediator mediator;

        public FilterAllCouponHandler(
            IRepository<CouponAggregate> couponRepository, IReposeCacheService cacheService, IMediator mediator)
        {
            this.couponRepository = couponRepository;
            this.cacheService = cacheService;
            this.mediator = mediator;
        }

        public async Task<List<CouponAggregate>> Handle(FilterAllCouponQuery request, CancellationToken cancellationToken)
        {
            List<CouponAggregate> getAllCoupon;
            var couponInCaches = await cacheService.GetAllCacheReponseAsync(RedisCachePattern.CouponPattern);
            if (couponInCaches.Count != 0) {
                getAllCoupon = couponInCaches.Select(c => JsonConvert.DeserializeObject<CouponAggregate>(c)).ToList();
                return PageCoupon(getAllCoupon, request.Page, request.PageSize);
            }

            getAllCoupon = (await couponRepository.GetAllAsync()).ToList();
            await mediator.Publish(new UpdateCacheEvent(), cancellationToken);
            return PageCoupon(getAllCoupon, request.Page, request.PageSize);
        }
        private static List<CouponAggregate> PageCoupon(List<CouponAggregate> coupons, int Page, int PageSize)
        {
            return coupons.OrderBy(p => p.MinPriceOrder).Skip(PageSize * Page).Take(PageSize).ToList();
        }
    }
}