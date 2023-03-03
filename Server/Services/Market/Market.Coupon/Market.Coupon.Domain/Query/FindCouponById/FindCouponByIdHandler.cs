using Application.Common.Repository;
using CatchingRedis.Data;
using CatchingRedis.Services;
using Market.Coupon.Domain.Model;
using MediatR;
using Newtonsoft.Json;

namespace Market.Coupon.Domain.Query.FindCouponById
{
    public class FindCouponByIdHandler : IRequestHandler<FindCouponByIdQuery, CouponAggregate>
    {
        private readonly IRepository<CouponAggregate> couponRepository;
        private readonly IReposeCacheService cacheService;

        public FindCouponByIdHandler(IRepository<CouponAggregate> couponRepository, IReposeCacheService cacheService)
        {
            this.couponRepository = couponRepository;
            this.cacheService = cacheService;
        }

        public async Task<CouponAggregate> Handle(FindCouponByIdQuery request, CancellationToken cancellationToken)
        {
            CouponAggregate coupon;
            var couponInCache = await cacheService.GetCacheReponseAsync(RedisCachePattern.CouponPattern + request.CouponId);
            if (couponInCache != null) {
                coupon = JsonConvert.DeserializeObject<CouponAggregate>(couponInCache);
                return coupon;
            }

            coupon = await couponRepository.GetByIdAsync(request.CouponId);
            await cacheService.SetCacheReponseAsync(RedisCachePattern.CouponPattern + request.CouponId, coupon, new TimeSpan(10, 10, 10));
            return coupon;
        }
    }
}